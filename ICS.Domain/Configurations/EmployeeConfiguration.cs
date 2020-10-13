using ICS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICS.Domain.Configurations
{
    public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration(string schemaName)
        {
            SchemaName = schemaName;
        }

        public string TableName => "Employees";

        public string SchemaName { get; private set; }

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(TableName, SchemaName);

            builder.HasKey(employee => employee.Id);

            builder.Property(employee => employee.Id)
                .HasColumnName("Uid")
                .ValueGeneratedNever();

            builder.Property(employee => employee.UserId).HasColumnName("UserUid");
            builder.Property(employee => employee.ContactId).HasColumnName("ContactUid");
            builder.Property(employee => employee.ManagerId).HasColumnName("ManagerUid");
            builder.Property(employee => employee.PassportId).HasColumnName("PassportUid");
            builder.Property(employee => employee.InvitationId).HasColumnName("InvitationUid");
            builder.Property(employee => employee.OrganizationId).HasColumnName("OrganizationUid");
            builder.Property(employee => employee.StateRegistrationId).HasColumnName("StateRegistrationUid");
            builder.Property(employee => employee.AcademicRank).HasColumnName("AcademicRank");
            builder.Property(employee => employee.AcademicDegree).HasColumnName("AcademicDegree");
            builder.Property(employee => employee.Education).HasColumnName("Education");
            builder.Property(employee => employee.Position).HasColumnName("Position");
            builder.Property(employee => employee.WorkPlace).HasColumnName("WorkPlace");

            builder.HasOne(employee => employee.Manager).WithMany().HasForeignKey(manager => manager.ManagerId);
        }
    }
}