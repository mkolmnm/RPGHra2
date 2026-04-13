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
        _maxHealth = 12;
        currentHealth = 12;
        ExperiencePoints = rnd.Next(15, 26);
    }

    public override void EnemyAtack(Character target)
    {
        Random rng = new Random();
        int x = rng.Next(0, 4);
        if (x == 0)//20% šance
        {
            target.Health -= 9;           
        }
        target.Health -= 3;
    }

}