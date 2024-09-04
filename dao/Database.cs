using System;
using System.Collections.Generic;

public class Database
{
    private List<Product> productTable = new List<Product>();
    private List<Category> categoryTable = new List<Category>();
    private List<Accessotion> accessotionTable = new List<Accessotion>();
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

    public void InsertTable(string name, object row)
    {
        switch (name)
        {
            case "product":
                productTable.Add(row as Product);
                break;
            case "category":
                categoryTable.Add(row as Category);
                break;
            case "accessotion":
                accessotionTable.Add(row as Accessotion);
                break;
            default:
                throw new ArgumentException("Tên bảng ko đúng");
        }
    }
    public List<object> SelectTable(string name)
    {
        List<object> listObj = new List<object>();
        switch (name)
        {
            case "product":
                foreach (var item in productTable)
                {
                    listObj.Add(item);
                }
                break;
            case "category":
                foreach (var item in categoryTable)
                {
                    listObj.Add(item);
                }
                break;
            case "accessotion":
                foreach (var item in accessotionTable)
                {
                    listObj.Add(item);
                }
                break;
            default:
                throw new ArgumentException("Tên bảng ko đúng");
        }
        return listObj;
    }

    public void UpdateTable(string name, object row)
    {
        switch (name)
        {
            case "product":
                Product product = row as Product;
                for (int i = 0; i < productTable.Count; i++)
                {
                    if (productTable[i].Id == product.Id)
                    {
                        productTable[i] = product;
                        return;
                    }
                }
                throw new ArgumentException("Product ko tồn tại");

            case "category":
                Category category = row as Category;
                for (int i = 0; i < categoryTable.Count; i++)
                {
                    if (categoryTable[i].Id == category.Id)
                    {
                        categoryTable[i] = category;
                        return;
                    }
                }
                throw new ArgumentException("Category ko tồn tại");

            case "accessotion":
                Accessotion accessotion = row as Accessotion;
                for (int i = 0; i < accessotionTable.Count; i++)
                {
                    if (accessotionTable[i].Id == accessotion.Id)
                    {
                        accessotionTable[i] = accessotion;
                        return;
                    }
                }
                throw new ArgumentException("Accessotion ko tồn tại");

            default:
                throw new ArgumentException("Tên bảng ko đúng");
        }
    }

    public void DeleteTable(string name, object row)
    {
        switch (name)
        {
            case "product":
                Product product = row as Product;
                for (int i = productTable.Count - 1; i >= 0; i--)
                {
                    if (productTable[i].Id == product.Id)
                    {
                        productTable.RemoveAt(i);
                        return;
                    }
                }
                throw new ArgumentException("Product ko tồn tại");

            case "category":
                Category category = row as Category;
                for (int i = categoryTable.Count - 1; i >= 0; i--)
                {
                    if (categoryTable[i].Id == category.Id)
                    {
                        categoryTable.RemoveAt(i);
                        return;
                    }
                }
                throw new ArgumentException("Category ko tồn tại");

            case "accessotion":
                Accessotion accessotion = row as Accessotion;
                for (int i = accessotionTable.Count - 1; i >= 0; i--)
                {
                    if (accessotionTable[i].Id == accessotion.Id)
                    {
                        accessotionTable.RemoveAt(i);
                        return;
                    }
                }
                throw new ArgumentException("Accessotion ko tồn tại");

            default:
                throw new ArgumentException("Tên bảng ko đúng");
        }
    }

    public void TruncateTable(string name)
    {
        switch (name)
        {
            case "product":
                productTable.Clear();
                break;
            case "category":
                categoryTable.Clear();
                break;
            case "accessotion":
                accessotionTable.Clear();   
                break;
            default:
                throw new ArgumentException("Tên bảng ko đúng");
        }
    }
}