using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControl_WUCDateTimePicker : System.Web.UI.UserControl
{
    public WebUserControl_WUCDateTimePicker loPicker = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        loPicker = this;
        //ScriptManager.RegisterClientScriptBlock(loPicker, loPicker.GetType(), "message", "<script type=\"text/javascript\" language=\"javascript\">getDateTimePicker();</script>", false);

        ScriptManager.RegisterStartupScript(loPicker, loPicker.GetType(), "", "<script type=\"text/javascript\" language=\"javascript\">getDateTimePicker();</script>", false);
    }
    public string DateTime
    {
        get { return txtFecha.Text; }
    }
}