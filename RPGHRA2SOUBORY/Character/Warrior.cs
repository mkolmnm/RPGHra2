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
        currentHealth = 100;
    }

}