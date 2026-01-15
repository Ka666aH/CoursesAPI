namespace Domain.Entities
{
    public class Assignment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Module Module { get; set; }
        public string Title{ get; set; }
        public Assignment(Module module, string title)
        {
            Module = module;
            Title = title;
        }
        private Assignment() { }
    }
}
