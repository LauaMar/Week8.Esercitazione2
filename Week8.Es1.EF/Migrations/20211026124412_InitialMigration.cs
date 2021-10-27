using Microsoft.EntityFrameworkCore.Migrations;

namespace Week8.Es1.EF.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(maxLength: 6, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    SellingPrice = table.Column<decimal>(nullable: false),
                    BuyingPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BuyingPrice", "Description", "ProductCode", "SellingPrice", "Type" },
                values: new object[] { 1, 1250.00m, "Laptop ASUS", "EL001", 1549.99m, 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BuyingPrice", "Description", "ProductCode", "SellingPrice", "Type" },
                values: new object[] { 2, 10m, "Jeans Levis donna", "ABB001", 49.99m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCode",
                table: "Products",
                column: "ProductCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
