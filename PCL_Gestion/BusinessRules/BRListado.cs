using PCL_Gestion.str;
using PCL_Gestion.dao;
using System.Text;
using System.Data;
using System;

namespace PCL_Gestion.BusinessRules
{
    public class BRListado
    {
        private string GetStringConnection;

        public BRListado(string getStringConnection)
        {
            this.GetStringConnection = getStringConnection;
        }

        public DataSet ObtenerReciboEmitido(long id, string tipo, string subTipo, bool impuesto)
        {
            DataSet ds = new DataSet("reciboEmitido");
            string est = string.Empty;
            est = "i.Id =  " + id;
            StringBuilder sbSelect = new StringBuilder();
            if (impuesto)
            {
                sbSelect.Append("Select tei.Nombre as Tipo, stei.Nombre as Subtipo, " +
                    "i.Serie, i.Folio, i.Emision, i.Pago, " +
                    "c.Descripcion as DesConcepto, p.ApellidoPaterno + ' ' + p.ApellidoMaterno + ' ' + p.Nombre " +
                    "as NombreCompleto, " +
                    "i.Subtotal, imp.Tasa as Tasa, i.Total, " +
                    "(CASE i.Estatus WHEN 1 THEN 'Emitido' " +
                    "WHEN 2 THEN 'Pagado' WHEN 3 THEN 'Cancelado' END) as DesEstatus ");
            }
            else
            {
                sbSelect.Append("Select tei.Nombre as Tipo, stei.Nombre as Subtipo, " +
                    "i.Serie, i.Folio, i.Emision, i.Pago, " +
                    "c.Descripcion as DesConcepto, p.ApellidoPaterno + ' ' + p.ApellidoMaterno + ' ' + p.Nombre " +
                    "as NombreCompleto, " +
                    "i.Subtotal, (CASE i.Estatus WHEN 1 THEN 'Emitido' " +
                    "WHEN 2 THEN 'Pagado' WHEN 3 THEN 'Cancelado' END) as DesEstatus ");
            }
            sbSelect.Append("from ingresos i ");
            sbSelect.Append("Left join Tipo_Egreso_Ingreso tei on tei.Clave = i.TipoIngreso ");
            sbSelect.Append("Left join SubTipo_Egreso_Ingreso stei on stei.Clave = i.SubTipoIngreso ");
            sbSelect.Append("Left join Concepto c on c.Clave = i.Concepto ");
            sbSelect.Append("Left join Persona p on p.Id = i.Cliente ");
            if (impuesto)
                sbSelect.Append("Left join Impuesto imp on imp.Clave = i.Impuesto ");
            sbSelect.Append("where " + est);
            sbSelect.Append(" order by i.Folio asc");

            daoGenerico dao = new daoGenerico();

            ds = dao.EjecutarConsulta(sbSelect.ToString(), this.GetStringConnection);

            return ds;
        }

        public DataSet ObtenerDeLaFechaAlaFecha(string tipo, string subTipo,
            strIngreso.eEstatus estatus, 
            string delaFecha, string alaFecha, bool impuesto, string tipoReporte = null)
        {
            DataSet ds = new DataSet("listado");
            string est = string.Empty;
            DateTime dFecha = DateTime.Parse(delaFecha);
            DateTime aFecha = DateTime.Parse(alaFecha);
            switch (estatus)
            {
                case strIngreso.eEstatus.Emitido:
                    {
                        est = "i.Emision >= CONVERT(date, '" + dFecha.ToString("yyyy-MM-dd") + "') " +
                            "and i.Emision <= CONVERT(date, '" + aFecha.ToString("yyyy-MM-dd") + "') " +
                            "and i.Estatus = 1";
                        break;
                    }
                case strIngreso.eEstatus.Pagado:
                    {
                        est = "i.Pago >= CONVERT(date, '" + dFecha.ToString("yyyy-MM-dd") + "') " +
                            "and i.Pago <= CONVERT(date, '" + aFecha.ToString("yyyy-MM-dd") + "') " +
                            "and i.Estatus = 2";
                        break;
                    }
                case strIngreso.eEstatus.Cancelado:
                    {
                        est = "i.Emision >= CONVERT(date, '" + dFecha.ToString("yyyy-MM-dd") + "') " +
                            "and i.Emision <= CONVERT(date, '" + aFecha.ToString("yyyy-MM-dd") + "') " +
                            "and i.Estatus = 3";
                        break;
                    }
            }

            StringBuilder sbSelect = new StringBuilder();
            if (impuesto)
            {
                sbSelect.Append("Select tei.Nombre as Tipo, stei.Nombre as Subtipo, " +
                    "i.Serie, i.Folio, i.Emision, i.Pago, " +
                    "c.Descripcion as DesConcepto, p.ApellidoPaterno + ' ' + p.ApellidoMaterno + ' ' + p.Nombre " +
                    "as NombreCompleto, " +
                    "i.Subtotal,imp.Tasa,i.Total, (CASE i.Estatus WHEN 1 THEN 'Emitido' " +
                    "WHEN 2 THEN 'Pagado' WHEN 3 THEN 'Cancelado' END) as DesEstatus ");
            }
            else
            {
                sbSelect.Append("Select tei.Nombre as Tipo, stei.Nombre as Subtipo, " +
                    "i.Serie, i.Folio, i.Emision, i.Pago, " +
                    "c.Descripcion as DesConcepto, p.ApellidoPaterno + ' ' + p.ApellidoMaterno + ' ' + p.Nombre " +
                    "as NombreCompleto, " +
                    "i.Subtotal, (CASE i.Estatus WHEN 1 THEN 'Emitido' " +
                    "WHEN 2 THEN 'Pagado' WHEN 3 THEN 'Cancelado' END) as DesEstatus ");
            }
            sbSelect.Append("from ingresos i ");
            sbSelect.Append("Left join Tipo_Egreso_Ingreso tei on tei.Clave = i.TipoIngreso ");
            sbSelect.Append("Left join SubTipo_Egreso_Ingreso stei on stei.Clave = i.SubTipoIngreso ");
            sbSelect.Append("Left join Concepto c on c.Clave = i.Concepto ");
            sbSelect.Append("Left join Persona p on p.Id = i.Cliente ");
            if (impuesto)
                sbSelect.Append("Left join impuesto imp on imp.Clave = i.Impuesto ");
            sbSelect.Append("where i.TipoIngreso='" + tipo + "' and i.SubtipoIngreso='" + subTipo + "' and " + est);
            sbSelect.Append(" order by i.Folio asc");

            daoGenerico dao = new daoGenerico();

            ds = dao.EjecutarConsulta(sbSelect.ToString(), this.GetStringConnection);

            return ds;
        }

