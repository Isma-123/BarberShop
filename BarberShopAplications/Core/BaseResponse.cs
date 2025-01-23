
namespace BarberShopAplications.Core
{
    public abstract class BaseResponse
    { 
        public bool succeful { get; set; }
        public string? mensaje { get; set; }
        public BaseResponse() { this.succeful = true; }

    }
}
