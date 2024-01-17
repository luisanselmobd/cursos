﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentoscsharp
{
    internal class Cronometro
    {
        DateTime dataHora = DateTime.MinValue;
        bool contagemAtiva = true;
        bool repetirContagem = false;

        public async Task Cronometrar()
        {
            do
            {
                if (!repetirContagem)
                {
                    Console.Clear();
                    Console.WriteLine("Aperte qualquer tecla para INICIAR a contagem");
                    Console.ReadKey();
                }

                Console.Clear();
                var contarTempo = ContarTempo();
                Console.ReadKey();
                contagemAtiva = false;
                await contarTempo;
                Console.Clear();
                Console.WriteLine($"O cronômetro foi interrompido no seguinte tempo: {dataHora.ToString("HH:mm:ss")}. Deseja realizar uma nova contagem?");
                Console.WriteLine($"Aperte qualquer tecla para iniciar a contagem ou 0 para sair");
                repetirContagem = Console.ReadKey().Key != ConsoleKey.D0;
                if (repetirContagem)
                {
                    contagemAtiva = true;
                    dataHora = DateTime.MinValue;
                }
            }
            while (repetirContagem);
        }

        async Task ContarTempo()
        {
            while (contagemAtiva)
            {
                Console.Clear();

                Console.WriteLine("Aperte qualquer tecla para PARAR a contagem");
                dataHora = dataHora.AddSeconds(1);
                Console.WriteLine(dataHora.ToString("HH:mm:ss"));
                await Task.Delay(1000);
            }
        }
    }
}
