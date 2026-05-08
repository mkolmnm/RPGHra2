using System;
using System.Reflection.Metadata.Ecma335;
using RPGHra2.RPGHRA2SOUBORY.Enemy;

namespace RPGHra2
{

    class Program
    {
        static void Main()

        {
            RPGHra2.Inventory.PridejPotion("Strength Potion");
            RPGHra2.Inventory.PridejPotion("Heal Potion");
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
                            bool vyhralHru = Dungeon.HrajDungeon(vybranyHrdina);
                            if (!vyhralHru)
                            {
                                vybranyHrdina = null;
                                Inventory.ResetInventory();
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
