namespace RPGHra2;

public class Archer : Character
{
    private static readonly Random _rnd = new Random();
    
    private int _damage = 8;
    public override int Damage { 
        get => _damage;
        set
        {
            if (_rnd.Next(0, 10) < 4)//30% šance
            {
                _damage = value * 2;
                Console.WriteLine("Critical Hit!");
            }
        }
    }
    public string name = "Archer";
    
    public Archer()
    {
        _maxHealth = 50;
        currentHealth = 50;
    }
}