using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace A1.Models
{
    public class A1DbContext : IdentityDbContext<Staff>
    {
        public A1DbContext(DbContextOptions<A1DbContext> options) : base(options)
        {
        }

        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<CustomerBooking> CustomerBookings { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}
