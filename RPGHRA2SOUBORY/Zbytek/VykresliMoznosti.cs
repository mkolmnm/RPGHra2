using System.Globalization;

namespace RPGHra2
{


    public class Moznosti
    {

        public static int VykresliMoznosti(string[] moznosti, string titulek)
        {
            int vybranyIndex = 0;
            ConsoleKey klavesa;

            Console.CursorVisible = false;

            do
            {
                Console.Clear();
                Console.WriteLine(new string('-', titulek.Length)); 
                Console.WriteLine(titulek);

                

                for (int i = 0; i < moznosti.Length; i++)
                {
                    if (i == vybranyIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"> {moznosti[i]} <");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {moznosti[i]}  ");
                    }
                }

                
           if (titulek.Contains("Hrdinu"))
{
    Console.WriteLine("\n--- STATISTIKY ---");
    if (vybranyIndex == 0)      Console.WriteLine("Health: 100  |  Damage: 10   |  Defence: 10");  // Warrior
    else if (vybranyIndex == 1) Console.WriteLine("Health: 30   |  Damage: 5+10 |  Mana: 100");    // Mage (5 + manaCost)
    else if (vybranyIndex == 2) Console.WriteLine("Health: 50   |  Damage: 8/16 |  Defence: 0");   // Archer (8 nebo crit 16)
}
                klavesa = Console.ReadKey(true).Key;

                if (klavesa == ConsoleKey.UpArrow && vybranyIndex > 0)
                    vybranyIndex--;
                else if (klavesa == ConsoleKey.DownArrow && vybranyIndex < moznosti.Length - 1)
                    vybranyIndex++;
                

                

            } while (klavesa != ConsoleKey.Enter);

            Console.CursorVisible = true;
            return vybranyIndex; // Vrátí číslo vybrané položky
        }
    }
}