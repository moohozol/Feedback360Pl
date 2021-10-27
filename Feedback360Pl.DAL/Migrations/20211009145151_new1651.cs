using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedbackReport.DAL.Migrations
{
    public partial class new1651 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "Scales",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Scales",
                newName: "CreatedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Scales",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Scales",
                newName: "Created");
        }
    }
}
