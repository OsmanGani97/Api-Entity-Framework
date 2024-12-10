using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace evipractice.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Skill = table.Column<int>(type: "int", nullable: false),
                    PayRate = table.Column<decimal>(type: "money", nullable: false),
                    HireDate = table.Column<DateTime>(type: "date", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.WorkerId);
                });

            migrationBuilder.CreateTable(
                name: "WorkLogs",
                columns: table => new
                {
                    WorkLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkLogs", x => x.WorkLogId);
                    table.ForeignKey(
                        name: "FK_WorkLogs_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "WorkerId", "ContactNo", "HireDate", "IsActive", "Name", "PayRate", "Picture", "Skill" },
                values: new object[,]
                {
                    { 1, "01710XXXXXX", new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Abul H", 1000m, "e1.jpg", 1 },
                    { 2, "01910XXXXXX", new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Belayet H", 1000m, "e2.jpg", 2 },
                    { 3, "01610XXXXXX", new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Kamrul I", 1000m, "e3.jpg", 3 },
                    { 4, "01710XXXXXX", new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Jubayer H", 1000m, "e4.jpg", 4 },
                    { 5, "01710XXXXXX", new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Imran H", 1000m, "e5.jpg", 5 },
                    { 6, "01710XXXXXX", new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Kedus H", 1000m, "e4.jpg", 5 }
                });

            migrationBuilder.InsertData(
                table: "WorkLogs",
                columns: new[] { "WorkLogId", "Description", "EndDate", "StartDate", "WorkerId" },
                values: new object[,]
                {
                    { 1, "Uttara prject Boundary wall", new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Plustering Baridhara project", null, new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkLogs_WorkerId",
                table: "WorkLogs",
                column: "WorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkLogs");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
