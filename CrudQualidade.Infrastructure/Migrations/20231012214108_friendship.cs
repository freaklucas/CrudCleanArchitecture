using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudQualidade.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class friendship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    PersonId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonId2 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => new { x.PersonId1, x.PersonId2 });
                    table.ForeignKey(
                        name: "FK_Friendships_Peoples_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Peoples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friendships_Peoples_PersonId2",
                        column: x => x.PersonId2,
                        principalTable: "Peoples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_PersonId2",
                table: "Friendships",
                column: "PersonId2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendships");
        }
    }
}
