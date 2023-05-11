using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class FulltimeStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }

        public FulltimeStudent(string name) : base(name) { }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int hours = 0;
            foreach (Course c in selectedCourses)
            {
                Course SelectedCourse = Helper.GetCourseByCode(c.Code);
                hours += SelectedCourse.WeeklyHours;
            }
            if (hours > MaxWeeklyHours)
            {
                throw new Exception("Total weekly hours cannot exceed {MaxWeeklyHours} for full-time students.");
            }
            base.RegisterCourses(selectedCourses);
        }

        public override string ToString()
        {
            return $"{Id} - {Name} (Full time)";
        }


    }
}