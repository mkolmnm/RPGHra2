namespace RPGHra2.RPGHRA2SOUBORY.Enemy;

public class Bat : Enemy
{
    public Bat()
    {
        Random rnd = new Random();
        EnemyName = "Bat";
        _maxHealth = 8;
        _currentHealth = 8;
        ExperiencePoints = rnd.Next(15, 26);
        
    }
    public override void EnemyAtack(Character target)
    {
        Random rng = new Random();
        Random rng2 = new Random();
        int x = rng.Next(0, 1);
        int y = rng2.Next(0, 1);
        if (x == 0)//50% šance
        {
            target.Health -= 4;           
        }
        if (y == 0)//50% šance
        {
            target.Health -= 4;           
        }
    }
}