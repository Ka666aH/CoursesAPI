namespace Domain.Entities
{
    public class Module
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public int Number { get;  set; }
        public string Title { get;  set; } = string.Empty;
        public List<Assignment> Assignments { get;  set; } = [];
    }
}
