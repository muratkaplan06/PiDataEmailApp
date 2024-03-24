﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PiDataEmailApp.DataAccess.Concrete;

#nullable disable

namespace PiDataEmailApp.DataAccess.Migrations
{
    [DbContext(typeof(PiDataDbContext))]
    partial class PiDataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PiDataEmailApp.Entities.EpostaAdresi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MailSunucuAdresi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Port")
                        .HasColumnType("integer");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EpostaAdresleri");
                });

            modelBuilder.Entity("PiDataEmailApp.Entities.EpostaGonderim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("EpostaAdresiId")
                        .HasColumnType("integer");

                    b.Property<string>("GonderenEpostaAdresi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Icerigi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Konusu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EpostaAdresiId");

                    b.ToTable("EpostaGonderimleri");
                });

            modelBuilder.Entity("PiDataEmailApp.Entities.EpostaGonderimDetay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("EpostaGonderimId")
                        .HasColumnType("uuid");

                    b.Property<bool>("GonderimDurumu")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("GonderimTarihi")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("KisiId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EpostaGonderimId");

                    b.HasIndex("KisiId");

                    b.ToTable("EpostaGonderimDetaylari");
                });

            modelBuilder.Entity("PiDataEmailApp.Entities.Kisi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cinsiyet")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Eposta")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Isyeri")
                        .HasColumnType("text");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefon")
                        .HasColumnType("text");

                    b.Property<string>("Unvan")
                        .HasColumnType("text");

                    b.Property<int>("Yas")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Kisiler");
                });

            modelBuilder.Entity("PiDataEmailApp.Entities.EpostaGonderim", b =>
                {
                    b.HasOne("PiDataEmailApp.Entities.EpostaAdresi", "EpostaAdresi")
                        .WithMany("EpostaGonderimler")
                        .HasForeignKey("EpostaAdresiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EpostaAdresi");
                });

            modelBuilder.Entity("PiDataEmailApp.Entities.EpostaGonderimDetay", b =>
                {
                    b.HasOne("PiDataEmailApp.Entities.EpostaGonderim", "EpostaGonderim")
                        .WithMany()
                        .HasForeignKey("EpostaGonderimId");

                    b.HasOne("PiDataEmailApp.Entities.Kisi", "Kisi")
                        .WithMany()
                        .HasForeignKey("KisiId");

                    b.Navigation("EpostaGonderim");

                    b.Navigation("Kisi");
                });

            modelBuilder.Entity("PiDataEmailApp.Entities.EpostaAdresi", b =>
                {
                    b.Navigation("EpostaGonderimler");
                });
#pragma warning restore 612, 618
        }
    }
}
