using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiUserAddressBook.Content
{
    public partial class AddressBook : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(Session["UserID"] == null)
                {
                    //Response.Redirect("~/Login.aspx");
                }
                lblDisplayName.Text = "Hi " + Session["DisplayName"].ToString();
            }
            ActiveNavBar();
        }
        private void ActiveNavBar()
        {
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            string[] str = path.Split('/');

            switch (str[2])
            {
                case "Country":
                    hlCountry.CssClass = "nav-link active";
                    break;
                case "State":
                    hlState.CssClass = "nav-link active";
                    break;
                case "City":
                    hlCity.CssClass = "nav-link active";
                    break;
                case "ContactCategory":
                    hlContactCategory.CssClass = "nav-link active";
                    break;
                case "Contact":
                    hlContact.CssClass = "nav-link active";
                    break;
            }
        }

        protected void lblLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}