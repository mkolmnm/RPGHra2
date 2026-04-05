namespace RPGHra2;

public class Mage
{
    private int _maxHealth = 30;//30 životů na začátku

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

    public int strenght;
    public int mana;
    public int defence;
}