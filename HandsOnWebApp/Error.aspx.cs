using System;
using System.Web;
using System.Web.UI;

namespace HandsOnWebApp {

    public partial class Error : Page {

        protected void Page_Load(object sender, EventArgs e) {
            Exception exc = Server.GetLastError();
            exc = exc.InnerException ?? exc;
            this.Label1.Text = HttpUtility.HtmlEncode(string.Format("{0}: \"{1}\"", exc.GetType(), exc.Message));
            Server.ClearError();
        }
    }
}