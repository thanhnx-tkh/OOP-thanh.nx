using System;
using System.Collections.Generic;

public abstract class BaseDao<T>
{
    public abstract void Insert(T row);

    public abstract void Update(T row);


    public abstract bool Delete(T row);


    public abstract List<BaseRow> FindAll();


    public abstract T FindById(int id);

}

