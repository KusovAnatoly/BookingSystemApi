using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystemApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "user",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "access_failed_count",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "concurrency_stamp",
                table: "user",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "user",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "email_confirmed",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "lockout_enabled",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "lockout_end",
                table: "user",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "security_stamp",
                table: "user",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "two_factor_enabled",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "user",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "user",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "access_failed_count",
                table: "user");

            migrationBuilder.DropColumn(
                name: "concurrency_stamp",
                table: "user");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "user");

            migrationBuilder.DropColumn(
                name: "email_confirmed",
                table: "user");

            migrationBuilder.DropColumn(
                name: "lockout_enabled",
                table: "user");

            migrationBuilder.DropColumn(
                name: "lockout_end",
                table: "user");

            migrationBuilder.DropColumn(
                name: "security_stamp",
                table: "user");

            migrationBuilder.DropColumn(
                name: "two_factor_enabled",
                table: "user");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "user");

            migrationBuilder.DropColumn(
                name: "username",
                table: "user");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "user",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);
        }
    }
}
