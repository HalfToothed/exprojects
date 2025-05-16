using Account.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Account.Api.AppDataLayer
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _connectionString = (string)httpContextAccessor.HttpContext.Items["ConnectionString"];
            //_connectionString = "Server=localhost;Port=5432;Database=postgres2;User Id=postgres;Password=3141";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connectionString);
            }
        }

        public virtual DbSet<Student> Students { get; set; }

        // DbSet and other configurations...
    }

}
