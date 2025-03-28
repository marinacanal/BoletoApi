﻿// <auto-generated />
using System;
using BoletoApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BoletoApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250324021551_CriacaoTabelasBancoBoleto")]
    partial class CriacaoTabelasBancoBoleto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BoletoApi.Entities.Banco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<short>("Codigo")
                        .HasColumnType("smallint");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<decimal>("PercentualJuros")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Bancos");
                });

            modelBuilder.Entity("BoletoApi.Entities.Boleto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BancoId")
                        .HasColumnType("uuid");

                    b.Property<string>("CpfCnpjBeneficiario")
                        .HasColumnType("text");

                    b.Property<string>("CpfCnpjPagador")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NomeBeneficiario")
                        .HasColumnType("text");

                    b.Property<string>("NomePagador")
                        .HasColumnType("text");

                    b.Property<string>("Observacao")
                        .HasColumnType("text");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.ToTable("Boletos");
                });

            modelBuilder.Entity("BoletoApi.Entities.Boleto", b =>
                {
                    b.HasOne("BoletoApi.Entities.Banco", "Banco")
                        .WithMany()
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banco");
                });
#pragma warning restore 612, 618
        }
    }
}
