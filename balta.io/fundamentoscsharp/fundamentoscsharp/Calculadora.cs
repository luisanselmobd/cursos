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

        public int RealizarOperacao(int a, int b, operacoes operacao)
        {   
            switch (operacao)
            {
                case operacoes.somar:
                    Resultado = somar(a, b);
                    break;
                case operacoes.subtrair:
                    Resultado = subtrair(a, b);
                    break;
                case operacoes.dividir:
                    Resultado = dividir(a, b);
                    break;
                case operacoes.multiplicar:
                    Resultado = multiplicar(a, b);
                    break;
            }
            return Resultado; 
        }

        int somar(int a, int b) { return a + b; }
        int subtrair(int a, int b) { return a - b; }
        int dividir(int a, int b) { return a / b;}
        int multiplicar(int a, int b) { return a * b; }

        
    }

    enum operacoes
    {
        somar,
        subtrair,
        dividir,
        multiplicar
    }

}
