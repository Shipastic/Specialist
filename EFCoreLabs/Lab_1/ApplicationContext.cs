using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Threading.Channels;

namespace Lab_1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        private readonly IConfiguration _configuration;
        public ApplicationContext(IConfiguration configuration)
        {
                _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = _configuration.GetConnectionString("LabConnection");
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
