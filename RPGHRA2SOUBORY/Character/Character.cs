namespace RPGHra2;

public abstract class Character
{
    public int Level { get; protected set; } = 1;
    public int XP { get; protected set; } = 0;
    public int XPToNextLevel => Level * 30;
    public int currentHealth;
    protected int _maxHealth;
    public virtual int Defence { get; set; } = 0; 

    public void PridejXP(int xp)
    {
        XP += xp;
        if (XP >= XPToNextLevel)
        {
            Level++;
            XP = 0;
            _maxHealth += 10;
            currentHealth = _maxHealth;
            
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"\nLevel {Level} has been achieved! Your Hp has risen by 10!");
            Console.ResetColor();
        }
    }
    public int Health
    {
        get => currentHealth;
        set
        {
            if (value > _maxHealth)
            {
                value = _maxHealth;
            }
            else if (value <= 0)
            {
                currentHealth = 0;
            }            
            else
            {
                currentHealth = value;
            }
        }
    }
    
    public void TakeDamage(int damageDealt)
    {
        int realdamage = damageDealt - Defence;
        if (realdamage < 0)
        {
            realdamage = 0;
        }
        currentHealth -= realdamage;
    }
    
    public abstract int Damage{get;set;}

}
    
