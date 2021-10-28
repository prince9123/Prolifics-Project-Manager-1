using Microsoft.EntityFrameworkCore;



namespace PPM.Model
{

    public class context : DbContext
    {
        private const string connectionString = "Server=(ESN0OA3)PRINCESQL; Database=Prince_kumar;Integrated security=true;TrustServerCertificate=true";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

         

        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
    }



}

 