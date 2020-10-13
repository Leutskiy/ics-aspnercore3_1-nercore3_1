using ICS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICS.Domain.Configurations
{
    public sealed class VisitDetailConfiguration : IEntityTypeConfiguration<VisitDetail>
    {
        public VisitDetailConfiguration(string schemaName)
        {
            SchemaName = schemaName;
        }

        public string TableName => "VisitDetails";

        public string SchemaName { get; private set; }

        public void Configure(EntityTypeBuilder<VisitDetail> builder)
        {
            builder.ToTable(TableName, SchemaName);

            builder.HasKey(visitDetail => visitDetail.Id);

            builder.Property(visitDetail => visitDetail.Id)
                .HasColumnName("Uid")
                .ValueGeneratedNever();

            builder.Property(visitDetail => visitDetail.InvitationId).HasColumnName("InvitationUid");
            builder.Property(visitDetail => visitDetail.Goal).HasColumnName("Goal");
            builder.Property(visitDetail => visitDetail.Country).HasColumnName("Country");
            builder.Property(visitDetail => visitDetail.VisitingPoints).HasColumnName("VisitingPoints");
            builder.Property(visitDetail => visitDetail.VisaType).HasColumnName("VisaType");
            builder.Property(visitDetail => visitDetail.VisaCity).HasColumnName("VisaCity");
            builder.Property(visitDetail => visitDetail.VisaCountry).HasColumnName("VisaCountry");
            builder.Property(visitDetail => visitDetail.VisaMultiplicity).HasColumnName("VisaMultiplicity");
            builder.Property(visitDetail => visitDetail.PeriodDays).HasColumnName("PeriodDays");
            builder.Property(visitDetail => visitDetail.ArrivalDate).HasColumnName("ArrivalDate");
            builder.Property(visitDetail => visitDetail.DepartureDate).HasColumnName("DepartureDate");
        }
    }
}