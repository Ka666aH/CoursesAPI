namespace Domain.Entities
{
    public class Module
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CourseId { get; set; }
        public int Number { get; private set; }
        public string Title { get; set; }
        public List<Assignment> Assignments { get; set; } = [];
        public Module(Guid courseId, string title)
        {
            CourseId = courseId;
            Title = title;
        }
        private Module() { }
    }
}
