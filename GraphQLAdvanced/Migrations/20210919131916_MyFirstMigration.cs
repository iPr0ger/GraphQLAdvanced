using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLAdvanced.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "owners",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    ownerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_accounts_owners_ownerId",
                        column: x => x.ownerId,
                        principalTable: "owners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_accounts_ownerId",
                table: "accounts",
                column: "ownerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "owners");
        }
    }
}
