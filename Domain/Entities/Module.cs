namespace Domain.Entities
{
    public class Module
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CourseId { get; init; }
        public int Number { get;  set; }
        public string Title { get;  set; } = string.Empty;
        public List<Assignment> Assignments { get;  set; } = [];
    }
}
