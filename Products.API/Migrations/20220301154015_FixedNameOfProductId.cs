using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Products_API.Migrations
{
    public partial class FixedNameOfProductId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66fe050c-f854-4c91-b4f5-49b389d7db7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4c9e45b-668e-464b-b87f-b369771c1f20");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products",
                newName: "ProductId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3463f783-7555-452e-9c54-b6d35486b716", "73849494-d849-4879-a888-ae0dda971845", "Owner", "OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39f03057-7363-479b-aea8-d286e6d7e8c9", "4b1450bf-1648-484a-8046-4e912a132dc3", "Guest", "GUEST" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "DefaultQuantity", "Image", "Name" },
                values: new object[] { new Guid("9f490a70-94ce-4d15-9494-5248280c2ce3"), 10, null, "Cheese" });

            migrationBuilder.InsertData(
                table: "fridge_products",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[] { new Guid("3a130a10-22ce-4d15-9494-5248780c2ce1"), new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"), new Guid("9f490a70-94ce-4d15-9494-5248280c2ce3"), 0 });

            migrationBuilder.InsertData(
                table: "fridge_products",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[] { new Guid("3b130a10-22ce-4d15-9494-5248780c2ce1"), new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"), new Guid("9f490a70-94ce-4d15-9494-5248280c2ce3"), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3463f783-7555-452e-9c54-b6d35486b716");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39f03057-7363-479b-aea8-d286e6d7e8c9");

            migrationBuilder.DeleteData(
                table: "fridge_products",
                keyColumn: "Id",
                keyValue: new Guid("3a130a10-22ce-4d15-9494-5248780c2ce1"));

            migrationBuilder.DeleteData(
                table: "fridge_products",
                keyColumn: "Id",
                keyValue: new Guid("3b130a10-22ce-4d15-9494-5248780c2ce1"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: new Guid("9f490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "products",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4c9e45b-668e-464b-b87f-b369771c1f20", "059d7c57-702d-4aa0-849d-ed6e32b9fb12", "Owner", "OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "66fe050c-f854-4c91-b4f5-49b389d7db7a", "50b1ce37-b6ec-48ae-add3-7b6dcbfe087c", "Guest", "GUEST" });
        }
    }
}
