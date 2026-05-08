namespace RPGHra2;

public class Inventory
{
   public static Dictionary<string, int> items =  new Dictionary<string, int>();

    public static void PridejPotion(string item)
    {
        if (items.ContainsKey(item))
        {
            items[item]++;
        }
        else
        {
            items[item] = 1;
        }
    }

    public static void OdeberPotion(string item)//kontrola ze item vubec existuje
    {
        if (items.ContainsKey(item) && items[item] > 0)
            items[item]--;
    }

    public static void ResetInventory()
    {
        items.Clear();
        PridejPotion("Strength Potion");
        PridejPotion("Heal Potion");
    }   
    
    
}