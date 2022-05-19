using System;
using UI_Gestion.Code;
using PCL_Gestion.str;
using PCL_Gestion.dao;
using System.Web.UI;

namespace UI_Gestion.Pages
{
    public partial class frmPresupuesto : BasePage
    {
        static string PClave = "PClave";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Session.Remove(PClave);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool bGuardo = false;
            strPresupuesto str = new strPresupuesto();
            str = CargaObjeto(str);
            daoPresupuestos dao = new daoPresupuestos(this.GetStringConnection);

            switch (Session[PClave])
            {
                case null://Insert
                    {
                        if (String.IsNullOrEmpty(str.Clave) == false)
                        {
                            int save = dao.Insert(str);
                            if (save > 0)
                                bGuardo = true;
                        }
                        break;
                    }
                default://Update
                    {
                        int save = dao.Update(str);
                        if (save > 0)
                            bGuardo = true;
                        break;
                    }
            }

            if (bGuardo)
            {
                CargarGrid(ddlTipo.SelectedValue, ddlSubTipo.SelectedValue);
                LimpiarTemplate();
                rbIngreso.Checked = false;
                rbEgreso.Checked = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(),
                    "alertify.alert('¡Operación fallida!', " +
                    "function(){ alertify.error('Faltan datos por llenar'); }); ", true);
            }
        }

        private strPresupuesto CargaObjeto(strPresupuesto str)
        {
            if (Session[PClave] != null)
                str.Clave = Session[PClave].ToString();
            else
                str.Clave = txtClave.Text;
            str.Tipo = ddlTipo.SelectedValue;
            str.SubTipo = ddlSubTipo.SelectedValue;
            if (txtAnio.Text != "")
                str.Anio = int.Parse(txtAnio.Text);
            else
                str.Anio = int.Parse(DateTime.Now.AddYears(1).Year.ToString());
            str.Meses = txt01.Text + "," + txt02.Text + "," + txt03.Text + "," + txt04.Text + "," +
                txt05.Text + "," + txt06.Text + "," + txt07.Text + "," + txt08.Text + "," +
                txt09.Text + "," + txt10.Text + "," + txt11.Text + "," + txt12.Text;
            return str;
        }

        protected void rbIngreso_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarTemplate();
            CargarCombos(strTipoEgresoIngreso.eTipo.Ingreso);
        }

        protected void rbEgreso_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarTemplate();
            CargarCombos(strTipoEgresoIngreso.eTipo.Egreso);
        }

        private void CargarCombos(strTipoEgresoIngreso.eTipo? tipo)
        {
            if (tipo != null)
            {
                daoTipoEgresosIngresos dao = new daoTipoEgresosIngresos(this.GetStringConnection);
                ddlTipo.DataSource = dao.GetAll((strTipoEgresoIngreso.eTipo)tipo);
                ddlTipo.DataBind();
                ddlTipo_SelectedIndexChanged(null, null);
            }
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipo.SelectedValue != null)
            {
                daoSubTipoEgresosIngresos dao = new daoSubTipoEgresosIngresos(this.GetStringConnection);
                ddlSubTipo.DataSource = dao.GetAll(ddlTipo.SelectedValue);
                ddlSubTipo.DataBind();
                ddlSubTipo_SelectedIndexChanged(null, null);
            }
        }

        protected void ddlSubTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSubTipo.SelectedValue != null)
            {
                CargarGrid(ddlTipo.SelectedValue, ddlSubTipo.SelectedValue);
            }
        }

        private void CargarGrid(string tipo, string subTipo)
        {
            daoPresupuestos dao = new daoPresupuestos(this.GetStringConnection);
            gvPresupuesto.DataSource = dao.GetAll(tipo, subTipo);
            gvPresupuesto.DataBind();
        }

        private void LimpiarTemplate()
        {
            Session.Remove(PClave);
            txtClave.Text = "";
            ddlTipo.Items.Clear();
            ddlSubTipo.Items.Clear();
            txtAnio.Text = "";
            txt01.Text = "";
            txt02.Text = "";
            txt03.Text = "";
            txt04.Text = "";
            txt05.Text = "";
            txt06.Text = "";
            txt07.Text = "";
            txt08.Text = "";
            txt09.Text = "";
            txt10.Text = "";
            txt11.Text = "";
            txt12.Text = "";
            gvPresupuesto.DataSource = null;
            gvPresupuesto.DataBind();
        }

        protected void gvPresupuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int RowIndex = gvPresupuesto.SelectedRow.RowIndex;

            var Clave = gvPresupuesto.Rows[RowIndex].Cells[1].Text;

            var Tipo = gvPresupuesto.Rows[RowIndex].Cells[2].Text;

            var SubTipo = gvPresupuesto.Rows[RowIndex].Cells[3].Text;

            var Anio = gvPresupuesto.Rows[RowIndex].Cells[4].Text;

            var Meses = gvPresupuesto.Rows[RowIndex].Cells[5].Text;

            string[] sMeses = Meses.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            Session[PClave] = Clave;

            txtClave.Text = Clave;

            ddlTipo.SelectedValue = Tipo;

            ddlSubTipo.SelectedValue = SubTipo;

            txtAnio.Text = Anio;

            if (sMeses.Length > 0)
            {
                txt01.Text = sMeses[0];
                txt02.Text = sMeses[1];
                txt03.Text = sMeses[2];
                txt04.Text = sMeses[3];
                txt05.Text = sMeses[4];
                txt06.Text = sMeses[5];
                txt07.Text = sMeses[6];
                txt08.Text = sMeses[7];
                txt09.Text = sMeses[8];
                txt10.Text = sMeses[9];
                txt11.Text = sMeses[10];
                txt12.Text = sMeses[11];
            }
        }
    }
}