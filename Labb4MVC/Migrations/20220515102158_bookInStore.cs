using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb4MVC.Migrations
{
    public partial class bookInStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InStore",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InStore",
                table: "Books");
        }
    }
}
