using System;
using System.Collections.Generic;

public class CategoryDAO : BaseDao<Category>
{
    private Database db;

    public CategoryDAO()
    {
        db = Database.Instance;
    }
    /// <summary>
    /// Inserts a new Category record into the 'category' table.
    /// </summary>
    /// <param name="row">The Category object to be inserted.</param>
    public override void Insert(Category row)
    {
        db.InsertTable(Entity.category, row);
    }

    /// <summary>
    /// Updates an existing Category record in the 'category' table.
    /// </summary>
    /// <param name="row">The Category object with updated data.</param>
    public override void Update(Category row)
    {
        db.UpdateTable(Entity.category, row);
    }

    /// <summary>
    /// Deletes a Category record from the 'category' table.
    /// </summary>
    /// <param name="row">The Category object to be deleted.</param>
    /// <returns>True if the deletion was successful, otherwise false.</returns>
    public override bool Delete(Category row)
    {
        return db.DeleteTable(Entity.category, row);
    }

    /// <summary>
    /// Retrieves all Category records from the 'category' table.
    /// </summary>
    /// <returns>A list of BaseRow objects representing all rows in the 'category' table.</returns>
    public override List<BaseRow> FindAll()
    {
        return db.SelectTable(Entity.category);
    }

    /// <summary>
    /// Finds a Category object by its ID.
    /// </summary>
    /// <param name="id">The ID of the Category to find.</param>
    /// <returns>The Category object if found, otherwise null.</returns>
    public override Category FindById(int id)
    {
        List<Category> categories = FindAll().ConvertAll(obj => (Category)obj);
        foreach (Category category in categories)
        {
            if (category.Id == id)
            {
                return category;
            }
        }
        return null;
    }
}

