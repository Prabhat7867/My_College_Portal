using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Student_Result_Management.Models
{
    public class Y2024
    {
        [Key]
        [Required]
        [DisplayName("Roll No.")]
        public int RollNo { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Passed Year")]
        public int PassedYear { get; set; }

        [Required]
        public int Hindi { get; set; }

        [Required]
        public int English { get; set; }

        [Required]
        public int Physics { get; set; }

        [Required]
        public int Chemistry { get; set; }

        [Required]
        public int Maths { get; set; }
    }
}
