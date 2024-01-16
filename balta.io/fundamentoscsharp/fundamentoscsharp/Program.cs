using fundamentoscsharp;
using System.Text;

int operacao;
Calculadora calculadora = new Calculadora();
string sair;

do
{
    operacao = imprimirMenuOperacoes();
    if (operacao == -1)
        break;

    int n1 = imprimirMenuNumeros(1);
    int n2 = imprimirMenuNumeros(2);
    calculadora.RealizarOperacao(n1, n2, (Operacoes)operacao);
    Console.WriteLine("\nPara sair, digite 1.\nPara fazer outra operação, digite qualquer outra tecla.");
    sair = Console.ReadLine();
    if (sair.Equals("1"))
        break;

} while (true);


string construirMenuOpcoes()
{
    StringBuilder menu = new StringBuilder();
    menu.AppendLine("Escolha qual operação você deseja realizar:");

    var lista = Enum.GetValues(typeof(Operacoes));
    foreach (var item in lista)
    {
        menu.AppendLine($"{(int)item + 1} - {item}");
    }
    menu.AppendLine("0 - Sair");
    return menu.ToString();
}
int imprimirMenuOperacoes()
{
    Console.WriteLine(construirMenuOpcoes());

    int operacaoEscolhida;
    bool operacaoValida;

    do
    {
        string escolhaUsuario = Console.ReadLine();

        if (!int.TryParse(escolhaUsuario, out operacaoEscolhida))
        {
            Console.WriteLine("Valor inválido! Digite novamente!");
            continue;
        }

        if (operacaoEscolhida == 0)
            return -1;

        if (!Enum.IsDefined(typeof(Operacoes), operacaoEscolhida - 1))
        {
            Console.WriteLine("Valor inválido! Digite novamente!");
            continue;
        }

        return operacaoEscolhida - 1;

    } while (true);

}

int imprimirMenuNumeros(int numero)
{
    Console.WriteLine($"Digite o {numero}º número inteiro:\n");
    do
    {
        string escolhaUsuario = Console.ReadLine();
        int numeroEscolhido;

        if (!int.TryParse(escolhaUsuario, out numeroEscolhido))
        {
            Console.WriteLine("Valor inválido! Digite novamente!");
            continue;
        }

        return numeroEscolhido;

    } while (true);

}