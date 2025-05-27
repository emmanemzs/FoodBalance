using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proj1
{
    public partial class Landing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Nav(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string buttonName = clickedButton.Text;

            Response.Redirect($"~/{buttonName}.aspx");

            // nav to aspx with correlating button name
        }
    }
}