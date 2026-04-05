namespace RPGHra2;

public class Warrior : Character
{
    public string name = "Warrior";
    
    public Warrior()
    {
        _maxHealth = 100;
        _currentHealth = 100;
        power = 10f;
        defence = 10f;
    }

    private float power { get; set; }
    private float defence { get; set;}
}