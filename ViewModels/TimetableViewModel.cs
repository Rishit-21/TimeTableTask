using TimeTableTask.Models;

namespace TimeTableTask.ViewModels
{
    public class TimetableViewModel
    {
        public int TotalHours { get; set; }
        public int TotalSubjects { get; set; }
        public int TotalWorkingDays { get; set; }
        public List<SubjectModel> Subjects { get; set; } = new List<SubjectModel>();
    }
}
