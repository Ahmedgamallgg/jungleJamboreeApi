using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    public partial class dropIndexOnCampChild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
            name: "IX_ChildCamps_CampId",
            table: "ChildCamps");

            migrationBuilder.DropIndex(
                name: "IX_ChildCamps_ChildId",
                table: "ChildCamps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ChildCamps_CampId",
                table: "ChildCamps",
                column: "CampId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChildCamps_ChildId",
                table: "ChildCamps",
                column: "ChildId",
                unique: true);
        }
    }
}
