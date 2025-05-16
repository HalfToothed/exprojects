using Account.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Account.MasterDataLayer
{
    public class MasterDbContext : DbContext
    { 
        public MasterDbContext(DbContextOptions<MasterDbContext> options): base(options)
        {   

        }

        public virtual DbSet<Database> Databases { get; set; }
    }
}
