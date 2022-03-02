using Microsoft.EntityFrameworkCore.Migrations;

namespace Products_API.Migrations
{
    public partial class AddedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3463f783-7555-452e-9c54-b6d35486b716");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39f03057-7363-479b-aea8-d286e6d7e8c9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "481940e0-2ecd-40cf-af85-76c2bc7ef4a2", "8d65f300-e5c9-4d37-ac8c-1e187c3da3d0", "Owner", "OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e672d87-cfe5-495a-a215-0d4c9716535e", "49c3ec49-dd48-4667-818a-6899a04cd805", "Guest", "GUEST" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e672d87-cfe5-495a-a215-0d4c9716535e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "481940e0-2ecd-40cf-af85-76c2bc7ef4a2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3463f783-7555-452e-9c54-b6d35486b716", "73849494-d849-4879-a888-ae0dda971845", "Owner", "OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39f03057-7363-479b-aea8-d286e6d7e8c9", "4b1450bf-1648-484a-8046-4e912a132dc3", "Guest", "GUEST" });
        }
    }
}
