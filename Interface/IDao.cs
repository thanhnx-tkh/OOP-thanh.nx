using System;
using System.Collections.Generic;

public interface IDao<T>
{
    T FindByName(string name);
    List<BaseRow> Search(string name);
}

