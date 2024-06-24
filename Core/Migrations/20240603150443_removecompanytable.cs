using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    public partial class removecompanytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripsEvents_Company_CompanyId",
                table: "TripsEvents");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripsEvents",
                table: "TripsEvents");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "TripsEvents");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TripsEvents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripsEvents",
                table: "TripsEvents",
                columns: new[] { "UserId", "RequestId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TripsEvents_AspNetUsers_UserId",
                table: "TripsEvents",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripsEvents_AspNetUsers_UserId",
                table: "TripsEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripsEvents",
                table: "TripsEvents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TripsEvents");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "TripsEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripsEvents",
                table: "TripsEvents",
                columns: new[] { "CompanyId", "RequestId" });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TripsEvents_Company_CompanyId",
                table: "TripsEvents",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
