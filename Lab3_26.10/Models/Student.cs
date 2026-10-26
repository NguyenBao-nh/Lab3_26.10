using System.ComponentModel.DataAnnotations;

namespace Lab3_26._10.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string? name { get; set; }

        [Required(ErrorMessage = "Email bắt buộc phải được nhập")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$", ErrorMessage = "Email không đúng định dạng")]
        public string? Email { get; set; }

        [StringLength(100, MinimumLength = 8)]
        [Required]
        public string Password { get; set; }

        [Required]
        public string Branch { get; set; }

        [Required]
        public Gender? Gender { get; set; }

        public bool IsRegular { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string? Address { get; set; }

        [Range(typeof(DateTime), "1963-01-01", "2005-12-31", ErrorMessage = "Ngày sinh phải từ 01/01/1963 đến 31/12/2005")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBorth { get; set; }
    }
}