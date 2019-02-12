using CurrencyConversion.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurrencyConversion.Data.Repository
{
    public abstract class GenericRepositoryBase<TModel> : IRepository<TModel>
        where TModel : class, IEntity
    {
        private CurrencyDbContext _dbContext;

        private DbSet<TModel> _dbSet => _dbContext.Set<TModel>();

        public GenericRepositoryBase(CurrencyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TModel> Query() => _dbSet.AsQueryable();

        public Task<TModel> FindAsync(long id) => _dbSet.FindAsync(id);

        public void Create(TModel item) => _dbSet.Add(item);

        public void Delete(long id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public IQueryable<TModel> Get(Expression<Func<TModel, bool>> predicate=null) => predicate != null ? _dbSet.Where(predicate) : _dbSet.AsQueryable();

        public Task<int> SaveChangesAsync() => _dbContext.SaveChangesAsync();

        public void Update(TModel item)
        {
            var entity = _dbSet.Find(item.Id);
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
