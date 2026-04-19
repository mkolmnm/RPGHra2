using System.Transactions;

namespace RPGHra2;

public class Archer : Character
{
    private static readonly Random _rnd = new Random();
    
    private int _damage = 8;
    public override int Damage {
        get
        {
            if (_rnd.Next(0, 100) < 30)//30% šance
            {
                Console.WriteLine("Critical Hit!");
                return _damage * 2;
            }
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
}