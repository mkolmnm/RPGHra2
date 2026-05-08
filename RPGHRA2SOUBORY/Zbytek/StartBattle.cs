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

        Action status = () => VykresliStatus(player, enemy);

        
        while (player.Health > 0 && enemy.Health > 0)
        {

            string battleMenu = $@"
════════════════════════════════   
Ty:          HP {player.Health}
Your BonusDamage: {player.BonusDamage}
{enemy.EnemyName,-12}  HP {enemy.Health}
════════════════════════════════";
            
            string[] akce = { "Zaútočit", "Jít do inventáře a pak zaútočit" };
            int volba = Moznosti.VykresliMoznosti(akce, "Co uděláš?","", status);
            
            if (volba == 0) // útok
            {
                Console.WriteLine(battleMenu);
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
                VykresliStatus(player, enemy);
                Console.ReadKey(true);
            }
            else // inventář
            {
                Console.Clear();
                while (true)
                {
                    int strengthPotionCount = Inventory.items.FirstOrDefault(x => x.Key == "Strength Potion").Value;
                    int healthPotionCount = Inventory.items.FirstOrDefault(x => x.Key == "Heal Potion").Value;    
                        string inventory = $@"
                ╔══════════════════════════════════════════════╗
                ║           ♦  BRAŠNA S PŘEDMĚTY  ♦            ║
                ╠══════════════════════════════════════════════╣
                ║  ❤  Health Potion  ···················  {healthPotionCount,2} ks ║
                ║  ⚔  Strength Potion  ·················  {strengthPotionCount,2} ks ║
                ╚══════════════════════════════════════════════╝";
                    List<string> dynamickeMoznosti = new List<string>();
        
                    if (healthPotionCount > 0) dynamickeMoznosti.Add("Použít Health Potion");
                    if (strengthPotionCount > 0) dynamickeMoznosti.Add("Použít Strength Potion");
                    dynamickeMoznosti.Add("<- Zpět do boje");          
                   
                        int volbaLekt = Moznosti.VykresliMoznosti(dynamickeMoznosti.ToArray(), "Co Použiješ?",inventory, status);
                        string vybranaVolba = dynamickeMoznosti[volbaLekt];
                        
                        if (vybranaVolba == "Použít Health Potion")
                        {
                            Console.WriteLine("Léčivý lektvar");
                            string[] moznostiF = {"Ano", "Ne"};
                            int poctHea = Moznosti.VykresliMoznosti(moznostiF,
                                "Seš si jistý/á že chceš použít Health Potion?", "", status);
                            if (poctHea == 0)//Ano
                            {
                                Inventory.OdeberPotion("Heal Potion");
                                player.Health += 10;
                                Console.Write("Vypil jsi ");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("Heal Potion");
                                Console.ResetColor(); 
                                Console.WriteLine("!");        
                                Console.ReadKey();
                            }
                            continue;
                        }

                        if (vybranaVolba == "Použít Strength Potion")
                        {
                            Console.WriteLine("Lektvar síly");
                            string[] moznostiG = {"Ano", "Ne"};
                            int poctStr = Moznosti.VykresliMoznosti(moznostiG,
                                "Seš si jistý/á že chceš použít Lektvar síly?","", status);
                            if (poctStr == 0)//Ano
                            {
                                player.PridejTempDamage(10);
                                Inventory.OdeberPotion("Strength Potion");
                                Console.Write("Vypil jsi ");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("Lektvar síly");
                                Console.ResetColor(); 
                                Console.WriteLine("!");        
                                Console.ReadKey();
                            }
                            continue;
                        }
                        
                            Console.Clear();
                            Console.WriteLine(battleMenu);
                            Console.ReadKey();
                            break;
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
                VykresliStatus(player, enemy); 
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
                Console.WriteLine("\n  Stiskni klávesu..."); 
                Console.ReadKey(true);
                Console.Clear();
                Character.ResetujTempDamage(player);
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
    private void VykresliStatus(Character player, Enemy enemy)
    {
        int savedLeft = Console.CursorLeft;
        int savedTop = Console.CursorTop;

        int bottom = Console.WindowHeight - 4;

        Console.SetCursorPosition(0, bottom);
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("════════════════════════════════");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"  ❤  HP: {player.Health,-5}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"  ⚔  Bonus DMG: {player.BonusDamage,-5}");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write($"  [{enemy.EnemyName} HP: {enemy.Health}]");
        Console.ResetColor();

        Console.SetCursorPosition(savedLeft, savedTop);
    }
}