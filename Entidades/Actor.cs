namespace IntroEFCore.Entidades
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Fortuna { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
