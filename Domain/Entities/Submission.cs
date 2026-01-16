namespace Domain.Entities
{
    public class Submission
    {
        public Guid Id { get; set; } 
        public Guid AssignmentId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
