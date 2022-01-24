﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MVC.Repository
{
    public interface IEmployeeRepository<T>
    {
        IEnumerable<T> GetAll();
        T FindFirstByCondition(Guid id);
        void Add(T entity);
        T Update(T entity);
        void Delete(Guid id);
        IEnumerable<T> GetByCompetitionId(Guid id);
    }
}
