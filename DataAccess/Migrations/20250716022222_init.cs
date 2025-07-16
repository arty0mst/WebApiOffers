using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiOffer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), "GermanCarsGroup" },
                    { 2, new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), "UsaCarsGroup" },
                    { 3, new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), "UkCarsGroup" },
                    { 4, new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), "JapanCarsGroup" },
                    { 5, new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), "RuCarsGroup" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Brand", "Model", "RegistrationDate", "SupplierId" },
                values: new object[,]
                {
                    { 1, "BMW", "530d", new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 2, "BMW", "320i", new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 3, "BMW", "M2", new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 4, "BMW", "640i", new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 5, "BMW", "750Ld", new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 6, "Porsche", "Panamera", new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 7, "Porsche", "Cayenne", new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 8, "Ford", "Mustang", new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 9, "Dodge", "Challenger", new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 10, "Dodge", "Charger", new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 11, "Land Rover", "Range Rover Velar", new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 12, "Land Rover", "Range Rove Sport", new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 13, "Toyota", "Land Cruiser 300", new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 14, "LiXiang", "L9", new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), 5 },
                    { 15, "LiXiang", "L7", new DateTime(2025, 7, 16, 12, 0, 0, 0, DateTimeKind.Utc), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_SupplierId",
                table: "Offers",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
