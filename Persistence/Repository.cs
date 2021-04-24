using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace mnd.Logic.Persistence
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        protected readonly PandapContext _dc;

        public RepositoryAsync(PandapContext context)
        {
            _dc = context;
        }

        public async Task<TEntity> GetirByIdAsync(int id)
        {
            return await _dc.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetirByKodAsync(string kod)
        {
            return await _dc.Set<TEntity>().FindAsync(kod);
        }

        public async Task<IEnumerable<TEntity>> TumunuGetirAsync()
        {
            return await _dc.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> BulAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dc.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> TekVeyaVarsayilanAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dc.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public async void EkleAsync(TEntity entity)
        {
            await _dc.Set<TEntity>().AddAsync(entity);
        }

        public async void AralikEkleAsync(IEnumerable<TEntity> entities)
        {
            await _dc.Set<TEntity>().AddRangeAsync(entities);
        }

        public void AralikSil(IEnumerable<TEntity> entities)
        {
            _dc.Set<TEntity>().RemoveRange(entities);
        }

        public void Sil(TEntity entity)
        {
            _dc.Set<TEntity>().Remove(entity);
        }
    }
}