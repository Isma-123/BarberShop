
using BarberShop.Entities.Personal;
using BarberShop.Persitance.cs.Models.Personal;
using BarberShop.Persitance.cs.Repository.Personal;
using BarberShopAplications.Contracts.Personal;
using BarberShopAplications.Dto.Personal.BarberDto.cs;
using BarberShopAplications.Responses.PersonalResponse;
using Microsoft.Extensions.Logging;

namespace BarberShopAplications.Services
{
    public class BarberServices : IBarberServices
    {

        // inyeccion de dependecia de mi respositorio 
        // configurartion of my proyect with serveral referece 


        private readonly BarberRespository _barberrepository;
        private readonly ILogger<BarberServices> _logger; 


        public BarberServices(BarberRespository barberrepository, ILogger<BarberServices> logger)
        {   

            if(barberrepository is null) throw new ArgumentNullException(nameof(barberrepository));

            _barberrepository = barberrepository;
             this._logger = logger;
        }

        public async Task<BarberResponse> DeleteAsync(RemoveBarberDto dto)
        {
            BarberResponse response = new BarberResponse();

            try
            {
                // Obtener el barbero por ID
                var result = await _barberrepository.GetById(dto.BarberID);

                if (result.success)
                {
                    // Si el barbero existe, proceder con la eliminación
                    Barber barber = (Barber)result.data!;
                    var deletionResult = await _barberrepository.delete(barber);

                    response.model = deletionResult;  
                    response.mensaje = $"Barber with ID {dto.BarberID} has been removed successfully!";
                }
                else
                {
                    // Manejar el caso de que el barbero no exista
                    response.succeful = false;
                    response.mensaje = $"Barber with ID {dto.BarberID} was not found in the system!";
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                response.succeful = false;
                response.mensaje = $"An error occurred while trying to remove Barber with ID {dto.BarberID}: {ex.Message}";
                _logger.LogError($"Exception: {ex.Message}\nDetails: {ex}");
            }

            return response;
        }

        public async Task<BarberResponse> GetAllAsync()
        {
            BarberResponse response = new BarberResponse();

            try
            {

                var result = await _barberrepository.GetAll();
                // convieto mis modelos en dto
                List<GetBarberDto> barber = ((List<BarberModels>)result.data!).
                    Select(barber => new GetBarberDto
                    {
                        BarberID = barber.BarberID,
                        AppointmentID = barber.AppointmentID,
                        CreateAt = DateTime.Now,
                        IsActive = barber.IsActive,
                        LicenseNumber = barber.LicenseNumber,
                        Name = barber.Name,
                        OffDay = barber.OffDay,
                        register  = barber.register,
                        YearsOfExperience = barber.YearsOfExperience,
                        Specialty = barber.Specialty,
                        
                    }).ToList();

                response.model = barber;
                response.mensaje = "List of barber!";
            }
            catch (Exception ex)
            {
                response.mensaje = $"Error type {ex.Message} try to get all of the barber into the system!";
               _logger.LogError($"Error type {ex.Message} " + ex.ToString());

            } 


            return response; 

        }

        public async Task<BarberResponse> GetByIdAsync(int id)
        {
            BarberResponse response = new BarberResponse(); 

            if(id <= 0)
            {
                response.succeful = false;
                response.mensaje = "you cannot put id 0 or equal to 0!";
                return response; 

            }

            try
            {
                var result = await _barberrepository.GetById(id);
                if (result.success)
                {
                    response.model = result.data;
                    response.mensaje = $"ID {id} has been found it  on the system! ";
                } else
                {
                    response.succeful = false;
                    response.mensaje = $"ID {id} has not been found it  on the system! ";
                }
            }
            catch (Exception ex)
            {
                response.succeful = false;
                response.mensaje = $"Error type {ex.Message} try to find the barber into the system!";
                _logger.LogError($"Error type {ex.Message} " + ex.ToString());

            }

             return response;
        }

        public async Task<BarberResponse> SaveAsync(SaveBarberDto dto)
        {
            BarberResponse response = new BarberResponse();

            try
            {
                Barber barber = new Barber();
                barber.OffDay = dto.OffDay;
                barber.register= dto.register;
                barber.CreateAt = dto.CreateAt; 
                barber.AppointmentID = dto.AppointmentID;
                barber.LicenseNumber = dto.LicenseNumber;
                barber.Name = dto.Name; 
                barber.YearsOfExperience = dto.YearsOfExperience;   
                barber.Specialty = dto.Specialty;   


                var result = await _barberrepository.add(barber);
                response.model = result;
                response.mensaje = "user has been added to the system succefully! ";
           
            }
            catch (Exception ex)
            {
                response.succeful = false;
                response.mensaje = $"Error type {ex.Message} try to save the barber into the system!";
               _logger.LogError($"Error type {ex.Message} " + ex.ToString()); 

            }
            return response;

        }

        public async Task<BarberResponse> UpdateAsync(UpdateBarberDto dto)
        {
            BarberResponse response = new BarberResponse();


            try
            {
                var result = await _barberrepository.GetById(dto.BarberID);

                if (result.success)
                {
                    Barber barber = (Barber)result.data!;
                    barber.BarberID = dto.BarberID;
                    barber.AppointmentID = dto.AppointmentID;
                    barber.LicenseNumber = dto.LicenseNumber;
                    barber.Name = dto.Name;
                    barber.OffDay = dto.OffDay;
                    barber.CreateAt = dto.CreateAt;
                    barber.Specialty = dto.Specialty;
                    barber.IsActive = dto.IsActive;
                    barber.YearsOfExperience = dto.YearsOfExperience;

                    var consult = await _barberrepository.update(barber);
                    response.model = consult;
                    response.mensaje = "barber has been updated succefully!";

                } else
                {
                    response.succeful = false;
                    response.mensaje = "barber to updated has not been found it!";
                }
            }
            catch (Exception ex)
            {
                response.succeful = false;
                response.mensaje = $"Error type {ex.Message} try to updated the barber into the system!";
                _logger.LogError($"Error type {ex.Message} " + ex.ToString());

            }

            return response; 

        }
    }
}
