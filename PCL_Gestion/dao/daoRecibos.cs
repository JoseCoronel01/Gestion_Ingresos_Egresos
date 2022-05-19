using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_Gestion.str;

namespace PCL_Gestion.dao
{
    public class daoRecibos
    {
        private string CadenaConexion = string.Empty;

        public daoRecibos(string cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion;
        }

        public int Insert(strRecibo str)
        {
            int save = 0;

            string query = "Insert into recibo (Serie,Folio,Descripcion) values (@Serie,@Folio,@Descripcion) ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Update(strRecibo str)
        {
            int save = 0;

            string query = "Update recibo set Folio=@Folio and Descripcion=@Descripcion where Serie=@Serie ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Delete(string Serie)
        {
            int save = 0;

            string query = "Delete from recibo where Serie=@Serie ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Serie", Serie);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public strRecibo GetObject(string Serie)
        {
            strRecibo str = null;

            string query = "Select * from recibo where Serie=@Serie ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Serie", Serie);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public List<strRecibo> GetAll()
        {
            List<strRecibo> lista = null;

            string query = "Select * from recibo order by Serie asc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(reader, lista);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        private List<strRecibo> LoadList(SqlDataReader reader, List<strRecibo> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strRecibo>();
                lista.Add(new strRecibo()
                {
                    Serie = reader["Serie"].ToString(),
                    Folio = reader["Folio"].ToString(),
                    Descripcion = reader["Descripcion"].ToString()
                });
            }
            return lista;
        }

        private strRecibo LoadObject(SqlDataReader reader, strRecibo str)
        {
            if (reader != null && reader.Read())
            {
                if (str == null) str = new strRecibo();
                str.Serie = reader["Serie"].ToString();
                str.Folio = reader["Folio"].ToString();
                str.Descripcion = reader["Descripcion"].ToString();
            }
            return str;
        }

        private void AddParameters(SqlCommand cmd, strRecibo str)
        {
            cmd.Parameters.AddWithValue("@Serie", str.Serie);
            cmd.Parameters.AddWithValue("@Folio", str.Folio);
            cmd.Parameters.AddWithValue("@Descripcion", str.Descripcion);
        }
    }
}