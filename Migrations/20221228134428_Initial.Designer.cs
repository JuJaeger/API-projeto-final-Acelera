﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Projeto_Final_AVMB;

#nullable disable

namespace ProjetoFinalAVMB.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20221228134428_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Projeto_Final_AVMB.DataModels.AlunoUniforme", b =>
                {
                    b.Property<int>("alunoId")
                        .HasColumnType("integer");

                    b.Property<int>("uniformeId")
                        .HasColumnType("integer");

                    b.HasKey("alunoId", "uniformeId");

                    b.HasIndex("uniformeId");

                    b.ToTable("AlunoUniformes");
                });

            modelBuilder.Entity("Projeto_final_AVMB.DataModels.Aluno", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("data_cadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("nome_completo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nome_guerra")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nome_responsavel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("numero")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("Projeto_final_AVMB.DataModels.Uniforme", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("peca_roupa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Uniformes");
                });

            modelBuilder.Entity("Projeto_Final_AVMB.DataModels.AlunoUniforme", b =>
                {
                    b.HasOne("Projeto_final_AVMB.DataModels.Aluno", "aluno")
                        .WithMany("AlunoUniformes")
                        .HasForeignKey("alunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto_final_AVMB.DataModels.Uniforme", "uniforme")
                        .WithMany("AlunoUniformes")
                        .HasForeignKey("uniformeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("aluno");

                    b.Navigation("uniforme");
                });

            modelBuilder.Entity("Projeto_final_AVMB.DataModels.Aluno", b =>
                {
                    b.Navigation("AlunoUniformes");
                });

            modelBuilder.Entity("Projeto_final_AVMB.DataModels.Uniforme", b =>
                {
                    b.Navigation("AlunoUniformes");
                });
#pragma warning restore 612, 618
        }
    }
}
