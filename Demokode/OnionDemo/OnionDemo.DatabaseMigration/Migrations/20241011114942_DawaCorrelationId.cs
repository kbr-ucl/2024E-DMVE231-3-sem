using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionDemo.DatabaseMigration.Migrations
{
    /// <inheritdoc />
    public partial class DawaCorrelationId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Address_DawaId",
                table: "Accommodations",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "Address_DawaCorrelationId",
                table: "Accommodations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_DawaCorrelationId",
                table: "Accommodations");

            migrationBuilder.AlterColumn<string>(
                name: "Address_DawaId",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
