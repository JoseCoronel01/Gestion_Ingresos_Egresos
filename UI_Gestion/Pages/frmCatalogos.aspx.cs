using System;

namespace UI_Gestion.Pages
{
    public partial class frmCatalogos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnBanco_Click(object sender, EventArgs e)
        {
            frmLoad.Src = "/strBanco/Index";
        }

        protected void btnConcepto_Click(object sender, EventArgs e)
        {
            frmLoad.Src = "/strConcepto/Index";
        }

        protected void btnImpuesto_Click(object sender, EventArgs e)
        {
            frmLoad.Src = "/strImpuesto/Index";
        }

        protected void btnRecibo_Click(object sender, EventArgs e)
        {
            frmLoad.Src = "/strRecibo/Index";
        }

        protected void btnTipo_Click(object sender, EventArgs e)
        {
            frmLoad.Src = "/strTipoEgresoIngreso/Index/";
        }

        protected void btnSubtipo_Click(object sender, EventArgs e)
        {
            frmLoad.Src = "/strSubTipoEgresoIngreso/Index/";
        }

        protected void btnContacto_Click(object sender, EventArgs e)
        {
            frmLoad.Src = "/strContacto/Index";
        }

        protected void btnTipoRef_Click(object sender, EventArgs e)
        {
            frmLoad.Src = "/strTipoReferencia/Index";
        }

        protected void btnRef_Click(object sender, EventArgs e)
        {
            frmLoad.Src = "/strReferencia/Index";
        }

        protected void btnCliente_Click(object sender, EventArgs e)
        {
            frmLoad.Src = "/strPCliente/Index";
        }

        protected void btnProveedor_Click(object sender, EventArgs e)
        {
            frmLoad.Src = "/strPProveedor/Index";
        }

        protected void btnUsuarioSis_Click(object sender, EventArgs e)
        {
            frmLoad.Src = "/strUsuarioSistema/Index";
        }
    }
}