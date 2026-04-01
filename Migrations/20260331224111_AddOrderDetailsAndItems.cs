using Microsoft.EntityFrameworkCore.Migrations;
using StreetTshirtApp.Data;
#nullable disable

namespace StreetTshirtApp.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderDetailsAndItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerializedItems",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerializedItems",
                table: "Orders");
        }
    }
}
