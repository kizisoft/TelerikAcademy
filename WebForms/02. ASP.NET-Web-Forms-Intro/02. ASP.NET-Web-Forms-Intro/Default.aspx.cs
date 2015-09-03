using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.ASP.NET_Web_Forms_Intro
{
    public partial class _Default : Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            var assemblyName = Assembly.GetExecutingAssembly().Location;
            this.AssemblyName.Text += assemblyName;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ShowHello_Click(object sender, EventArgs e)
        {
            this.HelloLabel.Text = "Hello, ASP.Net! - from code behind!";
            this.HelloLabel.Visible = true;
        }
    }
}