

using BarberShop.Entities.Product;
using BarberShop.Persitance.cs.Base;
using BarberShop.Persitance.cs.Context;
using BarberShop.Persitance.cs.Interfaces.Products;
using BarberShop.Persitance.cs.Models.Product;
using BarberShop.Result;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BarberShop.Persitance.cs.Repository.Products
{
    public class ProductsRepository : BaseRespository<Product>, IProductsInrterfaces
    {  

        private readonly  MyContext myContext; 
        private readonly ILogger<ProductsRepository> _logger; 
        public ProductsRepository(MyContext _mycontext, ILogger<ProductsRepository> 
              logger) : base(_mycontext)
        { 

            myContext = _mycontext;
            _logger = logger;

        }



        public async override Task<ResponseResult> add(Product entity)
        {
            ResponseResult result = new ResponseResult();

            if (entity.ProductID <= 0)
            {
                result.success = false;
                result.message = "you cant put 0 to an id product! ";
                return result;

            }

            if (string.IsNullOrEmpty(entity.ProductName) && string.IsNullOrEmpty(entity.OffDay))
            {
                result.success = false;
                result.message = "you cannot leave the field empty here!";
                return result;
            }

            if (entity.IsActive == false)
            {
                result.success = false;
                result.message = "the product is not active!";
                return result;

            } 

            if(entity.Price <= 0 && entity.StockQuantity <= 0)
            {
                result.success = false;
                result.message = "the price of the product cannot be 0!"; 
                return result;  

            }

            try
            {
               var consult = await base.add(entity);

                result.data = consult;
                result.message = "Product added succefully!!";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ($"Error type {ex.Message} trying to save the inovice! ");
               _logger.LogError($"Error type {result.message}");
            }


            return result; 
        }

        public async override Task<ResponseResult> delete(Product entity)
        {
            ResponseResult result = new ResponseResult();

            if (entity.ProductID <= 0)
            {
                result.success = false;
                result.message = "you cant put 0 to an id product! ";
                return result;

            }

            if (string.IsNullOrEmpty(entity.ProductName) && string.IsNullOrEmpty(entity.OffDay))
            {
                result.success = false;
                result.message = "you cannot leave the field empty here!";
                return result;
            }

            if (entity.IsActive == false)
            {
                result.success = false;
                result.message = "the product is not active!";
                return result;

            }

            if (entity.Price <= 0 && entity.StockQuantity <= 0)
            {
                result.success = false;
                result.message = "the price of the product cannot be 0!";
                return result;

            }

            try
            {
                Product? consult = await myContext.products.FindAsync(entity.ProductID);

                if (consult == null)
                {
                    result.success = false; 
                    result.message = $"the product {entity.ProductID} does not exist.";
                    return result;
                }

                 var response = await base.delete(consult);
                 result.data = response.data;
                 result.message += response.message;
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ($"Error type {ex.Message} trying to delete the inovice! ");
               _logger.LogError($"Error type {result.message}");

            }


            return result; 

        }

     
        public async override Task<ResponseResult> GetAll()
        {
            ResponseResult result = new ResponseResult();

            try
            {
                var consult = await (from a in myContext.products 
                                     orderby a.CreateAt descending 
                                     select new ProductModels
                                     {
                                         ProductID = a.ProductID,
                                         Price = a.Price,
                                         StockQuantity = a.StockQuantity,
                                         CreateAt = a.CreateAt,
                                         ProductName = a.ProductName,
                                         
                                     }).AsNoTracking()
                                     .ToListAsync();
                result.data = consult;
                result.message = "the list of prducts!";

                                     
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ($"Error type {ex.Message} trying to delete the inovice! ");
               _logger.LogError($"Error type {result.message}");

            }

            return result;
        }

        public async override Task<ResponseResult> GetById(int id)
        {
            ResponseResult result = new ResponseResult();
            try
            {
        
                var consult = await(from a in myContext.products
                                    where a.ProductID == id
                                    orderby a.CreateAt descending
                                    select new ProductModels
                                    {
                                        ProductID = a.ProductID,
                                        Price = a.Price,
                                        StockQuantity = a.StockQuantity,
                                        CreateAt = a.CreateAt,
                                        ProductName = a.ProductName,
                                        
                                    }).AsNoTracking()
                                    .ToListAsync();

                result.data = consult;
                result.message = $"the product id {id} has been found it succefully! ";

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ($"Error type {ex.Message} trying to delete the inovice! ");
                _logger.LogError($"Error type {result.message}");

            }

            return result;
            
        }

        public async override Task<ResponseResult> update(Product entity)
        {
            ResponseResult result = new ResponseResult();

            if (entity.ProductID <= 0)
            {
                result.success = false;
                result.message = "you cant put 0 to an id product! ";
                return result;

            }

            if (string.IsNullOrEmpty(entity.ProductName) && string.IsNullOrEmpty(entity.OffDay))
            {
                result.success = false;
                result.message = "you cannot leave the field empty here!";
                return result;
            }

            if (entity.IsActive == false)
            {
                result.success = false;
                result.message = "the product is not active!";
                return result;

            }

            if (entity.Price <= 0 && entity.StockQuantity <= 0)
            {
                result.success = false;
                result.message = "the price of the product cannot be 0!";
                return result;

            }

            try
            {
                Product? product = await myContext.products.FindAsync(entity.ProductID);

                if (product == null)
                {
                    result.success = false;
                    result.message = $"this {entity.ProductName} hast been found it!";
                    return result;
                }

                product.ProductID = entity.ProductID;
                product.StockQuantity = entity.StockQuantity;
                product.Price = entity.Price;
                product.IsActive = entity.IsActive;
                product.ProductName = entity.ProductName;
                product.OffDay = entity.OffDay;
                product.register = entity.register;
                product.IsActive = true;
                product.CreateAt = DateTime.Now;


                var datos = await base.update(product);
                result.data = datos;
                result.message = $"product {product.ProductID} has been updated succefully!";

          
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ($"Error type {ex.Message} trying to delete the inovice! ");
               _logger.LogError($"Error type {result.message}");
            }

            return result;
        }
    }
}
