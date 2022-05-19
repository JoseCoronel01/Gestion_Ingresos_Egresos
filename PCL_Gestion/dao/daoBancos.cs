using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_Gestion.str;

namespace PCL_Gestion.dao
{
    public class daoBancos
    {
        private string CadenaConexion = string.Empty;

        public daoBancos(string cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion;
        }

        public int Insert(strBanco str)
        {
            int save = 0;

            string query = "Insert into banco (Clave,Nombre,CtaBanco) values (@Clave,@Nombre,@CtaBanco) ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Update(strBanco str)
        {
            int save = 0;

            string query = "Update banco set Nombre=@Nombre,CtaBanco=@CtaBanco where Clave=@Clave ";

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

            string query = "Delete from banco where Clave=@Clave ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Clave", Clave);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public strBanco GetObject(string Clave)
        {
            strBanco str = null;

            string query = "Select * from banco where Clave=@Clave ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Clave", Clave);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public List<strBanco> GetAll()
        {
            List<strBanco> lista = null;

            string query = "Select * from banco order by Nombre asc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(reader, lista);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        private List<strBanco> LoadList(SqlDataReader reader, List<strBanco> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strBanco>();
                lista.Add(new strBanco()
                {
                    Clave = reader["Clave"].ToString(),
                    Nombre = reader["Nombre"].ToString(),
                    CtaBanco = reader["CtaBanco"].ToString()
                });
            }
            return lista;
        }

        private strBanco LoadObject(SqlDataReader reader, strBanco str)
        {
            if (reader != null && reader.Read())
            {
                if (str == null) str = new strBanco();
                str.Clave = reader["Clave"].ToString();
                str.Nombre = reader["Nombre"].ToString();
                str.CtaBanco = reader["CtaBanco"].ToString();
            }
            return str;
        }

        private void AddParameters(SqlCommand cmd, strBanco str)
        {
            cmd.Parameters.AddWithValue("@Clave", str.Clave);
            cmd.Parameters.AddWithValue("@Nombre", str.Nombre);
            cmd.Parameters.AddWithValue("@CtaBanco", str.CtaBanco);
        }
    }
}