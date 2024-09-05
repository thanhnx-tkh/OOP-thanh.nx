using System;
using System.Collections.Generic;

public class CategoryDAO : BaseDao<Category>
{
    private Database db;

    public CategoryDAO()
    {
        db = Database.Instance;
    }

    public override void Insert(Category row)
    {
        db.InsertTable(Entity.category, row);
    }

    public override void Update(Category row)
    {
        db.UpdateTable(Entity.category, row);
    }

    public override bool Delete(Category row)
    {
        return db.DeleteTable(Entity.category, row);
    }

    public override List<BaseRow> FindAll()
    {
        return db.SelectTable(Entity.category);
    }

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

