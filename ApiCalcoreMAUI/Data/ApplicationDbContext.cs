using Microsoft.EntityFrameworkCore;
using ClasesMAUI.Models;

namespace ApiCalcoreMAUI.Data
{
    public class ApplicationDbContext : DbContext
    {

        //protected readonly IConfiguration Configuration;

        //public ApplicationDbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to sql server with connection string from app settings
        //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        //}

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }
       public DbSet<Prioridad>? Prioridad { get; set; }
        public DbSet<Tema>? Tema { get; set; }
        public DbSet<Usuario>? Usuario { get; set; }
        public DbSet<Contacto>? Contacto { get; set; }
        public DbSet<Cita>? Cita { get; set; }
        public DbSet<Tarea>? Tarea { get; set; }
        public DbSet<Repeticion>? Repeticion { get; set; }
        public DbSet<TipoRepeticion>? TipoRepeticion { get; set; }
        public DbSet<TipoObjeto>? TipoObjeto { get; set; }


    }
}