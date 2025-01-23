

using BarberShopAplications.Base;
using BarberShopAplications.Dto.Personal.ScheduledDto;
using BarberShopAplications.Responses.PersonalResponse;

namespace BarberShopAplications.Contracts.Personal
{
    public interface ScheduledServices : BaseServices<ScheduledResponse, SaveScheduledDto, UpdateScheduledDto, 
        RemoveScheduledDto, GetScheduledDtos>
    {
    }
}
