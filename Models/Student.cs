using System.ComponentModel.DataAnnotations;

namespace GoMath.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã học sinh không được để trống")]
        [Display(Name = "Mã học sinh")]
        public string StudentCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Lớp không được để trống")]
        [Display(Name = "Lớp")]
        public string ClassName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Điểm trung bình không được để trống")]
        [Display(Name = "Điểm trung bình")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm trung bình phải từ 0.00 đến 10.00")]
        public double AverageScore { get; set; }

        public string GetRank()
        {
            return AverageScore switch
            {
                >= 8.0 => "Tốt",
                >= 6.5 => "Khá",
                >= 5.0 => "Đạt",
                _ => "Chưa đạt"
            };
        }
    }
}
