


using BarberShopAplications.Base;
using BarberShopAplications.Dto.Personal.BarberDto.cs;
using BarberShopAplications.Responses.PersonalResponse;

namespace BarberShopAplications.Contracts.Personal
{
    public interface IBarberServices : BaseServices
        <BarberResponse, SaveBarberDto, UpdateBarberDto, RemoveBarberDto, GetBarberDto>
    { 

    }
}
