namespace RPGHra2;

public class Mage : Character
{
    private int _damage = 3;
    private int _manaCost = 15;
    private int  _maxMana = 100;
    public int Mana { get; set; } = 100;
    public string Name { get; set; } = "Mage";

    public override int Damage
    {
        get
        {
            if (Mana >= _manaCost)
            {
                Mana -= _manaCost;
                return _damage + _manaCost + BonusDamage;
            }
            else if (Mana > 0)
            {
                int zbytek = Mana;
                Mana = 0;
                return _damage + zbytek + BonusDamage;
            }
            else
            {
                Console.WriteLine("No mana, utok bez many");
                return _damage + BonusDamage;
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
    
    protected override void OnLevelUp()
    {
        string[] volby = { "+2 Spell Damage", "+30 Max Mana" };
        int volba = Moznosti.VykresliMoznosti(volby, "Vyber si bonus za level up!");

        if (volba == 0)
        {
            _damage += 2;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  Spell damage +2 (celkem {_damage + _manaCost})");
        }
        else
        {
            _maxMana += 30;
            Mana = _maxMana;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  Max mana +30 (celkem {_maxMana})");
        }
        Console.ResetColor();
    }


}