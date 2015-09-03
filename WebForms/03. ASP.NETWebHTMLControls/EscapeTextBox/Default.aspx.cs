using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EscapeTextBox
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Submit_Click(object sender, EventArgs e)
        {
            this.TextBoxResult.Text = this.InputText.Text;
            this.LabelResult.Text = Server.HtmlEncode(this.TextBoxResult.Text);
        }
    }
}