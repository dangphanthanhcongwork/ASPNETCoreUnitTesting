namespace WebApplication.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{LastName} {FirstName}";
            }
        }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BirthPlace { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsGraduated { get; set; }
    }
}
