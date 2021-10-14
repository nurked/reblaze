using Microsoft.EntityFrameworkCore.Migrations;

namespace ReBlaze.Migrations
{
    public partial class ModelIdforDevice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_Model_ModelID",
                table: "Device");

            migrationBuilder.RenameColumn(
                name: "ModelID",
                table: "Device",
                newName: "ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Device_ModelID",
                table: "Device",
                newName: "IX_Device_ModelId");

            migrationBuilder.AlterColumn<int>(
                name: "ModelId",
                table: "Device",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Model_ModelId",
                table: "Device",
                column: "ModelId",
                principalTable: "Model",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_Model_ModelId",
                table: "Device");

            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "Device",
                newName: "ModelID");

            migrationBuilder.RenameIndex(
                name: "IX_Device_ModelId",
                table: "Device",
                newName: "IX_Device_ModelID");

            migrationBuilder.AlterColumn<int>(
                name: "ModelID",
                table: "Device",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Model_ModelID",
                table: "Device",
                column: "ModelID",
                principalTable: "Model",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
