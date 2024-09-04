﻿using System;

public class Product
{
    private int id;
    private string name;
    private int categoryId;

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public int CategoryId { get => categoryId; set => categoryId = value; }

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

