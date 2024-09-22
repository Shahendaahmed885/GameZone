using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameZone.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    cover = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    categoryid = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gamedevices",
                columns: table => new
                {
                    gameid = table.Column<int>(type: "int", nullable: false),
                    devicesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gamedevices", x => new { x.gameid, x.devicesid });
                    table.ForeignKey(
                        name: "FK_gamedevices_Games_gameid",
                        column: x => x.gameid,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gamedevices_devices_devicesid",
                        column: x => x.devicesid,
                        principalTable: "devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "sports" },
                    { 2, "action" },
                    { 3, "adventure" },
                    { 4, "racing" },
                    { 5, "fighting" },
                    { 6, "film" }
                });

            migrationBuilder.InsertData(
                table: "devices",
                columns: new[] { "Id", "Name", "icon" },
                values: new object[,]
                {
                    { 1, "playstation", "bi bi-playstation" },
                    { 2, "xbox", "bi bi-xbox" },
                    { 3, "nintendo switch", "bi bi-nintendo-switch" },
                    { 4, "pc", "bi bi-display" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_gamedevices_devicesid",
                table: "gamedevices",
                column: "devicesid");

            migrationBuilder.CreateIndex(
                name: "IX_Games_categoryid",
                table: "Games",
                column: "categoryid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gamedevices");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "devices");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
