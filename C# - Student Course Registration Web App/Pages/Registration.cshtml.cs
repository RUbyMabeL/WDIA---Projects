using AcademicManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Lab3.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public string SelectedStudentId { get; set; }
        [BindProperty]
        public List<SelectListItem> CourseSelections { get; set; }
        public List<Course> SelectedCourses { get; set; }
        public List<AcademicRecord> AcademicRecords { get; set; }
        public List<Student> Students { get; set; } = DataAccess.GetAllStudents();
        public List<Course> Courses { get; set; } = DataAccess.GetAllCourses();
        public string RegisterStatus { get; set; }
        [BindProperty]
        public Dictionary<string, double?> Grade { get; set; }
        public string OrderBy { get; set; }

        private void SortCourses()
        {
            if (OrderBy == "code")
            {
                if (AcademicRecords.Count == 0 || AcademicRecords.Count == null)
                {
                    Courses.Sort((s1, s2) => s1.CourseCode.CompareTo(s2.CourseCode));
                }
                else
                {
                    AcademicRecords.Sort((s1, s2) => s1.CourseCode.CompareTo(s2.CourseCode));
                }
            }
            else if (OrderBy == "title")
            {
                if (AcademicRecords.Count == 0 || AcademicRecords.Count == null)
                {
                    Courses.Sort((s1, s2) => s1.CourseTitle.CompareTo(s2.CourseTitle));
                }
                else
                {
                    AcademicRecords.Sort((s1, s2) =>
                    {
                        Course c1 = GetCourseByCode(s1.CourseCode);
                        Course c2 = GetCourseByCode(s2.CourseCode);
                        return c1.CourseTitle.CompareTo(c2.CourseTitle);
                    });
                }
            }
            else if (OrderBy == "grade")
            {
                AcademicRecords.Sort((c1, c2) => c1.Grade.CompareTo(c2.Grade));
            }
        }
        public Course GetCourseByCode(string courseCode)
        {
            Courses = DataAccess.GetAllCourses();
            return Courses.FirstOrDefault(c => c.CourseCode == courseCode);
        }

        public void OnGet(string orderby)
        {
            if (HttpContext.Session.GetString("SelectedStudentId") != null)
            {
                SelectedStudentId = HttpContext.Session.GetString("SelectedStudentId");
                AcademicRecords = DataAccess.GetAcademicRecordsByStudentId(SelectedStudentId);
                if (AcademicRecords.Count != 0)
                {
                    RegisterStatus = "HaveRecord";
                }
                else
                {
                    RegisterStatus = "NoRecord";
                }
            }
            else
            {
                SelectedStudentId = "-1";
            }

            if (orderby != null)
            {
                HttpContext.Session.SetString("orderby", orderby);
                OrderBy = orderby;
            }
            else
            {
                if (HttpContext.Session.GetString("orderby") != null)
                {
                    OrderBy = HttpContext.Session.GetString("orderby");
                }
            }
            SortCourses();
        }

        public void OnPostStudentSelected()
        {
            if (SelectedStudentId != "-1")
            {
                HttpContext.Session.SetString("SelectedStudentId", SelectedStudentId);

                AcademicRecords = DataAccess.GetAcademicRecordsByStudentId(SelectedStudentId);
                if (AcademicRecords.Count != 0)
                {
                    RegisterStatus = "HaveRecord";
                }
                else
                {
                    RegisterStatus = "NoRecord";
                }
            }
            else
            {
                RegisterStatus = "NotSelected";
            }
        }

        public void OnPostRegister()
        {
            SelectedCourses = new List<Course>();
            foreach (SelectListItem item in CourseSelections)
            {
                if (item.Selected)
                {
                    DataAccess.AddAcademicRecord(new AcademicRecord(SelectedStudentId, item.Value));
                }
                AcademicRecords = DataAccess.GetAcademicRecordsByStudentId(SelectedStudentId);
                SelectedCourses = Courses.Where(course => AcademicRecords.Any(record => record.CourseCode == course.CourseCode)).ToList();
            }

            if (SelectedCourses.Count > 0)
            {
                RegisterStatus = "HaveRecord";
            }
            else if (SelectedCourses.Count == 0)
            {
                RegisterStatus = "NotClicked";
            }
        }

        public void OnPostSubmitGrades()
        {
            AcademicRecords = DataAccess.GetAcademicRecordsByStudentId(SelectedStudentId);
            SelectedCourses = Courses.Where(course => AcademicRecords.Any(record => record.CourseCode == course.CourseCode)).ToList();
            foreach (Course c in SelectedCourses)
            {
                AcademicRecord record = AcademicRecords.FirstOrDefault(r => r.CourseCode == c.CourseCode);
                if (Grade[c.CourseCode] != null)
                {
                    record.Grade = (double)Grade[c.CourseCode];
                }
                else
                {
                    record.Grade = -100;
                }
            }
            RegisterStatus = "HaveRecord";


            OrderBy = HttpContext.Session.GetString("orderby");
            SortCourses();
        }
    }
}