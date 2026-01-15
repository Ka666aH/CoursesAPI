namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Email { get; private set; }
        public UserProfile Profile { get; private set; } = new();
        public User(string name, string email, UserProfile profile)
        {
            Name = name;
            Email = email;
            Profile = profile;
        }
        public void UpdateName(string newName)
        {
            Name = newName;
        }
        private User() { }
    }
}