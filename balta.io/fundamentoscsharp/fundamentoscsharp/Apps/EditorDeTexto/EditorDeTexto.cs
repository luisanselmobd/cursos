using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentoscsharp.Programas.EditorDeTexto
{
    internal class EditorDeTexto
    {
        private string texto;
        private string pasta = @$"Apps\EditorDeTexto\arquivosEditorDeTexto\";
        int ImprimirMenu()
        {
            string opcaoEscolhida;
            bool repetir = true;
            Console.WriteLine(@"O que você deseja fazer?
            1 - Criar arquivo
            2 - Abrir arquivo
            3 - Sair");

            do
            {
                opcaoEscolhida = char.ConvertFromUtf32(Console.ReadKey().KeyChar);
                switch (opcaoEscolhida)
                {
                    case "1":
                    case "2":
                    case "3":
                        repetir = false;
                        break;
                    default:
                        Console.WriteLine("\nValor inválido. Digite um caractere válido!");
                        break;
                }
            } while (repetir);

            return Convert.ToInt32(opcaoEscolhida);
        }
        void CriarArquivo()
        {
            string nomeArquivo = "";
            Console.Clear();
            Console.WriteLine("Digite o conteúdo do arquivo. Para sair, aperte ESC.");

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            }
            if (string.IsNullOrEmpty(texto))
            {
                Console.Clear();
                return;
            }

            Console.WriteLine("Digite o nome do arquivo: ");
            do
            {
                nomeArquivo = Console.ReadLine();
                Console.Clear();
            } while (string.IsNullOrEmpty(nomeArquivo));

            bool arquivoSalvo = false;
            do
            {
                try
                {
                    FileStream fs = new FileStream($@"{pasta}\{nomeArquivo}.txt", FileMode.CreateNew);
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(texto);
                        sw.Flush();

                    }
                    fs.Close();

                    Console.Clear();
                    Console.WriteLine($"Arquivo {nomeArquivo}.txt salvo com sucesso! Digite qualquer tecla para retornar ao menu.");
                    arquivoSalvo = true;
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("already exists"))
                    {
                        Console.Write($"Arquivo {nomeArquivo}.txt já existe! Digite um novo nome:");
                        nomeArquivo = Console.ReadLine();
                    }

                }

            } while (!arquivoSalvo);            
            
        }
        void AbrirArquivo()
        {
            string opcaoEscolhida;
            int indiceMenu = 0;
            string diretorio = pasta;
            string[] pastas = Directory.GetFiles(diretorio);

            Console.Clear();
            Console.WriteLine("Qual arquivo você deseja abrir?");

            if (pastas.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("Não existem arquivos cadastrados. Digite qualquer tecla para retornar ao menu.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < pastas.Length; i++)
            {
                int ultimaBarra = pastas[i].LastIndexOf("\\");
                Console.WriteLine($"{i + 1} - {pastas[i].Substring(ultimaBarra + 1)}");
            }

            do
            {
                opcaoEscolhida = char.ConvertFromUtf32(Console.ReadKey().KeyChar);
                if (!char.IsNumber(opcaoEscolhida, 0))
                {
                    Console.WriteLine("Digite um valor válido");
                    continue;
                }
                indiceMenu = Convert.ToInt16(opcaoEscolhida) - 1;
            } while (indiceMenu < 0 || indiceMenu > pastas.Length - 1);

            string arquivo = File.ReadAllText(pastas[indiceMenu]);
            Console.Clear();
            Console.WriteLine("#####");
            Console.WriteLine($"{pastas[indiceMenu].Substring(pastas[indiceMenu].LastIndexOf("\\") + 1)}");
            Console.WriteLine("#####");
            Console.WriteLine($"\n{arquivo}");
            Console.WriteLine("#############################");
            Console.WriteLine("Digite qualquer tecla para retornar ao menu.");
            Console.ReadKey();
        }
        public void Executar()
        {            
            int escolhaUsuario = 0;
            while (escolhaUsuario != 3)
            {
                Console.Clear();
                escolhaUsuario = ImprimirMenu();
                switch (escolhaUsuario)
                {
                    case 1:
                        CriarArquivo();
                        break;
                    case 2:
                        AbrirArquivo();
                        break;
                }
            }
        }
    }
}
