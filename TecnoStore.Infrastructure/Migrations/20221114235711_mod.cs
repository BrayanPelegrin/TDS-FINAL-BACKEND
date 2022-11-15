using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TecnoStore.Infrastructure.Migrations
{
    public partial class mod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 57, 11, 233, DateTimeKind.Local).AddTicks(5821));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 57, 11, 233, DateTimeKind.Local).AddTicks(5823));

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 57, 11, 233, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 57, 11, 233, DateTimeKind.Local).AddTicks(8029));

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 57, 11, 233, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 57, 11, 233, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 57, 11, 233, DateTimeKind.Local).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 57, 11, 233, DateTimeKind.Local).AddTicks(9631));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 57, 11, 233, DateTimeKind.Local).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 57, 11, 233, DateTimeKind.Local).AddTicks(9634));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 57, 11, 233, DateTimeKind.Local).AddTicks(9635));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 57, 11, 233, DateTimeKind.Local).AddTicks(9637));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 54, 56, 717, DateTimeKind.Local).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 54, 56, 717, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 54, 56, 717, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 54, 56, 717, DateTimeKind.Local).AddTicks(5082));

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 54, 56, 717, DateTimeKind.Local).AddTicks(5083));

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 54, 56, 717, DateTimeKind.Local).AddTicks(5084));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 54, 56, 717, DateTimeKind.Local).AddTicks(7687));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 54, 56, 717, DateTimeKind.Local).AddTicks(7692));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 54, 56, 717, DateTimeKind.Local).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 54, 56, 717, DateTimeKind.Local).AddTicks(7696));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 54, 56, 717, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreo",
                value: new DateTime(2022, 11, 14, 19, 54, 56, 717, DateTimeKind.Local).AddTicks(7700));
        }
    }
}
