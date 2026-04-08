namespace RPGHra2.RPGHRA2SOUBORY.Enemy;

public abstract class Enemy : Character
{
    public string EnemyName { get; protected set; }
    public int ExperiencePoints { get; protected set; }//nastavit podle enemy na random od x do y
    public abstract void EnemyAtack(Character target);
}
