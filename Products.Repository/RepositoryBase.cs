using Entities;
using Microsoft.EntityFrameworkCore;
using Products.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Products.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ProductsContext ProductsContext { get; set; }

        public RepositoryBase(ProductsContext productsContext)
        {
            ProductsContext = productsContext;
        }

        public void Create(T entity) => ProductsContext.Set<T>().Add(entity);

        public void Delete(T entity) => ProductsContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
            ProductsContext.Set<T>()
            .AsNoTracking() :
            ProductsContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            ProductsContext.Set<T>()
            .Where(expression)
            .AsNoTracking() :
            ProductsContext.Set<T>()
            .Where(expression);
    }
}
