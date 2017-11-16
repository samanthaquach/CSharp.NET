using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Wedding_Planner.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    confirm = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    firstname = table.Column<string>(nullable: false),
                    lastname = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "planning",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Userid = table.Column<int>(nullable: false),
                    address = table.Column<string>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    wedderone = table.Column<string>(nullable: false),
                    weddertwo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planning", x => x.id);
                    table.ForeignKey(
                        name: "FK_planning_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RSVP",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Planningid = table.Column<int>(nullable: false),
                    Userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RSVP", x => x.id);
                    table.ForeignKey(
                        name: "FK_RSVP_planning_Planningid",
                        column: x => x.Planningid,
                        principalTable: "planning",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RSVP_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_planning_Userid",
                table: "planning",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_RSVP_Planningid",
                table: "RSVP",
                column: "Planningid");

            migrationBuilder.CreateIndex(
                name: "IX_RSVP_Userid",
                table: "RSVP",
                column: "Userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RSVP");

            migrationBuilder.DropTable(
                name: "planning");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
