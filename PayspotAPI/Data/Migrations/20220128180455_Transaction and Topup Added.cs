using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayspotAPI.Data.Migrations
{
    public partial class TransactionandTopupAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Mode = table.Column<string>(type: "TEXT", nullable: true),
                    AgentId = table.Column<string>(type: "TEXT", nullable: true),
                    TransactionDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TransactionId = table.Column<string>(type: "TEXT", nullable: true),
                    RequestId = table.Column<string>(type: "TEXT", nullable: true),
                    Utility = table.Column<string>(type: "TEXT", nullable: true),
                    UtilitySubType = table.Column<string>(type: "TEXT", nullable: true),
                    UtilityPartner = table.Column<string>(type: "TEXT", nullable: true),
                    BaseAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    CustomerFee = table.Column<decimal>(type: "TEXT", nullable: false),
                    TransactionType = table.Column<string>(type: "TEXT", nullable: true),
                    DistributorId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompletedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updatedby = table.Column<string>(type: "TEXT", nullable: true),
                    RequestJson = table.Column<string>(type: "TEXT", nullable: true),
                    ResponseJson = table.Column<string>(type: "TEXT", nullable: true),
                    TransactionStatusCode = table.Column<int>(type: "INTEGER", nullable: false),
                    TransactionStatus = table.Column<string>(type: "TEXT", nullable: true),
                    OpeningBalance = table.Column<decimal>(type: "TEXT", nullable: false),
                    ClosingBalance = table.Column<decimal>(type: "TEXT", nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDb", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionDb");
        }
    }
}
