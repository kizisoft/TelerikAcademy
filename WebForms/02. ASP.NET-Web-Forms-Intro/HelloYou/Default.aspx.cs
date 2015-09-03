using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloYou
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ShowName_Click(object sender, EventArgs e)
        {
            this.Message.Text = this.FirstName.Text + " " + this.SecondName.Text;
            this.ResultMessage.Visible = true;
        }
    }
}