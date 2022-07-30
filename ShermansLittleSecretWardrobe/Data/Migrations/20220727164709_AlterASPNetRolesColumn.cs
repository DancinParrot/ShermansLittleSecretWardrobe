using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShermansLittleSecretWardrobe.Data.Migrations
{
    public partial class AlterASPNetRolesColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                nullable: true,
                type: "datetime2",
                defaultValueSql: "GETDATE()"
                );

            migrationBuilder.AddColumn<String>(
                name: "IPAddress",
                table: "AspNetRoles",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true
                );

            migrationBuilder.AddColumn<String>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
