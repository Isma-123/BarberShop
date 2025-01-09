using BarberShop.Entities.Servers;
using BarberShop.Persitance.cs.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberShopApi.cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InovicesControllers : ControllerBase
    {

        private readonly Iinvoice _invoicerepository; // inyeccion de dependecia de mi repositorio


        public InovicesControllers(Iinvoice invoicerepository)
        {
            _invoicerepository = invoicerepository;
        }
     
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var respusta = await _invoicerepository.GetAll(); // resquest http desde el servidor 
            if (respusta.success) return Ok(respusta);
            return BadRequest();
        }

   
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

     
        [HttpPost]
        public async Task<IActionResult> Post(Invoice value)
        { 
            var response = await _invoicerepository.add(value);
            if(response.success) return Ok(response);
            return BadRequest();
     

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Invoice value)
        { 

            var response = await _invoicerepository.update(value);
            if (response.success) return Ok(response);
            return BadRequest();

        }
  
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Invoice value)
        {
            var resposne = await _invoicerepository.delete(value); 
            if(resposne.success) return Ok(resposne);
            return BadRequest();

        }
    }
}
