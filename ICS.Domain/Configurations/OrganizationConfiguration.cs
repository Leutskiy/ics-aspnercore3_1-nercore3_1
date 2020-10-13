using ICS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICS.Domain.Configurations
{
    public sealed class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public OrganizationConfiguration(string schemaName)
        {
            SchemaName = schemaName;
        }

        public string TableName => "Organizations";

        public string SchemaName { get; private set; }

        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable(TableName, SchemaName);

            builder.HasKey(organization => organization.Id);

            builder.Property(organization => organization.Id)
                .HasColumnName("Uid")
                .ValueGeneratedNever();

            builder.Property(organization => organization.StateRegistrationId).HasColumnName("StateRegistrationUid");
            builder.Property(organization => organization.Name).HasColumnName("Name");
            builder.Property(organization => organization.ShortName).HasColumnName("ShortName");
            builder.Property(organization => organization.LegalAddress).HasColumnName("LegalAddress");
            builder.Property(organization => organization.ScientificActivity).HasColumnName("ScientificActivity");
        }
    }
}