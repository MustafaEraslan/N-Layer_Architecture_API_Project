using System.Linq.Expressions;


namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id); //bir asenkron methodumuz olsun.

        //productRepositoy.where(x=>x.id>5).ToListAsync yapmızda db ye yazıcak.
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
        IQueryable<T> Where(Expression<Func<T,bool>> expression); //queryable döndüğümüzde yazmış olduğumuz sorgular direkt veritabanına gitmez.
                                                                  //Memoryde tutulur. Birleştirilir
                                                                  //tolist async çağırırsak o zamna gider.
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);


    }
}