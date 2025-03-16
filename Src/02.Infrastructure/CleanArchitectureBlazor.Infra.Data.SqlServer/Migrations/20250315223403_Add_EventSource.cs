using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitectureBlazor.Infra.Data.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Add_EventSource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EventSourcing");

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserId",
                schema: "Business",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Business",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                schema: "Business",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedByUserId",
                schema: "Business",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserId",
                schema: "Business",
                table: "EventOutboxs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Business",
                table: "EventOutboxs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                schema: "Business",
                table: "EventOutboxs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedByUserId",
                schema: "Business",
                table: "EventOutboxs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserId",
                schema: "Business",
                table: "Discounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Business",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                schema: "Business",
                table: "Discounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedByUserId",
                schema: "Business",
                table: "Discounts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserId",
                schema: "Business",
                table: "Categories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Business",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                schema: "Business",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedByUserId",
                schema: "Business",
                table: "Categories",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Business",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventSource",
                schema: "EventSourcing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sequence = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AggregateId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Data = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Aggregate = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Business",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventSource_Sequence_Id",
                schema: "EventSourcing",
                table: "EventSource",
                columns: new[] { "Sequence", "Id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Business");

            migrationBuilder.DropTable(
                name: "EventSource",
                schema: "EventSourcing");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Business");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "Business",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Business",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                schema: "Business",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "Business",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "Business",
                table: "EventOutboxs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Business",
                table: "EventOutboxs");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                schema: "Business",
                table: "EventOutboxs");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "Business",
                table: "EventOutboxs");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "Business",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Business",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                schema: "Business",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "Business",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "Business",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Business",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                schema: "Business",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "Business",
                table: "Categories");
        }
    }
}
