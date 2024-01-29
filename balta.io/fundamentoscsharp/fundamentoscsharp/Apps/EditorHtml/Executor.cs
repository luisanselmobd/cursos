using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentoscsharp.Programas.EditorHtml
{
    internal class Executor
    {
        public void Executar()
        {
            Console.Clear();
            Menu menu = new Menu();
            Arquivo arquivo = new Arquivo();
            int escolhaUsuario = 0;
            while (escolhaUsuario != 3)
            {

                escolhaUsuario = menu.ImprimirMenu();
                switch (escolhaUsuario)
                {
                    case 1:
                        arquivo.CriarArquivo();
                        Console.Clear();
                        break;
                    case 2:
                        arquivo.AbrirArquivo();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
