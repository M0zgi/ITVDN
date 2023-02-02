﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(T entity);
        Task<List<T>> Select();
        Task<T> GetById(Guid id);
        Task<T> GetByName(string name);
    }
}
