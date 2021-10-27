﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8.Es1.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Fetch(Func<T, bool> filter = null);
        T GetById(int id);
        bool AddItem(T item);
        bool UpdateItem(T updatedItem);
        bool DeleteItemById(int id);
     }
            
}
