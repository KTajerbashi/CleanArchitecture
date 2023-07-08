using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Library.Migrations
{
    /// <inheritdoc />
    public partial class Initial_HasQueryFilter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Role",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 1, 17, 36, 921, DateTimeKind.Local).AddTicks(3139));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Role",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 1, 17, 36, 921, DateTimeKind.Local).AddTicks(3240));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Role",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 1, 17, 36, 921, DateTimeKind.Local).AddTicks(3258));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Role",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 1, 7, 12, 220, DateTimeKind.Local).AddTicks(818));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Role",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 1, 7, 12, 220, DateTimeKind.Local).AddTicks(877));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Role",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 1, 7, 12, 220, DateTimeKind.Local).AddTicks(893));
        }
    }
}
