using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PiDataEmailApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class gonderimdetay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "GonderimDurumu",
                table: "EpostaGonderimDetaylari",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "GonderimTarihi",
                table: "EpostaGonderimDetaylari",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GonderimDurumu",
                table: "EpostaGonderimDetaylari");

            migrationBuilder.DropColumn(
                name: "GonderimTarihi",
                table: "EpostaGonderimDetaylari");
        }
    }
}
