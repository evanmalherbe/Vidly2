using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly2.Data.Migrations
{
    public partial class PopulateMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.InsertData(
          table: "MembershipType",
          columns: new[] { "Id", "SignUpFee", "DurationInMonths", "DiscountRate" },
          values: new object[,]
          {
              { 1, 0, 0, 0 },
              {2, 30, 1, 10 },
              {3, 90, 3, 15 },
              {4, 300, 12, 20 }
              // Other seed data rows...
          });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
