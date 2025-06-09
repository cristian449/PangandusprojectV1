using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PangandusProjectv1.Migrations
{
    /// <inheritdoc />
    public partial class AdminMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ef4f3d80-6a3d-4689-994c-b4e2a8756c41"), null, "Admin", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ef4f3d80-6a3d-4689-994c-b4e2a8756c41"));
        }
    }
}
