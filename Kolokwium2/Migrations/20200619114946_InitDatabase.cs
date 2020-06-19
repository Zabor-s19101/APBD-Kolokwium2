using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium2.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    IdArtist = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.IdArtist);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    IdEvent = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.IdEvent);
                });

            migrationBuilder.CreateTable(
                name: "Organiser",
                columns: table => new
                {
                    IdOrganiser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organiser", x => x.IdOrganiser);
                });

            migrationBuilder.CreateTable(
                name: "Artist_Event",
                columns: table => new
                {
                    IdEvent = table.Column<int>(nullable: false),
                    IdArtist = table.Column<int>(nullable: false),
                    PerformanceDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist_Event", x => new { x.IdEvent, x.IdArtist });
                    table.ForeignKey(
                        name: "FK_Artist_Event_Artist_IdArtist",
                        column: x => x.IdArtist,
                        principalTable: "Artist",
                        principalColumn: "IdArtist",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artist_Event_Event_IdEvent",
                        column: x => x.IdEvent,
                        principalTable: "Event",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event_Organiser",
                columns: table => new
                {
                    IdEvent = table.Column<int>(nullable: false),
                    IdOrganiser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Organiser", x => new { x.IdEvent, x.IdOrganiser });
                    table.ForeignKey(
                        name: "FK_Event_Organiser_Event_IdEvent",
                        column: x => x.IdEvent,
                        principalTable: "Event",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Organiser_Organiser_IdOrganiser",
                        column: x => x.IdOrganiser,
                        principalTable: "Organiser",
                        principalColumn: "IdOrganiser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "IdArtist", "Nickname" },
                values: new object[,]
                {
                    { 1, "Zabor" },
                    { 2, "Adaś" },
                    { 3, "Krzychu" },
                    { 4, "Ela" },
                    { 5, "Eminem" }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "IdEvent", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Połowinki", new DateTime(2020, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Woodstock", new DateTime(2021, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2019, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wixapol", new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2020, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Skrra", new DateTime(2020, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2020, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Impreza", new DateTime(2020, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Organiser",
                columns: new[] { "IdOrganiser", "Name" },
                values: new object[,]
                {
                    { 1, "MTV" },
                    { 2, "Szkoła" },
                    { 3, "TVP" },
                    { 4, "TVN" },
                    { 5, "Wixapol" }
                });

            migrationBuilder.InsertData(
                table: "Artist_Event",
                columns: new[] { "IdEvent", "IdArtist", "PerformanceDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 5, new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 5, new DateTime(2020, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 3, new DateTime(2020, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, new DateTime(2020, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Event_Organiser",
                columns: new[] { "IdEvent", "IdOrganiser" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 4, 4 },
                    { 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artist_Event_IdArtist",
                table: "Artist_Event",
                column: "IdArtist");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Organiser_IdOrganiser",
                table: "Event_Organiser",
                column: "IdOrganiser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artist_Event");

            migrationBuilder.DropTable(
                name: "Event_Organiser");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Organiser");
        }
    }
}
