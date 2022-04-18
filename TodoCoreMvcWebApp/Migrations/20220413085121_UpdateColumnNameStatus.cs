using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoCoreMvcWebApp.Migrations
{
    public partial class UpdateColumnNameStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "intStatus",
                table: "Tasks",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tasks",
                newName: "intStatus");
        }
    }
}
