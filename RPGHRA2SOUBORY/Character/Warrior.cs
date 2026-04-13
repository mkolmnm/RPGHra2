namespace RPGHra2;

public class Warrior : Character
{
    private int _damage;
    public override int Damage { 
        get => _damage;
        set { }//pozdeji na debuffy
    }
    public string name = "Warrior";
    
    public Warrior()
    {
        _maxHealth = 100;
        currentHealth = 100;
        power = 10f;
        defence = 10f;
    }

    private float power { get; set; }
    private float defence { get; set;}
}