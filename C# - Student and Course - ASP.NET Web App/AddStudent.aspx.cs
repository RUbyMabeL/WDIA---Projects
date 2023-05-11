using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab7
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Student> students = Session["Students"] as List<Student>;
            if (students == null || students.Count == 0)
            {
                TableRow rowNew = new TableRow();
                result.Rows.Add(rowNew);

                TableCell cell1 = new TableCell();
                rowNew.Cells.Add(cell1);
                cell1.Text = "";

                TableCell cell2 = new TableCell();
                rowNew.Cells.Add(cell2);
                cell2.Text = "No Student Yet!";
                cell2.Style.Add("color", "red");
            }
            else
            {
                foreach (Student student in students)
                {
                    TableRow rowNew = new TableRow();
                    result.Rows.Add(rowNew);

                    TableCell cell1 = new TableCell();
                    rowNew.Cells.Add(cell1);
                    cell1.Text = student.Id.ToString();

                    TableCell cell2 = new TableCell();
                    rowNew.Cells.Add(cell2);
                    cell2.Text = student.Name;
                }
            }
        }

        protected void NewStudent(object sender, EventArgs e)
        {
            List<Student> students = Session["Students"] as List<Student> ?? new List<Student>();
           
            string name = studentname.Text;
            if (string.IsNullOrEmpty(name))
            {
                error1.Text = "Required!";
            }
            else
            {
                error1.Text = "";
            }
            if (int.Parse(type.SelectedValue) == -1)
            {
                error2.Text = "Must select one!";
            }

            if (int.Parse(type.SelectedValue) == 0)
            {
                FulltimeStudent student1 = new FulltimeStudent(name);
                students.Add(student1);
                error2.Text = "";
            }
            else if (int.Parse(type.SelectedValue) == 1)
            {
                ParttimeStudent student2 = new ParttimeStudent(name);
                students.Add(student2);
                error2.Text = "";
            }
            else if (int.Parse(type.SelectedValue) == 2)
            {
                CoopStudent student3 = new CoopStudent(name);
                students.Add(student3);
                error2.Text = "";
            }

            Session["Students"] = students;

            result.Rows.Clear();

            TableRow rowHead = new TableHeaderRow();
            TableCell cell3 = new TableHeaderCell();
            TableCell cell4 = new TableHeaderCell();
            cell3.Text = "ID";
            cell4.Text = "Name";
            rowHead.Cells.Add(cell3);
            rowHead.Cells.Add(cell4);
            result.Rows.Add(rowHead);

            foreach (Student student in students)
            {
                TableRow rowNew = new TableRow();
                result.Rows.Add(rowNew);

                TableCell cell1 = new TableCell();
                rowNew.Cells.Add(cell1);
                cell1.Text = student.Id.ToString();

                TableCell cell2 = new TableCell();
                rowNew.Cells.Add(cell2);
                cell2.Text = student.Name;
            }
        }
    }
}