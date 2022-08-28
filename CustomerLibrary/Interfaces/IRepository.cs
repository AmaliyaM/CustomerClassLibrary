using System.Collections.Generic;

namespace CustomerLibrary.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);

        TEntity Read(string EntityCode);

        void Update(TEntity entity);

        bool Delete(TEntity entity);
        List<TEntity> GetAll();
    }
}
