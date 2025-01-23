
using BarberShopAplications.Base;
using BarberShopAplications.Dto.Personal.CustomerDto;
using BarberShopAplications.Responses.PersonalResponse;

namespace BarberShopAplications.Contracts.Personal
{
    public interface ICustomerServices : BaseServices
        <CustomerResponse, CustomerSveDto, UpdateCustomerDto, RemoveCustomerDto, CostumerGetDto>
    {
    }
}
