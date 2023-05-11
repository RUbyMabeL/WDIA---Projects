using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class CoopStudent : Student
    {
        public static int MaxWeeklyHours {  get; set; }
        public static int MaxNumOfCourses { get; set; }

        public CoopStudent(string name) : base(name) { }


        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totalHours = 0;
            foreach (var course in selectedCourses)
            {
                totalHours += course.WeeklyHours;
            }
            if (totalHours > MaxWeeklyHours)
            {
                throw new Exception($"Total weekly hours cannot exceed {MaxWeeklyHours} for coop students.");
            }
            if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new Exception($"Cannot register more than {MaxNumOfCourses} courses for coop students.");
            }
            base.RegisterCourses(selectedCourses);
        }

        public override string ToString()
        {
            return $"{Id} - {Name} (Coop)";
        }
    }
}