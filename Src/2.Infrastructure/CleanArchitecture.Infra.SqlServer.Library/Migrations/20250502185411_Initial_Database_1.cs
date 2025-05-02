using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infra.SqlServer.Library.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Database_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppRoleClaimEntity_ClaimType",
                schema: "Security",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "AppRoleClaimEntity_ClaimValue",
                schema: "Security",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "AppRoleClaimEntity_IsActive",
                schema: "Security",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "AppRoleClaimEntity_IsDeleted",
                schema: "Security",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "AppRoleClaimEntity_RoleId",
                schema: "Security",
                table: "RoleClaims");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppRoleClaimEntity_ClaimType",
                schema: "Security",
                table: "RoleClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppRoleClaimEntity_ClaimValue",
                schema: "Security",
                table: "RoleClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AppRoleClaimEntity_IsActive",
                schema: "Security",
                table: "RoleClaims",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AppRoleClaimEntity_IsDeleted",
                schema: "Security",
                table: "RoleClaims",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AppRoleClaimEntity_RoleId",
                schema: "Security",
                table: "RoleClaims",
                type: "bigint",
                nullable: true);
        }
    }
}
