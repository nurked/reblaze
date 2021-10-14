using Microsoft.EntityFrameworkCore.Migrations;

namespace ReBlaze.Migrations
{
    public partial class Navigationproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Command_Model_ModelID",
                table: "Command");

            migrationBuilder.DropForeignKey(
                name: "FK_Device_Model_ModelID",
                table: "Device");

            migrationBuilder.AlterColumn<int>(
                name: "ModelID",
                table: "Device",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ModelID",
                table: "Command",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Command_Model_ModelID",
                table: "Command",
                column: "ModelID",
                principalTable: "Model",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Model_ModelID",
                table: "Device",
                column: "ModelID",
                principalTable: "Model",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Command_Model_ModelID",
                table: "Command");

            migrationBuilder.DropForeignKey(
                name: "FK_Device_Model_ModelID",
                table: "Device");

            migrationBuilder.AlterColumn<int>(
                name: "ModelID",
                table: "Device",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModelID",
                table: "Command",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Command_Model_ModelID",
                table: "Command",
                column: "ModelID",
                principalTable: "Model",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Model_ModelID",
                table: "Device",
                column: "ModelID",
                principalTable: "Model",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
