using System;

namespace TicTacToe
{
    class Program
    {
        // igralno polje
        static char[,] igralnoPolje =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };

        static int turns = 0;

        static void Main(string[] args)
        {
            int igralec = 2;
            int vnos = 0;
            bool praviVnos = true;

            do
            {
                if (igralec == 2)
                {
                    igralec = 1;
                    VnesiXaliO(igralec, vnos);
                }
                else if (igralec == 1)
                {
                    igralec = 2;
                    VnesiXaliO(igralec, vnos);
                }

                nastaviPolje();

                #region
                // preverjanje stanja zmage
                char[] charsIgralca = { 'X', 'O' };
                foreach(char charIgralca in charsIgralca)
                {
                    if (((igralnoPolje[0,0] == charIgralca) && (igralnoPolje[0,1] == charIgralca) && (igralnoPolje[0,2] == charIgralca)) // 123
                        || ((igralnoPolje[1, 0] == charIgralca) && (igralnoPolje[1, 1] == charIgralca) && (igralnoPolje[1, 2] == charIgralca)) // 456
                        || ((igralnoPolje[2, 0] == charIgralca) && (igralnoPolje[2, 1] == charIgralca) && (igralnoPolje[2, 2] == charIgralca)) // 789
                        || ((igralnoPolje[0, 0] == charIgralca) && (igralnoPolje[1, 0] == charIgralca) && (igralnoPolje[2, 0] == charIgralca)) // 147
                        || ((igralnoPolje[0, 1] == charIgralca) && (igralnoPolje[1, 1] == charIgralca) && (igralnoPolje[2, 1] == charIgralca)) // 258
                        || ((igralnoPolje[0, 2] == charIgralca) && (igralnoPolje[1, 2] == charIgralca) && (igralnoPolje[2, 2] == charIgralca)) // 369
                        || ((igralnoPolje[0, 0] == charIgralca) && (igralnoPolje[1, 1] == charIgralca) && (igralnoPolje[2, 2] == charIgralca)) // 159
                        || ((igralnoPolje[0, 2] == charIgralca) && (igralnoPolje[1, 1] == charIgralca) && (igralnoPolje[2, 0] == charIgralca)) // 357
                        )
                    {
                        if (charIgralca == 'X')
                        {
                            Console.WriteLine("\nIgralec št. 2 je zmagovalec!");
                        }
                        else
                        {
                            Console.WriteLine("\nIgralec št. 1 je zmagovalec!");
                        }
                        Console.WriteLine("Pritisni katerokoli tipko za novo igro!");
                        Console.ReadKey();

                        PonastaviPolje();
                        break;
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("NEODLOČENA IGRA");
                        Console.WriteLine("Pritisni katerokoli tipko za novo igro!");
                        Console.ReadKey();

                        PonastaviPolje();
                        break;
                    }
                }

                #endregion

                #region
                // preverba ali je polje že zasedeno / zavzeto
                do
                {
                    Console.Write("\nIgralec {0}: izberi svoje polje: ", igralec);
                    try
                    {
                        vnos = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Prosim vnesi število!");
                    }

                    if ((vnos == 1) && (igralnoPolje[0, 0] == '1'))
                    {
                        praviVnos = true;
                    }
                    else if ((vnos == 2) && igralnoPolje[0, 1] == '2')
                    {
                        praviVnos = true;
                    }
                    else if ((vnos == 3) && igralnoPolje[0, 2] == '3')
                    {
                        praviVnos = true;
                    }
                    else if ((vnos == 4) && igralnoPolje[1, 0] == '4')
                    {
                        praviVnos = true;
                    }
                    else if ((vnos == 5) && igralnoPolje[1, 1] == '5')
                    {
                        praviVnos = true;
                    }
                    else if ((vnos == 6) && igralnoPolje[1, 2] == '6')
                    {
                        praviVnos = true;
                    }
                    else if ((vnos == 7) && igralnoPolje[2, 0] == '7')
                    {
                        praviVnos = true;
                    }
                    else if ((vnos == 8) && igralnoPolje[2, 1] == '8')
                    {
                        praviVnos = true;
                    }
                    else if ((vnos == 9) && igralnoPolje[2, 2] == '9')
                    {
                        praviVnos = true;
                    } else
                    {
                        Console.WriteLine("\nNapačen vnos, prosim izberi drugo polje");
                        praviVnos = false;
                    }

                } while (!praviVnos);
                #endregion
            } while (true);
        }

        public static void PonastaviPolje()
        {
            char[,] igralnoPoljeInitial =
            {
                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'}
            };

            igralnoPolje = igralnoPoljeInitial;
            nastaviPolje();
            turns = 0;
        }

        public static void nastaviPolje()
        {
            Console.Clear();
            Console.WriteLine("     |      |      ");
            Console.WriteLine("  {0}  |   {1}  |  {2}", igralnoPolje[0,0], igralnoPolje[0,1], igralnoPolje[0,2]);
            Console.WriteLine("_____|______|_____");
            Console.WriteLine("     |      |      ");
            Console.WriteLine("  {0}  |   {1}  |  {2}", igralnoPolje[1, 0], igralnoPolje[1, 1], igralnoPolje[1, 2]);
            Console.WriteLine("_____|______|_____");
            Console.WriteLine("     |      |      ");
            Console.WriteLine("  {0}  |   {1}  |  {2}", igralnoPolje[2, 0], igralnoPolje[2, 1], igralnoPolje[2, 2]);
            Console.WriteLine("     |      |      ");
            turns++;
        }

        public static void VnesiXaliO(int igralec, int vnos)
        {
            char znakIgralca = ' ';

            if (igralec == 1)
            {
                znakIgralca = 'X';
            } else if (igralec == 2)
            {
                znakIgralca = 'O';
            }
            switch (vnos)
            {
                case 1: igralnoPolje[0, 0] = znakIgralca; break;
                case 2: igralnoPolje[0, 1] = znakIgralca; break;
                case 3: igralnoPolje[0, 2] = znakIgralca; break;
                case 4: igralnoPolje[1, 0] = znakIgralca; break;
                case 5: igralnoPolje[1, 1] = znakIgralca; break;
                case 6: igralnoPolje[1, 2] = znakIgralca; break;
                case 7: igralnoPolje[2, 0] = znakIgralca; break;
                case 8: igralnoPolje[2, 1] = znakIgralca; break;
                case 9: igralnoPolje[2, 2] = znakIgralca; break;
            }
        }
    }
}
