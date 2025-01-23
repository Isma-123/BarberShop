using BarberShop.Entities.Servers;
using BarberShop.Persitance.cs.Repository.Services;
using Microsoft.AspNetCore.Mvc;


namespace BarberShopApi.cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceControllers : ControllerBase
    {   

        private readonly InvoiceRepository _invoiceRepository; 

        public InvoiceControllers(InvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;

        }

        [HttpGet("GetInvoices")]
        public async Task<ActionResult> Get()
        {
          var result = await _invoiceRepository.GetAll();
          if (result.success) return Ok(result);
          return  BadRequest(result); 

        }

       
        [HttpGet("GetInvoicesById")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _invoiceRepository.GetById(id);
            if (result.success) return Ok(result); 
            return BadRequest(result);
        }


        [HttpPost("SaveInvoices")]
        public async Task<ActionResult> Post([FromBody] Invoice value)
        { 
            var result = await _invoiceRepository.add(value);   
            if(result.success) return Ok(result);
             return BadRequest(result);
        }

        [HttpPut("UpdateInvoices")]
        public async Task<ActionResult> Put(int id, [FromBody] Invoice value)
        { 

            var result = await _invoiceRepository.update(value);
            if(result.success) return Ok(result);  
            return BadRequest(result);
        }


        [HttpDelete("DeleteInvoices")]
        public async Task<ActionResult> Delete(Invoice id)
        {

            var result = await _invoiceRepository.delete(id);
            if (result.success) return Ok(result);
            return BadRequest(result);

        }
    }
}
