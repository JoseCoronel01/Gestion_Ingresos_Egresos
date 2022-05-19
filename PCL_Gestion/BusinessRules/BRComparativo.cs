using System;
using System.Collections.Generic;
using PCL_Gestion.str;
using PCL_Gestion.dao;
using System.Data.SqlClient;
using System.Data;

namespace PCL_Gestion.BusinessRules
{
    public class BRComparativo
    {
        private string CadenaConexion = string.Empty;
        string[] Meses = new string[12] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        string[] MesesABC = new string[12] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };

        public BRComparativo(string cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion;
        }

        public DataSet ObtenerTotalPorMes(string tipo, string subTipo, strIngreso.eEstatus estatus, bool conImpuesto)
        {
            daoPresupuestos dao = new daoPresupuestos(this.CadenaConexion);

            List<strPresupuesto> lista = dao.GetAll(tipo, subTipo);

            DataSet comparativos = new DataSet("comparativos");
            comparativos.Tables.Add();
            comparativos.Tables[0].Columns.Add("Anio");
            comparativos.Tables[0].Columns.Add("Mes");
            comparativos.Tables[0].Columns.Add("Presupuesto");
            comparativos.Tables[0].Columns.Add("Total");
            comparativos.Tables[0].Columns.Add("Diferencia");

            for (int i = 0; i < lista.Count; i++)
            {
                string[] sMeses = lista[i].Meses.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                for (int x = 0; x < sMeses.Length; x++)
                {
                    decimal diferencia = 0;
                    DataRow dr = comparativos.Tables[0].NewRow();
                    dr["Anio"] = lista[i].Anio;
                    dr["Mes"] = MesesABC[x];
                    dr["Presupuesto"] = decimal.Parse(sMeses[x]);
                    dr["Total"] = GeneraCalculoRealDiferencia(lista[i].Anio, Meses[x],
                        (x == 11 ? Meses[x] : Meses[x + 1]), decimal.Parse(sMeses[x]), out diferencia, estatus, conImpuesto);
                    dr["Diferencia"] = diferencia;
                    comparativos.Tables[0].Rows.Add(dr);
                }
            }

            return comparativos;
        }

        public DataSet ObtenerTotalPorMes(string tipo, string subTipo, strEgreso.eEstatus estatus, bool conImpuesto)
        {
            daoPresupuestos dao = new daoPresupuestos(this.CadenaConexion);

            List<strPresupuesto> lista = dao.GetAll(tipo, subTipo);

            DataSet comparativos = new DataSet();
            comparativos.Tables.Add();
            comparativos.Tables[0].Columns.Add("Anio");
            comparativos.Tables[0].Columns.Add("Mes");
            comparativos.Tables[0].Columns.Add("Presupuesto");
            comparativos.Tables[0].Columns.Add("Total");
            comparativos.Tables[0].Columns.Add("Diferencia");

            for (int i = 0; i < lista.Count; i++)
            {
                string[] sMeses = lista[i].Meses.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                for (int x = 0; x < sMeses.Length; x++)
                {
                    decimal diferencia = 0;
                    DataRow dr = comparativos.Tables[0].NewRow();
                    dr["Anio"] = lista[i].Anio;
                    dr["Mes"] = MesesABC[x];
                    dr["Presupuesto"] = decimal.Parse(sMeses[x]);
                    dr["Total"] = GeneraCalculoRealDiferencia(lista[i].Anio, Meses[x],
                        (x == 11 ? Meses[x] : Meses[x + 1]), decimal.Parse(sMeses[x]), out diferencia, estatus, conImpuesto);
                    dr["Diferencia"] = diferencia;
                    comparativos.Tables[0].Rows.Add(dr);
                }
            }

            return comparativos;
        }

