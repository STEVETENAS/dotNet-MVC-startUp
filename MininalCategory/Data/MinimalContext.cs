global using Microsoft.EntityFrameworkCore;

namespace MininalCategory.Data
{
    public class MinimalContext: DbContext
    {
        public MinimalContext(DbContextOptions<MinimalContext> options) : base(options)
        {}
        public DbSet<Category> Categories { get; set; }
    }
}
