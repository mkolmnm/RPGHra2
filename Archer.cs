namespace RPGHra2;

public class Archer
{
    private int _maxHealth = 50;//50 životů na začátku
    public int health
    {
        get => _maxHealth;
        set
        {
            if (value > 100)
            {
                value = 100;
            }
            else if (value <= 0)
            {
                value = 0;
                Console.WriteLine("Měl bys umřít!!!");
            }
            else
            {
                _maxHealth = value;
            }
        }
        
    }
    public float firePower{get;set;}
    public int defence{get;set;}
}