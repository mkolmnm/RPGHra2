namespace RPGHra2.RPGHRA2SOUBORY.Enemy;

public class Zombie : Enemy
{
    private int _damage;
    public override int Damage { 
        get => _damage;
        set { }//pozdeji na debuffy
    }
    
    public Zombie()
    {
        Random rnd = new Random();
        EnemyName = "Zombie";
        _maxHealth = 20;
        currentHealth = 20;
        ExperiencePoints = rnd.Next(20, 30);
    }

    public override void EnemyAtack(Character target)
    {
        Random rng = new Random();
        int x = rng.Next(0, 5);
        if (x == 0)//20% šance
        {
            target.TakeDamage(8);
        }
            target.TakeDamage(4);
    }

}