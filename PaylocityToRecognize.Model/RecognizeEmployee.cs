namespace PaylocityToRecognize.Model
{
    public class RecognizeEmployee
    {
        public string EmployeeId{ get; set; }
        public string Email{ get; set; } //required
        public string FirstName { get; set; } //required
        public string LastName { get; set; } //required
        public string DisplayName { get; set; }
        public string JobTitle { get; set; }
        public string Phone { get; set; }
        public string Team { get; set; }
        public string Roles { get; set; }
        public string StartDate { get; set; } //mm/dd/yyyy
        public string BirthDate { get; set; } //mm/dd
        public string ManagerEmail { get; set; } //optional - must be users in recognized
        public string Country { get; set; }
        public string Department { get; set; }
        public string Locale { get; set; }
        public string Status { get; set; }
    }
}