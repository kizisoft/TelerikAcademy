using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator
{
    public partial class _default : System.Web.UI.Page
    {
        string number = "0";

        protected void Result_PreRender(object sender, EventArgs e)
        {
            this.Result.Text = number;
        }

        protected void ButtonNumber_Click(object sender, EventArgs e)
        {
            if (ViewState["FirstValue"] != null)
            {
                ViewState["shouldCalc"] = true;
            }

            number = this.Result.Text;
            if (number.Length == 19)
            {
                return;
            }

            var button = sender as IButtonControl;
            int digit = 0;
            if (int.TryParse(button.Text, out digit))
            {
                if (ViewState["shouldClear"] != null && (bool)ViewState["shouldClear"] == true)
                {
                    ViewState["shouldClear"] = false;
                    number = "0";
                }

                if (number == "0")
                {
                    number = digit.ToString();
                }
                else
                {
                    number += digit;
                }
            }
        }

        protected void ButtonMath_Click(object sender, EventArgs e)
        {
            var button = sender as IButtonControl;

            if (button.CommandName == "sqrt")
            {
                string firstValStr = ViewState["FirstValue"] != null ? ViewState["FirstValue"].ToString() : this.Result.Text;
                this.Calc.Text += "sqrt(" + firstValStr + ")";
                try
                {
                    var val = double.Parse(firstValStr);
                    number = Calculate(val, 0, button.CommandName).ToString();
                    //ViewState["FirstValue"] = number;
                    ViewState["shouldCalc"] = true;
                }
                catch (Exception exeption)
                {
                    number = exeption.Message;
                }

                return;
            }

            if (ViewState["shouldCalc"] == null || (bool)ViewState["shouldCalc"] != true)
            {
                var length = this.Calc.Text.Length;
                ViewState["Math"] = button.CommandName;

                if (ViewState["FirstValue"] == null)
                {
                    ViewState["FirstValue"] = this.Result.Text;
                }

                if (length > 0)
                {
                    if (this.Calc.Text[length - 1] != ')')
                    {
                        this.Calc.Text = this.Calc.Text.Remove(length - 1);
                    }

                    this.Calc.Text += button.Text;
                    return;
                }

                this.Calc.Text = this.Result.Text + button.Text;
                return;
            }

            double firstValue = ViewState["FirstValue"] == null ? double.Parse(this.Result.Text) : double.Parse(ViewState["FirstValue"].ToString());
            double secondValue = double.Parse(this.Result.Text);
            try
            {
                number = Calculate(firstValue, secondValue, ViewState["Math"].ToString()).ToString();
                ViewState["FirstValue"] = number;
                this.Calc.Text += this.Result.Text + button.Text;
                ViewState["Math"] = button.CommandName;
                ViewState["shouldCalc"] = false;
                ViewState["shouldClear"] = true;
            }
            catch (Exception exeption)
            {
                number = exeption.Message;
            }
        }

        protected void ButtonCalc_Click(object sender, EventArgs e)
        {
            var button = sender as IButtonControl;

            if (ViewState["Math"] == null)
            {
                this.Calc.Text = "";
                ViewState["FirstValue"] = null;
                ViewState["shouldCalc"] = false;
                ViewState["shouldClear"] = true;
                return;
            }

            double firstValue = ViewState["FirstValue"] == null ? double.Parse(this.Result.Text) : double.Parse(ViewState["FirstValue"].ToString());
            double secondValue = double.Parse(this.Result.Text);
            try
            {
                number = Calculate(firstValue, secondValue, ViewState["Math"].ToString()).ToString();
                ViewState["FirstValue"] = number;
                this.Calc.Text = "";
                ViewState["Math"] = null;
                ViewState["shouldCalc"] = false;
                ViewState["shouldClear"] = true;
            }
            catch (Exception exeption)
            {
                number = exeption.Message;
            }
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            this.ViewState["FirstValue"] = null;
            this.ViewState["shouldCalc"] = null;
            this.Result.Text = "";
            this.Calc.Text = "";
        }

        private decimal Calculate(double firstValue, double secondValue, string operand)
        {
            switch (operand)
            {
                case "plus":
                    return (decimal)(firstValue + secondValue);
                case "minus":
                    return (decimal)(firstValue - secondValue);
                case "mult":
                    return (decimal)(firstValue * secondValue);
                case "div":
                    if (secondValue == 0)
                    {
                        throw new DivideByZeroException("Divide by zero!");
                    }

                    return (decimal)(firstValue / secondValue);
                case "sqrt":
                    if (firstValue < 0)
                    {
                        throw new ArithmeticException("Invalid input!");
                    }

                    return (decimal)Math.Sqrt(firstValue);
                default:
                    throw new ArithmeticException("Invalid operation!");
            }
        }
    }
}