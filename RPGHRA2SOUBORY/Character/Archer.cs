namespace RPGHra2;

public class Archer : Character
{
    public int firePower { get; set; } = 15;
    public override int Damage { 
        get => firePower;
        set { }//pozdeji na aim
    }
    public string name = "Archer";
    
    public Archer()
    {
        _maxHealth = 50;
        currentHealth = 50;
    }
}