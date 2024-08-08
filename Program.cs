using System;

namespace Matriz
{
    class Program
    {

        //programa que simula el juego de TikTakToe
        static void Main(string[] args)
        {
            
            char[,] miMatriz = new char[,]
            {
                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'}

            };

            Console.WriteLine("El objetivo del juego es ser el primero en conseguir tres marcas propias en línea" +
                "\nya sea horizontal, vertical o diagonalmente.\n");
                ImprimirMatriz(miMatriz);

            int contador = 0;
            string input;
            char caracter;
            
            do
            {
                if (contador % 2 == 0)
                {
                    Console.WriteLine("Jugador 1 ingrese numero de casillero ");
                    input = Console.ReadLine();
                    caracter = input[0];
                    BuscarEnMatriz(miMatriz, caracter, contador);
                    ImprimirMatriz(miMatriz);
                    if (HayGanador(miMatriz))
                    {
                        Console.WriteLine("Game Over");
                       
                       
                    }
                    
                }
                
                if (contador % 2 != 0)
                {
                    Console.WriteLine("Jugador 2 ingrese numero de casillero ");
                    input = Console.ReadLine();
                    caracter = input[0];
                    BuscarEnMatriz(miMatriz, caracter, contador);
                    ImprimirMatriz(miMatriz);
                    if (HayGanador(miMatriz))
                    {
                        Console.WriteLine("Game Over");
                       
                    }
                }
                contador++;
                if (HayGanador(miMatriz))
                {
                    if (contador % 2 != 0)
                    {
                        Console.WriteLine("FELICIDADES JUGADOR 1, HAS SIDO EL GANADOR.");
                    }
                    else
                    {
                        Console.WriteLine("FELICIDADES JUGADOR 2, HAS SIDO EL GANADOR. ");
                    }
                        break;

                }

            } while (contador < miMatriz.Length);
            if (HayGanador(miMatriz))
            {
                Console.WriteLine("Juego finalizado");
            }
            else
            {
                Console.WriteLine("NO HUBO NINGUN GANADOR.");
            }
               

        }

        static bool HayGanador(char[,] miMatriz)
        {
            return ValidarFilas(miMatriz) || ValidarColumnas(miMatriz) || ValidarDiagonales(miMatriz);
        }

        static bool ValidarFilas(char[,] miMatriz)
        {
            for (int i = 0; i < 3; i++)
            {
                if (miMatriz[i, 0] == miMatriz[i, 1] && miMatriz[i, 1] == miMatriz[i, 2] && miMatriz[i, 0] != ' ')
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ValidarColumnas(char[,] miMatriz)
        {
            for (int j = 0; j < 3; j++)
            {
                if (miMatriz[0, j] == miMatriz[1, j] && miMatriz[1, j] == miMatriz[2, j] && miMatriz[0, j] != ' ')
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ValidarDiagonales(char[,] miMatriz)
        {
            if (miMatriz[0, 0] == miMatriz[1, 1] && miMatriz[1, 1] == miMatriz[2, 2] && miMatriz[0, 0] != ' ')
            {
                return true;
            }

            // Diagonal secundaria
            if (miMatriz[0, 2] == miMatriz[1, 1] && miMatriz[1, 1] == miMatriz[2, 0] && miMatriz[0, 2] != ' ')
            {
                return true;
            }

            return false;
        }
        public static void BuscarEnMatriz(char[,] miMatriz, char caracter, int contador)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (miMatriz[i, j] == caracter)
                    {
                        if (contador % 2 == 0)
                        {
                            miMatriz[i, j] = 'X';
                            break;
                        }
                        else
                        {
                            miMatriz[i, j] = 'O';
                            break;
                        }
                       
                    }
                }
            }
        }

        public static void ImprimirMatriz(char[,] miMatriz)
        {
            for (int i = 0; i < 3 ;i++) 
            {
                for(int j = 0;j < 3;j++)
                {
                    if ((i != 0 || j != 2) && (i != 1 || j != 2) && (i != 2 || j != 2))
                    {
                        Console.Write(" "+ miMatriz[i, j] + " |");
                    }
                    else
                    {
                        Console.Write( " "+ miMatriz[i, j]);
                       
                    }
                    

                }
                Console.WriteLine();
                if ((i != 2))
                {
                    Console.WriteLine("---|---|---");
                }
            }
        }
    }
}