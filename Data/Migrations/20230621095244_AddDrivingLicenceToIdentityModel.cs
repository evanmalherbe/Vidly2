using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly2.Data.Migrations
{
    public partial class AddDrivingLicenceToIdentityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DrivingLicence",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrivingLicence",
                table: "AspNetUsers");
        }
    }
}
