using System.ComponentModel;

namespace Student_Result_Management.Models
{
    public class StudentDetails
    {
        public int RollNo { get; set; }

        [DisplayName("Student Name")]
        public string Name { get; set; } = null!;

        [DisplayName("Father's Name")]
        public string FathersName { get; set; } = null!;

        [DisplayName("Mother's Name")]
        public string MothersName { get; set; } = null!;

        public int Standard { get; set; }

        [DisplayName("Date of birth")]
        public string Dob { get; set; }

        [DisplayName("Passed Year")]
        public int? PassedYear { get; set; }
    }
}
