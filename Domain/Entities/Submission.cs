namespace Domain.Entities
{
    public class Submission
    {
        public Guid Id { get; } = Guid.NewGuid();
        public required Assignment Assignment { get; set; }
        public required User User { get; set; }
        public required DateTime DateTime { get; set; }
    }
}
