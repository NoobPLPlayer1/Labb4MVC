using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb4MVC.Migrations
{
    public partial class bookInStoreFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InStore",
                table: "Books",
                newName: "AtCustomer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AtCustomer",
                table: "Books",
                newName: "InStore");
        }
    }
}
