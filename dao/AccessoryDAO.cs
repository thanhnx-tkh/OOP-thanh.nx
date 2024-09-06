using System;
using System.Collections.Generic; 

public class AccessoryDAO : BaseDao<Accessotion>, IDao<Accessotion>
{
    private Database db;

    public AccessoryDAO()
    {
        db = Database.Instance;
    }
    /// <summary>
    /// Inserts a new row into the 'accessotion' table.
    /// </summary>
    /// <param name="row">The Accessotion object to insert.</param>
    public override void Insert(Accessotion row)
    {
        db.InsertTable(Entity.accessotion, row);
    }

    /// <summary>
    /// Updates an existing row in the 'accessotion' table.
    /// </summary>
    /// <param name="row">The Accessotion object with updated data.</param>
    public override void Update(Accessotion row)
    {
        db.UpdateTable(Entity.accessotion, row);
    }

    /// <summary>
    /// Deletes a row from the 'accessotion' table.
    /// </summary>
    /// <param name="row">The Accessotion object to delete.</param>
    /// <returns>True if deletion was successful, otherwise false.</returns>
    public override bool Delete(Accessotion row)
    {
        return db.DeleteTable(Entity.accessotion, row);
    }

    /// <summary>
    /// Retrieves all rows from the 'accessotion' table.
    /// </summary>
    /// <returns>A list of BaseRow objects representing all rows in the table.</returns>
    public override List<BaseRow> FindAll()
    {
        return db.SelectTable(Entity.accessotion);
    }

    /// <summary>
    /// Finds an Accessotion object by its ID.
    /// </summary>
    /// <param name="id">The ID of the Accessotion to find.</param>
    /// <returns>The Accessotion object if found, otherwise null.</returns>
    public override Accessotion FindById(int id)
    {
        List<Accessotion> accessotions = FindAll().ConvertAll(obj => (Accessotion)obj);
        foreach (Accessotion accessotion in accessotions)
        {
            if (accessotion.Id == id)
            {
                return accessotion;
            }
        }
        return null;
    }

    /// <summary>
    /// Finds an Accessotion object by its name (case-insensitive).
    /// </summary>
    /// <param name="name">The name of the Accessotion to find.</param>
    /// <returns>The Accessotion object if found, otherwise null.</returns>
    public Accessotion FindByName(string name)
    {
        List<Accessotion> accessotions = FindAll().ConvertAll(obj => (Accessotion)obj);
        foreach (Accessotion accessotion in accessotions)
        {
            if (String.Compare(accessotion.Name.ToLower(), name.ToLower(), true) == 0)
            {
                return accessotion;
            }
        }
        return null;
    }

    /// <summary>
    /// Searches for Accessotion objects whose name contains the specified substring (case-insensitive).
    /// </summary>
    /// <param name="name">The substring to search for in names.</param>
    /// <returns>A list of BaseRow objects matching the search criteria.</returns>
    public List<BaseRow> Search(string name)
    {
        List<Accessotion> accessotions = FindAll().ConvertAll(obj => (Accessotion)obj);
        List<BaseRow> accessotionsSearch = new List<BaseRow>();

        foreach (Accessotion accessotion in accessotions)
        {
            if (IsSubstring(accessotion.Name.ToLower(), name.ToLower()))
            {
                accessotionsSearch.Add(accessotion);
            }
        }
        return accessotionsSearch;
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
