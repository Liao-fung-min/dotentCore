using Microsoft.EntityFrameworkCore;


namespace DemoApi.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
