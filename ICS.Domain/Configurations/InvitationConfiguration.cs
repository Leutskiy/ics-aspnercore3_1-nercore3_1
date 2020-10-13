using ICS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICS.Domain.Configurations
{
    public sealed class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public InvitationConfiguration(string schemaName)
        {
            SchemaName = schemaName;
        }

        public string TableName => "Invitations";

        public string SchemaName { get; private set; }

        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.ToTable(TableName, SchemaName);

            builder.HasKey(invitation => invitation.Id);

            builder.Property(invitation => invitation.Id)
                .HasColumnName("Uid")
                .ValueGeneratedNever();

            builder.Property(invitation => invitation.AlienId).HasColumnName("AlienUid");
            builder.Property(invitation => invitation.EmployeeId).HasColumnName("EmployeeUid");
            builder.Property(invitation => invitation.VisitDetailId).HasColumnName("VisitDetailUid");
            builder.Property(invitation => invitation.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(invitation => invitation.UpdateDate).HasColumnName("UpdateDate");
            builder.Property(invitation => invitation.Status).HasColumnName("Status");

            builder.HasMany(invitation => invitation.ForeignParticipants);
        }
    }
}