        public DataSet ObtenerDeLaFechaAlaFecha(string tipo, string subTipo,
            strEgreso.eEstatus estatus,
            string delaFecha, string alaFecha, bool impuesto, string tipoReporte = null)
        {
            DataSet ds = new DataSet("listado");
            string est = string.Empty;
            DateTime dFecha = DateTime.Parse(delaFecha);
            DateTime aFecha = DateTime.Parse(alaFecha);
            switch (estatus)
            {
                case strEgreso.eEstatus.Activo:
                    {
                        est = "e.Fecha >= CONVERT(date, '" + dFecha.ToString("yyyy-MM-dd") + "') " +
                            "and e.Fecha <= CONVERT(date, '" + aFecha.ToString("yyyy-MM-dd") + "') " +
                            "and e.Estatus = 1";
                        break;
                    }
                case strEgreso.eEstatus.Cancelado:
                    {
                        est = "e.Fecha >= CONVERT(date, '" + dFecha.ToString("yyyy-MM-dd") + "') " +
                            "and e.Fecha <= CONVERT(date, '" + aFecha.ToString("yyyy-MM-dd") + "') " +
                            "and e.Estatus = 2";
                        break;
                    }
            }

            daoBancos dao = new daoBancos(this.GetStringConnection);
            strBanco str = dao.GetObject(tipoReporte);

            StringBuilder sbSelect = new StringBuilder();
            if (impuesto)
            {
                sbSelect.Append("Select tei.Nombre as Tipo, stei.Nombre as Subtipo, " +
                    " " + ((str == null) ? "e.NoCheque as Banco, " : " ban.Nombre + ' ' + ban.CtaBanco as Banco, ") +
                    "e.Fecha, " +
                    "c.Descripcion as DesConcepto, p.NombreComercial " +
                    "as Empresa, " +
                    "e.Subtotal, imp.Tasa as Tasa, e.Total, " +
                    "(CASE e.Estatus WHEN 1 THEN 'Activo' " +
                    "WHEN 2 THEN 'Cancelado' END) as DesEstatus ");
            }
            else
            {
                sbSelect.Append("Select tei.Nombre as Tipo, stei.Nombre as Subtipo, " +
                    " " + ((str == null) ? "e.NoCheque as Banco, " : " ban.Nombre + ' ' + ban.CtaBanco as Banco, ") +
                    "e.Fecha, " +
                    "c.Descripcion as DesConcepto, p.NombreComercial " +
                    "as Empresa, " +
                    "e.Subtotal, " +
                    "(CASE e.Estatus WHEN 1 THEN 'Activo' " +
                    "WHEN 2 THEN 'Cancelado' END) as DesEstatus ");
            }
            sbSelect.Append("from egresos e ");
            sbSelect.Append("Left join Tipo_Egreso_Ingreso tei on tei.Clave = e.TipoEgreso ");
            sbSelect.Append("Left join SubTipo_Egreso_Ingreso stei on stei.Clave = e.SubTipoEgreso ");
            sbSelect.Append("Left join Concepto c on c.Clave = e.Concepto ");
            sbSelect.Append("Left join Persona p on p.Id = e.Proveedor ");
            if (impuesto)
                sbSelect.Append("Left join Impuesto imp on imp.Clave = e.Impuesto ");
            if (str != null)
                sbSelect.Append("Left join Banco ban on ban.Clave = e.CtaBanco ");
            sbSelect.Append("where e.TipoEgreso='" + tipo + "' and e.SubTipoEgreso='" + subTipo + "' and " + est);
            if (str != null)
                sbSelect.Append(" and e.CtaBanco = '" + str.Clave + "'");
            else
                sbSelect.Append(" and (e.NoCheque is not null or e.NoCheque != '') ");
            sbSelect.Append(" order by e.Fecha asc");

            daoGenerico dao_ = new daoGenerico();

            ds = dao_.EjecutarConsulta(sbSelect.ToString(), this.GetStringConnection);

            return ds;
        }
    }
}