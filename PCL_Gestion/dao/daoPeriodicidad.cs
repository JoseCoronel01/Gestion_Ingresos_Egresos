using System.Collections.Generic;
using PCL_Gestion.str;
using System.Data.SqlClient;
using System;

namespace PCL_Gestion.dao
{
    public class daoPeriodicidad
    {
        private string CadenaConexion = string.Empty;

        public daoPeriodicidad(string sCadenaConexion)
        {
            this.CadenaConexion = sCadenaConexion;
        }

        public List<strPeriodicidad> GetAll()
        {
            List<strPeriodicidad> lista = null;

            string query = "Select * from periodicidad order by Id asc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(lista, reader);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        public strPeriodicidad GetObject(int Id)
        {
            strPeriodicidad obj = null;

            string query = "Select * from periodicidad where Id=@Id ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = cmd.ExecuteReader();

            obj = LoadObject(reader, obj);

            reader.Close();

            dao.Dispose();

            return obj;
        }

        private strPeriodicidad LoadObject(SqlDataReader reader, strPeriodicidad obj)
        {
            if (reader != null && reader.Read())
            {
                if (obj == null) obj = new strPeriodicidad();
                obj.Id = int.Parse(reader["Id"].ToString());
                obj.Periodicidad = reader["Periodicidad"].ToString();
            }
            return obj;
        }

        private List<strPeriodicidad> LoadList(List<strPeriodicidad> lista, SqlDataReader reader)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strPeriodicidad>();
                lista.Add(new strPeriodicidad()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Periodicidad = reader["Periodicidad"].ToString()
                });
            }
            return lista;
        }
    }
}