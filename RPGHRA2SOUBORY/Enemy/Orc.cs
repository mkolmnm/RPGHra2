namespace RPGHra2.RPGHRA2SOUBORY.Enemy;

public class Orc : Enemy
{
    public Orc()
    {
        Random rnd = new Random(); 
        EnemyName = "Orc";
        _maxHealth = 40;
        _currentHealth = 40;
        ExperiencePoints = rnd.Next(15, 26);
    }

    public override void EnemyAtack(Character target)
    {
        target.Health -= 5;
    }
}