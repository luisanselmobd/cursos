using fundamentoscsharp.Programas.Calculadora;
using fundamentoscsharp.Programas.Cronometro;
using fundamentoscsharp.Programas.EditorDeTexto;
using fundamentoscsharp.Programas.EditorHtml;

string menu = @"Qual dos programas abaixo você deseja executar?
1 - Calculadora
2 - Cronograma
3 - Editor de Texto
4 - Editor HTML
ESC - Fechar programa";
bool sair = false;
do
{
    Console.Clear();
    Console.WriteLine(menu);
    ConsoleKeyInfo escolha = Console.ReadKey();

    switch (escolha.Key)
    {
        case ConsoleKey.D1:
            Calculadora calculadora = new Calculadora();
            calculadora.Executar();
            break;
        case ConsoleKey.D2:
            Cronometro cronometro = new Cronometro();
            await cronometro.Executar();
            break;
        case ConsoleKey.D3:
            EditorDeTexto editorDeTexto = new EditorDeTexto();
            editorDeTexto.Executar();
            break;
        case ConsoleKey.D4:
            Executor executor = new Executor();
            executor.Executar();
            break;
        case ConsoleKey.Escape:
            sair = true;
            break;
    }

} while (!sair);