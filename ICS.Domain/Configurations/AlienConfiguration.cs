using ICS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICS.Domain.Configurations
{
    public sealed class AlienConfiguration : IEntityTypeConfiguration<Alien>
    {
        public AlienConfiguration(string schemaName)
        {
            SchemaName = schemaName;
        }

        public string TableName => "Aliens";

        public string SchemaName { get; private set; }

        public void Configure(EntityTypeBuilder<Alien> builder)
        {
            builder.ToTable(TableName, SchemaName);

            builder.HasKey(alien => alien.Id);

            builder.Property(alien => alien.Id).HasColumnName("AlienUid").ValueGeneratedNever();

            builder.Property(alien => alien.InvitationId).HasColumnName("InvitationUid");
            builder.Property(alien => alien.ContactId).HasColumnName("ContactUid");
            builder.Property(alien => alien.PassportId).HasColumnName("PassportUid");
            builder.Property(alien => alien.OrganizationId).HasColumnName("OrganizationUid");
            builder.Property(alien => alien.StateRegistrationId).HasColumnName("StateRegistrationUid");
            builder.Property(alien => alien.Position).HasColumnName("Position");
            builder.Property(alien => alien.WorkPlace).HasColumnName("WorkPlace");
            builder.Property(alien => alien.WorkAddress).HasColumnName("WorkAddress");
            builder.Property(alien => alien.StayAddress).HasColumnName("StayAddress");
        }
    }
}