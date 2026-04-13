namespace RPGHra2;

public abstract class Character
{ 
    public int currentHealth;
    protected int _maxHealth;

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
                value = 0;
                Console.WriteLine("Měl bys umřít!!!");
            }
            else
            {
                currentHealth = value;
            }
        }
    }
    public abstract int Damage{get;set;}

}
    
