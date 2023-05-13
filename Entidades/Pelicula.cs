namespace IntroEFCore.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }

        // Relación con la entidad Comentario
        public HashSet<Comentario> Comentarios { get; set; } = new HashSet<Comentario>();
        // Relación con la entidad Genero
        public HashSet<Genero> Generos { get; set; } = new HashSet<Genero>();
        // Relación con la entidad PeliculaActor
        public List<PeliculaActor> PeliculasActores { get; set; } = new List<PeliculaActor>();
    }
}
