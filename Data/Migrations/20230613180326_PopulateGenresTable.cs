using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly2.Data.Migrations
{
    public partial class PopulateGenresTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.InsertData(
            table: "Genres",
            columns: new[] { "Id", "Name" },
            values: new object[,]
            {
                {1, "Action" },
                {2, "Comedy" },
                {3, "Drama" },
                {4, "Thriller" },
                {5, "Horror" }
                // Other seed data rows...
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
