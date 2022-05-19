using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_Gestion.str;

namespace PCL_Gestion.dao
{
    public class daoCreditosDetalle
    {
        private string CadenaConexion = string.Empty;

        public daoCreditosDetalle(string sCadenaConexion)
        {
            this.CadenaConexion = sCadenaConexion;
        }

        public int Insert(strCreditoDetalle str)
        {
            int save = 0;

            string query = "Insert into credito_detalle (Id,Credito,Capital,Interes,Saldo,Estatus) values (@Id,@Credito,@Capital,@Interes,@Saldo,@Estatus) ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Update(strCreditoDetalle str)
        {
            int save = 0;

            string query = "Update credito_detalle set Capital=@Capital,Interes=@Interes,Saldo=@Saldo,Estatus=@Estatus where Id=@Id and Credito=@Credito ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public long CreateId(long Credito)
        {
            long id = 0;

            string query = "Select Top 1 Id from credito_detalle where Credito=@Credito order by Id desc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Credito", Credito);

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

        public List<strCreditoDetalle> GetAll()
        {
            List<strCreditoDetalle> lista = null;

            string query = "Select * from credito_detalle order by Credito,Id asc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(reader, lista);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        public strCreditoDetalle GetObject(long Id, long Credito)
        {
            strCreditoDetalle obj = null;

            string query = "Select * from credito_detalle where Id=@Id and Credito=@Credito";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Credito", Credito);

            SqlDataReader reader = cmd.ExecuteReader();

            obj = LoadObject(reader, obj);

            reader.Close();

            dao.Dispose();

            return obj;
        }

        private strCreditoDetalle LoadObject(SqlDataReader reader, strCreditoDetalle obj)
        {
            if (reader != null && reader.Read())
            {
                if (obj == null) obj = new strCreditoDetalle();
                obj.Id = long.Parse(reader["Id"].ToString());
                obj.Credito = long.Parse(reader["Credito"].ToString());
                obj.Capital = double.Parse(reader["Capital"].ToString());
                obj.Interes = double.Parse(reader["Interes"].ToString());
                obj.Saldo = double.Parse(reader["Saldo"].ToString());
                obj.Estatus = CargaEstatus(reader["Estatus"].ToString());
            }
            return obj;
        }

        private List<strCreditoDetalle> LoadList(SqlDataReader reader, List<strCreditoDetalle> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strCreditoDetalle>();
                lista.Add(new strCreditoDetalle()
                {
                    Id = long.Parse(reader["Id"].ToString()),
                    Credito = long.Parse(reader["Credito"].ToString()),
                    Capital = double.Parse(reader["Capital"].ToString()),
                    Interes = double.Parse(reader["Interes"].ToString()),
                    Saldo = double.Parse(reader["Saldo"].ToString()),
                    Estatus = CargaEstatus(reader["Estatus"].ToString())
                });
            }
            return lista;
        }

        public strCreditoDetalle.eEstatus CargaEstatus(string value)
        {
            switch (value)
            {
                case "1":
                    {
                        return strCreditoDetalle.eEstatus.PorPagar;
                    }
                case "2":
                    {
                        return strCreditoDetalle.eEstatus.Pagado;
                    }
                default:
                    {
                        return strCreditoDetalle.eEstatus.Error;
                    }
            }
        }

        private void AddParameters(SqlCommand cmd, strCreditoDetalle str)
        {
            cmd.Parameters.AddWithValue("@Id", str.Id);
            cmd.Parameters.AddWithValue("@Credito", str.Credito);
            cmd.Parameters.AddWithValue("@Capital", str.Capital);
            cmd.Parameters.AddWithValue("@Interes", str.Interes);
            cmd.Parameters.AddWithValue("@Saldo", str.Saldo);
            cmd.Parameters.AddWithValue("@Estatus", str.Estatus);
        }
    }
}