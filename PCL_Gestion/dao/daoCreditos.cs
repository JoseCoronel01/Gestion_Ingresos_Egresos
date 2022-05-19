using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_Gestion.str;

namespace PCL_Gestion.dao
{
    public class daoCreditos
    {
        private string CadenaConexion = string.Empty;

        public daoCreditos(string sCadenaConexion)
        {
            this.CadenaConexion = sCadenaConexion;
        }

        public int Insert(strCredito str)
        {
            int save = 0;

            string query = "Insert into credito (Id,Emision,Vencimiento,Capital,Interes,Periodicidad) values (@Id,@Emision,@Vencimiento,@Capital,@Interes,@Periodicidad) ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public List<strCredito> GetAll()
        {
            List<strCredito> lista = null;

            string query = "Select * from credito order by Id asc ";

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
            long id = 0;

            string query = "Select Top 1 Id from credito order by Id desc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.Read())
            {
                id = long.Parse(reader["Id"].ToString());

                id = id + 1;
            }
            else
                id = 1;

            reader.Close();

            dao.Dispose();

            return id;
        }

        public strCredito GetObject(long Id)
        {
            strCredito obj = null;

            string query = "Select * from credito where Id=@Id ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = cmd.ExecuteReader();

            obj = LoadObject(reader, obj);

            reader.Close();

            dao.Dispose();

            return obj;
        }

        private strCredito LoadObject(SqlDataReader reader, strCredito obj)
        {
            if (reader != null && reader.Read())
            {
                if (obj == null) obj = new strCredito();
                obj.Id = long.Parse(reader["Id"].ToString());
                obj.Emision = DateTime.Parse(reader["Emision"].ToString());
                obj.Vencimiento = DateTime.Parse(reader["Vencimiento"].ToString());
                obj.Capital = double.Parse(reader["Capital"].ToString());
                obj.Interes = double.Parse(reader["Interes"].ToString());
                obj.Periodicidad = int.Parse(reader["Periodicidad"].ToString());
            }
            return obj;
        }

        private List<strCredito> LoadList(SqlDataReader reader, List<strCredito> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strCredito>();
                lista.Add(new strCredito()
                {
                    Id = long.Parse(reader["Id"].ToString()),
                    Emision = DateTime.Parse(reader["Emision"].ToString()),
                    Vencimiento = DateTime.Parse(reader["Vencimiento"].ToString()),
                    Capital = double.Parse(reader["Capital"].ToString()),
                    Interes = double.Parse(reader["Interes"].ToString()),
                    Periodicidad = int.Parse(reader["Periodicidad"].ToString())
                });
            }
            return lista;
        }

        private void AddParameters(SqlCommand cmd, strCredito str)
        {
            cmd.Parameters.AddWithValue("@Id", str.Id);
            cmd.Parameters.AddWithValue("@Emision", str.Emision);
            cmd.Parameters.AddWithValue("@Vencimiento", str.Vencimiento);
            cmd.Parameters.AddWithValue("@Capital", str.Capital);
            cmd.Parameters.AddWithValue("@Interes", str.Interes);
            cmd.Parameters.AddWithValue("@Periodicidad", str.Periodicidad);
        }
    }
}