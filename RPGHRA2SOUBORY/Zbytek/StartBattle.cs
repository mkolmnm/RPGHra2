using RPGHra2.RPGHRA2SOUBORY.Enemy;


namespace RPGHra2;

public class Battle 
{
    public void StartBattle(Character player, Enemy enemy)
    {
        Console.WriteLine($"Potkal si {enemy.EnemyName}...");
        Console.ReadKey();
        while (player.Health > 0 && enemy.Health > 0)
        {
            //hracovo kolo
            Console.WriteLine("\nCo uděláš a)Utéct b)Zaútočit");
            string volba = Console.ReadLine();
            if (volba == "b")
            {
                enemy.currentHealth -= player.Damage;
            }
            else
            {
                Console.WriteLine("Nepodařilo se ti utéct!");
            }

            Console.WriteLine($"{enemy.EnemyName} útočí...");
            enemy.EnemyAtack(player);
            Console.WriteLine($"tvé životy: {player.Health}");

        }

        if (enemy.currentHealth <= 0)
        {
            Console.WriteLine($"Netvůra je mrtvá vyhrál si dostal si {enemy.ExperiencePoints} zkušeností");
            player.PridejXP(enemy.ExperiencePoints);
        }

        if (player.currentHealth <= 0)
        {
            Console.WriteLine($"Game Over, umřel si!");
        }


    }
}