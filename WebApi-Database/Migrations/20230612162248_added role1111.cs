using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_Database.Migrations
{
    /// <inheritdoc />
    public partial class addedrole1111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Document",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "DocumentId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Students");

            migrationBuilder.AddColumn<byte[]>(
                name: "Document",
                table: "Students",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
