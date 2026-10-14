namespace Domain.Models;

public class Product
{
    private Product() { }

    private Product(int id, string name, bool isBought)
    {
        Id = id;
        Name = name;
        IsBought = isBought;
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public bool IsBought { get; private set; }

    public static Product Create(int id, string name, bool isBought = false)
    {
        return new Product(id, name, isBought);
    }
}