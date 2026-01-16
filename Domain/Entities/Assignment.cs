namespace Domain.Entities
{
    public class Assignment
    {
        public Guid Id { get; set; }
        public Guid ModuleId { get; set; }
        public string Title{ get; set; } = string.Empty;
    }
}
