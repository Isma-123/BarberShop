
using BarberShop.Entities.Servers;
using BarberShop.Persitance.cs.Base;
using BarberShop.Persitance.cs.Context;
using BarberShop.Persitance.cs.Interfaces.Services;
using BarberShop.Persitance.cs.Models.Services;
using BarberShop.Result;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;

namespace BarberShop.Persitance.cs.Repository.Services
{
    public class InvoiceRepository : BaseRespository<Invoice>, Iinvoice
    {

        private readonly MyContext _micontext; 
        private readonly ILogger<InvoiceRepository> _logger;    
        public InvoiceRepository(MyContext _mycontext, 
             ILogger<InvoiceRepository> logger) : base(_mycontext)
        {

            _micontext = _mycontext;
             this._logger = logger;

        }

        public async override Task<ResponseResult> add(Invoice entity)
        {
            ResponseResult result = new ResponseResult();

            if (entity.InvoiceID <= 0 && entity.AppointmentID <= 0)
            {
                result.success = false;
                result.message = "error you cannot put id 0 or equal to 0!";
                return result; 

            }

            if (entity.TotalAmount <= 0)
            { 
                result.success = false;
                result.message = "you cant generate invoice with 0 dollars!";
                return result; 

            }

            if (string.IsNullOrEmpty(entity.PaymentMethod))
            {
                result.success = false;
                result.message = "you cant leave field empty!";
                return result;


            }

            if (entity.DateIssued < DateTime.Now)
            {

                result.success = false;
                result.message = "the dateissued has expirenced";
                return result;

            }


            try
            {
                var response = await base.add(entity);
                result.data = response.data;
                result.message = "invoice has been added in the system!";

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ($"Error type {ex.Message} trying to add the invoice ");
               _logger.LogError($"Error type {result.message}");

            }

            return result;  

        }


        public async override Task<ResponseResult> delete(Invoice entity)
        {
            ResponseResult result = new ResponseResult();


            if (entity.InvoiceID <= 0 && entity.AppointmentID <= 0)
            {
                result.success = false;
                result.message = "error you cannot put id 0 or equal to 0!";
                return result;

            }

            if (entity.TotalAmount <= 0)
            {
                result.success = false;
                result.message = "you cant generate invoice with 0 dollars!";
                return result;

            }

            if (string.IsNullOrEmpty(entity.PaymentMethod))
            {
                result.success = false;
                result.message = "you cant leave field empty!";
                return result;


            }

            if (entity.DateIssued < DateTime.Now)
            {

                result.success = false;
                result.message = "the dateissued has expirenced";
                return result;

            }

            try
            {
               Invoice? datos = await _micontext.invoices.FindAsync(entity.InvoiceID); 

                if (datos == null)
                {
                    result.message = $"Invoice {entity.InvoiceID} does not exist.";
                    result.success = false;
                    return result;
                }



                var response = await base.delete(datos); 
                result.data = response;
                result.message = $"Inovice {entity.InvoiceID} has been removed!  ";
             
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ($"Error type {ex.Message} trying to remove the invoice! ");
               _logger.LogError($"Error type {result.message}");

            }

            return result; 

        }

        public async override Task<ResponseResult> GetAll()
        {
             ResponseResult result = new ResponseResult();

            try
            {
               
                var datos = await (from a in _micontext.invoices 
                                   join s in _micontext.appointments  
                                   on a.AppointmentID equals s.AppointmentID    
                                   orderby a.CreateAt descending 
                                   select new InvoiceModels
                                   {
                                       AppointmentID = a.AppointmentID,
                                       DateIssued = a.DateIssued,
                                       InvoiceID = a.InvoiceID,
                                       CreateAt = a.CreateAt,
                                       PaymentMethod = a.PaymentMethod,
                                       TotalAmount = a.TotalAmount,
                                       
                                   }).AsNoTracking()
                                   .ToListAsync();
                result.data = datos;
                result.message = "List of Invoices!";

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ($"Error type {ex.Message} trying to list the inovices! ");
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
                result.message = "Error you cannot added any id with 0!";
                return result;
    
            }

            try
            {
                var consult = await (from a in _micontext.invoices
                                     join r in _micontext.appointments 
                                     on a.AppointmentID equals r.AppointmentID
                                     where a.InvoiceID == id
                                     orderby a.CreateAt descending
                                     select new InvoiceModels
                                     {   InvoiceID = id,
                                         AppointmentID = a.AppointmentID,
                                         DateIssued = a.DateIssued,
                                         CreateAt = a.CreateAt,
                                         PaymentMethod = a.PaymentMethod,
                                         TotalAmount = a.TotalAmount,
                                     }).AsNoTracking()
                                    .ToListAsync();

                result.data = consult;
                result.message = $" Invoice Id {id} has been found it on the system! ";

                
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ($"Error type {ex.Message} trying to get the inovice! ");
               _logger.LogError($"Error type {result.message}");

            }

            return result;

        }


        public async override Task<ResponseResult> update(Invoice entity)
        {

            ResponseResult result = new ResponseResult(); 

            if (entity.InvoiceID <= 0 && entity.AppointmentID <= 0)
            {
                result.success = false;
                result.message = "error you cannot put id 0 or equal to 0!";
                return result;

            }

            if (entity.TotalAmount <= 0)
            {
                result.success = false;
                result.message = "you cant generate invoice with 0 dollars!";
                return result;

            }

            if (string.IsNullOrEmpty(entity.PaymentMethod))
            {
                result.success = false;
                result.message = "you cant leave field empty!";
                return result;


            }

            if (entity.DateIssued < DateTime.Now)
            {

                result.success = false;
                result.message = "the dateissued has expirenced";
                return result;

            }

            try
            {
                Invoice? consult = await _micontext.invoices.FindAsync(entity.InvoiceID);
                if (consult == null)
                {
                    result.success = false;
                    result.message = "error we cant find this Invoices to update on the system";
                    return result;
                }

                consult.PaymentMethod = entity.PaymentMethod;
                consult.DateIssued = DateTime.Now;
                consult.CreateAt = DateTime.Now;
                consult.PaymentMethod = entity.PaymentMethod.ToString();
                consult.AppointmentID = entity.AppointmentID;
                consult.InvoiceID = entity.InvoiceID;

                var datos = await base.update(consult);
                result.data = datos.data;
                result.message = "Invoice has been updated it succefully!";

               
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ($"Error type {ex.Message} trying to get the inovice! ");
               _logger.LogError($"Error type {result.message}");

            }

            return result;
        }


    }
}
