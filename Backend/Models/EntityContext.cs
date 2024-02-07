using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {

        }
        public DbSet<Color> Colors { get; set; }
    }
}
