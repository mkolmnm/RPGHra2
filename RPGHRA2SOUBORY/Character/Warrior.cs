namespace RPGHra2;

public class Warrior : Character
{
    private int _damage = 10;
    public float Defence { get; set; } = 10f;
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

    private float power { get; set; }
    private float defence { get; set;}
}