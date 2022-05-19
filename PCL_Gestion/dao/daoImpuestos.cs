using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_Gestion.str;

namespace PCL_Gestion.dao
{
    public class daoImpuestos
    {
        private string CadenaConexion = string.Empty;

        public daoImpuestos(string cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion;
        }

        public int Insert(strImpuesto str)
        {
            int save = 0;

            string query = "Insert into impuesto (Clave,Tasa) values (@Clave,@Tasa) ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Update(strImpuesto str)
        {
            int save = 0;

            string query = "Update impuesto set Tasa=@Tasa where Clave=@Clave ";

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

            string query = "Delete from impuesto where Clave=@Clave ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Clave", Clave);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public strImpuesto GetObject(string Clave)
        {
            strImpuesto str = null;

            string query = "Select * from impuesto where Clave=@Clave ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Clave", Clave);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public List<strImpuesto> GetAll()
        {
            List<strImpuesto> lista = null;

            string query = "Select * from impuesto ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(reader, lista);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        private List<strImpuesto> LoadList(SqlDataReader reader, List<strImpuesto> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strImpuesto>();
                lista.Add(new strImpuesto()
                {
                    Clave = reader["Clave"].ToString(),
                    Tasa = decimal.Parse(reader["Tasa"].ToString())
                });
            }
            return lista;
        }

        private strImpuesto LoadObject(SqlDataReader reader, strImpuesto str)
        {
            if (reader != null && reader.Read())
            {
                if (str == null) str = new strImpuesto();
                str.Clave = reader["Clave"].ToString();
                str.Tasa = decimal.Parse(reader["Tasa"].ToString());
            }
            return str;
        }

        private void AddParameters(SqlCommand cmd, strImpuesto str)
        {
            cmd.Parameters.AddWithValue("@Clave", str.Clave);
            cmd.Parameters.AddWithValue("@Tasa", str.Tasa);
        }
    }
}