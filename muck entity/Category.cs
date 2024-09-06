using System;

public class Category: BaseRow
{
    public Category()
    {
    }
    /// <summary>
    /// Function initialize class 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    public Category(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }
}

