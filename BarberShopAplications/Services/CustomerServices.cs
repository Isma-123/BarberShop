
using BarberShop.Entities.Personal;
using BarberShop.Persitance.cs.Models.Personal;
using BarberShop.Persitance.cs.Repository.Personal;
using BarberShopAplications.Contracts.Personal;
using BarberShopAplications.Dto.Personal.CustomerDto;
using BarberShopAplications.Responses.PersonalResponse;
using Microsoft.Extensions.Logging;

namespace BarberShopAplications.Services
{
    public class CustomerServices : ICustomerServices
    {  

        private readonly CustomerRepository _customerRepository;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerServices(CustomerRepository customerRepository, ILogger<CustomerRepository> logger)
        {   
            if(customerRepository is null) throw new ArgumentNullException(nameof(customerRepository));

            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<CustomerResponse> DeleteAsync(RemoveCustomerDto dto)
        {
            CustomerResponse response = new CustomerResponse();

            try
            {
                var result = await _customerRepository.GetById(dto.CustomerID);
                
                if(result.success)
                {
                    Customer customer = (Customer)result.data!; 
                    var consult = await _customerRepository.delete(customer);
                    response.model = consult;
                    response.mensaje = $"Customer {dto.CustomerID} has been remove succefully!";

                } else
                {
                    response.succeful = false; 
                    response.mensaje = $"Customer {dto.CustomerID} has not been remove succefully!";
                }


            }
            catch (Exception ex)
            {
                response.succeful = false;
                response.mensaje = $"An error type {ex.Message}";
               _logger.LogError($"Exception: {ex.Message}\nDetails: {ex.ToString()}");
            }
             return response; 
        }

        public async Task<CustomerResponse> GetAllAsync()
        {
            CustomerResponse response = new CustomerResponse();


            try
            {
                var result = await _customerRepository.GetAll(); 

                if(result.success)
                {
                    List<CostumerGetDto> customers = ((List<CustomerModels>)result.data!).
                        Select(customer => new CostumerGetDto
                        {
                            CustomerID = customer.CustomerID,
                            CreateAt = DateTime.Now,
                            FirstName = customer.FirstName,
                            AppoinmentID = customer.AppoinmentID,
                            Email = customer.Email,
                            LastName = customer.LastName,
                            OffDay = customer.OffDay,
                            Phone = customer.Phone,
                            register = customer.register,
                            IsActive = customer.IsActive,

                        }).ToList();

                    response.model = customers;
                    response.mensaje = "List of customers register! into the system!";
                }
            }
            catch (Exception ex)
            {
                response.succeful = false;
                response.mensaje = $"An error type {ex.Message}";
               _logger.LogError($"Exception: {ex.Message}\nDetails: {ex.ToString()}");

            }

             return response;

        }

        public async Task<CustomerResponse> GetByIdAsync(int id)
        {
            CustomerResponse response = new CustomerResponse();


            try
            {
                var result = await _customerRepository.GetById(id);

                if(result.success)
                {
                    response.model = result.data;
                    response.mensaje = $"Id: {id} has been found it on the system!";
                    
                } else
                {
                    response.succeful = false; 
                    response.mensaje = $"Id: {id} has not been found it on the system!";
                }
            }
            catch (Exception ex)
            {
                response.succeful = false;
                response.mensaje = $"An error type {ex.Message}";
               _logger.LogError($"Exception: {ex.Message}\nDetails: {ex.ToString()}");

            }

            return response;
        }

        public async Task<CustomerResponse> SaveAsync(CustomerSveDto dto)
        {
            CustomerResponse response = new CustomerResponse();

            try
            {
                Customer customer = new Customer(); 
                customer.OffDay = dto.OffDay;
                customer.FirstName = dto.FirstName; 
                customer.Email = dto.Email;
                customer.Phone = dto.Phone;
                customer.CreateAt   = dto.CreateAt;
                customer.AppoinmentID = dto.AppoinmentID;
                customer.register=dto.register;


                var result = await _customerRepository.add(customer);
                response.model = result.data;
                response.mensaje = "customer has been added to the system!";
                
            }
            catch (Exception ex)
            {
                response.succeful = false;
                response.mensaje = $"An error type {ex.Message}";
               _logger.LogError($"Exception: {ex.Message}\nDetails: {ex.ToString()}");

            }

             return response;
        }

        public async Task<CustomerResponse> UpdateAsync(UpdateCustomerDto dto)
        {
            CustomerResponse response = new CustomerResponse();

            return response;
        }
    }
}
