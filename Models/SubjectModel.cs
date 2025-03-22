using System.ComponentModel.DataAnnotations;

namespace TimeTableTask.Models
{
    public class SubjectModel
    {
        [Required(ErrorMessage = "Subject name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Subject name must be between 2 and 50 characters.")]
        public string SubjectName { get; set; }

        [Required(ErrorMessage = "Allocated hours are required.")]
        [Range(1, 100, ErrorMessage = "Allocated hours must be at least 1.")]
        public int AllocatedHours { get; set; }
    }
}
