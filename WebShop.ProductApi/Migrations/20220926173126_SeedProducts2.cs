using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.ProductApi.Migrations
{
    public partial class SeedProducts2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO " +
                "products" +
                "(Name, Price, Description, Inventory, ImageURL, CategoryID) " +
                "VALUES" +
                "('Book', 7.55, 'Green book', 10, 'greenBook.jpg', 1)"
                );
            migrationBuilder.Sql(
                "INSERT INTO " +
                "products" +
                "(Name, Price, Description, Inventory, ImageURL, CategoryID) " +
                "VALUES" +
                "('Pen', 1.55, 'Blue Pen', 20, 'bluePen.jpg', 1)"
                );
            migrationBuilder.Sql(
                "INSERT INTO " +
                "products" +
                "(Name, Price, Description, Inventory, ImageURL, CategoryID) " +
                "VALUES" +
                "('Notepad', 3.55, 'Blank notepad', 11, 'notepad.jpg', 2)"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
