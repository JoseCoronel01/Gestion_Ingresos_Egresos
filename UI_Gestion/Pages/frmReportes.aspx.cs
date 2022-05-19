using System;
using System.Data;
using PCL_Gestion.BusinessRules;
using PCL_Gestion.dao;
using PCL_Gestion.str;
using UI_Gestion.Code;
using PCL_Gestion.util;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace UI_Gestion.Pages
{
    public partial class frmReportes : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && String.IsNullOrEmpty(this.GetStringConnection) == false && 
                String.IsNullOrEmpty(this.GetUserName) == false)
            {
                List<ElementoComboBox> elementos = new List<ElementoComboBox>();
                elementos.Add(new ElementoComboBox() { value = strTipoEgresoIngreso.eTipo.Ingreso, 
                    text = strTipoEgresoIngreso.eTipo.Ingreso.ToString() });
                elementos.Add(new ElementoComboBox() { value = strTipoEgresoIngreso.eTipo.Egreso, 
                    text = strTipoEgresoIngreso.eTipo.Egreso.ToString() });
                ddlTipoReporte.DataSource = elementos;
                ddlTipoReporte.DataBind();
                ddlTipoReporte_SelectedIndexChanged(null, null);
            }
        }

        protected void ddlTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlTipoReporte.SelectedValue)
            {
                case "Ingreso":
                    {
                        List<ElementoComboBox> elementos = new List<ElementoComboBox>();
                        elementos.Add(new ElementoComboBox() { value = "1", text = strIngreso.eEstatus.Emitido.ToString() });
                        elementos.Add(new ElementoComboBox() { value = "2", text = strIngreso.eEstatus.Pagado.ToString() });
                        elementos.Add(new ElementoComboBox() { value = "3", text = strIngreso.eEstatus.Cancelado.ToString() });
                        ddlEstatus.DataSource = elementos;
                        ddlEstatus.DataBind();

                        daoTipoEgresosIngresos dao = new daoTipoEgresosIngresos(this.GetStringConnection);
                        ddlTipo.DataSource = dao.GetAll(strTipoEgresoIngreso.eTipo.Ingreso);
                        ddlTipo.DataBind();
                        ddlTipo_SelectedIndexChanged(null, null);

                        ddlListado.Items.Clear();
                        List<ElementoComboBox> elementos1 = new List<ElementoComboBox>();
                        elementos1.Add(new ElementoComboBox() { value = 0, text = "Recibos" });
                        ddlListado.DataSource = elementos1;
                        ddlListado.DataBind();
                        break;
                    }
                case "Egreso":
                    {
                        List<ElementoComboBox> elementos = new List<ElementoComboBox>();
                        elementos.Add(new ElementoComboBox() { value = "1", text = strEgreso.eEstatus.Activo.ToString() });
                        elementos.Add(new ElementoComboBox() { value = "2", text = strEgreso.eEstatus.Cancelado.ToString() });
                        ddlEstatus.DataSource = elementos;
                        ddlEstatus.DataBind();

                        daoTipoEgresosIngresos dao = new daoTipoEgresosIngresos(this.GetStringConnection);
                        ddlTipo.DataSource = dao.GetAll(strTipoEgresoIngreso.eTipo.Egreso);
                        ddlTipo.DataBind();
                        ddlTipo_SelectedIndexChanged(null, null);

                        ddlListado.Items.Clear();
                        List<ElementoComboBox> elementos1 = new List<ElementoComboBox>();
                        daoBancos dao1 = new daoBancos(this.GetStringConnection);
                        List<strBanco> bancos = dao1.GetAll();
                        if (bancos != null)
                        {
                            foreach (var item in bancos)
                                elementos1.Add(new ElementoComboBox() { value = item.Clave, text = item.ToString() });
                            ddlListado.DataSource = elementos1;
                            ddlListado.DataBind();
                            ddlListado.Items.Insert(0, new ListItem() { Value = Guid.NewGuid().ToString(), Text = "Cheques" });
                        }
                        break;
                    }
            }
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            daoSubTipoEgresosIngresos dao1 = new daoSubTipoEgresosIngresos(this.GetStringConnection);
            ddlSubTipo.DataSource = dao1.GetAll(ddlTipo.SelectedValue);
            ddlSubTipo.DataBind();
        }

        protected void btnPreliminar_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            string nombre = string.Empty;
            if (chBoxTipoReporte.Checked == false)
            {
                BRComparativo comparativo = new BRComparativo(this.GetStringConnection);
                nombre = "comparativo";
                ds = new DataSet(nombre);
                switch (ddlTipoReporte.SelectedValue)
                {
                    case "Ingreso":
                        {
                            ds = comparativo.ObtenerTotalPorMes(ddlTipo.SelectedValue,
                                ddlSubTipo.SelectedValue, daoIngresos.ConvertToStr(ddlEstatus.SelectedValue),
                                chBoxImpuesto.Checked);
                            break;
                        }
                    case "Egreso":
                        {
                            ds = comparativo.ObtenerTotalPorMes(ddlTipo.SelectedValue,
                                ddlSubTipo.SelectedValue, daoEgresos.ConvertToStr(ddlEstatus.SelectedValue),
                                chBoxImpuesto.Checked);
                            break;
                        }
                }
            }
            else
            {
                BRListado listado = new BRListado(this.GetStringConnection);
                switch (ddlTipoReporte.SelectedValue)
                {
                    case "Ingreso":
                        {
                            nombre = "listadoIngresos";
                            ds = new DataSet(nombre);
                            ds = listado.ObtenerDeLaFechaAlaFecha(ddlTipo.SelectedValue,
                                ddlSubTipo.SelectedValue, daoIngresos.ConvertToStr(ddlEstatus.SelectedValue),
                                txtDelafecha.Text, 
                                txtAlaFecha.Text, chBoxImpuesto.Checked);
                            break;
                        }
                    case "Egreso":
                        {
                            nombre = "listadoEgresos";
                            ds = new DataSet(nombre);
                            ds = listado.ObtenerDeLaFechaAlaFecha(ddlTipo.SelectedValue,
                                ddlSubTipo.SelectedValue, daoEgresos.ConvertToStr(ddlEstatus.SelectedValue),
                                txtDelafecha.Text, 
                                txtAlaFecha.Text, chBoxImpuesto.Checked, ddlListado.SelectedValue);
                            break;
                        }
                }
            }

            if (ds == null) return;
            Session.Remove("frmGenReporte");
            Dictionary<string, object> keys = new Dictionary<string, object>();
            keys.Add("Nombre", nombre);
            keys.Add("DataSet", ds);
            Session["frmGenReporte"] = keys;

            ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(),
                "window.open('/Pages/frmGenReporte.aspx');", true);
        }
    }
}