using ICS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICS.Domain.Configurations
{
    public sealed class PassportConfiguration : IEntityTypeConfiguration<Passport>
    {
        public PassportConfiguration(string schemaName)
        {
            SchemaName = schemaName;
        }

        public string TableName => "Passports";

        public string SchemaName { get; private set; }

        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder.ToTable(TableName, SchemaName);

            builder.HasKey(passport => passport.Id);

            builder.Property(passport => passport.Id)
                .HasColumnName("Uid")
                .ValueGeneratedNever();

            builder.Property(passport => passport.NameRus).HasColumnName("NameRus");
            builder.Property(passport => passport.NameEng).HasColumnName("NameEng");
            builder.Property(passport => passport.SurnameRus).HasColumnName("SurnameRus");
            builder.Property(passport => passport.SurnameEng).HasColumnName("SurnameEng");
            builder.Property(passport => passport.PatronymicNameRus).HasColumnName("PatronymicNameRus");
            builder.Property(passport => passport.PatronymicNameEng).HasColumnName("PatronymicNameEng");
            builder.Property(passport => passport.BirthDate).HasColumnName("BirthDate");
            builder.Property(passport => passport.BirthPlace).HasColumnName("BirthPlace");
            builder.Property(passport => passport.BirthCountry).HasColumnName("BirthCountry");
            builder.Property(passport => passport.Citizenship).HasColumnName("Citizenship");
            builder.Property(passport => passport.Gender).HasColumnName("Gender");
            builder.Property(passport => passport.IdentityDocument).HasColumnName("IdentityDocument");
            builder.Property(passport => passport.IssueDate).HasColumnName("IssueDate");
            builder.Property(passport => passport.IssuePlace).HasColumnName("IssuePlace");
            builder.Property(passport => passport.DepartmentCode).HasColumnName("DepartmentCode");
            builder.Property(passport => passport.Residence).HasColumnName("Residence");
            builder.Property(passport => passport.ResidenceRegion).HasColumnName("ResidenceRegion");
            builder.Property(passport => passport.ResidenceCountry).HasColumnName("ResidenceCountry");
        }
    }
}