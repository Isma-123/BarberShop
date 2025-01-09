
using BarberShop.Entities.Personal;
using BarberShop.Entities.Product;
using BarberShop.Entities.Servers;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Persitance.cs.Context
{
    public partial class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        // mapeo de mis entidades para la base de datos  
        #region "Entities Personal" 
        public DbSet<Barber> barber { get; set; }    
        public DbSet<Customer> customer { get; set; }   
        public DbSet<BarberScheduled> barberScheduleds { get; set; }
        #endregion
        #region "Entities Product"
        public DbSet<Product> products { get; set; }

        #endregion
        #region "Entities Servers"
        public DbSet<Appointment> appointments { get; set; }

        public DbSet<Invoice> invoices { get; set; }
        #endregion

    }
}
