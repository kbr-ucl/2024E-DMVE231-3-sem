using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressManager.DatabaseMigration.Migrations
{
    /// <inheritdoc />
    public partial class CorrelationId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DawaCorrelationId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DawaCorrelationId",
                table: "Addresses");
        }
    }
}
