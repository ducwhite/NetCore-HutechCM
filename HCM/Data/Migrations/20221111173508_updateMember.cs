using Microsoft.EntityFrameworkCore.Migrations;

namespace HCM.Data.Migrations
{
    public partial class updateMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccecpt",
                table: "Members",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccecpt",
                table: "Members");
        }
    }
}
