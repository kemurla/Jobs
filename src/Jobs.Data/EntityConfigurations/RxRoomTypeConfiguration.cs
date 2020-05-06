using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Jobs.Core.Entities;

namespace Jobs.Data.EntityConfigurations
{
    public class RxRoomTypeConfiguration : IEntityTypeConfiguration<RxRoomType>
    {
        public void Configure(EntityTypeBuilder<RxRoomType> builder)
        {
            builder.ToTable("RX_RoomType");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(28)
                .IsUnicode(false);    
        }
    }
}
