using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitectureBlazor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Database_BaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Security",
                table: "UserTokens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Security",
                table: "UserTokens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "Key",
                schema: "Security",
                table: "UserTokens",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Security",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Security",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "Key",
                schema: "Security",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Security",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Security",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "Key",
                schema: "Security",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Security",
                table: "UserLogins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Security",
                table: "UserLogins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "Key",
                schema: "Security",
                table: "UserLogins",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Security",
                table: "UserClaims",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Security",
                table: "UserClaims",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "Key",
                schema: "Security",
                table: "UserClaims",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Security",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Security",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "Key",
                schema: "Security",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Privilege",
                table: "RoleMenu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Privilege",
                table: "RoleMenu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Security",
                table: "RoleClaims",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Security",
                table: "RoleClaims",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "Key",
                schema: "Security",
                table: "RoleClaims",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Setting",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Setting",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Security",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Security",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "Key",
                schema: "Security",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Key",
                schema: "Security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Security",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Security",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "Key",
                schema: "Security",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Security",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Security",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "Key",
                schema: "Security",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Security",
                table: "UserClaims");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Security",
                table: "UserClaims");

            migrationBuilder.DropColumn(
                name: "Key",
                schema: "Security",
                table: "UserClaims");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Security",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Security",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Key",
                schema: "Security",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Privilege",
                table: "RoleMenu");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Privilege",
                table: "RoleMenu");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Security",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Security",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "Key",
                schema: "Security",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Setting",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Setting",
                table: "Menu");
        }
    }
}
