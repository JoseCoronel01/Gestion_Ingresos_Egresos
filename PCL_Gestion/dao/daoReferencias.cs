using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_Gestion.str;

namespace PCL_Gestion.dao
{
    public class daoReferencias
    {
        private string CadenaConexion = string.Empty;

        public daoReferencias(string cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion;
        }

        public int Insert(strReferencia str)
        {
            int save = 0;

            string query = "Insert into referencia (Clave,Nombre,Persona,Tipo) values (@Clave,@Nombre,@Persona,@Tipo) ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Update(strReferencia str)
        {
            int save = 0;

            string query = "Update referencia set Nombre=@Nombre,Persona=@Persona,Tipo=@Tipo where Clave=@Clave ";

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

            string query = "Delete from referencia where Clave=@Clave ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Clave", Clave);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public strReferencia GetObject(string Clave)
        {
            strReferencia str = null;

            string query = "Select * from referencia where Clave=@Clave ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Clave", Clave);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public strReferencia ExisteTipo(int Tipo)
        {
            strReferencia str = null;

            string query = "Select top 1 * from referencia where Tipo=@Tipo ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Tipo", Tipo);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public strReferencia ExistePersona(long Persona)
        {
            strReferencia str = null;

            string query = "Select top 1 * from referencia where Persona=@Persona ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Persona", Persona);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public List<strReferencia> GetAll()
        {
            List<strReferencia> lista = null;

            string query = "Select * from referencia order by Nombre asc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(reader, lista);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        private List<strReferencia> LoadList(SqlDataReader reader, List<strReferencia> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strReferencia>();
                lista.Add(new strReferencia()
                {
                    Clave = reader["Clave"].ToString(),
                    Nombre = reader["Nombre"].ToString(),
                    Persona = long.Parse(reader["Persona"].ToString()),
                    Tipo = int.Parse(reader["Tipo"].ToString())
                });
            }
            return lista;
        }

        private strReferencia LoadObject(SqlDataReader reader, strReferencia str)
        {
            if (reader != null && reader.Read())
            {
                if (str == null) str = new strReferencia();
                str.Clave = reader["Clave"].ToString();
                str.Nombre = reader["Nombre"].ToString();
                str.Persona = long.Parse(reader["Persona"].ToString());
                str.Tipo = int.Parse(reader["Tipo"].ToString());
            }
            return str;
        }

        private void AddParameters(SqlCommand cmd, strReferencia str)
        {
            cmd.Parameters.AddWithValue("@Clave", str.Clave);
            cmd.Parameters.AddWithValue("@Nombre", str.Nombre);
            cmd.Parameters.AddWithValue("@Persona", str.Persona);
            cmd.Parameters.AddWithValue("@Tipo", str.Tipo);
        }
    }
}