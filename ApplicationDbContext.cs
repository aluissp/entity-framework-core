using IntroEFCore.Entidades;
using IntroEFCore.Entidades.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IntroEFCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aquí se pueden agregar configuraciones adicionales
            // modelBuilder.Entity<Genero>().HasKey(g => g.Id);
            //modelBuilder.Entity<Genero>().Property(g => g.Nombre).HasMaxLength(150);

            // Llamada a las configuraciones en la carpeta Configuraciones
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Seeding de datos
            SeedingInicial.Seed(modelBuilder);
        }

        // Estamos sobreescribiendo la configuración de las propiedades de tipo string para que tengan un máximo de 150 caracteres.
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        public DbSet<Actor> Actores => Set<Actor>();
        public DbSet<Genero> Generos => Set<Genero>();
        public DbSet<Pelicula> Peliculas => Set<Pelicula>();
        public DbSet<Comentario> Comentarios => Set<Comentario>();
        public DbSet<PeliculaActor> PeliculasActores => Set<PeliculaActor>();
    }
}
