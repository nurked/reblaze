using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReBlaze.Migrations
{
    public partial class Changingpayloadtypetostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Payload",
                table: "Command",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Payload",
                table: "Command",
                type: "BLOB",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
