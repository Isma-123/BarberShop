using BarberShop.Entities.Product;
using BarberShop.Persitance.cs.Interfaces.Products;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BarberShopApi.cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControllers : ControllerBase
    {
        private readonly IProductsInrterfaces _productrepository;

        public ProductControllers(IProductsInrterfaces productrepository)
        {
            _productrepository = productrepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
           var result =await _productrepository.GetAll();
            if (result.success) Ok(result);
            return BadRequest();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var response = await _productrepository.GetById(id);    
            if (response.success) Ok(response);
            return BadRequest();
        }

       
        [HttpPost]
        public async  Task<ActionResult> Post(Product value)
        { 
            var response = await _productrepository.add(value); 
            if (response.success) Ok(response);
            return BadRequest();
        }

        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductControllers>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Product value)
        {
            {

                var response = await _productrepository.delete(value);
                if (response.success) Ok(response);
                return BadRequest();
            }
        }
    }
}
