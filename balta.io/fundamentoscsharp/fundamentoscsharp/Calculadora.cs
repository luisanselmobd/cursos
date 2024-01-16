using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentoscsharp
{
    class Calculadora
    {
        private int resultado;

        public int Resultado { get => resultado; set => resultado = value; }

        public void RealizarOperacao(int a, int b, Operacoes operacao)
        {   
            switch (operacao)
            {
                case Operacoes.Somar:
                    Resultado = somar(a, b);
                    break;
                case Operacoes.Subtrair:
                    Resultado = subtrair(a, b);
                    break;
                case Operacoes.Dividir:
                    Resultado = dividir(a, b);
                    break;
                case Operacoes.Multiplicar:
                    Resultado = multiplicar(a, b);
                    break;
            }
            Console.WriteLine($"RESULTADO: {Resultado}"); 
        }

        int somar(int a, int b) { return a + b; }
        int subtrair(int a, int b) { return a - b; }
        int dividir(int a, int b) { return a / b;}
        int multiplicar(int a, int b) { return a * b; }

        
    }

    enum Operacoes
    {
        Somar,
        Subtrair,
        Dividir,
        Multiplicar
    }

}
