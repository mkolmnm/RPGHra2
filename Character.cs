namespace RPGHra2;

public abstract class Character
{ 
    protected int _currentHealth;
    protected int _maxHealth;

    public int Health
    {
        get => _currentHealth;
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
                _currentHealth = value;
            }
        }
    }


}
    
