﻿// <auto-generated />
using System;
using Api_Projeto_Ferias.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api_Projeto_Ferias.Migrations
{
    [DbContext(typeof(FeriasContext))]
    [Migration("20211013143514_CriandoRelacionamento")]
    partial class CriandoRelacionamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api_Projeto_Ferias.Models.Ferias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAtual")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFimFerias")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicioFerias")
                        .HasColumnType("datetime2");

                    b.Property<int>("usuario_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("usuario_Id");

                    b.ToTable("ferias");
                });

            modelBuilder.Entity("Api_Projeto_Ferias.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("Api_Projeto_Ferias.Models.Ferias", b =>
                {
                    b.HasOne("Api_Projeto_Ferias.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("usuario_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
