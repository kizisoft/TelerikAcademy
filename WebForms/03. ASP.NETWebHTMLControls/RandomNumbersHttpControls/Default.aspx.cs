using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumbersHttpControls
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

            if (!int.TryParse(this.inputMin.Value, out min))
            {
                this.inputMin.Value = min.ToString();
            }

            if (!int.TryParse(this.inputMax.Value, out max))
            {
                max = 100;
                this.inputMax.Value = max.ToString();
            }

            if (!int.TryParse(this.inputCount.Value, out count))
            {
                count = 50;
                this.inputCount.Value = count.ToString();
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

            this.Results.Value = numbers;
        }
    }
}