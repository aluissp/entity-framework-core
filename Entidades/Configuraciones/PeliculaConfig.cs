using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroEFCore.Entidades.Configuraciones
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            //builder.Property(p => p.Titulo).HasMaxLength(150);
            builder.Property(p => p.FechaEstreno).HasColumnType("date");
        }
    }
}
