namespace Domain.Entities
{
    public class Course
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; init; }
        public List<Guid> AuthorIds { get; init; } = [];
        public List<Module> Modules { get; init; } = [];
        public Course(string title, List<Guid> authorIds, List<Module> modules)
        {
            Title = title;
            AuthorIds = authorIds;
            Modules = modules;
        }
        private Course() { }
    }
}