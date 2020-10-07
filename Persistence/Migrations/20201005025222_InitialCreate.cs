using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseIdentities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseIdentities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Presentations",
                columns: table => new
                {
                    PresentationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Schedule = table.Column<DateTime>(nullable: false),
                    SpeakerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentations", x => x.PresentationId);
                    table.ForeignKey(
                        name: "FK_Presentations_BaseIdentities_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "BaseIdentities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Inscription",
                columns: table => new
                {
                    AttendantId = table.Column<int>(nullable: false),
                    PresentationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscription", x => new { x.PresentationId, x.AttendantId });
                    table.ForeignKey(
                        name: "FK_Inscription_BaseIdentities_AttendantId",
                        column: x => x.AttendantId,
                        principalTable: "BaseIdentities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscription_Presentations_PresentationId",
                        column: x => x.PresentationId,
                        principalTable: "Presentations",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseIdentities_Email",
                table: "BaseIdentities",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscription_AttendantId",
                table: "Inscription",
                column: "AttendantId");

            migrationBuilder.CreateIndex(
                name: "IX_Presentations_SpeakerId",
                table: "Presentations",
                column: "SpeakerId",
                unique: true,
                filter: "[SpeakerId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscription");

            migrationBuilder.DropTable(
                name: "Presentations");

            migrationBuilder.DropTable(
                name: "BaseIdentities");
        }
    }
}
