using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentoscsharp
{
    internal class EditorDeTexto
    {
        private string texto; 

        public int imprimirMenu()
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

        public void criarArquivo()
        {
            string nomeArquivo = "";
            Console.Clear();
            Console.WriteLine("Digite o conteúdo do arquivo. Para sair, aperte F1.");

            while (Console.ReadKey().Key != ConsoleKey.F1)
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            } 
            if(String.IsNullOrEmpty(texto))
            {
                Console.Clear();
                return;
            }
            Console.WriteLine("Digite o nome do arquivo: ");
            do
            {
                nomeArquivo = Console.ReadLine();
                Console.Clear();
            } while (String.IsNullOrEmpty(nomeArquivo));

            FileStream fs = new FileStream($"C:\\Programas\\luisanselmobd\\cursos\\balta.io\\fundamentoscsharp\\fundamentoscsharp\\arquivosEditorDeTexto\\{nomeArquivo}.txt", FileMode.CreateNew);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(texto);
            }

            Console.Clear();
            Console.WriteLine($"Arquivo {nomeArquivo}.txt salvo com sucesso!");
        }

        public void AbrirArquivo()
        {
            string opcaoEscolhida;
            int indiceMenu = 0;
            string diretorio = "C:\\Programas\\luisanselmobd\\cursos\\balta.io\\fundamentoscsharp\\fundamentoscsharp\\arquivosEditorDeTexto\\";
            string[] pastas = Directory.GetFiles(diretorio); 
            
            Console.Clear();
            Console.WriteLine("Qual arquivo você deseja abrir?");
            
            if(pastas.Length == 0)
            {
                Console.WriteLine("Não existem arquivos cadastrados.");
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
                if (!Char.IsNumber(opcaoEscolhida, 0))
                {
                    Console.WriteLine("Digite um valor válido");
                    continue;
                }
                indiceMenu = Convert.ToInt16(opcaoEscolhida) - 1;
            } while (indiceMenu < 0 || indiceMenu > pastas.Length - 1);

            string arquivo = File.ReadAllText(pastas[indiceMenu]);
            Console.Clear();
            Console.WriteLine(@$"
            {pastas[indiceMenu].Substring(pastas[indiceMenu].LastIndexOf("\\") + 1)}
            ----
            {arquivo}");
        }
    }
}
