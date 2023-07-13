using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Library.Migrations
{
    /// <inheritdoc />
    public partial class update_homePageImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Role",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 13, 23, 56, 3, 390, DateTimeKind.Local).AddTicks(6808));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Role",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 13, 23, 56, 3, 390, DateTimeKind.Local).AddTicks(6888));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Role",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 13, 23, 56, 3, 390, DateTimeKind.Local).AddTicks(6909));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Role",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 12, 22, 54, 0, 735, DateTimeKind.Local).AddTicks(8826));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Role",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 12, 22, 54, 0, 735, DateTimeKind.Local).AddTicks(8998));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Role",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 12, 22, 54, 0, 735, DateTimeKind.Local).AddTicks(9015));
        }
    }
}
