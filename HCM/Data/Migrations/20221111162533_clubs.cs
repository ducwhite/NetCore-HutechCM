using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HCM.Data.Migrations
{
    public partial class clubs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Managers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(18)",
                oldMaxLength: 18);

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    Time = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Require = table.Column<string>(nullable: false),
                    ClubDetails = table.Column<string>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    ManagerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clubs_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clubs_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_LocationId",
                table: "Clubs",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_ManagerId",
                table: "Clubs",
                column: "ManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Managers",
                type: "nvarchar(18)",
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
