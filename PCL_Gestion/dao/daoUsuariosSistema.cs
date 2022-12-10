using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_Gestion.str;

namespace PCL_Gestion.dao
{
    public class daoUsuariosSistema
    {
        private string cxn = string.Empty;

        public daoUsuariosSistema(string sCxn)
        {
            this.cxn = sCxn;
        }

        public int Insert(strUsuarioSistema str)
        {
            int save = 0;

            string query = "Insert into UsuariosSistema (Usuario,Password,Tipo) values (@Usuario,@Password,@Tipo) ";

            daoConexion dao = new daoConexion(this.cxn);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Update(strUsuarioSistema str)
        {
            int save = 0;

            string query = "Update UsuariosSistema set Password=@Password,Tipo=@Tipo where Usuario=@Usuario ";

            daoConexion dao = new daoConexion(this.cxn);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Delete(string Usuario)
        {
            int save = 0;

            string query = "Delete from UsuariosSistema where Usuario=@Usuario ";

            daoConexion dao = new daoConexion(this.cxn);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Usuario", Usuario);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public strUsuarioSistema GetIn(string Usuario, string Password)
        {
            strUsuarioSistema obj = null;

            string query = "Select * from UsuariosSistema " +
                "where Usuario = '" + Usuario + "' collate SQL_Latin1_General_CP1_CS_AS " +
                "and Password = '" + Password + "' collate SQL_Latin1_General_CP1_CS_AS ";

            daoConexion dao = new daoConexion(this.cxn);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            obj = LoadObject(reader, obj);

            reader.Close();

            dao.Dispose();

            return obj;
        }

        public List<strUsuarioSistema> GetAll()
        {
            List<strUsuarioSistema> lista = null;

            string query = "Select * from UsuariosSistema order by Usuario asc ";

            daoConexion dao = new daoConexion(this.cxn);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadData(reader, lista);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        public strUsuarioSistema GetObject(string Usuario)
        {
            strUsuarioSistema obj = null;

            string query = "Select * from UsuariosSistema where Usuario=@Usuario ";

            daoConexion dao = new daoConexion(this.cxn);

            SqlConnection sql = dao.GetSql();

            SqlCommand cmd = new SqlCommand(query, sql);

            cmd.Parameters.AddWithValue("@Usuario", Usuario);

            SqlDataReader reader = cmd.ExecuteReader();

            obj = LoadObject(reader, obj);

            reader.Close();

            dao.Dispose();

            return obj;
        }

        private static strUsuarioSistema LoadObject(SqlDataReader reader, strUsuarioSistema obj)
        {
            if (reader != null && reader.Read())
            {
                if (obj == null) obj = new strUsuarioSistema();
                obj.Usuario = reader["Usuario"].ToString();
                obj.Password = reader["Password"].ToString();
                obj.Tipo = CargarTipo(reader["Tipo"].ToString());
            }
            return obj;
        }

        private static List<strUsuarioSistema> LoadData(SqlDataReader reader, List<strUsuarioSistema> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strUsuarioSistema>();
                lista.Add(new strUsuarioSistema()
                {
                    Usuario = reader["Usuario"].ToString(),
                    Password = reader["Password"].ToString(),
                    Tipo = CargarTipo(reader["Tipo"].ToString())
                });
            }
            return lista;
        }

        private static strUsuarioSistema.eTipo CargarTipo(string value)
        {
            switch (value)
            {
                case "1":
                    {
                        return strUsuarioSistema.eTipo.SUPERVISOR;
                    }
                case "2":
                    {
                        return strUsuarioSistema.eTipo.OPERADOR;
                    }
                default:
                    {
                        return strUsuarioSistema.eTipo.AUDITOR;
                    }
            }
        }

        private static void AddParameters(SqlCommand cmd, strUsuarioSistema str)
        {
            cmd.Parameters.AddWithValue("@Usuario", str.Usuario);
            cmd.Parameters.AddWithValue("@Password", str.Password);
            cmd.Parameters.AddWithValue("@Tipo", str.Tipo);
        }
    }
}