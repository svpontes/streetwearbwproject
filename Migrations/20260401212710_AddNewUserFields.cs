using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreetTshirtApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNewUserFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Users",
                newName: "ZipCode");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Users",
                newName: "PostalCode");
        }
    }
}
