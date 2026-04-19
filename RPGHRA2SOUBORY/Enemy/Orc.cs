namespace RPGHra2.RPGHRA2SOUBORY.Enemy;

public class Orc : Enemy
{
    private int _damage = 8;
    public override int Damage { 
        get => _damage;
        set;
    }
    public Orc()
    {
        Random rnd = new Random(); 
        EnemyName = "Orc";
        _maxHealth = 50;
        _currentHealth = 50;
        ExperiencePoints = rnd.Next(40, 55);
    }

    public override void EnemyAtack(Character target)
    {
            target.TakeDamage(Damage);
    }
}