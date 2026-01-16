namespace Domain.Entities
{
    public class Enrollment
    {
        public required User User { get; set; }
        public required Course Course { get; set; }
        public required DateOnly Date { get; set; }
    }
}
