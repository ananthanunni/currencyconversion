using CurrencyConversion.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurrencyConversion.Data.Repository
{
    public interface IRepository<TModel>
    where TModel : class,IEntity
    {
        IQueryable<TModel> Query();

        Task<TModel> FindAsync(long id);

        IQueryable<TModel> Get(Expression<Func<TModel, bool>> predicate=null);

        void Update(TModel item);
        void Create(TModel item);

        void Delete(long id);

        Task<int> SaveChangesAsync();
    }
}