        private decimal GeneraCalculoRealDiferencia(int anio, string mes, string mes2, decimal presupuesto, 
            out decimal diferencia, strIngreso.eEstatus estatus, bool conImpuesto)
        {
            decimal total = 0;

            string query = string.Empty;

            switch (estatus)
            {
                case strIngreso.eEstatus.Pagado:
                    {
                        query = "select " + ((conImpuesto) ? "SUM(i.Total)" : "SUM(i.Subtotal)") + " as total " +
                                "from ingresos i " +
                                "where i.Pago >= CONVERT(date, '" + anio + "-" + mes + "-01') and i.Pago < CONVERT(date, " + (mes2 == "11" ? "'" + anio++ + "-" + mes2 + "-01'" : "'" + anio + "-" + mes2 + "-01'") + ") and i.Estatus = 2";
                        break;
                    }
                case strIngreso.eEstatus.Emitido:
                    {
                        query = "select " + ((conImpuesto) ? "SUM(i.Total)" : "SUM(i.Subtotal)") + " as total " +
                                "from ingresos i " +
                                "where i.Emision >= CONVERT(date, '" + anio + "-" + mes + "-01') " +
                                "and i.Emision < CONVERT(date, " + (mes2 == "11" ? "'" + anio++ + "-" + mes2 + "-01'" : "'" + anio + "-" + mes2 + "-01'") + ") and i.Estatus = 1";
                        break;
                    }
                case strIngreso.eEstatus.Cancelado:
                    {
                        query = "select " + ((conImpuesto) ? "SUM(i.Total)" : "SUM(i.Subtotal)") + " as total " +
                                "from ingresos i " +
                                "where i.Emision >= CONVERT(date, '" + anio + "-" + mes + "-01') " +
                                "and i.Emision < CONVERT(date, " + (mes2 == "11" ? "'" + anio++ + "-" + mes2 + "-01'" : "'" + anio + "-" + mes2 + "-01'") + ") and i.Estatus = 3";
                        break;
                    }
            }

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.Read())
            {
                if (String.IsNullOrEmpty(reader["total"].ToString()) == false)
                    total = decimal.Parse(reader["total"].ToString());
            }

            diferencia = total - presupuesto;

            return total;
        }

        private decimal GeneraCalculoRealDiferencia(int anio, string mes, string mes2, decimal presupuesto, 
            out decimal diferencia, strEgreso.eEstatus estatus, bool conImpuesto)
        {
            decimal total = 0;

            string query = string.Empty;

            switch (estatus)
            {
                case strEgreso.eEstatus.Activo:
                    {
                        query = "select " + ((conImpuesto) ? "SUM(e.Total)" : "SUM(e.Subtotal)") + " as total " +
                                "from egresos e " +
                                "where e.Fecha >= CONVERT(date, '" + anio + "-" + mes + "-01') " +
                                "and e.Fecha < CONVERT(date, " + (mes2 == "11" ? "'" + anio++ + "-" + mes2 + "-01'" : "'" + anio + "-" + mes2 + "-01'") + ") and e.Estatus = 1";
                        break;
                    }
                case strEgreso.eEstatus.Cancelado:
                    {
                        query = "select " + ((conImpuesto) ? "SUM(e.Total)" : "SUM(e.Subtotal)") + " as total " +
                                "from egresos e " +
                                "where e.Fecha >= CONVERT(date, '" + anio + "-" + mes + "-01') " +
                                "and e.Fecha < CONVERT(date, " + (mes2 == "11" ? "'" + anio++ + "-" + mes2 + "-01'" : "'" + anio + "-" + mes2 + "-01'") + ") and e.Estatus = 2";
                        break;
                    }
            }

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.Read())
            {
                if (String.IsNullOrEmpty(reader["total"].ToString()) == false)
                    total = decimal.Parse(reader["total"].ToString());
            }

            diferencia = total - presupuesto;

            return total;
        }
    }

    public class strComparativo
    {
        public int Anio { get; set; }
        public string Mes { get; set; }
        public decimal Presupuesto { get; set; }
        public decimal Total { get; set; }
        public decimal Diferencia { get; set; }
    }
}