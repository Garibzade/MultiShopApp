using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.Migrations
{
    /// <inheritdoc />
    public partial class CreateVM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDelete",
                table: "Categories",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Categories",
                newName: "CreateDateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Categories",
                newName: "isDelete");

            migrationBuilder.RenameColumn(
                name: "CreateDateTime",
                table: "Categories",
                newName: "DateTime");
        }
    }
}
