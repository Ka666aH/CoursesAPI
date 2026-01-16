using System.Xml.Linq;

namespace Domain.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<Guid> AuthorIds { get; set; } = [];
        public List<Module> Modules { get; set; } = [];
    }
}