using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ClasesMAUI.Models;

namespace ApiCalNS
{
    public class ApiCalNSDbContext : DbContext
    {
        public DbSet<Prioridad>? Prioridad { get; set; }
        public DbSet<Tema>? Tema { get; set; }
        public DbSet<Usuario>? Usuario { get; set; }
        public DbSet<Contacto>? Contacto { get; set; }
        public DbSet<Cita>? Cita { get; set; }
        public DbSet<Tarea>? Tarea { get; set; }
        public DbSet<Repeticion>? Repeticion { get; set; }
        public DbSet<TipoRepeticion>? TipoRepeticion { get; set; }
        public DbSet<TipoObjeto>? TipoObjeto { get; set; }

        public ApiCalNSDbContext(
            DbContextOptions options)
             : base(options)
        {
        }

    }
}