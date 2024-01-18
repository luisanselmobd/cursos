using fundamentoscsharp;
using System.Text;

//int operacao;
//Calculadora calculadora = new Calculadora();
//string sair;

//do
//{
//    operacao = calculadora.ImprimirMenuOperacoes();
//    if (operacao == -1)
//        break;

//    int n1 = calculadora.ImprimirMenuNumeros(1);
//    int n2 = calculadora.ImprimirMenuNumeros(2);
//    calculadora.RealizarOperacao(n1, n2, (Operacoes)operacao);
//    Console.WriteLine("\nPara sair, digite 1.\nPara fazer outra operação, digite qualquer outra tecla.");
//    sair = Console.ReadLine();
//    if (sair.Equals("1"))
//        break;

//} while (true);

//Cronometro cronometro = new Cronometro();
//await cronometro.Cronometrar();

EditorDeTexto editorDeTexto = new EditorDeTexto();
int escolhaUsuario = 0;
while (escolhaUsuario != 3)
{
    escolhaUsuario = editorDeTexto.imprimirMenu();
    switch(escolhaUsuario)
    {
        case 1:
            editorDeTexto.criarArquivo();
            break;
        case 2:
            editorDeTexto.AbrirArquivo();
            break;
    }
}
