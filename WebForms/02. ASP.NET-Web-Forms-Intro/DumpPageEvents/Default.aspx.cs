using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DumpPageEvents
{
    public partial class _Default : Page
    {
        List<string> events = new List<string>();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            events.Add("Page_PreInit");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            events.Add("Page_Init");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            events.Add("Page_Load");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            events.Add("Page_PreRender");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // Response is unavailable at page unload
            // events.Add("Page_Unload");
        }

        protected void ButtonShow_Init(object sender, EventArgs e)
        {
            events.Add("ButtonShow_Init");
        }

        protected void ButtonShow_Load(object sender, EventArgs e)
        {
            events.Add("ButtonShow_Load");
        }

        protected void ButtonShow_Click(object sender, EventArgs e)
        {
            events.Add("ButtonShow_Click");
        }

        protected void ButtonShow_PreRender(object sender, EventArgs e)
        {
            events.Add("ButtonShow_PreRender");
            PrintEvent();
        }

        protected void ButtonShow_Unload(object sender, EventArgs e)
        {
            // Response is unavailable at control unload
            // events.Add("ButtonShow_Unload");
        }

        private void PrintEvent()
        {
            foreach (var eventName in events)
            {
                var li = new HtmlGenericControl("li");
                li.Attributes["class"] = "list-group-item";
                li.InnerText = eventName + " invoked!";
                this.Results.Controls.Add(li);
            }
        }
    }
}