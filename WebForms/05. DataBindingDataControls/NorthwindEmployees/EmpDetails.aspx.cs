using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindEmployees
{
    public partial class EmpDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employees.aspx");
        }

        protected void NorthwindDetails_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["EmployeeID"];
            NorthwindDetails.SelectCommand = "SELECT [EmployeeID], [FirstName], [LastName], [BirthDate], [HireDate], [Country], [City], [Address] FROM [Employees] WHERE [EmployeeID] = " + id;
        }
    }
}