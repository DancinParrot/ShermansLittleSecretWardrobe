using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShermansLittleSecretWardrobe.Data.Migrations
{
    public partial class AddAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KeyMovieFieldID",
                table: "AuditRecord",
                newName: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "AuditRecord",
                newName: "KeyMovieFieldID");
        }
    }
}
