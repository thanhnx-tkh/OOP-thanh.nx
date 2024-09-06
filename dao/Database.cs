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
    private static readonly object padlock = new object();

    private Database() { }

    public static Database Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }
        }
    }

    /// <summary>
    /// Insert new BaseRow record into corresponding table
    /// </summary>
    /// <param name="name">Data type to be Insert</param>
    /// <param name="row">The BaseRow object to be Insert</param>
    public void InsertTable(Entity name, BaseRow row)
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

    /// <summary>
    /// Select BaseRow list according date type
    /// </summary>
    /// <param name="name">Data type to be Select</param>
    /// <returns>BaseRow list</returns>
    public List<BaseRow> SelectTable(Entity name)
    {
        List<BaseRow> listObj = new List<BaseRow>();
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

    /// <summary>
    /// Updates an existing BaseRow record in the  table.
    /// </summary>
    /// <param name="name">Data type to be update</param>
    /// <param name="row">The BaseRow object to be update</param>
    public void UpdateTable(Entity name, BaseRow row)
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
    /// <summary>
    /// Delete an existing BaseRow record in the  table.
    /// </summary>
    /// <param name="name">Data type to be delete</param>
    /// <param name="row">The BaseRow object to be delete</param>
    /// <returns></returns>
    public bool DeleteTable(Entity name, BaseRow row)
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
    /// <summary>
    /// Delete all data in the table 
    /// </summary>
    /// <param name="name">data type to be delete</param>
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
    /// <summary>
    /// Update a exsing BaseRow record in the table by id 
    /// </summary>
    /// <param name="id">BaseRow id to update</param>
    /// <param name="row">The BaseRow object to update</param>
    public void UpdateTableById(int id, BaseRow row)
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
    /// <summary>
    /// Init data in the all table
    /// </summary>
    public void InitDatabase()
    {
        for (int i = 1; i <= 10; i++)
        {
            InsertTable(Entity.product, new Product(i, $"Product {i}", i));
            InsertTable(Entity.category, new Category(i, $"Category {i}"));
            InsertTable(Entity.accessotion, new Accessotion(i, $"Accessotion {i}"));
        }
    }
}