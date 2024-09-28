using EmployeeAdminPortal.Controllers.Models.Entitties;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Data
{
    public class ApplicationDBContext : DbContext
    {
        //public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options)
        //{

        //}
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
