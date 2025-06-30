using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infra.SqlServer.Library.Migrations
{
    /// <inheritdoc />
    public partial class Add_Store_Schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Store",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Store",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserRoleId",
                schema: "Store",
                table: "Products",
                type: "bigint",
                maxLength: 50,
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Store",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "UpdatedByUserRoleId",
                schema: "Store",
                table: "Products",
                type: "bigint",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "Store",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Store",
                table: "ProductDetails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Store",
                table: "ProductDetails",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserRoleId",
                schema: "Store",
                table: "ProductDetails",
                type: "bigint",
                maxLength: 50,
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Store",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "UpdatedByUserRoleId",
                schema: "Store",
                table: "ProductDetails",
                type: "bigint",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "Store",
                table: "ProductDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Store",
                table: "ProductComments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Store",
                table: "ProductComments",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserRoleId",
                schema: "Store",
                table: "ProductComments",
                type: "bigint",
                maxLength: 50,
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Store",
                table: "ProductComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "UpdatedByUserRoleId",
                schema: "Store",
                table: "ProductComments",
                type: "bigint",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "Store",
                table: "ProductComments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Store",
                table: "ProductCards",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Store",
                table: "ProductCards",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserRoleId",
                schema: "Store",
                table: "ProductCards",
                type: "bigint",
                maxLength: 50,
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Store",
                table: "ProductCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "UpdatedByUserRoleId",
                schema: "Store",
                table: "ProductCards",
                type: "bigint",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "Store",
                table: "ProductCards",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Store",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Store",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserRoleId",
                schema: "Store",
                table: "Customers",
                type: "bigint",
                maxLength: 50,
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Store",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "UpdatedByUserRoleId",
                schema: "Store",
                table: "Customers",
                type: "bigint",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "Store",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Store",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Store",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserRoleId",
                schema: "Store",
                table: "Categories",
                type: "bigint",
                maxLength: 50,
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Store",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "UpdatedByUserRoleId",
                schema: "Store",
                table: "Categories",
                type: "bigint",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "Store",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Store",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Store",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserRoleId",
                schema: "Store",
                table: "Cards",
                type: "bigint",
                maxLength: 50,
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Store",
                table: "Cards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "UpdatedByUserRoleId",
                schema: "Store",
                table: "Cards",
                type: "bigint",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "Store",
                table: "Cards",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserRoleId",
                schema: "Store",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Store",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserRoleId",
                schema: "Store",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "Store",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedByUserRoleId",
                schema: "Store",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Store",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserRoleId",
                schema: "Store",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "Store",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "CreatedByUserRoleId",
                schema: "Store",
                table: "ProductComments");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Store",
                table: "ProductComments");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserRoleId",
                schema: "Store",
                table: "ProductComments");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "Store",
                table: "ProductComments");

            migrationBuilder.DropColumn(
                name: "CreatedByUserRoleId",
                schema: "Store",
                table: "ProductCards");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Store",
                table: "ProductCards");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserRoleId",
                schema: "Store",
                table: "ProductCards");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "Store",
                table: "ProductCards");

            migrationBuilder.DropColumn(
                name: "CreatedByUserRoleId",
                schema: "Store",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Store",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserRoleId",
                schema: "Store",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "Store",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedByUserRoleId",
                schema: "Store",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Store",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserRoleId",
                schema: "Store",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "Store",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedByUserRoleId",
                schema: "Store",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Store",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserRoleId",
                schema: "Store",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "Store",
                table: "Cards");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Store",
                table: "Products",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Store",
                table: "Products",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Store",
                table: "ProductDetails",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Store",
                table: "ProductDetails",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Store",
                table: "ProductComments",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Store",
                table: "ProductComments",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Store",
                table: "ProductCards",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Store",
                table: "ProductCards",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Store",
                table: "Customers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Store",
                table: "Customers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Store",
                table: "Categories",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Store",
                table: "Categories",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Store",
                table: "Cards",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Store",
                table: "Cards",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);
        }
    }
}
