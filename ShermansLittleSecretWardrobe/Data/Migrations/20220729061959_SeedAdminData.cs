using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShermansLittleSecretWardrobe.Data.Migrations
{
    public partial class SeedAdminData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Description", "IPAddress", "Name", "NormalizedName" },
                values: new object[] { "1", "664bc8eb-603b-4b74-a0e3-555aa3df6bb0", new DateTime(2022, 7, 29, 14, 19, 58, 858, DateTimeKind.Local).AddTicks(753), "Administrator role (Authorized to do anything)", "127.0.0.1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "09855c32-e3fc-4534-b080-0eee23db1cbd", "RealAdmin@gmail.com", true, false, null, "REALADMIN@GMAIL.COM", "REALADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEEv264N8Et2tUfM8TSe2y1/TPiuN4cFBk/upZoMmnYu/+8lVr1X7WpoPJrgzFEasSA==", null, false, "e12ba211-bbd9-4bd0-ba52-2f88a01a7480", false, "RealAdmin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
