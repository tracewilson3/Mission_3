using System.ComponentModel;

namespace Mission3;

public class FoodItem
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public DateTime Expiration { get; set; }

    public FoodItem(string name, string category, int quantity, DateTime expiration)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        Expiration = expiration;
    }
}
    



    