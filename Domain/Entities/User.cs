namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserProfile Profile { get; set; } = new();
        //public User(string name, string email, UserProfile profile)
        //{
        //    SetName(name.Trim());
        //    SetEmail(email.Trim());
        //    SetProfile(profile);
        //}
        //public void SetName(string newName)
        //{
        //    if (!string.IsNullOrEmpty(newName)) Name = newName;
        //    else throw new InvalidDataException("Имя не может быть пустым.");
        //}
        //public void SetEmail(string newEmail)
        //{
        //    if (IsValidEmail(newEmail)) Email = newEmail;
        //    else throw new InvalidDataException("Email некорректен.");
        //}
        //private bool IsValidEmail(string email)
        //{
        //    int atIndex = email.IndexOf('@');
        //    if (atIndex < 1 || atIndex > email.Length - 4) return false;

        //    string domain = email.Substring(atIndex + 1);
        //    int dotIndex = domain.IndexOf('.');
        //    if (dotIndex < 1 || dotIndex == domain.Length - 1) return false;

        //    return true;
        //}
        //public void SetProfile(UserProfile newProfile) => Profile = newProfile;
        //private User() { }
    }
}