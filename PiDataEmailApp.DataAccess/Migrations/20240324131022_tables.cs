using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PiDataEmailApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EpostaAdresleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Adres = table.Column<string>(type: "text", nullable: false),
                    MailSunucuAdresi = table.Column<string>(type: "text", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "text", nullable: false),
                    Sifre = table.Column<string>(type: "text", nullable: false),
                    Port = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpostaAdresleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kisiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    Soyad = table.Column<string>(type: "text", nullable: false),
                    Telefon = table.Column<string>(type: "text", nullable: true),
                    Eposta = table.Column<string>(type: "text", nullable: false),
                    Yas = table.Column<int>(type: "integer", nullable: false),
                    Cinsiyet = table.Column<string>(type: "text", nullable: false),
                    Unvan = table.Column<string>(type: "text", nullable: true),
                    Isyeri = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EpostaGonderimleri",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Konusu = table.Column<string>(type: "text", nullable: false),
                    Icerigi = table.Column<string>(type: "text", nullable: false),
                    GonderenEpostaAdresi = table.Column<string>(type: "text", nullable: false),
                    EpostaAdresiId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpostaGonderimleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EpostaGonderimleri_EpostaAdresleri_EpostaAdresiId",
                        column: x => x.EpostaAdresiId,
                        principalTable: "EpostaAdresleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpostaGonderimDetaylari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EpostaGonderimId = table.Column<Guid>(type: "uuid", nullable: true),
                    KisiId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpostaGonderimDetaylari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EpostaGonderimDetaylari_EpostaGonderimleri_EpostaGonderimId",
                        column: x => x.EpostaGonderimId,
                        principalTable: "EpostaGonderimleri",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EpostaGonderimDetaylari_Kisiler_KisiId",
                        column: x => x.KisiId,
                        principalTable: "Kisiler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EpostaGonderimDetaylari_EpostaGonderimId",
                table: "EpostaGonderimDetaylari",
                column: "EpostaGonderimId");

            migrationBuilder.CreateIndex(
                name: "IX_EpostaGonderimDetaylari_KisiId",
                table: "EpostaGonderimDetaylari",
                column: "KisiId");

            migrationBuilder.CreateIndex(
                name: "IX_EpostaGonderimleri_EpostaAdresiId",
                table: "EpostaGonderimleri",
                column: "EpostaAdresiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpostaGonderimDetaylari");

            migrationBuilder.DropTable(
                name: "EpostaGonderimleri");

            migrationBuilder.DropTable(
                name: "Kisiler");

            migrationBuilder.DropTable(
                name: "EpostaAdresleri");
        }
    }
}
