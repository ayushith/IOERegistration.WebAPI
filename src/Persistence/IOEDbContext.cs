using IOERegistration.WebAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace IOERegistration.WebAPI.Persistence
{
    public class IOEDbContext : DbContext
    {
        public IOEDbContext(DbContextOptions<IOEDbContext> options)
            :base(options)
        {

        }

        public DbSet<CourseDegreeLevel> CourseDegreeLevels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CourseDegreeLevel>()
                .Property(c => c.Created)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<CourseDegreeLevel>()
                .HasData(new CourseDegreeLevel[]
                {
                    new CourseDegreeLevel { Id = 1, DegreeLevelName = "Bachelor", DegreeLevelCode = 'B', CreatedBy = "Admin" },
                    new CourseDegreeLevel { Id = 2, DegreeLevelName = "Master", DegreeLevelCode = 'M', CreatedBy = "Admin" },
                    new CourseDegreeLevel { Id = 3, DegreeLevelName = "PHD", DegreeLevelCode = 'P', CreatedBy = "Admin" }
                });

            
            base.OnModelCreating(modelBuilder);
        }
    }
}
