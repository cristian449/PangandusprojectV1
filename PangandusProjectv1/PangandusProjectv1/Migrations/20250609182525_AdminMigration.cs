using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PangandusProjectv1.Migrations
{
    /// <inheritdoc />
    public partial class AdminMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AdminSince",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdministrator",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminSince",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsAdministrator",
                table: "AspNetUsers");
        }
    }
}
