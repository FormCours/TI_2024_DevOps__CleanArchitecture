using DemoCleanArchitecture.Domain.Enums;
using DemoCleanArchitecture.Domain.Modeles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoCleanArchitecture.Infrastructure.Database.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            // Table
            builder.ToTable("Member", table =>
            {
                table.HasCheckConstraint("CK_Member__NoEmptyMail", "len(trim(Mail)) > 0");
                table.HasCheckConstraint("CK_Member__NoEmptyPwd", "len(trim(Pwd)) > 0");
            });

            // Keys
            builder.HasKey(m => m.Id)
                .HasName("PK_Member")
                .IsClustered();

            // Props
            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder.Property(m => m.Email)
                .HasColumnName("Mail")
                .IsUnicode()
                .HasMaxLength(320)
                .IsRequired();

            builder.Property(m => m.Password)
                .HasColumnName("Pwd")
                .IsUnicode(false)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(m => m.Role)
                .HasDefaultValue(MemberRoleEnum.USER)
                .HasSentinel(MemberRoleEnum.UNSPECIFIED)
                .IsRequired();

            // Index
            builder.HasIndex(m => m.Email)
                .HasDatabaseName("IDX_Member__UniqueMail")
                .IsUnique();
        }
    }
}
