namespace Domain.Entities
{
    public class Assignment
    {
        public Guid Id { get; set; }
        public Guid ModuleId { get; set; }
        public Module Module { get; set; } = null!;
        public string Title{ get; set; } = string.Empty;
    }
}
