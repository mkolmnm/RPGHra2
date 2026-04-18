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
            Console.WriteLine($"  Ty:          HP {player.currentHealth}");
            Console.WriteLine($"  {enemy.EnemyName,-12}  HP {enemy.currentHealth}");
            Console.WriteLine("════════════════════════════════");
            Console.ReadKey(true);

            string[] akce = { "Zaútočit", "Utéct" };
            int volba = Moznosti.VykresliMoznosti(akce, "Co uděláš?");
            if (volba == 0) // útok
            {
                
                int dmg = player.Damage; 
                enemy.TakeDamage(dmg);
                Console.WriteLine($"\n  Způsobil jsi {dmg} poškození!");
                Console.ReadKey(true);
            }
            else // útěk
            {
                Console.WriteLine("\n  Nepodařilo se ti utéct!");
                Console.ReadKey(true);
            }

            Console.Clear();
            Console.WriteLine($"{enemy.EnemyName} útočí...");
            Console.ReadKey(true);
            enemy.EnemyAtack(player);
            Console.WriteLine($"{enemy.EnemyName}.ti UBRAL {enemy.Damage} HP!");
            Console.WriteLine($"Tvé HP: {player.Health}");
            Console.WriteLine("\n  Stiskni klávesu...");//fixnout cw u nepritele kdyz umre, kdyz umre tak at se nevypise ze bat utoci
            Console.ReadKey(true);
        }

        if (enemy.currentHealth <= 0)
        {
            Console.WriteLine($"Netvůra je mrtvá vyhrál si dostal jsi {enemy.ExperiencePoints} zkušeností");
            player.PridejXP(enemy.ExperiencePoints);
            return true;
        }

        else
        {
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
            ");
            Console.ResetColor();
            Console.ReadKey(true);
            string[] gameOverMenu = { "Hrát znovu (nová hra)", "Odejít" };
            int gameOverVolba = Moznosti.VykresliMoznosti(gameOverMenu, "Co teď?");

            if (gameOverVolba == 0)
                return false;
            else
            {
                Environment.Exit(0);
            }
        }
        return true;        
    }
}