using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitectureBlazor.Infra.Data.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Add_Agg_Version : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "Business",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "Business",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "Business",
                table: "EventOutboxs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "Business",
                table: "Discounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "Business",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "Business",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                schema: "Business",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "Business",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "Business",
                table: "EventOutboxs");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "Business",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "Business",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "Business",
                table: "Categories");
        }
    }
}
