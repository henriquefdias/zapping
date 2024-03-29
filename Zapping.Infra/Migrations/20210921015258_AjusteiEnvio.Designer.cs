﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zapping.Infra.Repositories.Base;

namespace Zapping.Infra.Migrations
{
    [DbContext(typeof(ZappingContext))]
    [Migration("20210921015258_AjusteiEnvio")]
    partial class AjusteiEnvio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Zapping.Domain.Entities.Campanha", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("IdUsuario");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Campanha");
                });

            modelBuilder.Entity("Zapping.Domain.Entities.Contato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("IdUsuario");

                    b.Property<int>("Nicho");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("Zapping.Domain.Entities.Envio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Enviado");

                    b.Property<Guid?>("IdCampanha");

                    b.Property<Guid?>("IdContato");

                    b.Property<Guid?>("IdGrupo");

                    b.HasKey("Id");

                    b.HasIndex("IdCampanha");

                    b.HasIndex("IdContato");

                    b.HasIndex("IdGrupo");

                    b.ToTable("Envio");
                });

            modelBuilder.Entity("Zapping.Domain.Entities.Grupo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("IdUsuario");

                    b.Property<int>("Nicho");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Grupo");
                });

            modelBuilder.Entity("Zapping.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.Property<string>("UltimoNome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Zapping.Domain.Entities.Campanha", b =>
                {
                    b.HasOne("Zapping.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario");
                });

            modelBuilder.Entity("Zapping.Domain.Entities.Contato", b =>
                {
                    b.HasOne("Zapping.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario");
                });

            modelBuilder.Entity("Zapping.Domain.Entities.Envio", b =>
                {
                    b.HasOne("Zapping.Domain.Entities.Campanha", "Campanha")
                        .WithMany()
                        .HasForeignKey("IdCampanha");

                    b.HasOne("Zapping.Domain.Entities.Contato", "Contato")
                        .WithMany()
                        .HasForeignKey("IdContato");

                    b.HasOne("Zapping.Domain.Entities.Grupo", "Grupo")
                        .WithMany()
                        .HasForeignKey("IdGrupo");
                });

            modelBuilder.Entity("Zapping.Domain.Entities.Grupo", b =>
                {
                    b.HasOne("Zapping.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
