using Lab6.Models;
using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab6
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Student> students = Session["Students"] as List<Student> ?? new List<Student>();
                foreach (Student student in students)
                {
                    selectStudent.Items.Add(student.ToString());
                    foreach (ListItem a in selectStudent.Items)
                    {
                        a.Attributes.Add("CssClass", "input");
                    }
                }

                foreach (Course c in Helper.GetAvailableCourses())
                {
                    course.Items.Add(new ListItem(c.Title + " - " + c.WeeklyHours.ToString() + " hours per week", c.Code));
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            bool IsValid = true;
            if (selectStudent.SelectedValue == "-1")
            {
                error3.Text = "Must select one!";
                IsValid = false;
            }
            else
            {
                error3.Text = "";
            }

            bool noCourseSelected = true;
            int time = 0;

            if (selectStudent.SelectedValue.Contains("Full"))
            {
                foreach (ListItem item in course.Items)
                {
                    if (item.Selected == true)
                    {
                        noCourseSelected = false;
                        Course SelectedCourse = Helper.GetCourseByCode(item.Value);
                        time += SelectedCourse.WeeklyHours;
                    }
                }
                if (time > 16)
                {
                    IsValid = false;
                    error.Text = "Your selection exceeds the maximum weekly hours: 16";
                    error.Style.Add("color", "red");
                }
            }
            else if (selectStudent.SelectedValue.Contains("Part"))
            {
                int courseNum = 0;
                foreach (ListItem item in course.Items)
                {
                    if (item.Selected == true)
                    {
                        noCourseSelected = false;
                        courseNum++;
                        Course SelectedCourse = Helper.GetCourseByCode(item.Value);
                        time += SelectedCourse.WeeklyHours;
                    }
                }
                if (courseNum > 3)
                {
                    IsValid = false;
                    error.Text = "Your selection exceeds the maximum number of courses: 3";
                    error.Style.Add("color", "red");
                }
            }
            else if (selectStudent.SelectedValue.Contains("Coop"))
            {
                int courseNum2 = 0;
                foreach(ListItem item in course.Items)
                {
                    if (item.Selected == true)
                    {
                        noCourseSelected = false;
                        courseNum2++;
                        Course SelectedCourse = Helper.GetCourseByCode(item.Value);
                        time += SelectedCourse.WeeklyHours;
                    }
                }
                if (courseNum2 > 2)
                {
                    IsValid = false;
                    error.Text = "Your selection exceeds the maximum number of courses: 2";
                    error.Style.Add("color", "red");
                }
                if (time > 4)
                {
                    IsValid = false;
                    error.Text = "Your selection exceeds the maximum weekly hours: 4";
                    error.Style.Add("color", "red");
                }
            }

            if (noCourseSelected && selectStudent.SelectedValue != "-1")
            {
                error.Text = "Select at least one course";
                error.Style.Add("color", "red");
                IsValid = false;
            }


            if (IsValid)
            {
                int courseNum = 0;
                foreach (ListItem item in course.Items)
                {
                    if (item.Selected == true)
                    {
                        courseNum++;
                    }
                    error.Text = "";
                    error.Text = "Selected student has registered " + courseNum + " course(s), " + time + " hours weekly";
                    error.Style.Add("color", "blue");
                }
            }
        }
    }
}