using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Products_API.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fridge_model",
                columns: table => new
                {
                    FridgeModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fridge_model", x => x.FridgeModelId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    PoductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.PoductId);
                });

            migrationBuilder.CreateTable(
                name: "Fridges",
                columns: table => new
                {
                    FidgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridges", x => x.FidgeId);
                    table.ForeignKey(
                        name: "FK_Fridges_fridge_model_Model_id",
                        column: x => x.Model_id,
                        principalTable: "fridge_model",
                        principalColumn: "FridgeModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fridge_products",
                columns: table => new
                {
                    FridgeProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FridgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fridge_products", x => x.FridgeProductsId);
                    table.ForeignKey(
                        name: "FK_fridge_products_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "FidgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fridge_products_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "PoductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fridge_products_FridgeId",
                table: "fridge_products",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_fridge_products_ProductId",
                table: "fridge_products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_Model_id",
                table: "Fridges",
                column: "Model_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fridge_products");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "fridge_model");
        }
    }
}
