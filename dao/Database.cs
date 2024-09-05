using System;
using System.Collections.Generic;

public enum Entity
{
    product,
    category,
    accessotion
}

public class Database
{
    public List<Product> ProductTable { get; set; } = new List<Product>();
    public List<Category> CategoryTable { get; set; } = new List<Category>();
    public List<Accessotion> AccessotionTable { get; set; } = new List<Accessotion>();

    private static Database instance;

    private Database() { }

    public static Database Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Database();
            }
            return instance;
        }
    }

    public void InsertTable(Entity name, Base row)
    {
        switch (name)
        {
            case Entity.product:
                ProductTable.Add((Product)row);
                break;
            case Entity.category:
                CategoryTable.Add((Category)row);
                break;
            case Entity.accessotion:
                AccessotionTable.Add((Accessotion)row);
                break;
            default:
                throw new ArgumentException("Tên bảng ko đúng");
        }
    }

    public List<object> SelectTable(Entity name)
    {
        List<object> listObj = new List<object>();
        switch (name)
        {
            case Entity.product:
                listObj.AddRange(ProductTable);
                break;
            case Entity.category:
                listObj.AddRange(CategoryTable);
                break;
            case Entity.accessotion:
                listObj.AddRange(AccessotionTable);
                break;
            default:
                throw new ArgumentException("Tên bảng ko đúng");
        }
        return listObj;
    }

    public void UpdateTable(Entity name, Base row)
    {
        switch (name)
        {
            case Entity.product:
                Product product = (Product)row;
                for (int i = 0; i < ProductTable.Count; i++)
                {
                    if (ProductTable[i].Id == product.Id)
                    {
                        ProductTable[i] = product;
                        return;
                    }
                }
                throw new ArgumentException("Product ko tồn tại");

            case Entity.category:
                Category category = (Category)row;
                for (int i = 0; i < CategoryTable.Count; i++)
                {
                    if (CategoryTable[i].Id == category.Id)
                    {
                        CategoryTable[i] = category;
                        return;
                    }
                }
                throw new ArgumentException("Category ko tồn tại");

            case Entity.accessotion:
                Accessotion accessotion = (Accessotion)row;
                for (int i = 0; i < AccessotionTable.Count; i++)
                {
                    if (AccessotionTable[i].Id == accessotion.Id)
                    {
                        AccessotionTable[i] = accessotion;
                        return;
                    }
                }
                throw new ArgumentException("Accessotion ko tồn tại");

            default:
                throw new ArgumentException("Tên bảng ko đúng");
        }
    }

    public bool DeleteTable(Entity name, Base row)
    {
        switch (name)
        {
            case Entity.product:
                Product product = (Product)row;
                for (int i = ProductTable.Count - 1; i >= 0; i--)
                {
                    if (ProductTable[i].Id == product.Id)
                    {
                        ProductTable.RemoveAt(i);
                        return true;
                    }
                }
                return false;

            case Entity.category:
                Category category = (Category)row;
                for (int i = CategoryTable.Count - 1; i >= 0; i--)
                {
                    if (CategoryTable[i].Id == category.Id)
                    {
                        CategoryTable.RemoveAt(i);
                        return true;
                    }
                }
                return false;

            case Entity.accessotion:
                Accessotion accessotion = (Accessotion)row;
                for (int i = AccessotionTable.Count - 1; i >= 0; i--)
                {
                    if (AccessotionTable[i].Id == accessotion.Id)
                    {
                        AccessotionTable.RemoveAt(i);
                        return true;
                    }
                }
                return false;

            default:
                return false;
        }
    }

    public void TruncateTable(Entity name)
    {
        switch (name)
        {
            case Entity.product:
                ProductTable.Clear();
                break;
            case Entity.category:
                CategoryTable.Clear();
                break;
            case Entity.accessotion:
                AccessotionTable.Clear();
                break;
            default:
                throw new ArgumentException("Tên bảng ko đúng");
        }
    }

    public void UpdateTableById(int id, Base row)
    {
        if (row is Product)
        {
            Product product = (Product)row;
            for (int i = 0; i < ProductTable.Count; i++)
            {
                if (ProductTable[i].Id == id)
                {
                    ProductTable[i] = product;
                    return;
                }
            }
            throw new ArgumentException("Product ko tồn tại");
        }
        else if (row is Category)
        {
            Category category = (Category)row;
            for (int i = 0; i < CategoryTable.Count; i++)
            {
                if (CategoryTable[i].Id == id)
                {
                    CategoryTable[i] = category;
                    return;
                }
            }
            throw new ArgumentException("Category ko tồn tại");
        }
        else if (row is Accessotion)
        {
            Accessotion accessotion = (Accessotion)row;
            for (int i = 0; i < AccessotionTable.Count; i++)
            {
                if (AccessotionTable[i].Id == id)
                {
                    AccessotionTable[i] = accessotion;
                    return;
                }
            }
            throw new ArgumentException("Accessotion ko tồn tại");
        }
        else
        {
            throw new ArgumentException("Bảng ko tồn tại");
        }
    }

    public void initDatabase()
    {
        for (int i = 1; i <= 10; i++)
        {
            InsertTable(Entity.product, new Product(i, $"Product {i}", i));
            InsertTable(Entity.category, new Category(i, $"Category {i}"));
            InsertTable(Entity.accessotion, new Accessotion(i, $"Accessotion {i}"));
        }
    }
}