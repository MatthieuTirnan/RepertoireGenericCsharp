using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstGenericRepository.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class addRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dd33333b-b5b8-4ce7-8882-bd803e486fda"));

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[] { new Guid("4da1f869-64c3-468e-893e-9c8ec99185b2"), "AdminPassword", 0, "AdminMail" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4da1f869-64c3-468e-893e-9c8ec99185b2"));

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { new Guid("dd33333b-b5b8-4ce7-8882-bd803e486fda"), "AdminPassword", "AdminMail" });
        }
    }
}
