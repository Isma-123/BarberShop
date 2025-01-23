
namespace BarberShopAplications.Dto.Personal.BarberDto.cs
{
    public class UpdateBarberDto : BaseBarberDto
    {
        public int BarberID { get; set; }
        public bool IsActive { get; set; }
    }
}
