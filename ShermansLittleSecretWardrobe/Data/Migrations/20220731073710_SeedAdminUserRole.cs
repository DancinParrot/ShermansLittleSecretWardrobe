using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShermansLittleSecretWardrobe.Data.Migrations
{
    public partial class SeedAdminUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Description", "IPAddress", "Name", "NormalizedName" },
                values: new object[] { "1", "f660e93d-bf15-49fe-b9e2-6c72f579e29a", new DateTime(2022, 7, 31, 15, 37, 9, 989, DateTimeKind.Local).AddTicks(5588), "Administrator role (Authorized to do anything)", "127.0.0.1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Description", "IPAddress", "Name", "NormalizedName" },
                values: new object[] { "a9aab020-5f31-4d2f-b5a2-a3a1dd9c64cf", "5b4e9ccd-abaf-4416-a158-42779723ed79", new DateTime(2022, 7, 31, 15, 37, 9, 992, DateTimeKind.Local).AddTicks(7944), "Basic User Role", "127.0.0.2", "Users", "USERS" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "01b75467-81e0-45e9-9665-e29d67cf5729", "RealAdmin@gmail.com", true, false, null, "REALADMIN@GMAIL.COM", "REALADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAELsLSuYIcaEKI5xy2AthUwdFExCO+yE1hHVMY4QZYTscQ3ugnUR/EmVHHOR630oQRw==", null, false, "a1360431-725f-4612-a355-1c6813559369", false, "RealAdmin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9aab020-5f31-4d2f-b5a2-a3a1dd9c64cf");

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
