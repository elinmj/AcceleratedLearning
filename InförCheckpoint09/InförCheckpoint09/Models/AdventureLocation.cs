namespace InförCheckpoint09.Models
{
    public class AdventureLocation
    {
        public int AdventureId { get; set; }
        public Adventure Adventure { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}