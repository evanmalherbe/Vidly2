using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly2.Data.Migrations
{
    public partial class UpdateMembershipTypeWithNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.UpdateData(
            table: "MembershipType",
            keyColumn: "Id",
            keyValue: 1,
            column: "Name",
            value: "Pay as you go");

           migrationBuilder.UpdateData(
            table: "MembershipType",
            keyColumn: "Id",
            keyValue: 2,
            column: "Name",
            value: "Monthly");

           migrationBuilder.UpdateData(
            table: "MembershipType",
            keyColumn: "Id",
            keyValue: 3,
            column: "Name",
            value: "Quarterly");

           migrationBuilder.UpdateData(
            table: "MembershipType",
            keyColumn: "Id",
            keyValue: 4,
            column: "Name",
            value: "Annually");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
