using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Products_API.Migrations
{
    public partial class AddedImageColumnForPoduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PoductId",
                table: "products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FidgeId",
                table: "Fridges",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FridgeProductsId",
                table: "fridge_products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FridgeModelId",
                table: "fridge_model",
                newName: "Id");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "products",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products",
                newName: "PoductId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Fridges",
                newName: "FidgeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "fridge_products",
                newName: "FridgeProductsId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "fridge_model",
                newName: "FridgeModelId");
        }
    }
}
