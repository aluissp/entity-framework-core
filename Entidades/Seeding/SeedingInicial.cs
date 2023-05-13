using Microsoft.EntityFrameworkCore;

namespace IntroEFCore.Entidades.Seeding
{
    public class SeedingInicial
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var samuelLJackson = new Actor
            {
                Id = 2,
                Nombre = "Samuel L. Jackson",
                FechaNacimiento = new DateTime(1948, 12, 21),
                Fortuna = 2200000
            };
            var robertDowneyJr = new Actor
            {
                Id = 3,
                Nombre = "Robert Downey Jr.",
                FechaNacimiento = new DateTime(1965, 4, 4),
                Fortuna = 3000000
            };
            var chrisEvans = new Actor
            {
                Id = 4,
                Nombre = "Chris Evans",
                FechaNacimiento = new DateTime(1981, 6, 13),
                Fortuna = 5000000
            };

            modelBuilder.Entity<Actor>().HasData(samuelLJackson, robertDowneyJr, chrisEvans);

            var avengers = new Pelicula
            {
                Id = 3,
                Titulo = "Avengers: Endgame",
                FechaEstreno = new DateTime(2019, 4, 26),
            };

            var spidermanNWH = new Pelicula
            {
                Id = 4,
                Titulo = "Spiderman No Way Home",
                FechaEstreno = new DateTime(2021, 12, 17)
            };

            var capitan3 = new Pelicula
            {
                Id = 6,
                Titulo = "Capitán América: Civil War",
                FechaEstreno = new DateTime(2016, 5, 6)
            };

            modelBuilder.Entity<Pelicula>().HasData(avengers, spidermanNWH, capitan3);

            var comentarioAvengers = new Comentario
            {
                Id = 5,
                Contenido = "Excelente película",
                PeliculaId = avengers.Id
            };

            var comentarioSpiderman = new Comentario
            {
                Id = 6,
                Contenido = "Muy buena película",
                PeliculaId = spidermanNWH.Id
            };

            var comentarioCapitan = new Comentario
            {
                Id = 7,
                Contenido = "Buena película",
                PeliculaId = capitan3.Id
            };

            modelBuilder.Entity<Comentario>().HasData(comentarioAvengers, comentarioSpiderman, comentarioCapitan);


            // Muchos a muchos con saltos
            var tablaGeneroPelicula = "GeneroPelicula";
            var generoIdProp = "GenerosId";
            var peliculaIdProp = "PeliculasId";
            var animacionId = 6;
            var cienciaFiccionId = 7;

            modelBuilder.Entity(tablaGeneroPelicula).HasData(
                new Dictionary<string, object>
                {
                    [generoIdProp] = cienciaFiccionId,
                    [peliculaIdProp] = avengers.Id
                },
                new Dictionary<string, object>
                {
                    [generoIdProp] = animacionId,
                    [peliculaIdProp] = spidermanNWH.Id
                }
            );

            // Muchos a muchos sin saltos
            var samuelLJacksonSpiderman = new PeliculaActor
            {
                ActorId = samuelLJackson.Id,
                PeliculaId = spidermanNWH.Id,
                Personaje = "Nick Fury",
                Orden = 1
            };

            var samuelLJacksonAvengers = new PeliculaActor
            {
                ActorId = samuelLJackson.Id,
                PeliculaId = avengers.Id,
                Personaje = "Nick Fury",
                Orden = 2
            };

            var robertDowneyJrAvengers = new PeliculaActor
            {
                ActorId = robertDowneyJr.Id,
                PeliculaId = avengers.Id,
                Personaje = "Tony Stark",
                Orden = 1
            };

            var robertDowneyJrCapitan = new PeliculaActor
            {
                ActorId = robertDowneyJr.Id,
                PeliculaId = capitan3.Id,
                Personaje = "Tony Stark",
                Orden = 1
            };

            modelBuilder.Entity<PeliculaActor>()
                .HasData(samuelLJacksonSpiderman,
                samuelLJacksonAvengers,
                robertDowneyJrAvengers,
                robertDowneyJrCapitan);
        }
    }
}
