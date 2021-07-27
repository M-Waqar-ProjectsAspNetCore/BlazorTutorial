using Microsoft.EntityFrameworkCore;

namespace BlazorTutorial.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
    }
}
