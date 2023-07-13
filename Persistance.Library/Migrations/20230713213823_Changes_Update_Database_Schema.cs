using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Library.Migrations
{
    /// <inheritdoc />
    public partial class Changes_Update_Database_Schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_User_UserId",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sliders",
                table: "Sliders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomePageImages",
                table: "HomePageImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.EnsureSchema(
                name: "GEN");

            migrationBuilder.EnsureSchema(
                name: "Pay");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "GEN");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "ProductImages",
                newSchema: "GEN");

            migrationBuilder.RenameTable(
                name: "ProductFeatures",
                newName: "ProductFeatures",
                newSchema: "GEN");

            migrationBuilder.RenameTable(
                name: "Sliders",
                newName: "Slider",
                newSchema: "GEN");

            migrationBuilder.RenameTable(
                name: "HomePageImages",
                newName: "HomePaheImages",
                newSchema: "GEN");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Cart",
                newSchema: "GEN");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_UserId",
                schema: "GEN",
                table: "Cart",
                newName: "IX_Cart_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slider",
                schema: "GEN",
                table: "Slider",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomePaheImages",
                schema: "GEN",
                table: "HomePaheImages",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                schema: "GEN",
                table: "Cart",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "RequestPay",
                schema: "Pay",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IsPay = table.Column<bool>(type: "bit", nullable: false),
                    PayDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Authority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestPay", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RequestPay_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "SEC",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "GEN",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RequestPayId = table.Column<long>(type: "bigint", nullable: false),
                    OrderState = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_RequestPay_RequestPayId",
                        column: x => x.RequestPayId,
                        principalSchema: "Pay",
                        principalTable: "RequestPay",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Orders_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "SEC",
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                schema: "GEN",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "GEN",
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "GEN",
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                schema: "GEN",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                schema: "GEN",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RequestPayId",
                schema: "GEN",
                table: "Orders",
                column: "RequestPayId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                schema: "GEN",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestPay_UserId",
                schema: "Pay",
                table: "RequestPay",
                column: "UserId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_User_UserId",
                schema: "GEN",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Cart_CartId",
                table: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderDetails",
                schema: "GEN");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "GEN");

            migrationBuilder.DropTable(
                name: "RequestPay",
                schema: "Pay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slider",
                schema: "GEN",
                table: "Slider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomePaheImages",
                schema: "GEN",
                table: "HomePaheImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                schema: "GEN",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "GEN",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                schema: "GEN",
                newName: "ProductImages");

            migrationBuilder.RenameTable(
                name: "ProductFeatures",
                schema: "GEN",
                newName: "ProductFeatures");

            migrationBuilder.RenameTable(
                name: "Slider",
                schema: "GEN",
                newName: "Sliders");

            migrationBuilder.RenameTable(
                name: "HomePaheImages",
                schema: "GEN",
                newName: "HomePageImages");

            migrationBuilder.RenameTable(
                name: "Cart",
                schema: "GEN",
                newName: "Carts");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_UserId",
                table: "Carts",
                newName: "IX_Carts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sliders",
                table: "Sliders",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomePageImages",
                table: "HomePageImages",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "ID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_User_UserId",
                table: "Carts",
                column: "UserId",
                principalSchema: "SEC",
                principalTable: "User",
                principalColumn: "ID");
        }
    }
}
