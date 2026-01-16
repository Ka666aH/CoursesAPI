namespace Domain.Entities
{
    public class Assignment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required Module Module { get; set; }
        public required string Title{ get; set; }
    }
}
