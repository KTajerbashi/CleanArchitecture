using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Library.Migrations
{
    /// <inheritdoc />
    public partial class AuthorityNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Authority",
                schema: "Pay",
                table: "RequestPays",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 15, 1, 5, 11, 890, DateTimeKind.Local).AddTicks(5089));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 15, 1, 5, 11, 890, DateTimeKind.Local).AddTicks(5131));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 15, 1, 5, 11, 890, DateTimeKind.Local).AddTicks(5143));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Authority",
                schema: "Pay",
                table: "RequestPays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 14, 1, 16, 18, 151, DateTimeKind.Local).AddTicks(5773));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 14, 1, 16, 18, 151, DateTimeKind.Local).AddTicks(5821));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 14, 1, 16, 18, 151, DateTimeKind.Local).AddTicks(5831));
        }
    }
}
