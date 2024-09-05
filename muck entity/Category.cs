using System;

public class Category
{
    private int id;
    private string name;

    public int Id { get; set; }
    public string Name { get; set; }

    public Category()
    {
    }
    public Category(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}

