namespace RPGHra2;

public class Warrior
{
    private int _maxHealth = 100;//100 životů na začátku

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

    public float power { get; set; }
    public float defence { get; set;}
}