using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_Gestion.str;

namespace PCL_Gestion.dao
{
    public class daoTipoEgresosIngresos
    {
        private string CadenaConexion = string.Empty;

        public daoTipoEgresosIngresos(string cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion;
        }

        public int Insert(strTipoEgresoIngreso str)
        {
            int save = 0;

            string query = "Insert into tipo_egreso_ingreso (Clave,Nombre,Tipo) values (@Clave,@Nombre,@Tipo) ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Update(strTipoEgresoIngreso str)
        {
            int save = 0;

            string query = "Update tipo_egreso_ingreso set Nombre=@Nombre,Tipo=@Tipo where Clave=@Clave ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Delete(string Clave)
        {
            int save = 0;

            string query = "Delete from tipo_egreso_ingreso where Clave=@Clave ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Clave", Clave);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public strTipoEgresoIngreso GetObject(string Clave)
        {
            strTipoEgresoIngreso str = null;

            string query = "Select * from tipo_egreso_ingreso where Clave=@Clave ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Clave", Clave);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public List<strTipoEgresoIngreso> GetAll(strTipoEgresoIngreso.eTipo tipo)
        {
            List<strTipoEgresoIngreso> lista = null;

            string query = "Select * from tipo_egreso_ingreso where Tipo=@Tipo order by Nombre asc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Tipo", tipo);

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(reader, lista);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        public List<strTipoEgresoIngreso> GetAll()
        {
            List<strTipoEgresoIngreso> lista = null;

            string query = "Select * from tipo_egreso_ingreso order by Nombre asc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(reader, lista);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        private List<strTipoEgresoIngreso> LoadList(SqlDataReader reader, List<strTipoEgresoIngreso> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strTipoEgresoIngreso>();
                lista.Add(new strTipoEgresoIngreso()
                {
                    Clave = reader["Clave"].ToString(),
                    Nombre = reader["Nombre"].ToString(),
                    Tipo = ConvertToStr(reader["Tipo"].ToString())
                });
            }
            return lista;
        }

        private strTipoEgresoIngreso LoadObject(SqlDataReader reader, strTipoEgresoIngreso str)
        {
            if (reader != null && reader.Read())
            {
                if (str == null) str = new strTipoEgresoIngreso();
                str.Clave = reader["Clave"].ToString();
                str.Nombre = reader["Nombre"].ToString();
                str.Tipo = ConvertToStr(reader["Tipo"].ToString());
            }
            return str;
        }

        private strTipoEgresoIngreso.eTipo ConvertToStr(string tipo)
        {
            switch (tipo)
            {
                case "0":
                    {
                        return strTipoEgresoIngreso.eTipo.Ingreso;
                    }
                case "1":
                    {
                        return strTipoEgresoIngreso.eTipo.Egreso;
                    }
                default:
                    {
                        return strTipoEgresoIngreso.eTipo.TipoC;
                    }
            }
        }

        private void AddParameters(SqlCommand cmd, strTipoEgresoIngreso str)
        {
            cmd.Parameters.AddWithValue("@Clave", str.Clave);
            cmd.Parameters.AddWithValue("@Nombre", str.Nombre);
            cmd.Parameters.AddWithValue("@Tipo", str.Tipo);
        }
    }
}