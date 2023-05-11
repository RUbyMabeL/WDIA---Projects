using Lab6;
using Lab6.Models;
using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class Student
    {
        public int Id { get; }
        public string Name { get; }
        public List<Course> RegisteredCourses { get; }

        public Student(string name)
        {
            Name = name;
            int x = new Random().Next(0, 1000000);
            string y = x.ToString("000000");
            Id = int.Parse(y);
            RegisteredCourses = new List<Course>();
        }

        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();
            RegisteredCourses.AddRange(selectedCourses);
        }

        public int TotalWeeklyHours(List<Course> RegisteredCourses)
        {
            int hours = 0;
            foreach (Course c in RegisteredCourses)
            {
                Course SelectedCourse = Helper.GetCourseByCode(c.Code);
                hours += SelectedCourse.WeeklyHours;
            }
            return hours;
        }
        public override string ToString()
        {
            return $"{Id} - {Name} (student type)";
        }

    }

}