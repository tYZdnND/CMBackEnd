using ContactManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=contactdb;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
