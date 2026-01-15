namespace Domain.Entities
{
    public class Enrollment
    {
        public User User { get; set; }
        public Course Course { get; set; }
        public DateOnly Date { get; set; }
        public Enrollment(User user, Course course, DateOnly date)
        {
            User = user;
            Course = course;
            Date = date;
        }
        private Enrollment() { }
    }
}
