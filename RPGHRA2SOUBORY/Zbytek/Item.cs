namespace RPGHra2;

public abstract class Item
{
    public abstract string Name { get; set; }
    public abstract void Effect(Character p);
    protected virtual bool _activeEffect { get; set; }


    public class HealPotion : Item
    {
        public override string Name { get; set; } = "Heal Potion";

        public override void Effect(Character player)
        {
            player.Health += 10;
        }
    }

    public class StrengthPotion : Item
    {
        public override string Name { get; set; } = "Strength Potion";

        public override void Effect(Character player)
        {
            player.Damage += 10;
            _activeEffect =  true;
        }

        public void CancelEfect(Character player)
        {
            player.Damage += 10;
            _activeEffect = false;
        } 
        
    }
}