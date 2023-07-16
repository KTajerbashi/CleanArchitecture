using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Library.Migrations
{
    /// <inheritdoc />
    public partial class ApplyConfurationEFCore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 16, 23, 58, 10, 150, DateTimeKind.Local).AddTicks(3425));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 16, 23, 58, 10, 150, DateTimeKind.Local).AddTicks(3454));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 16, 23, 58, 10, 150, DateTimeKind.Local).AddTicks(3458));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 16, 23, 19, 41, 250, DateTimeKind.Local).AddTicks(5629));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 16, 23, 19, 41, 250, DateTimeKind.Local).AddTicks(5673));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 16, 23, 19, 41, 250, DateTimeKind.Local).AddTicks(5709));
        }
    }
}
