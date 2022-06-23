using InterRazor.Modelos;
using Microsoft.EntityFrameworkCore;

namespace InterRazor.Datos
{
    public class InterRazorDbContext : DbContext
    {

        public InterRazorDbContext(DbContextOptions<InterRazorDbContext> options): base (options)
        {

        }

        public DbSet<Curso> Curso { get; set; }
        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
    }
}
