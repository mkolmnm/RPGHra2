namespace RPGHra2;

public class Warrior : Character
{
    private static int rnd = new Random().Next(2, 6);
    private int _damage = 10;
    public override int Defence { get; set; } = rnd;
    public override int Damage { 
        get => _damage + BonusDamage;
        set;
    }
    public string name = "Warrior";
    
    public Warrior()
    {
        _maxHealth = 70;
        _currentHealth = 70;
    }

    protected override void OnLevelUp()
    {
        string[] volby = { "+2 Damage", "+2 Defence" };
        int volba = Moznosti.VykresliMoznosti(volby, "Vyber si bonus za level up!");

        if (volba == 0)
        {
            _damage += 2;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Damage +2 (celkem {_damage})");
        }
        else
        {
            Defence += 2;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Defence +2 (celkem {Defence})");
        }
        Console.ResetColor();
    }
    
}