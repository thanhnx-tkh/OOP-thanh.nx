using System;

public class Product
{
    private int id;
    private string name;
    private int categoryId;

    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }

    public Product()
    {
    }

    public Product(int id, string name, int categoryId)
    {
        this.id = id;
        this.name = name;
        this.categoryId = categoryId;
    }
    
}

