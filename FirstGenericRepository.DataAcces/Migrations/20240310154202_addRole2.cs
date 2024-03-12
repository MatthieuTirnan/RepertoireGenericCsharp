using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstGenericRepository.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class addRole2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4da1f869-64c3-468e-893e-9c8ec99185b2"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[] { new Guid("4da1f869-64c3-468e-893e-9c8ec99185b2"), "AdminPassword", 0, "AdminMail" });
        }
    }
}
