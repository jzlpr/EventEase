using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class AttendanceModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string UserEmail { get; set; } = string.Empty;
    }
}
