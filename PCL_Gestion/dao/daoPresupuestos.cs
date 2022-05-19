using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_Gestion.str;

namespace PCL_Gestion.dao
{
    public class daoPresupuestos
    {
        private string CadenaConexion = string.Empty;

        public daoPresupuestos(string cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion;
        }

        public int Insert(strPresupuesto str)
        {
            int save = 0;

            string query = "Insert into presupuesto (Clave,Tipo,Subtipo,Anio,Meses) " +
                "values (@Clave,@Tipo,@Subtipo,@Anio,@Meses) ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Update(strPresupuesto str)
        {
            int save = 0;

            string query = "Update presupuesto set Meses=@Meses " +
                "where Clave=@Clave and Tipo=@Tipo and Subtipo=@Subtipo and Anio=@Anio ";

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

            string query = "Delete from presupuesto where Clave=@Clave ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Clave", Clave);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public strPresupuesto GetObject(string Clave)
        {
            strPresupuesto str = null;

            string query = "Select * from presupuesto where Clave=@Clave ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Clave", Clave);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public List<strPresupuesto> GetAll(string Tipo, string Subtipo)
        {
            List<strPresupuesto> lista = null;

            string query = "Select * from presupuesto where Tipo=@Tipo and Subtipo=@Subtipo order by Anio asc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Tipo", Tipo);
            cmd.Parameters.AddWithValue("@Subtipo", Subtipo);

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(reader, lista);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        private List<strPresupuesto> LoadList(SqlDataReader reader, List<strPresupuesto> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strPresupuesto>();
                lista.Add(new strPresupuesto()
                {
                    Clave = reader["Clave"].ToString(),
                    Tipo = reader["Tipo"].ToString(),
                    SubTipo = reader["SubTipo"].ToString(),
                    Anio = int.Parse(reader["Anio"].ToString()),
                    Meses = reader["Meses"].ToString()
                });
            }
            return lista;
        }

        private strPresupuesto LoadObject(SqlDataReader reader, strPresupuesto str)
        {
            if (reader != null && reader.Read())
            {
                if (str == null) str = new strPresupuesto();
                str.Clave = reader["Clave"].ToString();
                str.Tipo = reader["Tipo"].ToString();
                str.SubTipo = reader["SubTipo"].ToString();
                str.Anio = int.Parse(reader["Anio"].ToString());
                str.Meses = reader["Meses"].ToString();
            }
            return str;
        }

        private void AddParameters(SqlCommand cmd, strPresupuesto str)
        {
            cmd.Parameters.AddWithValue("@Clave", str.Clave);
            cmd.Parameters.AddWithValue("@Tipo", str.Tipo);
            cmd.Parameters.AddWithValue("@SubTipo", str.SubTipo);
            cmd.Parameters.AddWithValue("@Anio", str.Anio);
            cmd.Parameters.AddWithValue("@Meses", str.Meses);
        }
    }
}