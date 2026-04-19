namespace RPGHra2;

public class Mage : Character
{
    private int _damage = 5;
    private int _manaCost = 10;
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
    
    protected override void OnLevelUp()
    {
        _damage += 1;
        _maxMana += 20;
        Mana = _maxMana;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"  Spell damage +1 (celkem {_damage + _manaCost})  |  Max mana +20 (celkem {_maxMana})");
        Console.ResetColor();
    } 


}