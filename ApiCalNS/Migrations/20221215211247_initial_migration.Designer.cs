﻿// <auto-generated />
using System;
using ApiCalNS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiCalNS.Migrations
{
    [DbContext(typeof(ApiCalNSDbContext))]
    [Migration("20221215211247_initial_migration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClasesMAUI.Models.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Archivos")
                        .HasColumnType("int");

                    b.Property<int?>("Compras")
                        .HasColumnType("int");

                    b.Property<int?>("ContactoId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Futuras")
                        .HasColumnType("int");

                    b.Property<int>("Hora")
                        .HasColumnType("int");

                    b.Property<int?>("Hoy")
                        .HasColumnType("int");

                    b.Property<int?>("IdContacto")
                        .HasColumnType("int");

                    b.Property<int>("IdImportancia")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int?>("Ingreso")
                        .HasColumnType("int");

                    b.Property<string>("Notas")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int?>("Pagos")
                        .HasColumnType("int");

                    b.Property<int?>("Pasadas")
                        .HasColumnType("int");

                    b.Property<int?>("Presupuesto")
                        .HasColumnType("int");

                    b.Property<int?>("PrioridadId")
                        .HasColumnType("int");

                    b.Property<int?>("TareaId")
                        .HasColumnType("int");

                    b.Property<int?>("TemaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Total")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("VerificaFechaHora")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Verificado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Cita");
                });

            modelBuilder.Entity("ClasesMAUI.Models.Contacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Empresa")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("IdAspNetUsers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Notas")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("ClasesMAUI.Models.Prioridad", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<short?>("Orden")
                        .HasColumnType("smallint");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Prioridad");
                });

            modelBuilder.Entity("ClasesMAUI.Models.Repeticion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CitaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaFinaliza")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaHoraRegistro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("HoraFinaliza")
                        .HasColumnType("int");

                    b.Property<int>("HoraInicio")
                        .HasColumnType("int");

                    b.Property<int>("IdObjeto")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoObjeto")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoRepeticion")
                        .HasColumnType("int");

                    b.Property<string>("Notas")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int?>("PrioridadId")
                        .HasColumnType("int");

                    b.Property<int>("RepeticionesPeriodo")
                        .HasColumnType("int");

                    b.Property<int?>("TareaId")
                        .HasColumnType("int");

                    b.Property<int?>("TemaId")
                        .HasColumnType("int");

                    b.Property<int?>("TipoObjetoId")
                        .HasColumnType("int");

                    b.Property<int>("TiposRepeticionId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CitaId");

                    b.HasIndex("PrioridadId");

                    b.HasIndex("TareaId");

                    b.HasIndex("TemaId");

                    b.HasIndex("TipoObjetoId");

                    b.ToTable("Repeticion");
                });

            modelBuilder.Entity("ClasesMAUI.Models.Tarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CitaId")
                        .HasColumnType("int");

                    b.Property<int?>("CitaId1")
                        .HasColumnType("int");

                    b.Property<int?>("ContactoId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime?>("FechaFinaliza")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<short?>("HoraFinaliza")
                        .HasColumnType("smallint");

                    b.Property<short?>("HoraInicio")
                        .HasColumnType("smallint");

                    b.Property<short?>("HoraRegistro")
                        .HasColumnType("smallint");

                    b.Property<int>("IdImportancia")
                        .HasColumnType("int");

                    b.Property<int?>("IdTareaPadre")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Notas")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int?>("PrioridadId")
                        .HasColumnType("int");

                    b.Property<int>("TemaId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("VerificaFechaHora")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Verificado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CitaId1");

                    b.HasIndex("TemaId");

                    b.ToTable("Tarea");
                });

            modelBuilder.Entity("ClasesMAUI.Models.Tema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Archivos")
                        .HasColumnType("int");

                    b.Property<int?>("Compras")
                        .HasColumnType("int");

                    b.Property<int?>("ContactoId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime?>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Futuras")
                        .HasColumnType("int");

                    b.Property<int?>("Hoy")
                        .HasColumnType("int");

                    b.Property<int?>("IdContacto")
                        .HasColumnType("int");

                    b.Property<int?>("IdImportancia")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int?>("Ingreso")
                        .HasColumnType("int");

                    b.Property<string>("Notas")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int?>("Pagos")
                        .HasColumnType("int");

                    b.Property<int?>("Pasadas")
                        .HasColumnType("int");

                    b.Property<int?>("Presupuesto")
                        .HasColumnType("int");

                    b.Property<int>("PrioridadId")
                        .HasColumnType("int");

                    b.Property<int?>("Total")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId1")
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("VerificaFechaHora")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Verificado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PrioridadId")
                        .IsUnique();

                    b.HasIndex("UsuarioId1");

                    b.ToTable("Tema");
                });

            modelBuilder.Entity("ClasesMAUI.Models.TipoObjeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TipoObjeto");
                });

            modelBuilder.Entity("ClasesMAUI.Models.TipoRepeticion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TipoRepeticion");
                });

            modelBuilder.Entity("ClasesMAUI.Models.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CorreoElectronico")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ClasesMAUI.Models.Repeticion", b =>
                {
                    b.HasOne("ClasesMAUI.Models.Cita", "Cita")
                        .WithMany()
                        .HasForeignKey("CitaId");

                    b.HasOne("ClasesMAUI.Models.Prioridad", "Prioridad")
                        .WithMany()
                        .HasForeignKey("PrioridadId");

                    b.HasOne("ClasesMAUI.Models.Tarea", "Tarea")
                        .WithMany()
                        .HasForeignKey("TareaId");

                    b.HasOne("ClasesMAUI.Models.Tema", "Tema")
                        .WithMany()
                        .HasForeignKey("TemaId");

                    b.HasOne("ClasesMAUI.Models.TipoObjeto", "TipoObjeto")
                        .WithMany()
                        .HasForeignKey("TipoObjetoId");

                    b.Navigation("Cita");

                    b.Navigation("Prioridad");

                    b.Navigation("Tarea");

                    b.Navigation("Tema");

                    b.Navigation("TipoObjeto");
                });

            modelBuilder.Entity("ClasesMAUI.Models.Tarea", b =>
                {
                    b.HasOne("ClasesMAUI.Models.Cita", "Cita")
                        .WithMany()
                        .HasForeignKey("CitaId1");

                    b.HasOne("ClasesMAUI.Models.Tema", "Temas")
                        .WithMany()
                        .HasForeignKey("TemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cita");

                    b.Navigation("Temas");
                });

            modelBuilder.Entity("ClasesMAUI.Models.Tema", b =>
                {
                    b.HasOne("ClasesMAUI.Models.Prioridad", "Prioridad")
                        .WithOne("Temas")
                        .HasForeignKey("ClasesMAUI.Models.Tema", "PrioridadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClasesMAUI.Models.Usuario", null)
                        .WithMany("Temas")
                        .HasForeignKey("UsuarioId1");

                    b.Navigation("Prioridad");
                });

            modelBuilder.Entity("ClasesMAUI.Models.Prioridad", b =>
                {
                    b.Navigation("Temas");
                });

            modelBuilder.Entity("ClasesMAUI.Models.Usuario", b =>
                {
                    b.Navigation("Temas");
                });
#pragma warning restore 612, 618
        }
    }
}