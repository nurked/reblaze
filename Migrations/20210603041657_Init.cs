using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReBlaze.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Command",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Payload = table.Column<byte[]>(type: "BLOB", nullable: true),
                    ModelID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Command", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Command_Model_ModelID",
                        column: x => x.ModelID,
                        principalTable: "Model",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Port = table.Column<int>(type: "INTEGER", nullable: false),
                    ModelID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Device_Model_ModelID",
                        column: x => x.ModelID,
                        principalTable: "Model",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Command_ModelID",
                table: "Command",
                column: "ModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Device_ModelID",
                table: "Device",
                column: "ModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Command");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "Model");
        }
    }
}
