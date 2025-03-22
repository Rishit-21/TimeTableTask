namespace TimeTableTask.Models
{
    public class TimetableModel
    {
        public List<string> WorkingDays { get; set; }
        public List<List<string>> TimetableGrid { get; set; }
    }
}
