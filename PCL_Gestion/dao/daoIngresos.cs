using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Runtime.ConstrainedExecution;
using System.Xml;
using PCL_Gestion.str;

namespace PCL_Gestion.dao
{
    public class daoIngresos
    {
        private string CadenaConexion = string.Empty;

        public daoIngresos(string cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion;
        }

        public int Insert(strIngreso str)
        {
            int save = 0;

            string query = "Insert into ingresos (Id,Serie,Folio,Emision,Pago,TipoIngreso,SubTipoIngreso," +
                "Concepto,Cliente,Subtotal,Impuesto,Total,Estatus) " +
                "values (@Id,@Serie,@Folio,@Emision,@Pago,@TipoIngreso,@SubTipoIngreso,@Concepto," +
                "@Cliente,@Subtotal,@Impuesto,@Total,@Estatus) ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Update(strIngreso str)
        {
            int save = 0;

            string query = "Update ingresos set Serie=@Serie,Folio=@Folio,Emision=@Emision,Pago=@Pago," +
                "TipoIngreso=@TipoIngreso,SubTipoIngreso=@SubTipoIngreso,Concepto=@Concepto," +
                "Cliente=@Cliente,Subtotal=@Subtotal,Impuesto=@Impuesto," +
                "Total=@Total,Estatus=@Estatus where Id=@Id ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Delete(long Id)
        {
            int save = 0;

            string query = "Delete from ingresos where Id=@Id ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Id", Id);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public strIngreso GetObject(long Id)
        {
            strIngreso str = null;

            string query = "Select * from ingresos where Id=@Id ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public strIngreso ExisteConcepto(string Concepto)
        {
            strIngreso str = null;

            string query = "Select top 1 * from ingresos where Concepto=@Concepto ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Concepto", Concepto);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public strIngreso ExisteTasa(string impuesto)
        {
            strIngreso str = null;

            string query = "Select top 1 * from ingresos where Impuesto=@Impuesto ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Impuesto", impuesto);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public strIngreso ExisteSerie(string serie)
        {
            strIngreso str = null;

            string query = "Select top 1 * from ingresos where Serie=@Serie ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Serie", serie);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public strIngreso ExisteTipo(string TipoIngreso)
        {
            strIngreso str = null;

            string query = "Select top 1 * from ingresos where TipoIngreso=@TipoIngreso ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@TipoIngreso", TipoIngreso);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public strIngreso ExisteSubtipo(string SubTipoIngreso)
        {
            strIngreso str = null;

            string query = "Select top 1 * from ingresos where SubTipoIngreso=@SubTipoIngreso ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@SubTipoIngreso", SubTipoIngreso);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public strIngreso ExisteCliente(long Cliente)
        {
            strIngreso str = null;

            string query = "Select top 1 * from ingresos where Cliente=@Cliente ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Cliente", Cliente);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public List<strIngreso> GetAll()
        {
            List<strIngreso> lista = null;

            string query = "Select * from ingresos order by Pago desc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(reader, lista);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        public List<strIngreso> GetAll(strIngreso.eEstatus estatus)
        {
            List<strIngreso> lista = null;

            string query = string.Empty;

            if (estatus == strIngreso.eEstatus.Emitido)
                query = "Select * from ingresos where Estatus=@Estatus order by Emision asc ";
            else if (estatus == strIngreso.eEstatus.Pagado)
                query = "Select * from ingresos where Estatus=@Estatus order by Pago desc ";
            else if (estatus == strIngreso.eEstatus.Cancelado)
                query = "Select * from ingresos where Estatus=@Estatus order by Emision desc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Estatus", estatus);

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(reader, lista);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        public string GetNextFolio(string serie)
        {
            int count = 0;

            string query = "Select COUNT(Id) as count from ingresos where Serie=@Serie ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Serie", serie);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.Read())
            {
                count = int.Parse(reader["count"].ToString());

                count = count + 1;
            }
            else
                count = 1;

            reader.Close();

            dao.Dispose();

            daoRecibos recibos = new daoRecibos(this.CadenaConexion);

            var obj = recibos.GetObject(serie);

            string sFolio = string.Empty;

            if (obj == null)
            {
                sFolio = "Sin folio";
                return sFolio;
            }

            int FolioLength = obj.Folio.Length;

            if (count >= int.Parse(obj.Folio))
                sFolio = "Sin folio";
            else
            {
                string ceros = string.Empty;
                for (int i = 0; i < FolioLength; i++)
                    ceros += "0";
                sFolio = serie.ToUpper() + count.ToString(ceros);
            }

            return sFolio;
        }

        public long CreateId()
        {
            long Id = 0;

            string query = "Select Id from ingresos order by Id desc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.Read())
            {
                Id = long.Parse(reader["Id"].ToString());

                Id = Id + 1;
            }
            else
                Id = 1;

            reader.Close();

            dao.Dispose();

            return Id;
        }

        private List<strIngreso> LoadList(SqlDataReader reader, List<strIngreso> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strIngreso>();
                lista.Add(new strIngreso()
                {
                    Cliente = long.Parse(reader["Cliente"].ToString()),
                    Concepto = reader["Concepto"].ToString(),
                    Estatus = ConvertToStr(reader["Estatus"].ToString()),
                    Emision = DateTime.Parse(reader["Emision"].ToString()),
                    Id = long.Parse(reader["Id"].ToString()),
                    Impuesto = reader["Impuesto"].ToString(),
                    Folio = reader["Folio"].ToString(),
                    Pago = (reader["Pago"] != DBNull.Value) ? DateTime.Parse(reader["Pago"].ToString()) : DateTime.MinValue,
                    Serie = reader["Serie"].ToString(),
                    Subtotal = decimal.Parse(reader["Subtotal"].ToString()),
                    SubTipoIngreso = reader["SubTipoIngreso"].ToString(),
                    Total = decimal.Parse(reader["Total"].ToString()),
                    TipoIngreso = reader["TipoIngreso"].ToString()
                });
            }
            return lista;
        }

        private strIngreso LoadObject(SqlDataReader reader, strIngreso str)
        {
            if (reader != null && reader.Read())
            {
                if (str == null) str = new strIngreso();
                str.Cliente = long.Parse(reader["Cliente"].ToString());
                str.Concepto = reader["Concepto"].ToString();
                str.Estatus = ConvertToStr(reader["Estatus"].ToString());
                str.Emision = DateTime.Parse(reader["Emision"].ToString());
                str.Id = long.Parse(reader["Id"].ToString());
                str.Impuesto = (reader["Impuesto"] != DBNull.Value) ? reader["Impuesto"].ToString() : null;
                str.Folio = reader["Folio"].ToString();
                str.Pago = (reader["Pago"] != DBNull.Value) ? DateTime.Parse(reader["Pago"].ToString()) : DateTime.MinValue;
                str.Serie = reader["Serie"].ToString();
                str.Subtotal = decimal.Parse(reader["Subtotal"].ToString());
                str.SubTipoIngreso = reader["SubTipoIngreso"].ToString();
                str.Total = decimal.Parse(reader["Total"].ToString());
                str.TipoIngreso = reader["TipoIngreso"].ToString();
            }
            return str;
        }

        public static strIngreso.eEstatus ConvertToStr(string estatus)
        {
            switch (estatus)
            {
                case "1":
                    {
                        return strIngreso.eEstatus.Emitido;
                    }
                case "2":
                    {
                        return strIngreso.eEstatus.Pagado;
                    }
                case "3":
                    {
                        return strIngreso.eEstatus.Cancelado;
                    }
                default:
                    {
                        return strIngreso.eEstatus.Error;
                    }
            }
        }

        private void AddParameters(SqlCommand cmd, strIngreso str)
        {
            if (str.Pago != DateTime.MinValue)
                cmd.Parameters.AddWithValue("@Pago", str.Pago);
            else
                cmd.Parameters.AddWithValue("@Pago", DBNull.Value);

            cmd.Parameters.AddWithValue("@Cliente", str.Cliente);
            cmd.Parameters.AddWithValue("@Concepto", str.Concepto);
            cmd.Parameters.AddWithValue("@Emision", str.Emision);
            cmd.Parameters.AddWithValue("@Estatus", str.Estatus);
            cmd.Parameters.AddWithValue("@Folio", str.Folio);
            cmd.Parameters.AddWithValue("@Id", str.Id);
            if (str.Impuesto != null)
                cmd.Parameters.AddWithValue("@Impuesto", str.Impuesto);
            else
                cmd.Parameters.AddWithValue("@Impuesto", DBNull.Value);
            cmd.Parameters.AddWithValue("@Serie", str.Serie);
            cmd.Parameters.AddWithValue("@SubTipoIngreso", str.SubTipoIngreso);
            cmd.Parameters.AddWithValue("@Subtotal", str.Subtotal);
            cmd.Parameters.AddWithValue("@TipoIngreso", str.TipoIngreso);
            cmd.Parameters.AddWithValue("@Total", str.Total);
        }
    }
}