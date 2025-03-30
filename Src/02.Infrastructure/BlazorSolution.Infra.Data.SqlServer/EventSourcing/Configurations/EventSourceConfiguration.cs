using BlazorSolution.Core.Domain.EventSourcing.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorSolution.Infra.Data.SqlServer.EventSourcing.Configurations;

public class EventSourceConfiguration : IEntityTypeConfiguration<EventSource>
{
    public void Configure(EntityTypeBuilder<EventSource> builder)
    {
        builder.HasIndex(item => new { item.Sequence, item.Id }).IsUnique();
        //builder.Property(item => item.Sequence).HasDefaultValueSql("NEXT VALUE FOR ValueGenerator");
        builder.Property(item => item.Aggregate).HasMaxLength(250);
        builder.Property(item => item.AggregateId).HasMaxLength(50);
        builder.Property(item => item.Data).HasMaxLength(250);
        builder.Property(item => item.Name).HasMaxLength(250);
    }
}
