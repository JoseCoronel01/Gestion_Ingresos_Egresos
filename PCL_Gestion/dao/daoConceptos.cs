using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_Gestion.str;

namespace PCL_Gestion.dao
{
    public class daoConceptos
    {
        private string CadenaConexion = string.Empty;

        public daoConceptos(string cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion;
        }

        public int Insert(strConcepto str)
        {
            int save = 0;

            string query = "Insert into concepto (Clave,Descripcion) values (@Clave,@Descripcion) ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Update(strConcepto str)
        {
            int save = 0;

            string query = "Update concepto set Descripcion=@Descripcion where Clave=@Clave ";

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

            string query = "Delete from concepto where Clave=@Clave ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Clave", Clave);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public strConcepto GetObject(string Clave)
        {
            strConcepto str = null;

            string query = "Select * from concepto where Clave=@Clave ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Clave", Clave);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public List<strConcepto> GetAll()
        {
            List<strConcepto> lista = null;

            string query = "Select * from concepto ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(reader, lista);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        private List<strConcepto> LoadList(SqlDataReader reader, List<strConcepto> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strConcepto>();
                lista.Add(new strConcepto()
                {
                    Clave = reader["Clave"].ToString(),
                    Descripcion = reader["Descripcion"].ToString()
                });
            }
            return lista;
        }

        private strConcepto LoadObject(SqlDataReader reader, strConcepto str)
        {
            if (reader != null && reader.Read())
            {
                if (str == null) str = new strConcepto();
                str.Clave = reader["Clave"].ToString();
                str.Descripcion = reader["Descripcion"].ToString();
            }
            return str;
        }

        private void AddParameters(SqlCommand cmd, strConcepto str)
        {
            cmd.Parameters.AddWithValue("@Clave", str.Clave);
            cmd.Parameters.AddWithValue("@Descripcion", str.Descripcion);
        }
    }
}