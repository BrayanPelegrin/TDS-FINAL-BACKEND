using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TecnoStore.Infrastructure.Migrations
{
    public partial class applicationuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreCompleto",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 13, 0, 30, 40, 476, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 13, 0, 30, 40, 476, DateTimeKind.Local).AddTicks(4619));

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 13, 0, 30, 40, 476, DateTimeKind.Local).AddTicks(4622));

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 13, 0, 30, 40, 476, DateTimeKind.Local).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 13, 0, 30, 40, 476, DateTimeKind.Local).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 13, 0, 30, 40, 476, DateTimeKind.Local).AddTicks(6008));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreCompleto",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 12, 16, 43, 34, 753, DateTimeKind.Local).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 12, 16, 43, 34, 753, DateTimeKind.Local).AddTicks(7105));

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 12, 16, 43, 34, 753, DateTimeKind.Local).AddTicks(7109));

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 12, 16, 43, 34, 753, DateTimeKind.Local).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 12, 16, 43, 34, 753, DateTimeKind.Local).AddTicks(7111));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 12, 16, 43, 34, 753, DateTimeKind.Local).AddTicks(9588));
        }
    }
}
