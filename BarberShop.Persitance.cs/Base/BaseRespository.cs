

using System.Linq.Expressions;
using BarberShop.Persitance.cs.Context;
using BarberShop.Repository;
using BarberShop.Result;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Persitance.cs.Base
{
    public abstract class BaseRespository<TEntities> 
                     : IRepository<TEntities> where TEntities : class
    { 

        private readonly MyContext _context;
        private readonly DbSet<TEntities> _entities;

        public BaseRespository(MyContext _mycontext)
        { 
            _context = _mycontext;
            _entities = _context.Set<TEntities>();  

        }

        public virtual async Task<ResponseResult> add(TEntities entity)
        {   

            ResponseResult result = new ResponseResult();
            try
            {
                _entities.Add(entity);
                await _context.SaveChangesAsync(); // confirmo que se guardo dentro de mu base de datos


            }
            catch (Exception ex)
            {
                 result.success = false;
                 result.message = $"Erro try to saving the entitie {ex.Message} ";

            }


            return result; 

        }

        public virtual async Task<ResponseResult> delete(TEntities entity)
        {  

            ResponseResult result = new ResponseResult();

            try
            {
                _entities.Remove(entity);  
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.success = false; 
                result.message = $"Erro try to remove the entitie {ex.Message}";   

            }

            return result; 

        }

        public virtual async Task<bool> exist(Expression<Func<TEntities, bool>> predicate)
        {
            
            return await this._entities.AnyAsync(predicate);

 
        }

        public virtual async Task<ResponseResult> GetAll()
        {   
            ResponseResult result = new ResponseResult();

            try
            {
                  var datos = await _entities.ToListAsync();
                  result.data  = datos;
                  result.message = "list of the entities! ";

                 
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = $"error type try to list the entities {ex.Message}"; 

            }


            return result; 

        }

        public virtual async Task<ResponseResult> GetById(int id)
        {
            ResponseResult result = new ResponseResult(); 

            try
            {
              
                var datos = await _entities.FindAsync(id);
                result.data = datos;
                result.message = "Entitie found succefully!";



            } catch (Exception ex)
            {
                result.success = false; 
                result.message = $"Error type {ex.Message}";    

            }

            return result; 
        }

        public virtual async Task<ResponseResult> update(TEntities entity)
        {
            ResponseResult result = new ResponseResult();


            try
            {
                 _entities.Update(entity);
                  await _context.SaveChangesAsync();
                  result.message = "Entities has been updated succefully! ";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = $"Error type {ex.Message}";
            }

            return result; 

        }
    }
}
