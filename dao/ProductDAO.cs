using System;
using System.Collections.Generic;

public class ProductDAO : BaseDao<Product> , IDao<Product>
{
    private Database db;

    public ProductDAO()
    {
        db = Database.Instance;
    }

    /// <summary>
    /// Inserts a new Product record into the 'product' table.
    /// </summary>
    /// <param name="row">The Product object to be inserted.</param>
    public override void Insert(Product row)
    {
        db.InsertTable(Entity.product, row);
    }

    /// <summary>
    /// Updates an existing Product record in the 'product' table.
    /// </summary>
    /// <param name="row">The Product object with updated data.</param>
    public override void Update(Product row)
    {
        db.UpdateTable(Entity.product, row);
    }

    /// <summary>
    /// Deletes a Product record from the 'product' table.
    /// </summary>
    /// <param name="row">The Product object to be deleted.</param>
    /// <returns>True if the deletion was successful, otherwise false.</returns>
    public override bool Delete(Product row)
    {
        return db.DeleteTable(Entity.product, row);
    }

    /// <summary>
    /// Retrieves all Product records from the 'product' table.
    /// </summary>
    /// <returns>A list of BaseRow objects representing all rows in the 'product' table.</returns>
    public override List<BaseRow> FindAll()
    {
        return db.SelectTable(Entity.product);
    }

    /// <summary>
    /// Finds a Product object by its ID.
    /// </summary>
    /// <param name="id">The ID of the Product to find.</param>
    /// <returns>The Product object if found, otherwise null.</returns>
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

    /// <summary>
    /// Finds a Product object by its name (case-insensitive).
    /// </summary>
    /// <param name="name">The name of the Product to find.</param>
    /// <returns>The Product object if found, otherwise null.</returns>
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

    /// <summary>
    /// Searches for Product objects whose name contains the specified substring (case-insensitive).
    /// </summary>
    /// <param name="name">The substring to search for in product names.</param>
    /// <returns>A list of BaseRow objects matching the search criteria.</returns>
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

    /// <summary>
    /// Checks if one string is a substring of another string.
    /// </summary>
    /// <param name="mainString">The main string to search within.</param>
    /// <param name="subString">The substring to search for.</param>
    /// <returns>True if subString is found within mainString, otherwise false.</returns>
    private bool IsSubstring(string mainString, string subString)
    {
        return mainString.Contains(subString);
    }
}

