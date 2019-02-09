namespace EfSamurai.Domain
{
    // Dependent entitet till Samurai
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }  // har foreign key till Samurai

        public QuoteStyle? Style { get; set; }
    }
}
