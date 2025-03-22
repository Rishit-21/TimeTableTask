using System;
using System.Collections.Generic;
using System.Linq;
using TimeTableTask.Common.Enum;
using TimeTableTask.Models;

namespace TimeTableTask.Services
{
    public class TimetableService
    {
        public TimetableModel GenerateTimetable(List<SubjectModel> subjects, int totalHours, int totalWorkingDays)
        {
            int row = totalWorkingDays; // Number of working days
            int col = totalHours / row; // Number of hours per day

            var workingDays = Enum.GetValues(typeof(eWeekDays))
                      .Cast<eWeekDays>()
                      .Take(totalWorkingDays)
                      .Select(day => day.ToString()) // Convert Enum to string
                      .ToList();

            // Initialize timetableGrid using LINQ
            var timetableGrid = Enumerable.Range(0, row)
                                          .Select(_ => new List<string>(new string[col]))
                                          .ToList();

            int subIndex = 0; // Track the subject index
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    // Find the next available subject with allocated hours
                    while (subjects[subIndex].AllocatedHours == 0)
                    {
                        subIndex = (subIndex + 1) % subjects.Count; // Move to next subject in a circular manner
                    }

                    // Assign the subject to the timetable
                    timetableGrid[i][j] = subjects[subIndex].SubjectName;
                    subjects[subIndex].AllocatedHours--;

                    // Move to the next subject
                    subIndex = (subIndex + 1) % subjects.Count;
                }
            }

            return new TimetableModel
            {
                WorkingDays = workingDays,
                TimetableGrid = timetableGrid
            };
        }
    }
}
