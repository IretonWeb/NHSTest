using Microsoft.EntityFrameworkCore;
using NHSTest.Domain.Entities;
using NHSTest.Persistence.Models;

namespace NHSTest.Persistence
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        } 
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Requirements> Requirements { get; set; }
        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            modelBuilder.ApplyConfiguration(new RequirementsConfiguration());

            modelBuilder.Entity<Requirements>().HasOne(e => e.Staff)
                .WithMany(x => x.Requirements)
                .HasForeignKey(e => e.StaffId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
