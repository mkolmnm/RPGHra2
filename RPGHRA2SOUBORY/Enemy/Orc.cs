namespace RPGHra2.RPGHRA2SOUBORY.Enemy;

public class Orc : Enemy
{
    private int _damage;//tady nepouzit
    public override int Damage { 
        get => _damage;
        set { }//pozdeji na debuffy
    }

    public Orc()
    {
        Random rnd = new Random(); 
        EnemyName = "Orc";
        _maxHealth = 40;
        currentHealth = 40;
        ExperiencePoints = rnd.Next(15, 26);
    }

    public override void EnemyAtack(Character target)
    {
        target.Health -= 5;
    }
}