using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoCleanArchitecture.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class init_member : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mail = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    Pwd = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.CheckConstraint("CK_Member__NoEmptyMail", "len(trim(Mail)) > 0");
                    table.CheckConstraint("CK_Member__NoEmptyPwd", "len(trim(Pwd)) > 0");
                });

            migrationBuilder.CreateIndex(
                name: "IDX_Member__UniqueMail",
                table: "Member",
                column: "Mail",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
