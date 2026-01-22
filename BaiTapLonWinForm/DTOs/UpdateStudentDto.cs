using System.ComponentModel.DataAnnotations;

namespace BaiTapLonWinForm.DTOs
{
    public class UpdateStudentDto
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public bool? Gender { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public DateOnly? DateOfBirth { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? PhoneNumberOfParents { get; set; }
    }
}
