namespace RPGHra2;

public class Archer : Character
{
    public Archer()
    {
        _maxHealth = 50;
        _currentHealth = 50;
        firePower = 15.5f;
    }
    public float firePower{get;set;}
}