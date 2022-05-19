using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_Gestion.str;

namespace PCL_Gestion.dao
{
    public class daoSubTipoEgresosIngresos
    {
        private string CadenaConexion = string.Empty;

        public daoSubTipoEgresosIngresos(string cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion;
        }

        public int Insert(strSubTipoEgresoIngreso str)
        {
            int save = 0;

            string query = "Insert into subtipo_egreso_ingreso (Clave,Nombre,Clave_Tipo) " +
                "values (@Clave,@Nombre,@Clave_Tipo) ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Update(strSubTipoEgresoIngreso str)
        {
            int save = 0;

            string query = "Update subtipo_egreso_ingreso set Nombre=@Nombre,Clave_Tipo=@Clave_Tipo where Clave=@Clave ";

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

            string query = "Delete from subtipo_egreso_ingreso where Clave=@Clave ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Clave", Clave);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public strSubTipoEgresoIngreso GetObject(string Clave)
        {
            strSubTipoEgresoIngreso str = null;

            string query = "Select * from subtipo_egreso_ingreso where Clave=@Clave ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Clave", Clave);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public List<strSubTipoEgresoIngreso> GetAll(string Clave_Tipo)
        {
            List<strSubTipoEgresoIngreso> lista = null;

            string query = "Select * from subtipo_egreso_ingreso where Clave_Tipo=@Clave_Tipo order by Nombre asc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Clave_Tipo", Clave_Tipo);

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(reader, lista);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        public List<strSubTipoEgresoIngreso> GetAll()
        {
            List<strSubTipoEgresoIngreso> lista = null;

            string query = "Select * from subtipo_egreso_ingreso order by Nombre,Clave_Tipo asc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(reader, lista);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        private List<strSubTipoEgresoIngreso> LoadList(SqlDataReader reader, List<strSubTipoEgresoIngreso> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strSubTipoEgresoIngreso>();
                lista.Add(new strSubTipoEgresoIngreso()
                {
                    Clave = reader["Clave"].ToString(),
                    Nombre = reader["Nombre"].ToString(),
                    Clave_Tipo = reader["Clave_Tipo"].ToString()
                });
            }
            return lista;
        }

        private strSubTipoEgresoIngreso LoadObject(SqlDataReader reader, strSubTipoEgresoIngreso str)
        {
            if (reader != null && reader.Read())
            {
                if (str == null) str = new strSubTipoEgresoIngreso();
                str.Clave = reader["Clave"].ToString();
                str.Nombre = reader["Nombre"].ToString();
                str.Clave_Tipo = reader["Clave_Tipo"].ToString();
            }
            return str;
        }

        private void AddParameters(SqlCommand cmd, strSubTipoEgresoIngreso str)
        {
            cmd.Parameters.AddWithValue("@Clave", str.Clave);
            cmd.Parameters.AddWithValue("@Nombre", str.Nombre);
            cmd.Parameters.AddWithValue("@Clave_Tipo", str.Clave_Tipo);
        }
    }
}