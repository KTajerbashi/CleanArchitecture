using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Library.Migrations
{
    /// <inheritdoc />
    public partial class ApplyChangesVer1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_User_UserId",
                schema: "GEN",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Cart_CartId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParentCategoryId",
                schema: "SEC",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_RequestPay_RequestPayId",
                schema: "GEN",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_User_UserId",
                schema: "GEN",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "GEN",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestPay_User_UserId",
                schema: "Pay",
                table: "RequestPay");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RoleId",
                schema: "SEC",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId",
                schema: "SEC",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                schema: "SEC",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "SEC",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slider",
                schema: "GEN",
                table: "Slider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                schema: "SEC",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestPay",
                schema: "Pay",
                table: "RequestPay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                schema: "SEC",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                schema: "GEN",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "CartItems",
                newName: "CartItems",
                newSchema: "GEN");

            migrationBuilder.RenameTable(
                name: "UserRole",
                schema: "SEC",
                newName: "UserRoles",
                newSchema: "SEC");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "SEC",
                newName: "Users",
                newSchema: "SEC");

            migrationBuilder.RenameTable(
                name: "Slider",
                schema: "GEN",
                newName: "Sliders",
                newSchema: "GEN");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "SEC",
                newName: "Roles",
                newSchema: "SEC");

            migrationBuilder.RenameTable(
                name: "RequestPay",
                schema: "Pay",
                newName: "RequestPays",
                newSchema: "Pay");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "SEC",
                newName: "Categories",
                newSchema: "SEC");

            migrationBuilder.RenameTable(
                name: "Cart",
                schema: "GEN",
                newName: "Carts",
                newSchema: "GEN");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_UserId",
                schema: "SEC",
                table: "UserRoles",
                newName: "IX_UserRoles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_RoleId",
                schema: "SEC",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Email",
                schema: "SEC",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.RenameIndex(
                name: "IX_RequestPay_UserId",
                schema: "Pay",
                table: "RequestPays",
                newName: "IX_RequestPays_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_ParentCategoryId",
                schema: "SEC",
                table: "Categories",
                newName: "IX_Categories_ParentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_UserId",
                schema: "GEN",
                table: "Carts",
                newName: "IX_Carts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                schema: "SEC",
                table: "UserRoles",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "SEC",
                table: "Users",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sliders",
                schema: "GEN",
                table: "Sliders",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                schema: "SEC",
                table: "Roles",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestPays",
                schema: "Pay",
                table: "RequestPays",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                schema: "SEC",
                table: "Categories",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                schema: "GEN",
                table: "Carts",
                column: "ID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                schema: "GEN",
                table: "CartItems",
                column: "CartId",
                principalSchema: "GEN",
                principalTable: "Carts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserId",
                schema: "GEN",
                table: "Carts",
                column: "UserId",
                principalSchema: "SEC",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                schema: "SEC",
                table: "Categories",
                column: "ParentCategoryId",
                principalSchema: "SEC",
                principalTable: "Categories",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_RequestPays_RequestPayId",
                schema: "GEN",
                table: "Orders",
                column: "RequestPayId",
                principalSchema: "Pay",
                principalTable: "RequestPays",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                schema: "GEN",
                table: "Orders",
                column: "UserId",
                principalSchema: "SEC",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "GEN",
                table: "Products",
                column: "CategoryId",
                principalSchema: "SEC",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestPays_Users_UserId",
                schema: "Pay",
                table: "RequestPays",
                column: "UserId",
                principalSchema: "SEC",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                schema: "SEC",
                table: "UserRoles",
                column: "RoleId",
                principalSchema: "SEC",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                schema: "SEC",
                table: "UserRoles",
                column: "UserId",
                principalSchema: "SEC",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                schema: "GEN",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserId",
                schema: "GEN",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                schema: "SEC",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_RequestPays_RequestPayId",
                schema: "GEN",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                schema: "GEN",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "GEN",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestPays_Users_UserId",
                schema: "Pay",
                table: "RequestPays");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                schema: "SEC",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                schema: "SEC",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "SEC",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                schema: "SEC",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sliders",
                schema: "GEN",
                table: "Sliders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                schema: "SEC",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestPays",
                schema: "Pay",
                table: "RequestPays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                schema: "SEC",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                schema: "GEN",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "CartItems",
                schema: "GEN",
                newName: "CartItems");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "SEC",
                newName: "User",
                newSchema: "SEC");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "SEC",
                newName: "UserRole",
                newSchema: "SEC");

            migrationBuilder.RenameTable(
                name: "Sliders",
                schema: "GEN",
                newName: "Slider",
                newSchema: "GEN");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "SEC",
                newName: "Role",
                newSchema: "SEC");

            migrationBuilder.RenameTable(
                name: "RequestPays",
                schema: "Pay",
                newName: "RequestPay",
                newSchema: "Pay");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "SEC",
                newName: "Category",
                newSchema: "SEC");

            migrationBuilder.RenameTable(
                name: "Carts",
                schema: "GEN",
                newName: "Cart",
                newSchema: "GEN");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                schema: "SEC",
                table: "User",
                newName: "IX_User_Email");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_UserId",
                schema: "SEC",
                table: "UserRole",
                newName: "IX_UserRole_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                schema: "SEC",
                table: "UserRole",
                newName: "IX_UserRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestPays_UserId",
                schema: "Pay",
                table: "RequestPay",
                newName: "IX_RequestPay_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ParentCategoryId",
                schema: "SEC",
                table: "Category",
                newName: "IX_Category_ParentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_UserId",
                schema: "GEN",
                table: "Cart",
                newName: "IX_Cart_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "SEC",
                table: "User",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                schema: "SEC",
                table: "UserRole",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slider",
                schema: "GEN",
                table: "Slider",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                schema: "SEC",
                table: "Role",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestPay",
                schema: "Pay",
                table: "RequestPay",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                schema: "SEC",
                table: "Category",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                schema: "GEN",
                table: "Cart",
                column: "ID");

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Role",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 14, 1, 8, 23, 266, DateTimeKind.Local).AddTicks(3771));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Role",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 14, 1, 8, 23, 266, DateTimeKind.Local).AddTicks(3816));

            migrationBuilder.UpdateData(
                schema: "SEC",
                table: "Role",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2023, 7, 14, 1, 8, 23, 266, DateTimeKind.Local).AddTicks(3827));

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_User_UserId",
                schema: "GEN",
                table: "Cart",
                column: "UserId",
                principalSchema: "SEC",
                principalTable: "User",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Cart_CartId",
                table: "CartItems",
                column: "CartId",
                principalSchema: "GEN",
                principalTable: "Cart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParentCategoryId",
                schema: "SEC",
                table: "Category",
                column: "ParentCategoryId",
                principalSchema: "SEC",
                principalTable: "Category",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_RequestPay_RequestPayId",
                schema: "GEN",
                table: "Orders",
                column: "RequestPayId",
                principalSchema: "Pay",
                principalTable: "RequestPay",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_User_UserId",
                schema: "GEN",
                table: "Orders",
                column: "UserId",
                principalSchema: "SEC",
                principalTable: "User",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "GEN",
                table: "Products",
                column: "CategoryId",
                principalSchema: "SEC",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestPay_User_UserId",
                schema: "Pay",
                table: "RequestPay",
                column: "UserId",
                principalSchema: "SEC",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_RoleId",
                schema: "SEC",
                table: "UserRole",
                column: "RoleId",
                principalSchema: "SEC",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId",
                schema: "SEC",
                table: "UserRole",
                column: "UserId",
                principalSchema: "SEC",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
