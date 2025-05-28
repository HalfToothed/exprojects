using DemoOne.Utilities;

namespace DemoOne.Models
{
    public class EditStudentModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int PhoneNumber { get; set; }
        public bool Status { get; set; }
        public Constants.RecordStatus State { get; set; }
    }
}
