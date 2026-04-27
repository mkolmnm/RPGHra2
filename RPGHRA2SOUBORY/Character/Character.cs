namespace RPGHra2;

public abstract class Character
{
    public int Level { get; protected set; } = 1;
    public int XP { get; protected set; } = 0;
    public int XPToNextLevel => Level * 30;
    protected int _currentHealth;
    protected int _maxHealth;
    
    public virtual int Defence { get; set; } = 0; 

    public void PridejXP(int xp)
    {
        XP += xp;
        if (XP >= XPToNextLevel)
        {
            Level++;
            XP -= XPToNextLevel;
            _maxHealth += 10;
            _currentHealth = _maxHealth;

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"\nLevel {Level} achieved! HP +10");
            Console.ResetColor();

            OnLevelUp(); 
        }
    }

    protected virtual void OnLevelUp() { }
    
    
    public int Health
    {
        get => _currentHealth;
        set
        {
            if (value > _maxHealth) //kdyz zivoty presahuji
            {
                _currentHealth = _maxHealth;
            }
            else if (_currentHealth < 0)//mene nez 0
            {
                _currentHealth = 0;
            }            
            else
            {
                _currentHealth = value;
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
        Health -= realdamage;
    }

    public virtual int Damage { get; set; } = 0;

}
    
