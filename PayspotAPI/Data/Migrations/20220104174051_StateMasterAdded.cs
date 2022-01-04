using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayspotAPI.Data.Migrations
{
    public partial class StateMasterAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "AddressDetail",
                newName: "StateCode");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "AddressDetail",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "AddressDetail",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "StateMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StateName = table.Column<string>(type: "TEXT", nullable: true),
                    StateCode = table.Column<string>(type: "TEXT", nullable: true),
                    GstStateCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMasters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 1, 35, "AN", "Andaman and Nicobar Islands" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 2, 37, "AP", "Andhra Pradesh" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 3, 12, "AR", "Arunachal Pradesh" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 4, 18, "AS", "Assam" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 5, 10, "BR", "Bihar" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 6, 4, "CH", "Chandigarh" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 7, 22, "CG", "Chhattisgarh" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 8, 26, "DN", "Dadra and Nagar Haveli" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 9, 25, "DD", "Daman and Diu" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 10, 7, "DL", "Delhi" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 11, 30, "GA", "Goa" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 12, 24, "GJ", "Gujarat" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 13, 6, "HR", "Haryana" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 14, 2, "HP", "Himachal Pradesh" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 15, 1, "JK", "Jammu and Kashmir" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 16, 20, "JH", "Jharkhand" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 17, 29, "KA", "Karnataka" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 18, 32, "KL", "Kerala" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 19, 38, "LA", "Ladakh" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 20, 31, "LD", "Lakshadweep" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 21, 23, "MP", "Madhya Pradesh" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 22, 27, "MH", "Maharashtra" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 23, 14, "MN", "Manipur" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 24, 17, "ML", "Meghalaya" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 25, 15, "MZ", "Mizoram" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 26, 13, "NL", "Nagaland" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 27, 21, "OR", "Odisha" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 28, 97, "OT", "Other Territory" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 29, 34, "PY", "Puducherry" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 30, 3, "PB", "Punjab" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 31, 8, "RJ", "Rajasthan" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 32, 11, "SK", "Sikkim" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 33, 33, "TN", "Tamil Nadu" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 34, 36, "TS", "Telangana" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 35, 16, "TR", "Tripura" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 36, 9, "UP", "Uttar Pradesh" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 37, 5, "UA", "Uttarakhand" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 38, 19, "WB", "West Bengal" });

            migrationBuilder.InsertData(
                table: "StateMasters",
                columns: new[] { "Id", "GstStateCode", "StateCode", "StateName" },
                values: new object[] { 39, 96, "FC", "Foreign Country	" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StateMasters");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "AddressDetail");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "AddressDetail");

            migrationBuilder.RenameColumn(
                name: "StateCode",
                table: "AddressDetail",
                newName: "State");
        }
    }
}
