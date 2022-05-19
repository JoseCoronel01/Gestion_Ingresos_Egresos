using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_Gestion.str;

namespace PCL_Gestion.dao
{
    public class daoContactos
    {
        private string CadenaConexion = string.Empty;

        public daoContactos(string cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion;
        }

        public int Insert(strContacto str)
        {
            int save = 0;

            string query = "Insert into contacto (Persona,Direccion,TelefonoCasa,TelefonoOficina," +
                "TelefonoCelular,Correo,CorreoAlt) " +
                "values (@Persona,@Direccion,@TelefonoCasa,@TelefonoOficina,@TelefonoCelular,@Correo,@CorreoAlt) ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Update(strContacto str)
        {
            int save = 0;

            string query = "Update contacto set Direccion=@Direccion,TelefonoCasa=@TelefonoCasa," +
                "TelefonoOficina=@TelefonoOficina,TelefonoCelular=@TelefonoCelular,Correo=@Correo," +
                "CorreoAlt=@CorreoAlt where Persona=@Persona ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Delete(long Persona)
        {
            int save = 0;

            string query = "Delete from contacto where Persona=@Persona ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Persona", Persona);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public strContacto GetObject(long Persona)
        {
            strContacto str = null;

            string query = "Select * from contacto where Persona=@Persona ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Persona", Persona);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public List<strContacto> GetAll()
        {
            List<strContacto> lista = null;

            string query = "Select * from contacto order by Direccion asc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(reader, lista);

            reader.Close();

            dao.Dispose();

            return lista;
        }

        private List<strContacto> LoadList(SqlDataReader reader, List<strContacto> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strContacto>();
                lista.Add(new strContacto()
                {
                    Persona = long.Parse(reader["Persona"].ToString()),
                    Direccion = reader["Direccion"].ToString(),
                    TelefonoCasa = reader["TelefonoCasa"].ToString(),
                    TelefonoOficina = reader["TelefonoOficina"].ToString(),
                    TelefonoCelular = reader["TelefonoCelular"].ToString(),
                    Correo = reader["Correo"].ToString(),
                    CorreoAlt = reader["CorreoAlt"].ToString()
                });
            }
            return lista;
        }

        private strContacto LoadObject(SqlDataReader reader, strContacto str)
        {
            if (reader != null && reader.Read())
            {
                if (str == null) str = new strContacto();
                str.Persona = long.Parse(reader["Persona"].ToString());
                str.Direccion = reader["Direccion"].ToString();
                str.TelefonoCasa = reader["TelefonoCasa"].ToString();
                str.TelefonoOficina = reader["TelefonoOficina"].ToString();
                str.TelefonoCelular = reader["TelefonoCelular"].ToString();
                str.Correo = reader["Correo"].ToString();
                str.CorreoAlt = reader["CorreoAlt"].ToString();
            }
            return str;
        }

        private void AddParameters(SqlCommand cmd, strContacto str)
        {
            cmd.Parameters.AddWithValue("@Persona", str.Persona);
            cmd.Parameters.AddWithValue("@Direccion", str.Direccion);
            cmd.Parameters.AddWithValue("@TelefonoCasa", str.TelefonoCasa);
            cmd.Parameters.AddWithValue("@TelefonoOficina", str.TelefonoOficina);
            cmd.Parameters.AddWithValue("@TelefonoCelular", str.TelefonoCelular);
            cmd.Parameters.AddWithValue("@Correo", str.Correo);
            cmd.Parameters.AddWithValue("@CorreoAlt", str.CorreoAlt);
        }
    }
}