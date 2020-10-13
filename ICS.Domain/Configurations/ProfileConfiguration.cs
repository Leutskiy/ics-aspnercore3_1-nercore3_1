using ICS.Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICS.Domain.Configurations
{
    public sealed class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public ProfileConfiguration(string schemaName)
        {
            SchemaName = schemaName;
        }

        public string TableName => "Profiles";

        public string SchemaName { get; private set; }

        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable(TableName, SchemaName);

            builder.HasKey(profile => profile.Id);

            builder.Property(profile => profile.Id)
                .HasColumnName("Uid")
                .ValueGeneratedNever();

            builder.Property(profile => profile.OrdinalNumber).HasColumnName("OrdinalNumber");
            builder.Property(profile => profile.UserId).HasColumnName("UserUid");
            builder.Property(profile => profile.Photo).HasColumnName("Avatar");
            builder.Property(profile => profile.WebPages).HasColumnName("WebPages");

            builder
                .HasOne(profile => profile.User)
                .WithOne(user => user.Profile)
                .HasForeignKey<Profile>(profile => profile.UserId)
                .HasPrincipalKey<User>(user => user.Id);
        }
    }
}