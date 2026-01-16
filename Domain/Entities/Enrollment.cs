namespace Domain.Entities
{
    public class Enrollment
    {
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public DateOnly Date { get; set; }
    }
}
