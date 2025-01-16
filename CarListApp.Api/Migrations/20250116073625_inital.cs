using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarListApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Make = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Vin = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Make", "Model", "Vin" },
                values: new object[,]
                {
                    { 1, "Volvo", "Q7", "123" },
                    { 2, "Benz", "GLE", "456" },
                    { 3, "Audi", "A6", "789" },
                    { 4, "BMW", "X5", "012" },
                    { 5, "RangeRover", "Velar", "345" },
                    { 6, "Jaguar", "XE", "678" },
                    { 7, "Suzuki", "Swift", "951" },
                    { 8, "Honda", "Amaze", "753" },
                    { 9, "Tata", "Punch", "456" },
                    { 10, "Mahindra", "Thar", "555" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
