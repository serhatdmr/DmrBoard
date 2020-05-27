using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DmrBoard.EntityFrameworkCore.Migrations
{
    public partial class UpdateTableOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorUserId",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastModifierUserId",
                table: "Organizations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Organizations");
        }
    }
}
