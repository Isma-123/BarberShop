

namespace BarberShopAplications.Base
{
    public interface BaseServices<TResponse, TSaveDto,  TUpdateDto, TDeleteDto, TGetDto>
    {
        Task<TResponse> SaveAsync(TSaveDto dto); 
        Task<TResponse> DeleteAsync(TDeleteDto dto);
        Task<TResponse> UpdateAsync(TUpdateDto dto);
        Task<TResponse> GetByIdAsync(int id);
        Task<TResponse> GetAllAsync(); 

    }
}
