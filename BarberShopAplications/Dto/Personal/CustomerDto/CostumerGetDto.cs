

namespace BarberShopAplications.Dto.Personal.CustomerDto
{
    public class CostumerGetDto
    {
        public int CustomerID { get; set; }
        public int AppoinmentID { get; set; } // clave foranea    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime register { get; set; }
        public string? OffDay { get; set; }
        public DateTime? CreateAt { get; set; }
        public bool IsActive { get; set; }
    }
}
