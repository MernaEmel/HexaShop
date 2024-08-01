using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HexaShop.Migrations
{
    /// <inheritdoc />
    public partial class uploadimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "products",
                newName: "ImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "products",
                newName: "Image");
        }
    }
}
