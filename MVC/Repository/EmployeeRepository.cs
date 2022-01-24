using Db.SQL;
using System;
using System.Collections.Generic;

namespace MVC.Repository
{
    class EmployeeRepository<T> /*: IEmployeeRepository<T> where T : class*/
    {
        //TODO: context DB
        protected MssqlDbContext _context { get; set; }
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public T FindFirstByCondition(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetByCompetitionId(Guid id)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
