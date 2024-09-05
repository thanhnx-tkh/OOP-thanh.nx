using System;

public class Product : Base
{
    public int CategoryId { get; set; }

    public Product()
    {
    }

    public Product(int id, string name, int categoryId)
    {
        this.Id = id;
        this.Name = name;
        this.CategoryId = categoryId;
    }
    
}

