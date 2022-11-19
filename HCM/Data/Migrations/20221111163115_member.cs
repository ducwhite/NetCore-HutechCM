using Microsoft.EntityFrameworkCore.Migrations;

namespace HCM.Data.Migrations
{
    public partial class member : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: false),
                    StudentNumber = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    ClubId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_ClubId",
                table: "Members",
                column: "ClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
