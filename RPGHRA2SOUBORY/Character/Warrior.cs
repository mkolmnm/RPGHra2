namespace RPGHra2;

public class Warrior : Character
{
    private int _damage = 10;
    public override int Defence { get; set; } = 10;
    public override int Damage { 
        get => _damage;
        set { }//pozdeji na debuffy
    }
    public string name = "Warrior";
    
    public Warrior()
    {
        _maxHealth = 100;
        _currentHealth = 100;
    }

    protected override void OnLevelUp()
    {
        _damage += 1;
        Defence += 1;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  Damage +1 (celkem {_damage})  |  Defence +1 (celkem {Defence})");
        Console.ResetColor();
    } 
    
}