using System;
using System.Collections.Generic;

public class ProductDAO : BaseDao<Product> , IDao<Product>
{
    private Database db;

    public ProductDAO()
    {
        db = Database.Instance;
    }

    public override void Insert(Product row)
    {
        db.InsertTable(Entity.product, row);
    }

    public override void Update(Product row)
    {
        db.UpdateTable(Entity.product, row);
    }

    public override bool Delete(Product row)
    {
        return db.DeleteTable(Entity.product, row);
    }

    public override List<BaseRow> FindAll()
    {
        return db.SelectTable(Entity.product);
    }

    public override Product FindById(int id)
    {
        List<Product> products = FindAll().ConvertAll(obj => (Product)obj);
        foreach (Product product in products)
        {
            if (product.Id == id)
            {
                return product;
            }
        }
        return null;
    }
    public Product FindByName(string name)
    {
        List<Product> products = FindAll().ConvertAll(obj => (Product)obj);
        foreach (Product product in products)
        {
            if (String.Compare(product.Name.ToLower(), name.ToLower(), true) == 0)
            {
                return product;
            }   
        }
        return null;
    }
    public List<BaseRow> Search(string name)
    {
        List<Product> products = FindAll().ConvertAll(obj => (Product)obj);
        List<BaseRow> productsSearch = new List<BaseRow>();

        foreach (Product product in products)
        {
            if (IsSubstring(product.Name.ToLower(), name.ToLower()))
            {
                productsSearch.Add(product);
            }
        }
        return productsSearch;
    }

    private bool IsSubstring(string mainString, string subString)
    {
        return mainString.Contains(subString);
    }
}

