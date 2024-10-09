using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionDemo.DatabaseMigration.Migrations
{
    /// <inheritdoc />
    public partial class AddressValidation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_Building",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_Building",
                table: "Accommodations");
        }
    }
}
