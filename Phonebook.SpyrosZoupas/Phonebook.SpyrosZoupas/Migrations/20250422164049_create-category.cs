using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phonebook.SpyrosZoupas.Migrations
{
    /// <inheritdoc />
    public partial class createcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contacts",
                newName: "ContactId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CategoryId",
                table: "Contacts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Name",
                table: "Contacts",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Categories_CategoryId",
                table: "Contacts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Categories_CategoryId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CategoryId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_Name",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "Contacts",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
