using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLAdvanced.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("1ece43db-bcce-4b1a-bd1a-1387938caaa6"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("8f176a63-bc68-496c-b3a9-bde32939ea9c"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("f6beea8c-11ef-43f4-9474-40fde8b855c3"));

            migrationBuilder.DeleteData(
                table: "owners",
                keyColumn: "id",
                keyValue: new Guid("1a5af26f-6ba0-4706-b8fc-402ccdb71fa6"));

            migrationBuilder.DeleteData(
                table: "owners",
                keyColumn: "id",
                keyValue: new Guid("8e1caea5-569d-4dff-b41d-4b69cfdca5fe"));

            migrationBuilder.InsertData(
                table: "owners",
                columns: new[] { "id", "address", "name" },
                values: new object[,]
                {
                    { new Guid("b048ec5c-2fab-4afe-83f2-aedaffe5c44c"), "John Doe's address", "John Doe" },
                    { new Guid("7cc88ce6-3418-42c4-b83d-bae1dc4819d1"), "Jane Doe's address", "Jane Doe" }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "description", "ownerId", "name" },
                values: new object[,]
                {
                    { new Guid("8e9aaae3-280f-4170-875c-ea1d473d1df9"), "Cash account for our users", new Guid("b048ec5c-2fab-4afe-83f2-aedaffe5c44c"), 0 },
                    { new Guid("e4662e74-fd5f-4b38-8b82-ff1e0981fec7"), "Savings account for our users", new Guid("7cc88ce6-3418-42c4-b83d-bae1dc4819d1"), 1 },
                    { new Guid("bb491f40-e532-43c5-ba09-fc408848f83c"), "Income account for our users", new Guid("7cc88ce6-3418-42c4-b83d-bae1dc4819d1"), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("8e9aaae3-280f-4170-875c-ea1d473d1df9"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("bb491f40-e532-43c5-ba09-fc408848f83c"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("e4662e74-fd5f-4b38-8b82-ff1e0981fec7"));

            migrationBuilder.DeleteData(
                table: "owners",
                keyColumn: "id",
                keyValue: new Guid("7cc88ce6-3418-42c4-b83d-bae1dc4819d1"));

            migrationBuilder.DeleteData(
                table: "owners",
                keyColumn: "id",
                keyValue: new Guid("b048ec5c-2fab-4afe-83f2-aedaffe5c44c"));

            migrationBuilder.InsertData(
                table: "owners",
                columns: new[] { "id", "address", "name" },
                values: new object[,]
                {
                    { new Guid("1a5af26f-6ba0-4706-b8fc-402ccdb71fa6"), "John Doe's address", "John Doe" },
                    { new Guid("8e1caea5-569d-4dff-b41d-4b69cfdca5fe"), "Jane Doe's address", "Jane Doe" }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "description", "ownerId", "name" },
                values: new object[,]
                {
                    { new Guid("8f176a63-bc68-496c-b3a9-bde32939ea9c"), "Cash account for our users", new Guid("1a5af26f-6ba0-4706-b8fc-402ccdb71fa6"), 0 },
                    { new Guid("1ece43db-bcce-4b1a-bd1a-1387938caaa6"), "Savings account for our users", new Guid("8e1caea5-569d-4dff-b41d-4b69cfdca5fe"), 1 },
                    { new Guid("f6beea8c-11ef-43f4-9474-40fde8b855c3"), "Income account for our users", new Guid("8e1caea5-569d-4dff-b41d-4b69cfdca5fe"), 3 }
                });
        }
    }
}
