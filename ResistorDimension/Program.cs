using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace ResistorDimension
{
    internal class Program
    {

        enum Menu {sair, resistoresSerie, resistoresParalelo}

        static void Main(string[] args) 
        {
            Console.Write("Olá! Seja boas vindas ao Resistor Dimension!\n\nPressione ENTER para acessar o Menu. ");
            ReadLine();
            Clear();
            ProgramMenu();

            static void ProgramMenu()
            {
                Console.WriteLine("Selecione uma Opção: \n");

                Console.WriteLine("1- Calcular resistores em série\n2- Calcular resistores em paralelo\n0- Sair\n");
                Menu opcao = (Menu)int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case Menu.resistoresSerie:
                        Serie();
                        break;
                    case Menu.resistoresParalelo:
                        Paralelo();
                        break;
                    case Menu.sair:
                        Clear();
                        Console.WriteLine("Muito Obrigado por utilizar o programa!");
                        Console.Write("\nPressione ENTER para fechar o programa. ");
                        ReadLine();
                        break;
                    default:
                        Clear();
                        Console.WriteLine("Por favor Escolha uma opção válida.");
                        Console.Write("\nPressione ENTER para retornar ao menu. ");
                        ReadLine();
                        Clear();
                        ProgramMenu();
                        break;
                }
            }

            static void Serie()
            {
                decimal valor = 1;
                List<decimal> resistores = new List<decimal>();

                while (valor != 0)
                {
                    Clear();
                    Console.Write("Digite o valor do resistor (Para parar digite 0): ");
                    valor = decimal.Parse(Console.ReadLine());

                    if (valor != 0)
                    {
                        resistores.Add(valor);
                    }
                    Clear();
                }

                Console.Write("Digite a tensão total da malha de resistores (em volts): ");
                decimal tensaoTotal = decimal.Parse(Console.ReadLine());
                tensaoTotal = Math.Round(tensaoTotal, 3);
                Clear();

                Console.WriteLine($"Tensão total: {tensaoTotal}V\n");

                int i = 1;
                decimal resistenciaTotal = 0;
                foreach (decimal resistor in resistores)
                {
                    Console.WriteLine($"Resistor{i}: {resistor} Ohms");
                    resistenciaTotal += resistor;
                    i++;
                }

                Console.Write("\nDeseja alterar os valores? (sim/não) ");
                string opcao = Console.ReadLine().ToUpper();

                if (opcao == "SIM")
                {
                    Clear();
                    Serie();
                }else if (opcao == "NÃO" || opcao == "NAO"){

                    Clear();
                }

                decimal correnteTotal = tensaoTotal / resistenciaTotal;

                Console.WriteLine("Tensão sobre cada resistor: \n");
                Console.WriteLine("Resistores\tResistência\tTensão\n");

                i = 1;
                foreach (decimal resistor in resistores)
                {
                    decimal tensaoResistor = correnteTotal * resistor;
                    tensaoResistor = Math.Round(tensaoResistor, 3);

                    Console.WriteLine($"Resistor{i}:\t{resistor} Ohms \t{tensaoResistor}V");
                    i++;
                }

                Console.Write("\nPressione ENTER para retornar ao menu. ");
                ReadLine();
                Clear();
                ProgramMenu();
            }

            static void Paralelo()
            {
                decimal valor = 1;
                List<decimal> resistores = new List<decimal>();

                while (valor != 0)
                {
                    Clear();
                    Console.Write("Digite o valor do resistor (Para parar digite 0): ");
                    valor = decimal.Parse(Console.ReadLine());

                    if (valor != 0)
                    {
                        resistores.Add(valor);
                    }
                    Clear();
                }

                int i = 1;
                foreach(int resistor in resistores)
                {
                    Console.WriteLine($"Resistor{i}: {resistor} Ohms");
                }
                Console.Write("\nDeseja alterar os valores? (sim/não) ");
                string opcao = Console.ReadLine().ToUpper();

                if (opcao == "SIM")
                {
                    Clear();
                    Paralelo();

                }else if (opcao == "NÃO" || opcao == "NAO")
                {
                    Clear();
                }

                if (resistores.Count == 2)
                {
                    decimal resistenciaTotal = (resistores[0] * resistores[1]) / (resistores[0] + resistores[1]);
                    resistenciaTotal = Math.Round(resistenciaTotal, 3);
                    Console.WriteLine($"A resistência total da malha é: {resistenciaTotal} Ohms");

                } else if (resistores.Count > 2)
                {
                    decimal inversoResistenciaTotal = 0;
                    foreach (decimal resistor in resistores)
                    {
                    inversoResistenciaTotal += 1 / resistor;
                    }

                    decimal resistenciaTotal = 1 / inversoResistenciaTotal;
                    resistenciaTotal = Math.Round(resistenciaTotal, 3);
                    Console.WriteLine($"A resistência total da malha é: {resistenciaTotal} Ohms");
                    }

                Console.Write("\nPressione ENTER para retornar ao menu. ");
                ReadLine();
                Clear();
                ProgramMenu();
            }
        }

        static void Clear()
        {
            Console.Clear();
        }
        static void ReadLine() 
        { 
            Console.ReadLine();
        }
    }
}
