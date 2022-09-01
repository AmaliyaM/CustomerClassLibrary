using System.Collections.Generic;

namespace CustomerLibrary.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);

        TEntity Read(int EntityCode);

        void Update(TEntity entity);

        bool Delete(int entityCode);
        List<TEntity> GetAll();
    }
}
