using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroEFCore.Entidades.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            var animacion = new Genero { Id = 6, Nombre = "Animación" };
            var cienciaFiccion = new Genero { Id = 7, Nombre = "Ciencia Ficción" };
            
            builder.HasData(cienciaFiccion, animacion);
        }
    }
}
