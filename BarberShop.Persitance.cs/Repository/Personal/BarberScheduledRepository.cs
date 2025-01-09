
using BarberShop.Entities.Personal;
using BarberShop.Persitance.cs.Base;
using BarberShop.Persitance.cs.Context;
using BarberShop.Persitance.cs.Interfaces.Personal;
using BarberShop.Persitance.cs.Models.Personal;
using BarberShop.Result;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace BarberShop.Persitance.cs.Repository.Personal
{
    public class BarberScheduledRepository : BaseRespository<BarberScheduled>, IBarberShoped
    {

        private readonly MyContext _mycontext; 
        private readonly ILogger<BarberScheduledRepository> _logger;    
        public BarberScheduledRepository(MyContext _mycontext,
                                         ILogger<BarberScheduledRepository> _logger) : base(_mycontext)
        {
            _mycontext = _mycontext;
            this._logger = _logger; 

        }

        // acciones para base de datos 

        public async override Task<ResponseResult> add(BarberScheduled entity)
        {
            ResponseResult result = new ResponseResult();

            // validaciones

            if (entity.ScheduleID <= 0 && entity.BarberID <= 0)
            {
                result.success = false;
                result.message = "you cannot put id that is 0!";
                return result; 

            } 

            if(entity.DayOfWeek.IsNullOrEmpty())
            {
                result.success = false;
                result.message = "you cannot leave field empty!";
                return result; 

            }
           
         
            try
            {

                var datos = await base.add(entity);
                result.data = datos;
                result.message = "The schedule has been registered successfully!";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ($"Error type {ex.Message} trying to add the barber Sheduled ");
               _logger.LogError($"Error type {result.message}");

            }

            return result; 

        }


        public async override Task<ResponseResult> delete(BarberScheduled entity)
        {
            ResponseResult result = new ResponseResult();

            if (entity.ScheduleID <= 0 && entity.BarberID <= 0)
            {
                result.success = false;
                result.message = "you cannot put id that is 0!";
                return result;

            }

            if (entity.DayOfWeek.IsNullOrEmpty())
            {
                result.success = false;
                result.message = "you cannot leave field empty!";
                return result;

            } 


            try
            {  

                BarberScheduled? respuesta = await _mycontext.barberScheduleds.FindAsync(entity.ScheduleID);
                if(respuesta == null)
                {
                    result.success = false;
                    result.message = "The Barber scheduled has not been found it on the system ";
                    return result;
                } 


                var datos = await base.delete(respuesta);
                result.data = datos.data;
                result.message = "The Barber schedule has been removed successfully!";

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ($"Error type {ex.Message} trying to removed the barber Sheduled ");
               _logger.LogError($"Error type {result.message}");
            }

            return result; 

        }


        public async override Task<ResponseResult> GetAll()
        {
            ResponseResult result = new ResponseResult();

            try
            {
                var datos = await (from s in _mycontext.barberScheduleds 
                                  join a in _mycontext.barber on s.BarberID equals a.BarberID
                                  orderby s.CreateAt descending
                                  select new BarberScheduled()
                                  {
                                      BarberID = s.BarberID,
                                      ScheduleID = s.ScheduleID,
                                      DayOfWeek = s.DayOfWeek,
                                      CreateAt = s.CreateAt,
                                      EndTime = s.EndTime,
                                      StartTime = s.StartTime,

                                  }).AsNoTracking()
                                  .ToListAsync();

                result.data = datos;
                result.message = "All of the Schulded  has been list!";
                                  
                                
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ($"Error type {ex.Message} trying to list all of the barber Sheduled ");
               _logger.LogError($"Error type {result.message}");

            }
            return result; 

        }

        public async override Task<ResponseResult> GetById(int id)
        {
            ResponseResult result = new ResponseResult();

            if(id <= 0)
            {
                result.success = false;
                result.message = "you cannot put id on 0! ";
                return result; 
            } 


            try
            {


                var consult = await (from a in _mycontext.barberScheduleds
                                     join s in _mycontext.barber on a.BarberID equals s.BarberID
                                     where a.ScheduleID == id
                                     orderby a.CreateAt descending
                                     select new BarberScheduled()
                                     {

                                         ScheduleID = id,
                                         CreateAt = a.CreateAt,
                                         EndTime = a.EndTime,
                                         StartTime = a.StartTime,
                                         DayOfWeek = a.DayOfWeek,
                                         BarberID = a.BarberID

                                     }).AsNoTracking()
                                     .ToListAsync();


                result.data = consult;
                result.message = "Schulded has been found it succefully! ";
                                          
                
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ($"Error type {ex.Message} trying to list all of the barber Sheduled ");
               _logger.LogError($"Error type {result.message}");

            }
            return result;

        }

        public async override Task<ResponseResult> update(BarberScheduled entity)
        {
            ResponseResult result = new ResponseResult();

            if (entity.ScheduleID <= 0 && entity.BarberID <= 0)
            {
                result.success = false;
                result.message = "you cannot put id that is 0!";
                return result;

            }

            if (entity.DayOfWeek.IsNullOrEmpty())
            {
                result.success = false;
                result.message = "you cannot leave field empty!";
                return result;
            }

            try
            {
               BarberScheduled? barberconsult = await _mycontext.barberScheduleds.FindAsync(entity.ScheduleID);

                if (barberconsult == null)
                {
                    result.success=false;
                    result.message = "this Schulded to updated has not been found it on the system!";
                    return result;
                } 

                 barberconsult.BarberID = entity.BarberID;
                 barberconsult.ScheduleID = entity.ScheduleID;
                 barberconsult.StartTime = entity.StartTime;
                 barberconsult.DayOfWeek = entity.DayOfWeek;
                 barberconsult.CreateAt = entity.CreateAt;
                 barberconsult.EndTime = entity.EndTime;

                var response = await base.update(barberconsult); 
                result.data = response.data;
                result.message = "Sheduled has been updated succefully!";

             

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ($"Error type {ex.Message} trying to list all of the barber Sheduled ");
                _logger.LogError($"Error type {result.message}");
            }

            return result; 

        } // terminado respositorio
    }
}
