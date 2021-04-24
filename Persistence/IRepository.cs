using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace mnd.Logic.Persistence
{
    public interface IRepositoryAsync<TEntity> where TEntity : class
    {
        Task<TEntity> GetirByIdAsync(int id);

        Task<TEntity> GetirByKodAsync(string id);

        Task<IEnumerable<TEntity>> TumunuGetirAsync();

        Task<IEnumerable<TEntity>> BulAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> TekVeyaVarsayilanAsync(Expression<Func<TEntity, bool>> predicate);

        void EkleAsync(TEntity entity);

        void AralikEkleAsync(IEnumerable<TEntity> entities);

        void Sil(TEntity entity);

        void AralikSil(IEnumerable<TEntity> entities);
    }
}