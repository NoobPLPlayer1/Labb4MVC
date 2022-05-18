using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb4MVC.Migrations
{
    public partial class timespan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "LendPeriods");

            migrationBuilder.AddColumn<int>(
                name: "Days",
                table: "LendPeriods",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Days",
                table: "LendPeriods");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "LendPeriods",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
