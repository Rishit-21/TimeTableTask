using Microsoft.AspNetCore.Mvc;
using TimeTableTask.Models;
using TimeTableTask.Services;
using TimeTableTask.ViewModels;

namespace DynamicTimeTableGenerator.Controllers
{
    public class TimetableController : Controller
    {
        private readonly TimetableService _timetableService;

        public TimetableController()
        {
            _timetableService = new TimetableService();
        }

        [HttpPost]
        public IActionResult GetTimetableForm(TimetableInputModel input)
        {
            if (input.NoOfWorkingDays < 1 || input.NoOfWorkingDays > 7 ||
                input.SubjectsPerDay < 1 || input.SubjectsPerDay > 8 ||
                input.TotalSubjects <= 0)
            {
                ViewBag.Error = "Invalid input values!";
                return View("Error");
            }


            var viewModel = new TimetableViewModel
            {
                TotalHours = input.NoOfWorkingDays * input.SubjectsPerDay,
                TotalSubjects = input.TotalSubjects,
                TotalWorkingDays = input.NoOfWorkingDays
            };
            for (int i = 0; i < viewModel.TotalSubjects; i++)
            {
                viewModel.Subjects.Add(new SubjectModel());
            }


            return View("SubjectsForm", viewModel);
        }

        [HttpPost]
        public IActionResult GenerateTimetable(List<SubjectModel> subjects, int totalHours, int totalWorkingDays )
        {
            if (subjects.Sum(s => s.AllocatedHours) != totalHours)
            {
                ViewBag.Error = "Total subject hours must match the calculated total hours!";
                return View("Error");
            }

            TimetableModel timetable = _timetableService.GenerateTimetable(subjects, totalHours, totalWorkingDays);
            return View("GeneratedTimetable", timetable);
        }
    }
}