

namespace BarberShop.Base
{
    public abstract class BaseEntities
    {
        public DateTime register { get; set; }
        public string? OffDay { get; set; } 
        public bool IsActive { get; set; }
        public DateTime? CreateAt { get; set; }


    }
}
