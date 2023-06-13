using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly2.Data.Migrations
{
    public partial class AddDatesToBirthdateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

          migrationBuilder.UpdateData(
            table: "Customers",
            keyColumn: "Id",
            keyValue: 1,
            column: "Birthdate",
            value: new DateTime(1983,01,02));

           migrationBuilder.UpdateData(
             table: "Customers",
             keyColumn: "Id",
             keyValue: 2,
             column: "Birthdate",
             value: null);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
