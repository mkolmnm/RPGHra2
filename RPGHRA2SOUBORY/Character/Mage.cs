namespace RPGHra2;

public class Mage : Character
{
    private int _damage = 5;
    private int _manaCost = 10;

    public int Mana { get; set; } = 100;
    public string Name { get; set; } = "Mage";

    public override int Damage
    {
        get
        {
            if (Mana >= _manaCost)
            {
                Mana -= _manaCost;
                return _damage + _manaCost;
            }
            else if (Mana > 0)
            {
                int zbytek = Mana;
                Mana = 0;
                return _damage + zbytek;
            }
            else
            {
                Console.WriteLine("No mana, utok bez many");
                return _damage;
            }
        }
        set{ }
        //pozdeji na debuffy
    }
    public Mage()
    {
        _maxHealth = 30;
        _currentHealth = 30;
    }


}