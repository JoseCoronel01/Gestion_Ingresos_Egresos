using System;
using UI_Gestion.Code;
using PCL_Gestion.str;
using PCL_Gestion.dao;
using System.Web.UI.HtmlControls;

namespace UI_Gestion
{
    public partial class SiteMaster : MasterBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.GetStringConnection) == true && 
                String.IsNullOrEmpty(this.GetUserName) == true)
            {
                this.Page.Response.Redirect("/Inicio.aspx");
            }
            else
            {
                daoUsuariosSistema dao = new daoUsuariosSistema(this.GetStringConnection);
                strUsuarioSistema str = dao.GetObject(this.GetUserName);
                if (str == null) return;
                lbTitulo.Text = "HOLA " + str.Usuario.ToUpper();
                switch (str.Tipo)
                {
                    case strUsuarioSistema.eTipo.SUPERVISOR:
                        {
                            HtmlGenericControl control1 = new HtmlGenericControl("li");
                            control1.InnerHtml = "<a runat='server' href='/Default.aspx'>Inicio</a>";

                            HtmlGenericControl control2 = new HtmlGenericControl("li");
                            control2.InnerHtml = "<a runat='server' href='/Pages/frmCatalogos.aspx'>Catálogos</a>";

                            HtmlGenericControl control3 = new HtmlGenericControl("li");
                            control3.InnerHtml = "<a runat='server' href='/Pages/frmPresupuesto.aspx'>Presupuesto</a>";

                            HtmlGenericControl control4 = new HtmlGenericControl("li");
                            control4.InnerHtml = "<a runat='server' href='/Pages/frmIngresos.aspx'>Ingresos</a>";

                            HtmlGenericControl control5 = new HtmlGenericControl("li");
                            control5.InnerHtml = "<a runat='server' href='/Pages/frmEgresos.aspx'>Egresos</a>";

                            HtmlGenericControl control6 = new HtmlGenericControl("li");
                            control6.InnerHtml = "<a runat='server' href='/Pages/frmReportes.aspx'>Reportes</a>";

                            HtmlGenericControl control7 = new HtmlGenericControl("li");
                            control7.InnerHtml = "<a runat='server' href='/Pages/frmListado.aspx'>Listados</a>";

                            menu.Controls.AddAt(0, control1);
                            menu.Controls.AddAt(1, control2);
                            menu.Controls.AddAt(2, control3);
                            menu.Controls.AddAt(3, control4);
                            menu.Controls.AddAt(4, control5);
                            menu.Controls.AddAt(5, control6);
                            menu.Controls.AddAt(6, control7);
                            break;
                        }
                    case strUsuarioSistema.eTipo.OPERADOR:
                        {
                            HtmlGenericControl control1 = new HtmlGenericControl("li");
                            control1.InnerHtml = "<a runat='server' href='/Default.aspx'>Inicio</a>";

                            HtmlGenericControl control4 = new HtmlGenericControl("li");
                            control4.InnerHtml = "<a runat='server' href='/Pages/frmIngresos.aspx'>Ingresos</a>";

                            HtmlGenericControl control5 = new HtmlGenericControl("li");
                            control5.InnerHtml = "<a runat='server' href='/Pages/frmEgresos.aspx'>Egresos</a>";

                            HtmlGenericControl control7 = new HtmlGenericControl("li");
                            control7.InnerHtml = "<a runat='server' href='/Pages/frmReportes.aspx'>Reportes</a>";

                            HtmlGenericControl control8 = new HtmlGenericControl("li");
                            control8.InnerHtml = "<a runat='server' href='/Pages/frmListado.aspx'>Listados</a>";

                            menu.Controls.AddAt(0, control1);
                            menu.Controls.AddAt(1, control4);
                            menu.Controls.AddAt(2, control5);
                            menu.Controls.AddAt(3, control7);
                            menu.Controls.AddAt(4, control8);
                            break;
                        }
                    case strUsuarioSistema.eTipo.AUDITOR:
                        {
                            HtmlGenericControl control1 = new HtmlGenericControl("li");
                            control1.InnerHtml = "<a runat='server' href='/Default.aspx'>Inicio</a>";

                            HtmlGenericControl control6 = new HtmlGenericControl("li");
                            control6.InnerHtml = "<a runat='server' href='/Pages/frmReportes.aspx'>Reportes</a>";

                            HtmlGenericControl control7 = new HtmlGenericControl("li");
                            control7.InnerHtml = "<a runat='server' href='/Pages/frmListado.aspx'>Listados</a>";

                            menu.Controls.AddAt(0, control1);
                            menu.Controls.AddAt(1, control6);
                            menu.Controls.AddAt(2, control7);
                            break;
                        }
                }
            }
        }

        protected void linkSalir_Click(object sender, EventArgs e)
        {
            this.CleanSessionVariable();
            this.Page.Response.Redirect("/Inicio.aspx");
        }

        protected void linkCambiarContrasena_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("/Pages/frmCambiarContrasena.aspx");
        }
    }
}