using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingAPI.Migrations
{
    public partial class ShoppingDatabaseInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productItems",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productItems", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "shoppingItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productID = table.Column<int>(type: "int", nullable: false),
                    orderPrice = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shoppingItems_productItems_productID",
                        column: x => x.productID,
                        principalTable: "productItems",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shoppingItems_productID",
                table: "shoppingItems",
                column: "productID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shoppingItems");

            migrationBuilder.DropTable(
                name: "productItems");
        }
    }
}
