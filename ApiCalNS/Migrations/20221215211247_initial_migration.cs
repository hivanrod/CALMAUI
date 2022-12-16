using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCalNS.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdImportancia = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hora = table.Column<int>(type: "int", nullable: false),
                    Verificado = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    VerificaFechaHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notas = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Ingreso = table.Column<int>(type: "int", nullable: true),
                    Presupuesto = table.Column<int>(type: "int", nullable: true),
                    Compras = table.Column<int>(type: "int", nullable: true),
                    Pagos = table.Column<int>(type: "int", nullable: true),
                    IdContacto = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true),
                    Pasadas = table.Column<int>(type: "int", nullable: true),
                    Hoy = table.Column<int>(type: "int", nullable: true),
                    Futuras = table.Column<int>(type: "int", nullable: true),
                    Archivos = table.Column<int>(type: "int", nullable: true),
                    ContactoId = table.Column<int>(type: "int", nullable: true),
                    PrioridadId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    TemaId = table.Column<int>(type: "int", nullable: false),
                    TareaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Notas = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IdAspNetUsers = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prioridad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Orden = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioridad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoObjeto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoObjeto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoRepeticion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRepeticion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdImportancia = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Verificado = table.Column<bool>(type: "bit", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    VerificaFechaHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notas = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Ingreso = table.Column<int>(type: "int", nullable: true),
                    Presupuesto = table.Column<int>(type: "int", nullable: true),
                    Compras = table.Column<int>(type: "int", nullable: true),
                    Pagos = table.Column<int>(type: "int", nullable: true),
                    IdContacto = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true),
                    Pasadas = table.Column<int>(type: "int", nullable: true),
                    Hoy = table.Column<int>(type: "int", nullable: true),
                    Futuras = table.Column<int>(type: "int", nullable: true),
                    Archivos = table.Column<int>(type: "int", nullable: true),
                    ContactoId = table.Column<int>(type: "int", nullable: true),
                    PrioridadId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId1 = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tema", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tema_Prioridad_PrioridadId",
                        column: x => x.PrioridadId,
                        principalTable: "Prioridad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tema_Usuario_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdImportancia = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraRegistro = table.Column<short>(type: "smallint", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraInicio = table.Column<short>(type: "smallint", nullable: true),
                    FechaFinaliza = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraFinaliza = table.Column<short>(type: "smallint", nullable: true),
                    Verificado = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    VerificaFechaHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notas = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ContactoId = table.Column<int>(type: "int", nullable: true),
                    CitaId = table.Column<int>(type: "int", nullable: true),
                    TemaId = table.Column<int>(type: "int", nullable: false),
                    PrioridadId = table.Column<int>(type: "int", nullable: true),
                    IdTareaPadre = table.Column<int>(type: "int", nullable: true),
                    CitaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarea_Cita_CitaId1",
                        column: x => x.CitaId1,
                        principalTable: "Cita",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tarea_Tema_TemaId",
                        column: x => x.TemaId,
                        principalTable: "Tema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repeticion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdObjeto = table.Column<int>(type: "int", nullable: false),
                    IdTipoObjeto = table.Column<int>(type: "int", nullable: false),
                    FechaHoraRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraInicio = table.Column<int>(type: "int", nullable: false),
                    FechaFinaliza = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraFinaliza = table.Column<int>(type: "int", nullable: false),
                    RepeticionesPeriodo = table.Column<int>(type: "int", nullable: false),
                    IdTipoRepeticion = table.Column<int>(type: "int", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    PrioridadId = table.Column<int>(type: "int", nullable: true),
                    TemaId = table.Column<int>(type: "int", nullable: true),
                    CitaId = table.Column<int>(type: "int", nullable: true),
                    TareaId = table.Column<int>(type: "int", nullable: true),
                    TipoObjetoId = table.Column<int>(type: "int", nullable: true),
                    TiposRepeticionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repeticion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repeticion_Cita_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Cita",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Repeticion_Prioridad_PrioridadId",
                        column: x => x.PrioridadId,
                        principalTable: "Prioridad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Repeticion_Tarea_TareaId",
                        column: x => x.TareaId,
                        principalTable: "Tarea",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Repeticion_Tema_TemaId",
                        column: x => x.TemaId,
                        principalTable: "Tema",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Repeticion_TipoObjeto_TipoObjetoId",
                        column: x => x.TipoObjetoId,
                        principalTable: "TipoObjeto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repeticion_CitaId",
                table: "Repeticion",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Repeticion_PrioridadId",
                table: "Repeticion",
                column: "PrioridadId");

            migrationBuilder.CreateIndex(
                name: "IX_Repeticion_TareaId",
                table: "Repeticion",
                column: "TareaId");

            migrationBuilder.CreateIndex(
                name: "IX_Repeticion_TemaId",
                table: "Repeticion",
                column: "TemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Repeticion_TipoObjetoId",
                table: "Repeticion",
                column: "TipoObjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_CitaId1",
                table: "Tarea",
                column: "CitaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_TemaId",
                table: "Tarea",
                column: "TemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tema_PrioridadId",
                table: "Tema",
                column: "PrioridadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tema_UsuarioId1",
                table: "Tema",
                column: "UsuarioId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "Repeticion");

            migrationBuilder.DropTable(
                name: "TipoRepeticion");

            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "TipoObjeto");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Tema");

            migrationBuilder.DropTable(
                name: "Prioridad");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
