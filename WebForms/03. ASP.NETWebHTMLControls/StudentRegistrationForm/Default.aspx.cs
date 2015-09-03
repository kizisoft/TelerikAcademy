using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace StudentRegistrationForm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            this.PlaceHolderResult.Visible = false;
            this.TextBoxFirstName.Text = "";
            this.TextBoxLastName.Text = "";
            this.TextBoxFacultyNumber.Text = "";
            this.DropDownUniversity.SelectedItem.Selected = false;
            this.DropDownSpecialty.SelectedItem.Selected = false;
            this.ListBoxCourses.SelectedIndex = -1;
        }

        protected void ButtonCreateStudent_Click(object sender, EventArgs e)
        {
            var panelDefault = new Panel() { CssClass = "panel panel-default" };
            var panelBody = new Panel() { CssClass = "panel-body" };
            panelDefault.Controls.Add(panelBody);

            var name = new HtmlGenericControl("h2") { InnerText = Server.HtmlEncode(this.TextBoxFirstName.Text) + " " + Server.HtmlEncode(this.TextBoxLastName.Text) };
            panelBody.Controls.Add(name);

            panelBody.Controls.Add(new HtmlGenericControl("hr"));

            var facultyNumberLabel = new Label() { Text = "Faculty number: " };
            panelBody.Controls.Add(facultyNumberLabel);
            var facultyNumber = new Literal() { Text = Server.HtmlEncode(this.TextBoxFacultyNumber.Text) };
            panelBody.Controls.Add(facultyNumber);

            panelBody.Controls.Add(new HtmlGenericControl("br"));

            var universityLabel = new Label() { Text = "University: " };
            panelBody.Controls.Add(universityLabel);
            var university = new Literal() { Text = Server.HtmlEncode(this.DropDownUniversity.SelectedItem.Text) };
            panelBody.Controls.Add(university);

            panelBody.Controls.Add(new HtmlGenericControl("br"));

            var specialtyLabel = new Label() { Text = "Specialty: " };
            panelBody.Controls.Add(specialtyLabel);
            var specialty = new Literal() { Text = Server.HtmlEncode(this.DropDownSpecialty.SelectedItem.Text) };
            panelBody.Controls.Add(specialty);

            panelBody.Controls.Add(new HtmlGenericControl("br"));

            var coursesLabel = new Label() { Text = "Courses: " };
            panelBody.Controls.Add(coursesLabel);
            var ul = new HtmlGenericControl("ul");
            foreach (int i in this.ListBoxCourses.GetSelectedIndices())
            {
                var course = new HtmlGenericControl("li") { InnerText = Server.HtmlEncode(this.ListBoxCourses.Items[i].Text) };
                ul.Controls.Add(course);
            }

            panelBody.Controls.Add(ul);
            panelDefault.Controls.Add(panelBody);
            this.PlaceHolderResult.Controls.Add(panelDefault);
            this.PlaceHolderResult.Visible = true;
        }
    }
}