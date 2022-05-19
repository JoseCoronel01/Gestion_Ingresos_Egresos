using System;
using UI_Gestion.Code;

namespace UI_Gestion.Pages.WF
{
    public partial class frmMenu : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.GetStringConnection) == false && 
                String.IsNullOrEmpty(this.GetUserName) == false)
            {
                this.Page.Session.Remove("CreditoId");
                this.Page.Response.Redirect("/Pages/WF/frmAltaCredito.aspx");
            }
        }
    }
}