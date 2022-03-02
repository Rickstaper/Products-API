using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Products.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
            bool trackChanges);
        void Create(T entity);
        void Delete(T entity);

        public IQueryable<T> FindByStoredProcedure(string storedProcedure, bool trackChanges);
    }
}
