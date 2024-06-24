using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    public partial class AddRealtionOneTOManyWithChildBirthDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BirthdayParty_ChildId",
                table: "BirthdayParty");

            migrationBuilder.CreateIndex(
                name: "IX_BirthdayParty_ChildId",
                table: "BirthdayParty",
                column: "ChildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BirthdayParty_ChildId",
                table: "BirthdayParty");

            migrationBuilder.CreateIndex(
                name: "IX_BirthdayParty_ChildId",
                table: "BirthdayParty",
                column: "ChildId",
                unique: true);
        }
    }
}
