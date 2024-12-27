using System;
using System.ComponentModel;
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
                        //Paralelo();
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
                    Console.Clear();
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
                Clear();
                int i = 1;
                decimal resistenciaTotal = 0;
                foreach (decimal resistor in resistores)
                {
                    Console.WriteLine($"Resistor{i}: {resistor}");
                    resistenciaTotal += resistor;
                    i++;
                }
                Clear();
                ReadLine();

                decimal correnteTotal = tensaoTotal / resistenciaTotal;

                i = 1;
                foreach (decimal resistor in resistores)
                {
                    decimal tensaoResistor = correnteTotal * resistor;
                    tensaoResistor = Math.Round(tensaoResistor, 3);

                    Console.WriteLine($"Tensão sobre o resistor{i}: {tensaoResistor}");
                    i++;
                }

                ReadLine();
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
