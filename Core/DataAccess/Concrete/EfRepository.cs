using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()

    {
        private readonly DbContext _context;
        protected DbSet<TEntity> _entity;
        public EfRepository(DbContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _entity.Add(entity);
            _context.SaveChanges();
        }
        public List<TEntity> GetAllAsNoTracking(Expression<Func<TEntity, bool>> filter = null) => filter == null ? _entity.AsNoTracking().ToList() : _entity.Where(filter).AsNoTracking().ToList();

        public void Delete(TEntity entity)
        {
            _entity.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(TEntity entity) {
            _entity.Update(entity); 
            _context.SaveChanges();
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> filter) => _entity.SingleOrDefault(filter);

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null) => filter == null ? _entity.ToList() : _entity.Where(filter).ToList();



    }
}
