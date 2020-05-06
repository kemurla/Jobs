using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Jobs.Core.Entities;

namespace Jobs.Data.EntityConfigurations
{
    public class RxJobConfiguration : IEntityTypeConfiguration<RxJob>
    {
        public void Configure(EntityTypeBuilder<RxJob> builder)
        {
            builder.ToTable("RX_Job");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.ContractorId).HasColumnName("ContractorID");

            builder.Property(e => e.DateCompleted).HasColumnType("datetime");

            builder.Property(e => e.DateCreated).HasColumnType("datetime");

            builder.Property(e => e.DateDelayed).HasColumnType("datetime");

            builder.Property(e => e.DelayReason)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.RjobId).HasColumnName("RJobID");

            builder.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.RoomType)
                .WithMany(p => p.RxJob)
                .HasForeignKey(d => d.RoomTypeId)
                .HasConstraintName("FK_JobRoomType");
        }
    }
}
