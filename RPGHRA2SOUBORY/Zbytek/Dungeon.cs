using RPGHra2.RPGHRA2SOUBORY.Enemy;

namespace RPGHra2;

public class Dungeon
{
    public static bool HrajDungeon(Character hrdina)
    {
        int celkemRoomu = 5;
        Random rnd = new Random();

        for (int room = 1; room <= celkemRoomu; room++)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  ══════════════════════════════");
            Console.WriteLine($"        ROOM {room} / {celkemRoomu}");
            Console.WriteLine($"  ══════════════════════════════");
            Console.ResetColor();
            Console.WriteLine($"  Tvoje HP: {hrdina.Health}");
            Console.WriteLine("\n  Stiskni klávesu...");
            Console.ReadKey(true);

            // Vyber 3 náhodné dveře z poolu
            string[] popisyDveri = GenerujDvere(room, rnd);
            int volba = Moznosti.VykresliMoznosti(
                popisyDveri,
                "Před tebou jsou tři dveře. Kam půjdeš?"
            );

            bool prezil = ZpracujRoom(hrdina, volba, popisyDveri, room, rnd);
            if (!prezil) return false;
            
        }
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
  ██╗   ██╗██╗████████╗███████╗███████╗██╗
  ██║   ██║██║╚══██╔══╝██╔════╝╚════██║██║
  ██║   ██║██║   ██║   █████╗      ██╔╝██║
  ╚██╗ ██╔╝██║   ██║   ██╔══╝     ██╔╝ ╚═╝
   ╚████╔╝ ██║   ██║   ███████╗   ██║  ██╗
    ╚═══╝  ╚═╝   ╚═╝   ╚══════╝   ╚═╝  ╚═╝");
        Console.ResetColor();
        Console.WriteLine($"\n  Prošel jsi celý dungeon! Jsi na levelu {hrdina.Level}.");
        Console.ReadKey(true);
        return true;
    }
    
    static string[] GenerujDvere(int roomCislo, Random rnd)
    {
        // Pool možných dveří — mix nepřátel a eventů
        List<string> pool = new List<string>
        {
            "🦇 Rezavé dveře (slyšíš mávání křídel...)",
            "🧟 Zaprášené dveře (cítíš hnilobu...)",
            "👹 Masivní dveře (slyšíš dunění kroků...)",
            "✨ Zářící dveře (vidíš světlo...)",
            "💀 Prorezlé dveře (ticho...)",
            "🎲 Záhadné dveře (nevíš co čekat...)"
        };

        for (int i = pool.Count - 1; i > 0; i--)
        {
            int j = rnd.Next(i + 1);
            (pool[i], pool[j]) = (pool[j], pool[i]);
        }
        return new string[] { pool[0], pool[1], pool[2] };
    }
    
    static bool ZpracujRoom(Character hrdina, int volba, string[] dvere, int roomCislo, Random rnd)
        {
            string vybraneDvere = dvere[volba];
            Battle battle = new Battle();

            if (vybraneDvere.Contains("Rezavé"))
            {
                return battle.StartBattle(hrdina, new Bat());
            }
            else if (vybraneDvere.Contains("Zaprášené"))
            {
                return battle.StartBattle(hrdina, new Zombie());
            }
            else if (vybraneDvere.Contains("Masivní"))
            {
                return battle.StartBattle(hrdina, new Orc());
            }
            else if (vybraneDvere.Contains("Zářící"))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n  ✨ Našel jsi léčivý pramen!");
                Console.ResetColor();
                hrdina.Health += 20;
                Console.WriteLine($"  HP +20  (nyní {hrdina.Health})");
                Console.WriteLine("\n  Stiskni klávesu...");
                Console.ReadKey(true);
                return true;
            }
            else if (vybraneDvere.Contains("Prorezlé"))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  💀 Šlápnul jsi na past!");
                Console.ResetColor();
                hrdina.TakeDamage(8);
                Console.WriteLine($"  HP -8  (nyní {hrdina.Health})");
                if (hrdina.Health <= 0)
                {
                    Console.WriteLine("  Zemřel jsi na past...");
                    Console.ReadKey(true);
                    return false;
                }
                Console.WriteLine("\n  Stiskni klávesu...");
                Console.ReadKey(true);
                return true;
            }
            else 
            {
                int nahodnost = rnd.Next(3);
                if (nahodnost == 0)
                    return battle.StartBattle(hrdina, new Bat());
                else if (nahodnost == 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n  🎲 Našel jsi potion!");
                    Console.ResetColor();
                    Inventory.PridejPotion("Heal Potion");
                    Console.WriteLine("  Heal Potion přidán do inventáře.");
                    Console.ReadKey(true);
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n  🎲 Prázdná místnost. Nic se nestalo.");
                    Console.ReadKey(true);
                    return true;
                }
            }
        }
}

