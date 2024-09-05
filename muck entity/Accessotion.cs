using System;

public class Accessotion
{
    private int id;
    private string name;

    public int Id { get; set; }
    public string Name { get; set; }

    public Accessotion()
    {
    }

    public Accessotion(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}

