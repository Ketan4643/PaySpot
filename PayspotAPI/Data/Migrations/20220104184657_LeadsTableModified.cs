using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayspotAPI.Data.Migrations
{
    public partial class LeadsTableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Leads",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "PendingStatus",
                table: "Leads",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedBy",
                table: "Leads",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Leads",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "PendingStatus",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Leads");
        }
    }
}
