using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phonebook.SpyrosZoupas.Migrations
{
    /// <inheritdoc />
    public partial class categorynameisunique2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nameTest",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nameTest",
                table: "Categories");
        }
    }
}
