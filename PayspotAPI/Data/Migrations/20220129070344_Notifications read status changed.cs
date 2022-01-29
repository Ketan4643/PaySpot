using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayspotAPI.Data.Migrations
{
    public partial class Notificationsreadstatuschanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Notifications",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Notifications");
        }
    }
}
