using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumbersWebControls
{
    public partial class Default : System.Web.UI.Page
    {
        Random rand = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Generate_Click(object sender, EventArgs e)
        {
            int min;
            int max;
            int count;

            if (!int.TryParse(this.InputMin.Text, out min))
            {
                this.InputMin.Text = min.ToString();
            }

            if (!int.TryParse(this.InputMax.Text, out max))
            {
                max = 100;
                this.InputMax.Text = max.ToString();
            }

            if (!int.TryParse(this.InputCount.Text, out count))
            {
                count = 50;
                this.InputCount.Text = count.ToString();
            }

            string numbers = "";
            string str = ", ";
            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    str = "";
                }

                numbers += rand.Next(min, max) + str;
            }

            this.Results.Text = numbers;
        }
    }
}