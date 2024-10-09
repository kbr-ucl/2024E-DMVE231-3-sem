using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressManager.DatabaseMigration.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Building = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressHashCode_HashCode = table.Column<int>(type: "int", nullable: false),
                    DawaAddress_DawaErrorReasonPhrase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DawaAddress_DawaHttpError = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DawaAddress_DawaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DawaAddress_Kategori = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DawaAddress_ValidationState = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
