using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServer
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.RequestType=="POST")
            {
                // HTTP Post
                string key1 = Request.Form["key1"];
                string key2 = Request.Form["key2"];
                Response.Write("Web server has recieved " + key1 + " " + key2 + " from a client by POST.");
                //Response.End();
            }
            else
            {
                // HTTP Get
                string key1 = Request.QueryString["key1"];
                string key2 = Request.QueryString["key2"];
                Response.Write("Web server has recieved " + key1 + " " + key2 + " from a client by GET.");
                //Response.End();
               
            }

        }
    }
}