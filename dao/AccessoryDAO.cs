using System;
using System.Collections.Generic; 

public class AccessoryDAO : BaseDao<Accessotion>, IDao<Accessotion>
{
    private Database db;

    public AccessoryDAO()
    {
        db = Database.Instance;
    }

    public override void Insert(Accessotion row)
    {
        db.InsertTable(Entity.accessotion, row);
    }

    public override void Update(Accessotion row)
    {
        db.UpdateTable(Entity.accessotion, row);
    }

    public override bool Delete(Accessotion row)
    {
        return db.DeleteTable(Entity.accessotion, row);
    }

    public override List<BaseRow> FindAll()
    {
        return db.SelectTable(Entity.accessotion);
    }

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

    private bool IsSubstring(string mainString, string subString)
    {
        return mainString.Contains(subString);
    }
}
