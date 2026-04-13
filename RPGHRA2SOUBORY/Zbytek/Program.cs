using System;
using System.Reflection.Metadata.Ecma335;
using RPGHra2.RPGHRA2SOUBORY.Enemy;

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


                            string[] smenuHry1 = { "Odrápané dveře", "Starožitné dveře" };
                            Console.WriteLine("");
                            int menuHry1 = Moznosti.VykresliMoznosti(smenuHry1,
                                "Objevil ses v Dungenu a jsou před tebou dvoje DVEŘE. 1. DVEŘE vypadají odrápaně, 2. DVEŘE zase starožitně."
                                + "\n\u001b[1m\u001b[34mKam půjdeš?\u001b[0m");

                            Battle battle = new Battle();
                            Enemy nepritel;

                            if (menuHry1 == 0)
                                nepritel = new Bat(); // odrápané = slabší nepřítel
                            else
                                nepritel = new Orc(); // starožitné = silnější

                            bool vyhra = battle.StartBattle(vybranyHrdina, nepritel);

                            if (!vyhra)
                            {
                                vybranyHrdina = null;
                            }
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
