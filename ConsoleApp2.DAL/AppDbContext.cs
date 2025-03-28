using Microsoft.EntityFrameworkCore;
using ConsoleApp2.Entities;

namespace ConsoleApp2.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SchoolDb;Integrated Security=True;");
        }
    }
}
