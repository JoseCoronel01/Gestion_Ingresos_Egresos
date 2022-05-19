using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_Gestion.str;

namespace PCL_Gestion.dao
{
    public class daoTipoReferencias
    {
        private string CadenaConexion = string.Empty;

        public daoTipoReferencias(string cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion;
        }

        public int Insert(strTipoReferencia str)
        {
            int save = 0;

            string query = "Insert into tipo_referencia (Id,Nombre) values (@Id,@Nombre) ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Update(strTipoReferencia str)
        {
            int save = 0;

            string query = "Update tipo_referencia set Nombre=@Nombre where Id=@Id ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Delete(int Id)
        {
            int save = 0;

            string query = "Delete from tipo_referencia where Id=@Id ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Id", Id);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public strTipoReferencia GetObject(int Id)
        {
            strTipoReferencia str = null;

            string query = "Select * from tipo_referencia where Id=@Id ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public List<strTipoReferencia> GetAll()
        {
            List<strTipoReferencia> lista = null;

            string query = "Select * from tipo_referencia order by Nombre asc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(reader, lista);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        public int CreateId()
        {
            int id = 0;

            string query = "Select Id from tipo_referencia order by Id desc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.Read())
            {
                id = int.Parse(reader["Id"].ToString());

                id = id + 1;
            }
            else
                id = 1;

            reader.Close();

            dao.Dispose();

            return id;
        }

        private List<strTipoReferencia> LoadList(SqlDataReader reader, List<strTipoReferencia> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strTipoReferencia>();
                lista.Add(new strTipoReferencia()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                });
            }
            return lista;
        }

        private strTipoReferencia LoadObject(SqlDataReader reader, strTipoReferencia str)
        {
            if (reader != null && reader.Read())
            {
                if (str == null) str = new strTipoReferencia();
                str.Id = int.Parse(reader["Id"].ToString());
                str.Nombre = reader["Nombre"].ToString();
            }
            return str;
        }

        private void AddParameters(SqlCommand cmd, strTipoReferencia str)
        {
            cmd.Parameters.AddWithValue("@Id", str.Id);
            cmd.Parameters.AddWithValue("@Nombre", str.Nombre);
        }
    }
}