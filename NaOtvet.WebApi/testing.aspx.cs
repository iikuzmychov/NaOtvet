using System;
using System.Web.UI;

namespace NaOtvet.WebApi
{
    public partial class testing : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["session_id"] != null && int.TryParse(Request.QueryString["session_id"], out int session_id))
                ng.Attributes["ng-init"] = $"init(478664, {session_id}, 1605115228)";
        }
    }
}