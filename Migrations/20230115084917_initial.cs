using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VersedApi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "commands",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    commandString = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    platform = table.Column<string>(type: "text", nullable: false),
                    createdOn = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_commands", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "commands",
                columns: new[] { "id", "commandString", "createdOn", "description", "platform" },
                values: new object[,]
                {
                    { 1, "dotnet watch run", new DateOnly(2023, 1, 15), "executes dotnet with 'watch' parameter for file changes and reload", "dotnet" },
                    { 2, "dotnet build", new DateOnly(2023, 1, 15), "build the current project/solution", "dotnet" },
                    { 3, "npm init vue@latest", new DateOnly(2023, 1, 15), "start a new vue project", "vuejs" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "commands");
        }
    }
}
