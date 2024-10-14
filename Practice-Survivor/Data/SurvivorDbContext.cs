using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Practice_Survivor.Entities;

namespace Practice_Survivor.Data
{
    public class SurvivorDbContext : DbContext
    {
        public SurvivorDbContext(DbContextOptions<SurvivorDbContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompetitorEntity>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Competitors)
                .HasForeignKey(c => c.CategoryId);
        }

        public DbSet<CompetitorEntity> Competitors => Set<CompetitorEntity>();
        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
    }
}
