namespace BarberShopAplications.Dto.Personal.BarberDto.cs
{
    public class GetBarberDto
    {
        public int BarberID { get; set; }
        public int AppointmentID { get; set; } // clave foranea
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public int YearsOfExperience { get; set; }
        public string Specialty { get; set; }
        public DateTime register { get; set; }
        public string? OffDay { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
