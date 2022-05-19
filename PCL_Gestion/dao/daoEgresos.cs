using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_Gestion.str;

namespace PCL_Gestion.dao
{
    public class daoEgresos
    {
        private string CadenaConexion = string.Empty;

        public daoEgresos(string cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion;
        }

        public int Insert(strEgreso str)
        {
            int save = 0;

            string query = "Insert into egresos (Id,NoCheque,CtaBanco,Fecha,TipoEgreso,SubTipoEgreso," +
                "Concepto,Proveedor,Subtotal,Impuesto,Total,Estatus) " +
                "values (@Id,@NoCheque,@CtaBanco,@Fecha,@TipoEgreso,@SubTipoEgreso,@Concepto," +
                "@Proveedor,@Subtotal,@Impuesto,@Total,@Estatus) ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            try
            {
                save = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)//foreign key restrictions
                {
                    str.CtaBanco = null;
                    save = Insert(str);
                }
            }
            finally
            {
                dao.Dispose();
            }

            return save;
        }

        public int Update(strEgreso str)
        {
            int save = 0;
            //Fecha=@Fecha,

            string query = "Update egresos set NoCheque=@NoCheque,CtaBanco=@CtaBanco," +
                "TipoEgreso=@TipoEgreso,SubTipoEgreso=@SubTipoEgreso,Concepto=@Concepto," +
                "Proveedor=@Proveedor,Subtotal=@Subtotal,Impuesto=@Impuesto," +
                "Total=@Total,Estatus=@Estatus where Id=@Id ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            try
            {
                save = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)//foreign key restriccionts
                {
                    str.CtaBanco = null;
                    save = Update(str);
                }
            }
            finally
            {
                dao.Dispose();
            }

            return save;
        }

        public int Delete(long Id)
        {
            int save = 0;

            string query = "Delete from egresos where Id=@Id ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Id", Id);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public strEgreso GetObject(long Id)
        {
            strEgreso str = null;

            string query = "Select * from egresos where Id=@Id ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public strEgreso ExisteBanco(string banco)
        {
            strEgreso str = null;

            string query = "Select top 1 * from egresos where CtaBanco=@CtaBanco ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@CtaBanco", banco);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public strEgreso ExisteConcepto(string concepto)
        {
            strEgreso str = null;

            string query = "Select top 1 * from egresos where Concepto=@Concepto ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Concepto", concepto);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public strEgreso ExisteTasa(string impuesto)
        {
            strEgreso str = null;

            string query = "Select top 1 * from egresos where Impuesto=@Impuesto ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Impuesto", impuesto);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public strEgreso ExisteTipo(string TipoEgreso)
        {
            strEgreso str = null;

            string query = "Select top 1 * from egresos where TipoEgreso=@TipoEgreso ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@TipoEgreso", TipoEgreso);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public strEgreso ExisteSubtipo(string SubTipoEgreso)
        {
            strEgreso str = null;

            string query = "Select top 1 * from egresos where SubTipoEgreso=@SubTipoEgreso ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@SubTipoEgreso", SubTipoEgreso);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public strEgreso ExisteProveedor(long Proveedor)
        {
            strEgreso str = null;

            string query = "Select top 1 * from egresos where Proveedor=@Proveedor ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Proveedor", Proveedor);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public List<strEgreso> GetAll(strEgreso.eEstatus estatus)
        {
            List<strEgreso> lista = null;

            string query = string.Empty;

            if (strEgreso.eEstatus.Activo == estatus)
                query = "Select * from egresos where Estatus=1 order by Fecha desc ";
            else if (strEgreso.eEstatus.Cancelado == estatus)
                query = "Select * from egresos where Estatus=2 order by Fecha desc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(reader, lista);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        public long CreateId()
        {
            long Id = 0;

            string query = "Select Id from egresos order by Id desc ";

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

        private List<strEgreso> LoadList(SqlDataReader reader, List<strEgreso> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strEgreso>();
                lista.Add(new strEgreso()
                {
                    Concepto = reader["Concepto"].ToString(),
                    CtaBanco = reader["CtaBanco"].ToString(),
                    Estatus = ConvertToStr(reader["Estatus"].ToString()),
                    Fecha = DateTime.Parse(reader["Fecha"].ToString()),
                    Id = long.Parse(reader["Id"].ToString()),
                    Impuesto = reader["Impuesto"].ToString(),
                    NoCheque = reader["NoCheque"].ToString(),
                    Proveedor = long.Parse(reader["Proveedor"].ToString()),
                    SubTipoEgreso = reader["SubTipoEgreso"].ToString(),
                    Subtotal = decimal.Parse(reader["Subtotal"].ToString()),
                    TipoEgreso = reader["TipoEgreso"].ToString(),
                    Total = decimal.Parse(reader["Total"].ToString())
                });
            }
            return lista;
        }

        private strEgreso LoadObject(SqlDataReader reader, strEgreso str)
        {
            if (reader != null && reader.Read())
            {
                if (str == null) str = new strEgreso();
                str.Concepto = reader["Concepto"].ToString();
                str.CtaBanco = reader["CtaBanco"].ToString();
                str.Estatus = ConvertToStr(reader["Estatus"].ToString());
                str.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                str.Id = long.Parse(reader["Id"].ToString());
                str.Impuesto = reader["Impuesto"].ToString();
                str.NoCheque = reader["NoCheque"].ToString();
                str.Proveedor = long.Parse(reader["Proveedor"].ToString());
                str.SubTipoEgreso = reader["SubTipoEgreso"].ToString();
                str.Subtotal = decimal.Parse(reader["Subtotal"].ToString());
                str.TipoEgreso = reader["TipoEgreso"].ToString();
                str.Total = decimal.Parse(reader["Total"].ToString());
            }
            return str;
        }

        public static strEgreso.eEstatus ConvertToStr(string estatus)
        {
            switch (estatus)
            {
                case "1":
                    {
                        return strEgreso.eEstatus.Activo;
                    }
                case "2":
                    {
                        return strEgreso.eEstatus.Cancelado;
                    }
                default:
                    {
                        return strEgreso.eEstatus.Error;
                    }
            }
        }

        private void AddParameters(SqlCommand cmd, strEgreso str)
        {
            if (String.IsNullOrEmpty(str.CtaBanco) == true)
            {
                cmd.Parameters.AddWithValue("@CtaBanco", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@CtaBanco", str.CtaBanco);
            }

            if (String.IsNullOrEmpty(str.NoCheque) == true)
            {
                cmd.Parameters.AddWithValue("@NoCheque", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@NoCheque", str.NoCheque);
            }

            cmd.Parameters.AddWithValue("@Concepto", str.Concepto);
            cmd.Parameters.AddWithValue("@Estatus", str.Estatus);
            cmd.Parameters.AddWithValue("@Fecha", str.Fecha);
            cmd.Parameters.AddWithValue("@Id", str.Id);
            cmd.Parameters.AddWithValue("@Impuesto", str.Impuesto);
            cmd.Parameters.AddWithValue("@Proveedor", str.Proveedor);
            cmd.Parameters.AddWithValue("@SubTipoEgreso", str.SubTipoEgreso);
            cmd.Parameters.AddWithValue("@Subtotal", str.Subtotal);
            cmd.Parameters.AddWithValue("@TipoEgreso", str.TipoEgreso);
            cmd.Parameters.AddWithValue("@Total", str.Total);
        }
    }
}