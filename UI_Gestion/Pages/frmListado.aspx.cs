using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Data;
using UI_Gestion.Code;
using PCL_Gestion.util;

namespace UI_Gestion.Pages
{
    public partial class frmListado : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && String.IsNullOrEmpty(this.GetStringConnection) == false &&
                String.IsNullOrEmpty(this.GetUserName) == false)
            {
                CargaCombo();
            }
        }

        private void CargaCombo()
        {
            List<ElementoComboBox> elementos = new List<ElementoComboBox>();
            elementos.Clear();
            elementos.Add(new ElementoComboBox() { value = 0, text = "Bancos" });
            elementos.Add(new ElementoComboBox() { value = 1, text = "Conceptos" });
            elementos.Add(new ElementoComboBox() { value = 2, text = "Impuestos" });
            elementos.Add(new ElementoComboBox() { value = 3, text = "Recibos" });
            elementos.Add(new ElementoComboBox() { value = 4, text = "Referencias" });
            elementos.Add(new ElementoComboBox() { value = 5, text = "Tipos de Movimientos" });
            elementos.Add(new ElementoComboBox() { value = 6, text = "Subtipos de Movimientos" });
            elementos.Add(new ElementoComboBox() { value = 7, text = "Clientes" });
            elementos.Add(new ElementoComboBox() { value = 8, text = "Proveedores" });
            ddlListados.DataSource = elementos;
            ddlListados.DataBind();
        }

        protected void btnPreliminar_Click(object sender, EventArgs e)
        {
            CreaXML creaXML = new CreaXML(this.GetStringConnection);
            DataSet ds = null;
            string fileName = string.Empty;
            switch (ddlListados.SelectedValue)
            {
                case "0":
                    {
                        fileName = "banco";
                        ds = creaXML.GeneraDataSet("Select * from banco", fileName, Server.MapPath("/App_Data/"));
                        break;
                    }
                case "1":
                    {
                        fileName = "concepto";
                        ds = creaXML.GeneraDataSet("Select * from concepto", fileName, Server.MapPath("/App_Data/"));
                        break;
                    }
                case "2":
                    {
                        fileName = "impuesto";
                        ds = creaXML.GeneraDataSet("Select * from impuesto", fileName, Server.MapPath("/App_Data/"));
                        break;
                    }
                case "3":
                    {
                        fileName = "recibo";
                        ds = creaXML.GeneraDataSet("Select * from recibo", fileName, Server.MapPath("/App_Data/"));
                        break;
                    }
                case "4":
                    {
                        fileName = "referencia";
                        ds = creaXML.GeneraDataSet("Select r.Clave, r.Nombre as Referencia, " +
                            "(CASE p.Tipo WHEN 0 THEN P.ApellidoPaterno + ' ' + P.ApellidoMaterno + ' ' + P.Nombre WHEN 1 THEN p.NombreComercial END), " +
                            "tRef.Nombre as TipoDeReferencia " +
                            "from referencia r " +
                            "inner join tipo_referencia tRef on tRef.Id = r.Tipo " +
                            "inner join persona p on p.Id = r.Persona " +
                            "order by Referencia asc ",
                            fileName, Server.MapPath("/App_Data/"));
                        break;
                    }
                case "5":
                    {
                        fileName = "tipo_egreso_ingreso";
                        ds = creaXML.GeneraDataSet("Select t.Clave, t.Nombre, " +
                            "(CASE t.Tipo WHEN 0 THEN 'INGRESO' WHEN 1 THEN 'EGRESO' END) as TipoDes " +
                            "from tipo_egreso_ingreso as t order by Clave,Nombre,TipoDes asc", 
                            fileName, Server.MapPath("/App_Data/"));
                        break;
                    }
                case "6":
                    {
                        fileName = "subtipo_egreso_ingreso";
                        ds = creaXML.GeneraDataSet("Select s.Clave, s.Nombre, t.Nombre as Tipo " +
                            "from subtipo_egreso_ingreso s " +
                            "inner join tipo_egreso_ingreso t on t.Clave = s.Clave_Tipo ",
                            fileName, Server.MapPath("/App_Data/"));
                        break;
                    }
                case "7":
                    {
                        fileName = "cliente";
                        ds = creaXML.GeneraDataSet("Select p.Id,p.ApellidoPaterno,p.ApellidoMaterno,p.Nombre,p.FechaNacimiento,p.Sexo,p.FechaRegistro,p.Curp,p.Rfc, (CASE p.Estatus WHEN 1 THEN 'ACTIVO' WHEN 2 THEN 'INACTIVO' WHEN 3 THEN 'BAJA' END) as Status from persona p Where p.Tipo = 0 ", fileName, Server.MapPath("/App_Data/"));
                        break;
                    }
                case "8":
                    {
                        fileName = "proveedor";
                        ds = creaXML.GeneraDataSet("Select p.Id,p.FechaRegistro,p.Rfc,p.RazonSocial,p.NombreComercial, (CASE p.Estatus WHEN 1 THEN 'ACTIVO' WHEN 2 THEN 'INACTIVO' WHEN 3 THEN 'BAJA' END) as Status from persona p Where p.Tipo = 1", fileName, Server.MapPath("/App_Data/"));
                        break;
                    }
            }

            if (ds == null) return;
            Session.Remove("frmGenReporte");
            Dictionary<string, object> keys = new Dictionary<string, object>();
            keys.Add("Nombre", fileName);
            keys.Add("DataSet", ds);
            Session["frmGenReporte"] = keys;

            ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(),
                "window.open('/Pages/frmGenReporte.aspx');", true);
        }
    }
}