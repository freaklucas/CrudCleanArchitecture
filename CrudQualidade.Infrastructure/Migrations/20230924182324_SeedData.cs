using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CrudQualidade.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Peoples",
                columns: new[] { "Id", "Age", "City", "Email", "LastName", "Name", "NumberPhone" },
                values: new object[,]
                {
                    { 1, 25, "Rio Verde", "lucas@email.com", "Oliveira", "Lucas", "64123456879" },
                    { 2, 44, "Rio Verde", "marcia@email.com", "Oliveira", "Márcia", "64123412342" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Peoples",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Peoples",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
