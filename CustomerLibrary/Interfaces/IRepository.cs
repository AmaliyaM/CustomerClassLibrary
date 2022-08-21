namespace CustomerLibrary.Interfaces
{
    internal interface IRepository<TEntity>
    {
        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);


    }
}
