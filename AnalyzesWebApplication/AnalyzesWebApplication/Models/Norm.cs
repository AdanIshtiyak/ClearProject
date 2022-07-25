namespace AnalyzesWebApplication.Models
{
    public class Norm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double ManMin { get; set; }
        public double ManMax { get; set; }
        public double WManMin { get; set; }
        public double WManMax { get; set; }

        public int AnalyzId { get; set; }
        public Analyz Anzlyz { get; set; }
    }
}
