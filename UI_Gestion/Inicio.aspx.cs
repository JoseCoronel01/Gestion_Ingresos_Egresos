using System;
using UI_Gestion.Code;
using PCL_Gestion.str;
using PCL_Gestion.dao;
using PCL_Gestion.BusinessRules;

namespace UI_Gestion
{
    public partial class Inicio : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != "" && txtPassword.Text != "")
            {
                BRPortal portal = new BRPortal(this.GetStringConnectionPortal);

                string[] host = this.Request.Url.Host.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);

                this.GetStringConnection = portal.GetPortal(host[0]);

                strUsuarioSistema str = null;

                daoUsuariosSistema dao = new daoUsuariosSistema(this.GetStringConnection);

                str = dao.GetIn(txtUserName.Text, txtPassword.Text);

                if (str != null)
                {
                    this.GetUserName = str.Usuario;
                    this.Page.Response.Redirect("/Default.aspx");
                }
            }
        }
    }
}