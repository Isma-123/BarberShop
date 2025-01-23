

using BarberShop.Entities.Product;
using BarberShop.Persitance.cs.Interfaces.Products;
using BarberShop.Persitance.cs.Models.Product;
using BarberShopAplications.Contracts.Product;
using BarberShopAplications.Dto.Products.ProductDto;
using BarberShopAplications.Responses.ProductResponse;
using Microsoft.Extensions.Logging;

namespace BarberShopAplications.Services
{
    public class ProductServices : IProductServices
    {   

        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductServices> _logger;

        public ProductServices(IProductRepository productRepository, 
            ILogger<ProductServices> logger)
        {   
             if(productRepository is null) throw new ArgumentNullException(nameof(productRepository));

            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<ProductResponse> DeleteAsync(RemoveProductDto dto)
        {
             ProductResponse response = new ProductResponse();


            try
            {
                 var result = await _productRepository.GetById(dto.ProductID);

                 if(result.success)
                {
                     Product productRemove = (Product)result.data!;
                     var consult = await _productRepository.delete(productRemove);
                     response.model = consult;
                     response.mensaje = $"Product {dto.ProductID} has been removed succefully!";
                    
                } else
                {
                    response.succeful = false;
                    response.mensaje = "This id Product has not been found it on the system!";
                }
            }
            catch (Exception ex)
            {
                response.succeful = false;
                response.mensaje = $"Error type {ex.Message} try to delete the product!"; 
                _logger.LogError($"Error type {ex.Message }", ex.ToString());  
            }

             return response; 

        }

        public async Task<ProductResponse> GetAllAsync()
        {
            ProductResponse response = new ProductResponse(); 

            try
            {
                var result = await _productRepository.GetAll();
                if (result.success)
                {
                    List<ProductGetDto> products = ((List<ProductModels>)result.data!).
                        Select(products => new ProductGetDto
                        {
                            Price = products.Price, 
                            ProductID = products.ProductID,
                            ProductName = products.ProductName,
                            CreateAt = DateTime.Now,
                            StockQuantity   = products.StockQuantity,   
                            
                        }).ToList(); 


                    response.model = products;
                    response.mensaje = "List of Product On the System!";
                } else
                {
                    response.succeful = false;
                    response.mensaje = "error getting the list of products!";
                }
            }
            catch (Exception ex)
            {
                response.succeful = false;
                response.mensaje = $"Error type {ex.Message} try to delete the product!";
               _logger.LogError($"Error type {ex.Message}", ex.ToString());
            } 
             return response; 

        }

        public async Task<ProductResponse> GetByIdAsync(int id)
        {
            ProductResponse response = new ProductResponse();

            try
            {
                var result = await _productRepository.GetById(id);
                if(result.success)
                {
                    response.model = result.data;
                    response.mensaje = $"Id {id} has been found it on the system!"; 

                } else
                {
                    response.succeful = false;  
                    response.mensaje = $"ID {id} has not been found it on the system!";
                }
            }
            catch (Exception ex)
            {
                response.succeful = false;
                response.mensaje = $"Error type {ex.Message} try to get the product!";
               _logger.LogError($"Error type {ex.Message}", ex.ToString());

            }
             
             return response; 

        }

        public async Task<ProductResponse> SaveAsync(SaveProductDto dto)
        {
            ProductResponse response = new ProductResponse();

            try
            {
                Product product = new Product(); 
                product.ProductName = dto.ProductName;
                product.StockQuantity = dto.StockQuantity;  
                product.Price = dto.Price;  
                product.CreateAt  = dto.CreateAt;   


                var result = await _productRepository.add(product);
                if(!result.success)
                {
                    response.succeful = false;
                    response.mensaje = "error this couldn happen again trying to save the product!";
                    return response;
                }

                response.model = result.data;
                response.mensaje = "product has been added to the sytem succefully!";
               
            }
            catch (Exception ex)
            {
                response.succeful = false;
                response.mensaje = $"Error type {ex.Message} try to save the product!";
               _logger.LogError($"Error type {ex.Message}", ex.ToString());
            }

            return response; 

        }

        public async Task<ProductResponse> UpdateAsync(UpdateProductDto dto)
        {
            ProductResponse response = new ProductResponse();


            try
            {
                var result = await _productRepository.GetById(dto.ProductID);
                if(result.success)
                {
                    Product product = (Product)result.data!;
                    product.ProductName = dto.ProductName;
                    product.StockQuantity = dto.StockQuantity;
                    product.Price = dto.Price;
                    product.CreateAt= dto.CreateAt;
                    product.ProductID = dto.ProductID;


                    var consult =await _productRepository.update(product); 
                    response.model = consult;
                    response.mensaje = "Product has been updated succefully!";
                } else
                {
                    response.succeful = false;
                    response.mensaje = "Product has not been fount it into the system!";
                }
            }
            catch (Exception ex)
            {
                response.succeful = false;
                response.mensaje = $"Error type {ex.Message} try to updated the product!";
               _logger.LogError($"Error type {ex.Message}", ex.ToString());
            }
            return response; 

        }
    }
}
