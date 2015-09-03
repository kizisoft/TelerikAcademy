namespace SearchCarsWebForm
{
    using SearchCarsWebForm.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Index : System.Web.UI.Page
    {
        private List<Producer> producers;
        private List<Extra> extras;
        private List<string> engines;

        protected void Page_Init(object sender, EventArgs e)
        {
            engines = new List<string>() { "1000cc", "1400cc", "1600cc", "1800cc", "2000cc", "2500cc" };
            extras = new List<Extra>()
            {
                new Extra("4x4"),
                new Extra("AutomaticTransmission"),
                new Extra("AirCondition"),
                new Extra("Parktronic")
            };
            producers = new List<Producer>()
            {
                new Producer("", new List<Model>(){ 
                }),
                new Producer("Mercedes", new List<Model>(){ 
                    new Model("C200"), 
                    new Model("C220"), 
                    new Model("S500")
                }),
                new Producer("BMW", new List<Model>(){ 
                    new Model("M5"),
                    new Model("M3"),
                    new Model("520d")
                }),
                new Producer("Subaru", new List<Model>(){
                    new Model("Legacy"),
                    new Model("Impresa"),
                    new Model("Outbac")
                })
            };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            this.DropDownListProducers.DataSource = producers;
            this.CheckBoxListExtras.DataSource = extras;
            this.RadioButtonListEngine.DataSource = engines;

            Page.DataBind();
        }

        protected void DropDownListModels_PreRender(object sender, EventArgs e)
        {
            if (this.DropDownListProducers.SelectedIndex > 0)
            {
                List<Model> selectedModels = producers.FirstOrDefault(p => p.Name == this.DropDownListProducers.SelectedItem.Text).Models;
                this.DropDownListModels.DataSource = selectedModels;
                this.DropDownListModels.DataBind();
                this.DropDownListModels.Enabled = true;
            }
            else
            {
                if (this.IsPostBack)
                {
                    this.DropDownListModels.SelectedItem.Text = "";
                    this.DropDownListModels.Enabled = false;
                }
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder resultStr = new StringBuilder("Car producer: " + this.DropDownListProducers.SelectedItem.Text + "<br />" +
                 "Model: " + this.DropDownListModels.SelectedItem.Text + "<br />Extras: <ul>");

            foreach (ListItem extra in this.CheckBoxListExtras.Items)
            {
                if (extra.Selected)
                {
                    resultStr.Append("<li>" + extra.Text + "</li>");
                }
            }

            resultStr.Append("</ul>Engine: " + this.RadioButtonListEngine.SelectedItem.Text);
            this.LiteralResult.Text = resultStr.ToString();
            this.PanelResult.Visible = true;
        }
    }
}