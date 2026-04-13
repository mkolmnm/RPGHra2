using System;
using System.Reflection.Metadata.Ecma335;

namespace RPGHra2
{

    class Program
    {
        static void Main()
        {
            Character vybranyHrdina = null;
            bool konecHry = false;
            while (!konecHry)
            {


                string[] menuPrvni = { "Play", "Choose a Character", "Exit" };
                int volbaPohyb = Moznosti.VykresliMoznosti(menuPrvni, "Vítej!");
                switch (volbaPohyb)
                {
                    case 0:
                        Console.Clear();
                        if (vybranyHrdina == null)
                        {
                            Console.WriteLine("Napred si vyber hrdinu!");
                            Console.WriteLine("\nStiskni libovolnou klávesu pro návrat do menu...");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.WriteLine($"Máš vybraného: {vybranyHrdina.GetType().Name}!");
                            Console.WriteLine("Hra běží...");


                            string[] smenuHry2 = { "Odrápané dveře", "Starožitné dveře" };
                            Console.WriteLine("");
                            int menuHry2 = Moznosti.VykresliMoznosti(smenuHry2,
                                "Objevil ses v Dungenu a jsou před tebou dvoje DVEŘE. 1. DVEŘE vypadají odrápaně, 2. DVEŘE zase starožitně."
                                + "\n\u001b[1m\u001b[34mKam půjdeš?\u001b[0m");
                            switch (menuHry2)
                            {
                                case 0:
                                    Console.WriteLine($"You have chosen the {smenuHry2[0]}!");
                                    break;

                                case 1:
                                    Console.WriteLine($"You have chosen the {smenuHry2[1]}!");
                                    break;
                                default:
                                    Console.WriteLine("nefunguje");
                                    break;
                            }

                            Console.ReadKey(true);
                        }
                        break;

                    case 1:
                        vybranyHrdina = RPGHra2.HrdinaLogika.VyberPostavu();
                        Console.WriteLine($"Vybral sis hrdinu: {vybranyHrdina}!");
                        break;
                    case 2:
                        Console.WriteLine("Konec");
                        konecHry = true;
                        break;
                }
            }
        }
    }
}    
