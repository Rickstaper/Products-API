using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Products_API.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "fridge_model",
                columns: new[] { "FridgeModelId", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("5f390a10-94ce-4d15-9494-5248780c2ce3"), "SAMSUNG 253 L Frost Free Double Door 3 Star Convertible Refrigerator  (Elegant Inox, RT28T3743S8/HL)", 2020 },
                    { new Guid("1b240a10-22ce-4d15-9494-5248780c2ce1"), "Whirlpool 240 L Frost Free Triple Door Refrigerator  (Magnum Steel, FP 263D PROTTON ROY MAGNUM STEEL(N))", 2020 }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "PoductId", "DefaultQuantity", "Name" },
                values: new object[,]
                {
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 3, "Butter" },
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), 0, "Apple" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "FidgeId", "Model_id", "Name", "Owner_name" },
                values: new object[] { new Guid("6b572a70-94ce-4d15-9494-5248280c2ce3"), new Guid("5f390a10-94ce-4d15-9494-5248780c2ce3"), "My fridge", "Anton Pupkin" });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "FidgeId", "Model_id", "Name", "Owner_name" },
                values: new object[] { new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"), new Guid("1b240a10-22ce-4d15-9494-5248780c2ce1"), "JJ", "Artem Petrov" });

            migrationBuilder.InsertData(
                table: "fridge_products",
                columns: new[] { "FridgeProductsId", "FridgeId", "ProductId", "Quantity" },
                values: new object[] { new Guid("7f330a10-22ce-4d15-9494-5248780c2ce1"), new Guid("6b572a70-94ce-4d15-9494-5248280c2ce3"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 2 });

            migrationBuilder.InsertData(
                table: "fridge_products",
                columns: new[] { "FridgeProductsId", "FridgeId", "ProductId", "Quantity" },
                values: new object[] { new Guid("6f130a10-22ce-4d15-9494-5248780c2ce1"), new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "fridge_products",
                keyColumn: "FridgeProductsId",
                keyValue: new Guid("6f130a10-22ce-4d15-9494-5248780c2ce1"));

            migrationBuilder.DeleteData(
                table: "fridge_products",
                keyColumn: "FridgeProductsId",
                keyValue: new Guid("7f330a10-22ce-4d15-9494-5248780c2ce1"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "FidgeId",
                keyValue: new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "FidgeId",
                keyValue: new Guid("6b572a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "PoductId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "PoductId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DeleteData(
                table: "fridge_model",
                keyColumn: "FridgeModelId",
                keyValue: new Guid("1b240a10-22ce-4d15-9494-5248780c2ce1"));

            migrationBuilder.DeleteData(
                table: "fridge_model",
                keyColumn: "FridgeModelId",
                keyValue: new Guid("5f390a10-94ce-4d15-9494-5248780c2ce3"));
        }
    }
}
