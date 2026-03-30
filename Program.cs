using System;

namespace RPGHra2
{

    class Program
    {
        static void Main()
        {
            string[] menuPrvni = { "Play", "Choose a Character", "Exit" };
            int volbaPohyb = RPGHra2.Moznosti.VykresliMoznosti(menuPrvni, "Kam chceš jít?");
            switch (volbaPohyb)
            {
                case 0:
                    //Vypsani hry
                    while (true)
                    {
                        Console.WriteLine("Hra");
                    }
                    break;  
                                        
                case 1:
                    //Vybrani charakteru
                    while (true)
                    {
                        Console.WriteLine("Vyber charakter!");
                    }
                    
                    break;
                case 2:
                    Console.WriteLine("Konec");
                    break;
            }
        }
        public static void VypisZadaní(string text)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine($"| {text} |");

            Console.ResetColor();
            Console.WriteLine("\n(Stiskni libovolnou klávesu pro pokračování...)");
            Console.ReadKey(true);
        }
    }   
       
    }
