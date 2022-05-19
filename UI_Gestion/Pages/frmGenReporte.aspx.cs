using CrystalDecisions.CrystalReports.Engine;
using PCL_Gestion.util;
using System;
using System.IO;
using UI_Gestion.Code;
using System.Data;
using System.Collections.Generic;

namespace UI_Gestion.Pages
{
    public partial class frmGenReporte : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.Session["frmGenReporte"] != null)
            {
                Dictionary<string, object> keys = (Dictionary<string, object>)this.Page.Session["frmGenReporte"];

                string nombre = keys["Nombre"].ToString();
                DataSet ds = (DataSet)keys["DataSet"];

                CreaXML.GeneraXSD(ds, nombre, Server.MapPath("/App_Data/"));

                ReportDocument doc = new ReportDocument();

                switch (nombre)
                {
                    case "comparativo":
                        {
                            doc.Load(Server.MapPath("/rpt/rptComparativo.rpt"));
                            break;
                        }
                    case "listadoIngresos":
                        {
                            doc.Load(Server.MapPath("/rpt/rptIngresos.rpt"));
                            break;
                        }
                    case "listadoEgresos":
                        {
                            doc.Load(Server.MapPath("/rpt/rptEgresos.rpt"));
                            break;
                        }
                    case "banco":
                        {
                            doc.Load(Server.MapPath("/rpt/rptBanco.rpt"));
                            break;
                        }
                    case "concepto":
                        {
                            doc.Load(Server.MapPath("/rpt/rptConcepto.rpt"));
                            break;
                        }
                    case "impuesto":
                        {
                            doc.Load(Server.MapPath("/rpt/rptImpuesto.rpt"));
                            break;
                        }
                    case "recibo":
                        {
                            doc.Load(Server.MapPath("/rpt/rptRecibos.rpt"));
                            break;
                        }
                    case "referencia":
                        {
                            doc.Load(Server.MapPath("/rpt/rptReferencia.rpt"));
                            break;
                        }
                    case "tipo_egreso_ingreso":
                        {
                            doc.Load(Server.MapPath("/rpt/rptTipo.rpt"));
                            break;
                        }
                    case "subtipo_egreso_ingreso":
                        {
                            doc.Load(Server.MapPath("/rpt/rptSubtipo.rpt"));
                            break;
                        }
                    case "cliente":
                        {
                            doc.Load(Server.MapPath("/rpt/rptCliente.rpt"));
                            break;
                        }
                    case "proveedor":
                        {
                            doc.Load(Server.MapPath("/rpt/rptProveedor.rpt"));
                            break;
                        }
                }

                doc.SetDataSource(ds);

                Stream stream = doc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                var pdfbyteArray = new byte[stream.Length];

                stream.Position = 0;
                stream.Read(pdfbyteArray, 0, Convert.ToInt32(stream.Length));
                Context.Response.ClearContent();
                Context.Response.ClearHeaders();
                Context.Response.AddHeader("content-disposition", "filename=" + nombre + ".pdf");
                Context.Response.ContentType = "application/pdf";
                Context.Response.AddHeader("content-length", pdfbyteArray.Length.ToString());
                Context.Response.BinaryWrite(pdfbyteArray);

                this.Page.Session.Remove("frmGenReporte");
            }
        }
    }
}