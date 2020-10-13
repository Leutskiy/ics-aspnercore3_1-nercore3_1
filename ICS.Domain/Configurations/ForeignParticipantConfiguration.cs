using ICS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICS.Domain.Configurations
{
    public sealed class ForeignParticipantConfiguration : IEntityTypeConfiguration<ForeignParticipant>
    {
        public ForeignParticipantConfiguration(string schemaName)
        {
            SchemaName = schemaName;
        }

        public string TableName => "ForeignParticipants";

        public string SchemaName { get; private set; }

        public void Configure(EntityTypeBuilder<ForeignParticipant> builder)
        {
            builder.ToTable(TableName, SchemaName);

            builder.HasKey(foreignParticipant => foreignParticipant.Id);

            builder.Property(foreignParticipant => foreignParticipant.Id)
                .HasColumnName("Uid")
                .ValueGeneratedNever();

            builder.Property(foreignParticipant => foreignParticipant.AlienId).HasColumnName("AlienUid");
            builder.Property(foreignParticipant => foreignParticipant.InvitationId).HasColumnName("InvitationUid");
            builder.Property(foreignParticipant => foreignParticipant.PassportId).HasColumnName("PassportUid");
        }
    }
}