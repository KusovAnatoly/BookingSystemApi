using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystemApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "user",
                newName: "second_name");

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "user",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "first_name",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "second_name",
                table: "user",
                newName: "name");
        }
    }
}
