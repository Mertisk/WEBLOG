using Microsoft.EntityFrameworkCore;

namespace BlogApiCore.DataAccsessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-O59BAOAB\\SQLEXPRESS;database=CoreBlogApiDb;integrated security=true;");

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
