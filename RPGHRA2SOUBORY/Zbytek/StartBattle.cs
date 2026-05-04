using System.Reflection.Metadata.Ecma335;
using RPGHra2.RPGHRA2SOUBORY.Enemy;


namespace RPGHra2;

public class Battle
{
    public bool StartBattle(Character player, Enemy enemy)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Potkal si {enemy.EnemyName}!");
        Console.ResetColor();
        Console.WriteLine("  Stiskni klávesu pro zahájení boje...");
        Console.ReadKey(true);

        while (player.Health > 0 && enemy.Health > 0)
        {
            Console.WriteLine("════════════════════════════════");
            Console.WriteLine($"  Ty:          HP {player.Health}");
            Console.WriteLine($"  {enemy.EnemyName,-12}  HP {enemy.Health}");
            Console.WriteLine("════════════════════════════════");
            Console.ReadKey(true);

            string[] akce = { "Zaútočit", "Jít do inventáře a pak zaútočit" };
            int volba = Moznosti.VykresliMoznosti(akce, "Co uděláš?");
            if (volba == 0) // útok
            {
                
                int dmg = player.Damage; 
                enemy.TakeDamage(dmg);
                if (player is Archer a && a.CritHit)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("  ★ CRITICAL HIT!");
                    Console.ResetColor();
                }
                Console.WriteLine($"\n  Způsobil jsi {dmg} poškození!");
                Console.WriteLine($"{enemy.EnemyName} má {enemy.Health} HP");
                Console.ReadKey(true);
            }
            else // inventář
            {
                Console.Clear();
                while (true)
                {
                int strengthPotionCount = Inventory.items.FirstOrDefault(x => x.Key == "StrengthPotion").Value;
                int healthPotionCount = Inventory.items.FirstOrDefault(x => x.Key == "HealthPotion").Value;    
                    string inventory = $@"
                ╔══════════════════════════════════════════════╗
                ║           ♦  BRAŠNA S PŘEDMĚTY  ♦            ║
                ╠══════════════════════════════════════════════╣
                ║  ❤  Health Potion  ···················  {healthPotionCount,2} ks ║
                ║  ⚔  Strength Potion  ·················  {strengthPotionCount,2} ks ║
                ╚══════════════════════════════════════════════╝";
                    string[] moznostiA = { 
                        $"Léčivý lektvar  ({healthPotionCount} ks) [+50 HP]", 
                        $"Lektvar síly    ({strengthPotionCount} ks) [+5 DMG]", 
                        "<- Zpět do boje" 
                    };                
                   
                    int volbaLekt = Moznosti.VykresliMoznosti(moznostiA, "Co Použiješ?", inventory);

                    switch (volbaLekt)
                    {
                        case 0:
                            Console.WriteLine("Léčivý lektvar");
                            string[] moznostiF = {"Ano", "Ne"};
                            int poctHea = Moznosti.VykresliMoznosti(moznostiF,
                                "Seš si jistý/á že chceš použít Health Potion?");
                            if (poctHea == 0)//Ano
                            {
                                Inventory.OdeberPotion("HealthPotion");
                                player.Health += 10;
                                Console.Write("Vypil jsi ");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("Health Potion");
                                Console.ResetColor(); 
                                Console.WriteLine("!");        
                                Console.ReadKey();
                            }
                            continue;
                            
                        case 1:
                            Console.WriteLine("Lektvar síly");
                            string[] moznostiG = {"Ano", "Ne"};
                            int poctStr = Moznosti.VykresliMoznosti(moznostiG,
                                "Seš si jistý/á že chceš použít Health Potion?");
                            if (poctStr == 0)//Ano
                            {
                                player.PridejTempDamage(10);
                            }
                            continue;
                        case 2:
                            Console.WriteLine("Zpět do boje");
                            break;
                    }
                    Console.ReadKey();

                }
               
                int dmg = player.Damage; 
                enemy.TakeDamage(dmg);
                if (player is Archer a && a.CritHit)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("  ★ CRITICAL HIT!");
                    Console.ResetColor();
                }
                Console.WriteLine($"\n  Způsobil jsi {dmg} poškození!");
                Console.WriteLine($"{enemy.EnemyName} má {enemy.Health} HP");
                Console.ReadKey(true);
            }

            Console.Clear();
            if (enemy.Health > 0)
            {
                int HpBefore  = player.Health;
                Console.WriteLine($"{enemy.EnemyName} útočí...");
                Console.ReadKey(true);
                enemy.EnemyAtack(player);
                int actualDamage = HpBefore - player.Health;

                
                if (player is Warrior a && a.Defence > 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"Tvůj štít zablokoval {a.Defence} Poškození!");
                    Console.ResetColor();
                }
                Console.WriteLine($"{enemy.EnemyName} ti UBRAL {actualDamage} HP!");
                Console.ReadKey(true);
                Console.WriteLine($"Tvé HP: {player.Health}");
                Console.WriteLine("\n  Stiskni klávesu..."); //fixnout cw u nepritele kdyz umre, kdyz umre tak at se nevypise ze bat utoci
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        if (enemy.Health <= 0)
        {
            Console.WriteLine($"Netvůra je mrtvá vyhrál si dostal jsi {enemy.ExperiencePoints} zkušeností");
            player.PridejXP(enemy.ExperiencePoints);
            
            Console.WriteLine($"XP to next level: {player.XPToNextLevel - player.XP}");
            Console.ReadKey(true);
            return true;
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(@"
██████╗  █████╗ ███╗   ███╗███████╗
██╔════╝ ██╔══██╗████╗ ████║██╔════╝
██║  ███╗███████║██╔████╔██║█████╗  
██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  
╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗
╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝
██████╗ ██╗   ██╗███████╗██████╗   
██╔═══██╗██║   ██║██╔════╝██╔══██╗  
██║   ██║██║   ██║█████╗  ██████╔╝  
██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗  
╚██████╔╝ ╚████╔╝ ███████╗██║  ██║  
╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝  
        ");//GAME OVER
        Console.ResetColor();
        Console.ReadKey(true);
        string[] gameOverMenu = { "Hrát znovu (nová hra)", "Odejít" };
        int gameOverVolba = Moznosti.VykresliMoznosti(gameOverMenu, "Co teď?");

        if (gameOverVolba == 1)
        {
            Environment.Exit(0);
        }
            return false;
    }
}