

using System.Linq.Expressions;
using BarberShop.Result;

namespace BarberShop.Repository
{
    public interface IRepository<TEntities> where TEntities : class 
    { 

        Task<ResponseResult> add(TEntities entity); 
        Task<ResponseResult> update(TEntities entity);
        Task<ResponseResult> delete(TEntities entity);
        Task<ResponseResult> GetById(int id);
        Task<ResponseResult> GetAll(); 
        Task<bool> exist(Expression<Func<TEntities, bool>> predicate);

    }
}
