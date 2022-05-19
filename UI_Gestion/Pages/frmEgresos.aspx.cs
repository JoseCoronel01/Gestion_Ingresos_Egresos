using System;
using System.Collections.Generic;
using PCL_Gestion.dao;
using PCL_Gestion.str;
using PCL_Gestion.util;
using UI_Gestion.Code;
using PCL_Gestion.BusinessRules;
using System.Web.UI.WebControls;

namespace UI_Gestion.Pages
{
    public partial class frmEgresos : BasePage
    {
        static string IdEgreso = "IdEgreso";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && String.IsNullOrEmpty(this.GetStringConnection) == false &&
                String.IsNullOrEmpty(this.GetUserName) == false)
            {
                Session.Remove(IdEgreso);
                CargarCombos();
                CargarGrid();
            }
        }

        private void CargarGrid()
        {
            daoEgresos dao = new daoEgresos(this.GetStringConnection);
            List<strEgreso> lista = dao.GetAll(strEgreso.eEstatus.Activo);
            gvEgresos.DataSource = lista;
            gvEgresos.DataBind();
        }

        private void CargarCombos()
        {
            daoTipoEgresosIngresos dao1 = new daoTipoEgresosIngresos(this.GetStringConnection);
            ddlTipo.DataSource = dao1.GetAll(strTipoEgresoIngreso.eTipo.Egreso);
            ddlTipo.DataBind();
            ddlTipo_SelectedIndexChanged(null, null);

            daoConceptos dao2 = new daoConceptos(this.GetStringConnection);
            ddlConcepto.DataSource = dao2.GetAll();
            ddlConcepto.DataBind();

            List<ElementoComboBox> elementos = new List<ElementoComboBox>();
            daoPersonas dao3 = new daoPersonas(this.GetStringConnection);
            List<strPersona> lista = dao3.GetAll(strPersona.eTipo.Proveedor);
            if (lista != null)
                foreach (var item in lista)
                    elementos.Add(new ElementoComboBox() { value = item.Id, text = item.ToString() });
            ddlProveedor.DataSource = elementos;
            ddlProveedor.DataBind();

            daoImpuestos dao4 = new daoImpuestos(this.GetStringConnection);
            ddlImpuesto.DataSource = dao4.GetAll();
            ddlImpuesto.DataBind();

            daoBancos dao = new daoBancos(this.GetStringConnection);
            List<ElementoComboBox> elementos1 = new List<ElementoComboBox>();
            List<strBanco> bancos = dao.GetAll();
            elementos1.Add(new ElementoComboBox() { value = "-1", text = "==Seleccionar banco==" });
            if (bancos != null)
                foreach (var item in bancos)
                    elementos1.Add(new ElementoComboBox() { value = item.Clave, text = item.ToString() });
            ddlBanco.DataSource = elementos1;
            ddlBanco.DataBind();
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ddlTipo.SelectedValue) == false)
            {
                daoSubTipoEgresosIngresos dao = new daoSubTipoEgresosIngresos(this.GetStringConnection);
                ddlSubTipo.DataSource = dao.GetAll(ddlTipo.SelectedValue);
                ddlSubTipo.DataBind();
            }
        }

        protected void txtSubtotal_TextChanged(object sender, EventArgs e)
        {
            BRCalcularTotal calcularTotal = new BRCalcularTotal(this.GetStringConnection);
            txtTotal.Text = calcularTotal.GenerarCalculo(ddlImpuesto.SelectedValue, txtSubtotal.Text).ToString();
        }

        protected void ddlImpuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            BRCalcularTotal calcularTotal = new BRCalcularTotal(this.GetStringConnection);
            txtTotal.Text = calcularTotal.GenerarCalculo(ddlImpuesto.SelectedValue, txtSubtotal.Text).ToString();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarDatos();
            CargarCombos();
            gvEgresos.Visible = true;
        }

        private void limpiarDatos()
        {
            Session.Remove(IdEgreso);
            txtNoCheque.Text = "";
            txtSubtotal.Text = "";
            txtTotal.Text = "";
            ddlBanco.Items.Clear();
            ddlConcepto.Items.Clear();
            ddlImpuesto.Items.Clear();
            ddlProveedor.Items.Clear();
            ddlSubTipo.Items.Clear();
            ddlTipo.Items.Clear();
        }

        protected void gvEgresos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var row = gvEgresos.SelectedRow;

            var Id = long.Parse(row.Cells[1].Text);

            daoEgresos dao = new daoEgresos(this.GetStringConnection);
            strEgreso str = dao.GetObject(Id);

            CargarCombos();
            MostrarDatos(str);
            gvEgresos.Visible = false;
        }

        private void MostrarDatos(strEgreso str)
        {
            Session[IdEgreso] = str.Id;
            txtNoCheque.Text = str.NoCheque;
            txtSubtotal.Text = str.Subtotal.ToString();
            txtTotal.Text = str.Total.ToString();
            ListItem item = ddlBanco.Items.FindByValue(str.CtaBanco);
            if (item != null)
                ddlBanco.SelectedValue = item.Value;
            item = ddlConcepto.Items.FindByValue(str.Concepto);
            ddlConcepto.SelectedValue = item.Value;
            item = ddlImpuesto.Items.FindByValue(str.Impuesto);
            ddlImpuesto.SelectedValue = item.Value;
            item = ddlProveedor.Items.FindByValue(str.Proveedor.ToString());
            ddlProveedor.SelectedValue = item.Value;
            item = ddlTipo.Items.FindByValue(str.TipoEgreso);
            ddlTipo.SelectedValue = item.Value;
            item = ddlSubTipo.Items.FindByValue(str.SubTipoEgreso);
            ddlSubTipo.SelectedValue = item.Value;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            daoEgresos dao = new daoEgresos(this.GetStringConnection);

            switch (Session[IdEgreso])
            {
                case null:
                    {
                        if (ValidarEgreso())
                        {
                            strEgreso str = CargaDatos(dao.CreateId());
                            str.Fecha = DateTime.Now;
                            int save = dao.Insert(str);
                            if (save > 0)
                            {
                                limpiarDatos();
                                CargarCombos();
                                CargarGrid();
                            }
                        }
                        break;
                    }
                default:
                    {
                        if (ValidarEgreso())
                        {
                            strEgreso str = CargaDatos(long.Parse(Session[IdEgreso].ToString()));
                            int save = dao.Update(str);
                            if (save > 0)
                            {
                                limpiarDatos();
                                CargarCombos();
                                CargarGrid();
                            }
                        }
                        break;
                    }
            }
        }

        private bool ValidarEgreso()
        {
            if (txtNoCheque.Text != "" && ddlBanco.SelectedValue == "-1")
                return true;
            else if (txtNoCheque.Text == "" && ddlBanco.SelectedValue != "-1")
                return true;
            else
                return false;
        }

        private strEgreso CargaDatos(long Id)
        {
            strEgreso str = new strEgreso();
            str.Id = Id;
            str.NoCheque = txtNoCheque.Text;
            str.Subtotal = decimal.Parse(txtSubtotal.Text);
            str.Total = decimal.Parse(txtTotal.Text);
            str.CtaBanco = ddlBanco.SelectedValue;
            str.Concepto = ddlConcepto.SelectedValue;
            str.Impuesto = ddlImpuesto.SelectedValue;
            str.Proveedor = long.Parse(ddlProveedor.SelectedValue);
            str.TipoEgreso = ddlTipo.SelectedValue;
            str.SubTipoEgreso = ddlSubTipo.SelectedValue;
            str.Estatus = strEgreso.eEstatus.Activo;
            return str;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Session[IdEgreso] != null)
            {
                daoEgresos dao = new daoEgresos(this.GetStringConnection);
                strEgreso str = dao.GetObject(long.Parse(Session[IdEgreso].ToString()));
                str.Estatus = strEgreso.eEstatus.Cancelado;
                int save = dao.Update(str);
                if (save > 0)
                {
                    limpiarDatos();
                    CargarCombos();
                    CargarGrid();
                    gvEgresos.Visible = true;
                }
            }
        }
    }
}