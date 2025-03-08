using FDS.DbLogger.PostgreSQL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FDS.DbLogger.PostgreSQL.Infrastructure.Persistence.Mappings;

internal class AuditLogMap : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.ToTable("audit_logs");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(e => e.EventTimestamp)
            .HasColumnName("event_timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(e => e.EventAction)
            .HasColumnName("event_action")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.ContextName)
            .HasColumnName("context_name")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.HttpStatusCode)
            .HasColumnName("http_status_code")
            .IsRequired(false);

        builder.Property(e => e.UserEmail)
            .HasColumnName("user_email")
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(e => e.EventMessage)
            .HasColumnName("event_message")
            .HasColumnType("TEXT")
            .IsRequired(false);

        builder.Property(e => e.EventData)
            .HasColumnName("event_data")
            .HasColumnType("jsonb")
            .IsRequired(false);
    }
}
