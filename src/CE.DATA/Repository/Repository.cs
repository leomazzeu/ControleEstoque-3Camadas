using CE.BUSINESS.Interfaces;
using CE.BUSINESS.Models;
using CE.DATA.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.DATA.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly CEDbContext _context;
        protected readonly DbSet<TEntity> dbSet;

        public Repository(CEDbContext context)
        {
            _context = context;
            dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task Adicionar(TEntity obj)
        {
            dbSet.AddAsync(obj);
            await SaveChanges();

        }

        public virtual async Task Atualizar(TEntity obj)
        {
            dbSet.Update(obj);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            dbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
