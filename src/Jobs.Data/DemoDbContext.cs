using Microsoft.EntityFrameworkCore;

using Jobs.Core.Entities;
using Jobs.Data.EntityConfigurations;

namespace Jobs.Data
{
    public partial class DemoDbContext : DbContext
    {
        public DemoDbContext() { }

        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options) { }

        public virtual DbSet<RxJob> RxJob { get; set; }
        public virtual DbSet<RxRoomType> RxRoomType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // On a bigger project I would probably use .ApplyConfigurationsFromAssembly, but this is sufficient for now.
            modelBuilder.ApplyConfiguration(new RxJobConfiguration());
            modelBuilder.ApplyConfiguration(new RxRoomTypeConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
