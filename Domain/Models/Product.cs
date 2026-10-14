namespace Domain.Models;

public class Product
{
    public const int MaxNameLength = 20;

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

    public static (Product? product, string error) Create(int id, string name, bool isBought = false)
    {
        if (string.IsNullOrEmpty(name) || name.Length > MaxNameLength)
            return (null, "Name cannot be empty or exceed 20 characters");

        return (new Product(id, name, isBought), string.Empty);
    }
}