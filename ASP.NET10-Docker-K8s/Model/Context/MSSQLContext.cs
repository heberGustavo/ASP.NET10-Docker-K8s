using Microsoft.EntityFrameworkCore;

namespace ASP.NET10_Docker_K8s.Model.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
