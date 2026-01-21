namespace Domain.Entities
{
    public class Submission
    {
        public Guid Id { get; set; } 
        public Guid AssignmentId { get; set; }
        public Assignment Assignment { get; set; } = null!;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime DateTime { get; set; }
    }
}
