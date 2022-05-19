using System;
using System.Collections.Generic;
using System.Data;
using PCL_Gestion.str;
using PCL_Gestion.dao;
using PCL_Gestion.util;
using UI_Gestion.Code;
using PCL_Gestion.BusinessRules;
using System.Web.UI;

namespace UI_Gestion.Pages
{
    public partial class frmIngresos : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && String.IsNullOrEmpty(this.GetStringConnection) == false && 
                String.IsNullOrEmpty(this.GetUserName) == false)
            {
                pnlEmision.Visible = true;
                CargarCombos();
            }
        }

        private void CargarCombos()
        {
            ddlTipo.Items.Clear();
            daoTipoEgresosIngresos dao1 = new daoTipoEgresosIngresos(this.GetStringConnection);
            ddlTipo.DataSource = dao1.GetAll(strTipoEgresoIngreso.eTipo.Ingreso);
            ddlTipo.DataBind();
            ddlTipo.Items.Insert(0, "==Seleccionar Tipo de Ingreso==");

            ddlConcepto.Items.Clear();
            daoConceptos dao2 = new daoConceptos(this.GetStringConnection);
            ddlConcepto.DataSource = dao2.GetAll();
            ddlConcepto.DataBind();
            ddlConcepto.Items.Insert(0, "==Seleccionar Concepto==");

            List<ElementoComboBox> elementos = new List<ElementoComboBox>();
            daoPersonas dao3 = new daoPersonas(this.GetStringConnection);
            List<strPersona> lista = dao3.GetAll(strPersona.eTipo.Cliente);
            if (lista != null)
                foreach (var item in lista)
                    elementos.Add(new ElementoComboBox() { value = item.Id, text = item.ToString() });
            ddlCliente.DataSource = elementos;
            ddlCliente.DataBind();
            ddlCliente.Items.Insert(0, "==Seleccionar Cliente==");

            ddlImpuesto.Items.Clear();
            daoImpuestos dao4 = new daoImpuestos(this.GetStringConnection);
            ddlImpuesto.DataSource = dao4.GetAll();
            ddlImpuesto.DataBind();
            ddlImpuesto.Items.Insert(0, "==Seleccionar Impuesto==");

            ddlSerie.Items.Clear();
            daoRecibos dao = new daoRecibos(this.GetStringConnection);
            ddlSerie.DataSource = dao.GetAll();
            ddlSerie.DataBind();
            ddlSerie.Items.Insert(0, "==Seleccionar Serie==");
        }

        protected void rbEmitido_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEmitido.Checked)
            {
                pnlPagado.Visible = false;
                pnlEmision.Visible = true;
                CargarCombos();
            }
        }

        protected void rbPagado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPagado.Checked)
            {
                btnPagar.Text = "Pagar";
                txtFechaPago.Visible = true;
                pnlEmision.Visible = false;
                pnlPagado.Visible = true;
                CargarIngresos();
            }
        }

        private void CargarIngresos()
        {
            ddlIngresos.Items.Clear();
            daoIngresos dao = new daoIngresos(this.GetStringConnection);
            ddlIngresos.DataSource = dao.GetAll(strIngreso.eEstatus.Emitido);
            ddlIngresos.DataBind();
            ddlIngresos.Items.Insert(0, "==Seleccionar Ingreso==");
        }

        protected void rbCancelado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCancelado.Checked)
            {
                btnPagar.Text = "Cancelar";
                txtFechaPago.Visible = false;
                pnlEmision.Visible = false;
                pnlPagado.Visible = true;
                CargarIngresos();
            }
        }

        protected void ddlSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSerie.SelectedValue != null)
            {
                daoIngresos dao = new daoIngresos(this.GetStringConnection);
                string sFol = dao.GetNextFolio(ddlSerie.SelectedValue);
                ddlFolio.Items.Clear();
                ddlFolio.Items.Insert(0, sFol);
            }
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipo.SelectedValue != null)
            {
                daoSubTipoEgresosIngresos dao = new daoSubTipoEgresosIngresos(this.GetStringConnection);
                ddlSubTipo.DataSource = dao.GetAll(ddlTipo.SelectedValue);
                ddlSubTipo.DataBind();
                ddlSubTipo.Items.Insert(0, "==Seleccionar Sub Tipo==");
            }
        }

        protected void txtSubtotal_TextChanged(object sender, EventArgs e)
        {
            BRCalcularTotal calcularTotal = new BRCalcularTotal(this.GetStringConnection);
            if (ddlImpuesto.SelectedIndex > 0)
                txtTotal.Text = calcularTotal.GenerarCalculo(ddlImpuesto.SelectedValue, txtSubtotal.Text).ToString();
        }

        protected void ddlImpuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            BRCalcularTotal calcularTotal = new BRCalcularTotal(this.GetStringConnection);
            if (ddlImpuesto.SelectedIndex > 0)
                txtTotal.Text = calcularTotal.GenerarCalculo(ddlImpuesto.SelectedValue, txtSubtotal.Text).ToString();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarIngreso())
            {
                daoIngresos dao = new daoIngresos(this.GetStringConnection);
                strIngreso str = CargarDatos(dao);
                int save = dao.Insert(str);
                if (save > 0)
                {
                    BRListado listado = new BRListado(this.GetStringConnection);
                    string nombre = "listadoIngresos";
                    DataSet ds = new DataSet(nombre);
                    ds = listado.ObtenerReciboEmitido(str.Id, ddlTipo.SelectedValue,
                        ddlSubTipo.SelectedValue, (ddlImpuesto.SelectedIndex > 0) ? true : false);

                    if (ds == null) return;
                    Session.Remove("frmGenReporte");
                    Dictionary<string, object> keys = new Dictionary<string, object>();
                    keys.Add("Nombre", nombre);
                    keys.Add("DataSet", ds);
                    Session["frmGenReporte"] = keys;

                    limpiarDatos();
                    rbEmitido.Checked = false;

                    ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(),
                        "window.open('/Pages/frmGenReporte.aspx');", true);
                }
            }
        }

        private bool ValidarIngreso()
        {
            if (ddlFolio.Text != "Sin folio" && ddlFolio.Text != "" && ddlSerie.SelectedIndex > 0)
                return true;
            else
                return false;
        }

        private void limpiarDatos()
        {
            ddlCliente.Items.Clear();
            ddlConcepto.Items.Clear();
            ddlFolio.Items.Clear();
            ddlImpuesto.Items.Clear();
            ddlSerie.Items.Clear();
            ddlSubTipo.Items.Clear();
            txtSubtotal.Text = "";
            ddlTipo.Items.Clear();
            txtTotal.Text = "";
        }

        private strIngreso CargarDatos(daoIngresos dao)
        {
            strIngreso str = new strIngreso();
            str.Cliente = long.Parse(ddlCliente.SelectedValue);
            str.Concepto = ddlConcepto.SelectedValue;
            str.Emision = DateTime.Now;
            str.Estatus = strIngreso.eEstatus.Emitido;
            str.Folio = ddlFolio.Text;
            str.Id = dao.CreateId();
            if (ddlImpuesto.SelectedIndex > 0)
                str.Impuesto = ddlImpuesto.SelectedValue;
            str.Serie = ddlSerie.SelectedValue;
            str.SubTipoIngreso = ddlSubTipo.SelectedValue;
            str.Subtotal = decimal.Parse(txtSubtotal.Text);
            str.TipoIngreso = ddlTipo.SelectedValue;
            str.Total = decimal.Parse(txtTotal.Text);
            return str;
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            if (ddlIngresos.SelectedValue == null) return;
            if (rbCancelado.Checked)
            {
                daoIngresos dao = new daoIngresos(this.GetStringConnection);
                strIngreso str = dao.GetObject(long.Parse(ddlIngresos.SelectedValue));
                str.Estatus = strIngreso.eEstatus.Cancelado;
                int save = dao.Update(str);
                if (save > 0)
                {
                    lbConceptoDesc.Text = "";
                    CargarIngresos();
                }
                return;
            }
            if (txtFechaPago.Text != "")
            {
                daoIngresos dao = new daoIngresos(this.GetStringConnection);
                strIngreso str = dao.GetObject(long.Parse(ddlIngresos.SelectedValue));
                str.Pago = DateTime.Parse(txtFechaPago.Text);
                str.Estatus = strIngreso.eEstatus.Pagado;
                int save = dao.Update(str);
                if (save > 0)
                {
                    lbConceptoDesc.Text = "";
                    txtFechaPago.Text = "";
                    CargarIngresos();
                }
            }
        }

        protected void ddlIngresos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ddlIngresos.SelectedValue) == false && ddlIngresos.SelectedIndex > 0)
            {
                daoConceptos dao = new daoConceptos(this.GetStringConnection);
                daoIngresos dao1 = new daoIngresos(this.GetStringConnection);
                strIngreso str1 = dao1.GetObject(long.Parse(ddlIngresos.SelectedValue));
                if (String.IsNullOrEmpty(str1.Concepto) == false)
                    lbConceptoDesc.Text = dao.GetObject(str1.Concepto).Descripcion;
                else
                    lbConceptoDesc.Text = "Sin Concepto";
            }
        }
    }
}