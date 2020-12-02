using AspNetCoreCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreCRUD.Data
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Founder> Founders { get; set; }
    }
}
