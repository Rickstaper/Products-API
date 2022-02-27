using Microsoft.EntityFrameworkCore.Migrations;

namespace Products_API.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4c9e45b-668e-464b-b87f-b369771c1f20", "059d7c57-702d-4aa0-849d-ed6e32b9fb12", "Owner", "OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "66fe050c-f854-4c91-b4f5-49b389d7db7a", "50b1ce37-b6ec-48ae-add3-7b6dcbfe087c", "Guest", "GUEST" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66fe050c-f854-4c91-b4f5-49b389d7db7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4c9e45b-668e-464b-b87f-b369771c1f20");
        }
    }
}
