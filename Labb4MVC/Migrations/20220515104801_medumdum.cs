using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb4MVC.Migrations
{
    public partial class medumdum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtCustomer",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AtCustomer",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
