using System;

public class Product : BaseRow
{
    public int CategoryId { get; set; }

    public Product()
    {
    }
    /// <summary>
    /// Function initialize class 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="categoryId"></param>
    public Product(int id, string name, int categoryId)
    {
        this.Id = id;
        this.Name = name;
        this.CategoryId = categoryId;
    }
    
}

