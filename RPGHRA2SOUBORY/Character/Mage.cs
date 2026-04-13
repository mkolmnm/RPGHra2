namespace RPGHra2;

public class Mage : Character
{
    private int _damage = 5;
    public override int Damage
    {
        get => _damage;
        set
        {
            if (useMana = true)
            {
                value + mana = _damage;
            }
        }//pozdeji na debuffy
    }
    public string name = "Mage";
    public Mage()
    {
        _maxHealth = 30;
        currentHealth = 30;
        mana = 100;
        bool useMana = false;
    }

    public int mana { get; set; } = 100;
    public int usedMana;

}