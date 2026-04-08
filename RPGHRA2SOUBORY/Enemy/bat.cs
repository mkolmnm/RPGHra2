namespace RPGHra2.RPGHRA2SOUBORY.Enemy;

public class Bat : Enemy
{
    private static readonly Random _rng = new Random();
    private int _atackDamage = 4;
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
        if (_rng.Next(0,2) == 0)//50% šance
        {
            target.Health -= _atackDamage;           
        }
        if (_rng.Next(0,2) == 0)//50% šance
        {
            target.Health -= _atackDamage;           
        }
    }
}