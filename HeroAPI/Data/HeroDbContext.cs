using Microsoft.EntityFrameworkCore;

namespace HeroAPI.Data
{
    public class HeroDbContext : DbContext
    {
        public HeroDbContext(DbContextOptions<HeroDbContext> options) : base(options)
        { }

        //table name and representation of data in DB
        public DbSet<Category> categories => Set<Category>();

    }
}
