using System;
using UI_Gestion.Code;
using PCL_Gestion.str;
using PCL_Gestion.dao;
using PCL_Gestion.BusinessRules;
using System.Collections.Generic;

namespace UI_Gestion.Pages.WF
{
    public partial class frmListarCreditoDetalle : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack &&
                String.IsNullOrEmpty(this.GetStringConnection) == false && 
                String.IsNullOrEmpty(this.GetUserName) == false && this.Page.Session["CreditoId"] != null)
            {
                long id = long.Parse(this.Page.Session["CreditoId"].ToString());
                this.Page.Session["ListarCreditoDetalle"] = CargaGrid(id);
            }
        }

        private List<strCreditoDetalle> CargaGrid(long id)
        {
            daoCreditos dao = new daoCreditos(this.GetStringConnection);
            strCredito str = dao.GetObject(id);
            BRCreditoDetalle creditoDetalle = new BRCreditoDetalle(this.GetStringConnection);
            List<strCreditoDetalle> lista = creditoDetalle.ListarDetalleDelCredito(str);
            gvCreditoDetalle.DataSource = lista;
            gvCreditoDetalle.DataBind();
            return lista;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            daoCreditosDetalle dao = new daoCreditosDetalle(this.GetStringConnection);
            List<strCreditoDetalle> lista = (List<strCreditoDetalle>)this.Page.Session["ListarCreditoDetalle"];
            string mensaje = string.Empty;
            int contador = 1;
            foreach (var item in lista)
            {
                int save = dao.Insert(item);
                if (save > 0)
                {
                    mensaje = string.Empty;
                    mensaje += string.Format("Se insertarón {0} de {1}", new object[] { contador, lista.Count });
                    contador = contador + 1;
                }
            }
            if (String.IsNullOrEmpty(mensaje) == false)
            {
                this.Page.Session.Remove("CreditoId");
                this.Page.Session.Remove("ListarCreditoDetalle");
                this.Page.Response.Redirect("/Pages/WF/frmMenu.aspx");
            }
        }
    }
}