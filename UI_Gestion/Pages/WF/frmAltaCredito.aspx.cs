using System;
using System.Web.UI;
using UI_Gestion.Code;
using PCL_Gestion.str;
using PCL_Gestion.dao;

namespace UI_Gestion.Pages.WF
{
    public partial class frmAltaCredito : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && String.IsNullOrEmpty(this.GetStringConnection) == false &&
                String.IsNullOrEmpty(this.GetUserName) == false)
            {
                CargaCombo();
            }
            else if (String.IsNullOrEmpty(this.GetStringConnection) == true || 
                String.IsNullOrEmpty(this.GetUserName) == true)
            {
                this.Page.Response.Redirect("/Inicio.aspx");
            }
        }

        private void CargaCombo()
        {
            daoPeriodicidad dao = new daoPeriodicidad(this.GetStringConnection);
            ddlPeriodicidad.DataSource = dao.GetAll();
            ddlPeriodicidad.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarForma())
            {
                daoCreditos dao = new daoCreditos(this.GetStringConnection);
                strCredito str = new strCredito();
                str.Id = dao.CreateId();
                str.Emision = DateTime.Parse(txtEmision.Text);
                str.Vencimiento = DateTime.Parse(txtVencimiento.Text);
                str.Capital = double.Parse(txtCapital.Text);
                str.Interes = double.Parse(txtInteres.Text);
                str.Periodicidad = int.Parse(ddlPeriodicidad.SelectedValue);
                int save = dao.Insert(str);
                if (save > 0)
                {
                    this.Page.Session["CreditoId"] = str.Id;
                    this.Page.Response.Redirect("/Pages/WF/frmListarCreditoDetalle.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Error');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Error.. Hay Campos Vacíos');", true);
            }
        }

        private bool ValidarForma()
        {
            if (txtEmision.Text != "" && txtVencimiento.Text != "" && txtCapital.Text != ""
                && txtInteres.Text != "")
            {
                return true;
            }
            else
                return false;
        }
    }
}