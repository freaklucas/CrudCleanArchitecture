using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudQualidade.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class friendship2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Peoples_PersonId1",
                table: "Friendships",
                column: "PersonId1",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Peoples_PersonId2",
                table: "Friendships",
                column: "PersonId2",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Peoples_PersonId1",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Peoples_PersonId2",
                table: "Friendships");
        }
    }
}
