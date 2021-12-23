using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Webgentle.Bookstore.Migrations
{
    public partial class add2Columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Books");
        }
    }
}
