

using BarberShop.Entities.Servers;
using BarberShop.Repository;

namespace BarberShop.Persitance.cs.Interfaces.Services
{
    public interface IAppointments : IRepository<Appointment>
    {
    }
}
