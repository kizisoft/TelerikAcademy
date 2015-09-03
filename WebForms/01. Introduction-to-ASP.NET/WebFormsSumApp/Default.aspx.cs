using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsSumApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calc(object sender, EventArgs e)
        {
            var firstNumber = int.Parse(this.FirstNumber.Text);
            var secondNumber = int.Parse(this.FirstNumber.Text);
            var result = firstNumber + secondNumber;

            this.ResultMessage.Visible = true;
            this.Message.Text = result.ToString();
        }
    }
}