namespace Domain.Entities
{
    public class Authorship
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
    }
}