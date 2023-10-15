using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CrudQualidade.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPostTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PeopleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    DatePost = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Peoples_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "Peoples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "DatePost", "PeopleId" },
                values: new object[,]
                {
                    { 1, "Primeira postagem de Lucas :)", new DateTime(2023, 10, 14, 0, 19, 8, 669, DateTimeKind.Local).AddTicks(2012), 1 },
                    { 2, "Márcia disse que Deus está vivo <3", new DateTime(2023, 10, 14, 0, 19, 8, 669, DateTimeKind.Local).AddTicks(2026), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PeopleId",
                table: "Posts",
                column: "PeopleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
