using System.ComponentModel.DataAnnotations;

namespace TimeTableTask.Models
{
    public class TimetableInputModel
    {
        [Required(ErrorMessage = "Number of working days is required.")]
        [Range(1, 7, ErrorMessage = "Working days must be between 1 and 7.")]
        public int NoOfWorkingDays { get; set; }

        [Required(ErrorMessage = "Subjects per day is required.")]
        [Range(1, 8, ErrorMessage = "Subjects per day must be between 1 and 8.")]
        public int SubjectsPerDay { get; set; }

        [Required(ErrorMessage = "Total subjects is required.")]
        [Range(1, 100, ErrorMessage = "Total subjects must be greater than 0.")]
        public int TotalSubjects { get; set; }
    }
}
