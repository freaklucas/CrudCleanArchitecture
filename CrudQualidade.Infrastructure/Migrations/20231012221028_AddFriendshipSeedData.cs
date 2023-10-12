using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudQualidade.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFriendshipSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Friendships",
                columns: new[] { "PersonId1", "PersonId2" },
                values: new object[] { 1, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "PersonId1", "PersonId2" },
                keyValues: new object[] { 1, 2 });
        }
    }
}
