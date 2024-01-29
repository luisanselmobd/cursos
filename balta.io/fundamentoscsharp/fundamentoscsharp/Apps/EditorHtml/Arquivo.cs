using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Spectre.Console;
namespace fundamentoscsharp.Programas.EditorHtml
{
    internal class Arquivo
    {
        private string texto;
        private string pasta = @$"Apps\EditorHtml\arquivosEditorHtml";
        public void CriarArquivo()
        {
            Console.Clear();
            string nomeArquivo = "";
            var nomes = Enum.GetNames(typeof(TagsStyle));
            string arquivos = string.Join(", ", nomes.Select(nome => $"<{nome}>"));
            int ultimaVirgula = arquivos.LastIndexOf(",");
            arquivos = arquivos.Substring(0, ultimaVirgula) + " e" + arquivos.Substring(ultimaVirgula + 1);
            AnsiConsole.MarkupLine(@$"Digite o conteúdo do arquivo. Para sair, aperte ESC.
[italic]Suporte para as seguintes tags: {arquivos}.[/]");

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
                    FileStream fs = new FileStream($@"{pasta}\{nomeArquivo}.html", FileMode.CreateNew);
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(texto);
                        sw.Flush();
                    }
                    fs.Close();
                    Console.Clear();
                    Console.WriteLine($"Arquivo {nomeArquivo}.html salvo com sucesso! Digite qualquer tecla para retornar ao menu.");
                    arquivoSalvo = true;
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("already exists"))
                    {
                        Console.Write($"Arquivo {nomeArquivo}.html já existe! Digite um novo nome:");
                        nomeArquivo = Console.ReadLine();
                    }
                }

            } while (!arquivoSalvo);
        
        }
        public void AbrirArquivo()
        {
            string opcaoEscolhida;
            int indiceMenu = 0;
            string diretorio = @$"{pasta}\";
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


            Console.BackgroundColor = ConsoleColor.Black;
            string arquivo = File.ReadAllText(pastas[indiceMenu]);
            Console.Clear();
            Console.WriteLine("#####");
            Console.WriteLine($"{pastas[indiceMenu].Substring(pastas[indiceMenu].LastIndexOf("\\") + 1)}");
            Console.WriteLine("#####");
            AnsiConsole.MarkupLine($"\n{FormatarTexto(arquivo)}");
            Console.WriteLine("#############################");
            Console.WriteLine("Digite qualquer tecla para retornar ao menu.");
            Console.ReadKey();
        }
        public string FormatarTexto(string texto)
        {
            List<string> tagsContempladas = new List<string>();
            string expresaoCapturaTags = @"<([^/].*?)>";
            Regex regexCapturaTags = new Regex(expresaoCapturaTags);
            MatchCollection tags = regexCapturaTags.Matches(texto);

            foreach (Match tag in tags)
            {
                string nomeTag = tag.ToString().Remove(tag.ToString().Length - 1, 1).Remove(0, 1);
                bool contemplaTag = Enum.IsDefined(typeof(TagsStyle), nomeTag);
                if (contemplaTag)
                    tagsContempladas.Add(nomeTag);
            }

            foreach (string tag in tagsContempladas)
            {
                int valorTag = (int)Enum.Parse(typeof(TagsStyle), tag);
                string valorTagMarkup = Enum.GetName(typeof(TagsStyleMarkup), valorTag);
                string expressaoCapturaTextoTag = @$"(<{tag}>(.*?)<\/{tag}>)";
                Regex regexCapturaTextoTag = new Regex(expressaoCapturaTextoTag);
                MatchCollection textosCapturados = regexCapturaTextoTag.Matches(texto);
                foreach (var textoCapturado in textosCapturados)
                {
                    string expressaoCapturaTagsFechamento = @$"\[\/]|<\/([^{tag}].*?)>";
                    string novoTexto = Regex.Replace(textoCapturado.ToString(), expressaoCapturaTagsFechamento, match => $"[/]{match.Value}[{valorTagMarkup}]");
                    novoTexto = novoTexto.ToString().Replace($"<{tag}>", $"[{valorTagMarkup}]").Replace($"</{tag}>", "[/]");
                    texto = texto.Replace(textoCapturado.ToString(), novoTexto);
                }
            }
            return texto;
        }
        private enum TagsStyleMarkup
        {
            bold,
            italic,
            underline,
            strikethrough,
            reverse
        }
        private enum TagsStyle
        {
            strong = 0,
            b = 0,
            em = 1,
            i = 1,
            u = 2,
            ins = 2,
            s = 3,
            del = 3,
            mark = 4
        }
    }
}

