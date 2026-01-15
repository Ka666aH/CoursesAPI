namespace Domain.Entities
{
    public class Submission
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Assignment Assignment { get; set; }
        public User User { get; set; }
        public DateTime DateTime { get; set; }
        public int? Grade { get; set; }
        public Submission(Assignment assignment, User user, DateTime dateTime, int? grade = null)
        {
            Assignment = assignment;
            User = user;
            DateTime = dateTime;
            Grade = grade;
        }
        private Submission() { }
    }
}
