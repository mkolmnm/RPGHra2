using System.Transactions;

namespace RPGHra2;

public class Archer : Character
{
    private static readonly Random _rnd = new Random();
    
    private int _damage = 8;
    public bool CritHit { get; private set; } = false;
    private int _critChance = 30;


    public override int Damage {
        get
        {
            if (_rnd.Next(0, 100) < _critChance)
            {
                CritHit = true;
                return (_damage + BonusDamage) * 2 ;
            }
            CritHit = false;
            return _damage + BonusDamage;
        }
        set;
    }
    public string name = "Archer";
    
    public Archer()
    {
        _maxHealth = 50;
        _currentHealth = 50;
    }

    protected override void OnLevelUp()
    {
        string[] volby = { "+2 Damage", "+10% Crit Chance" };
        int volba = Moznosti.VykresliMoznosti(volby, "Vyber si bonus za level up!");

        if (volba == 0)
        {
            _damage += 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  Damage +2 (celkem {_damage}, crit {_damage * 2})");
        }
        else
        {
            _critChance += 10;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  Crit chance +10% (celkem {_critChance}%)");
        }
        Console.ResetColor();
    }
    
}