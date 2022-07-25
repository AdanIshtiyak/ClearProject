namespace AnalyzesWebApplication.Models
{
    public class Analyz
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public IEnumerable<Norm> Norm { get; set; }
    }
}
