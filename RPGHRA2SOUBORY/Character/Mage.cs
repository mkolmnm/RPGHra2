namespace RPGHra2;

public class Mage : Character
{
    public override int Damage { 
        get => usedMana / 2;
        set { }//pozdeji na debuffy
    }
    public string name = "Mage";
    public Mage()
    {
        _maxHealth = 30;
        currentHealth = 30;
        mana = 100;
        
    }

    public int mana { get; set; } = 100;
    public int usedMana;

}