namespace RPGHra2.RPGHRA2SOUBORY.Enemy;

public class Bat : Enemy
{
    private int _damage = 4;
    public override int Damage { 
        get => _damage;
        set { }
    }
    private static readonly Random _rng = new Random();
    public Bat()
    {
        Random rnd = new Random();
        EnemyName = "Bat";
        _maxHealth = 8;
        currentHealth = 8;
        ExperiencePoints = rnd.Next(10, 15);
        
    }
    public override void EnemyAtack(Character target)
    {
        if (_rng.Next(0,2) == 0)//50% šance
        {
            target.TakeDamage(Damage);           
        }
    }
}