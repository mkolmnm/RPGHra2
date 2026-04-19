using System.Transactions;

namespace RPGHra2;

public class Archer : Character
{
    private static readonly Random _rnd = new Random();
    
    private int _damage = 8;
    public bool CritHit { get; private set; } = false;

    public override int Damage {
        get
        {
            if (_rnd.Next(0, 100) < 30)//30% šance
            {
                CritHit = true;
                return _damage * 2;
            }
            CritHit = false;
            return _damage;
        }
        set { }
    }
    public string name = "Archer";
    
    public Archer()
    {
        _maxHealth = 50;
        _currentHealth = 50;
    }

    protected override void OnLevelUp()
    {
        _damage += 1;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"  Damage +1 (celkem {_damage}, crit {_damage * 2})");
        Console.ResetColor();
    } 
    
}