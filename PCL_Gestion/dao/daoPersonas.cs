using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_Gestion.str;

namespace PCL_Gestion.dao
{
    public class daoPersonas
    {
        private string CadenaConexion = string.Empty;

        public daoPersonas(string cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion;
        }

        public int Insert(strPersona str, strPersona.eTipo tipo)
        {
            int save = 0;

            string query = string.Empty;

            if (strPersona.eTipo.Proveedor == tipo)
            {
                query = "Insert into persona (Id,Rfc,RazonSocial,NombreComercial,Estatus,FechaRegistro,Tipo) " +
                    "values (@Id,@Rfc,@RazonSocial,@NombreComercial,@Estatus,@FechaRegistro,@Tipo) ";
            }
            else
            {
                query = "Insert into persona (Id,ApellidoPaterno,ApellidoMaterno," +
                    "Nombre,FechaNacimiento," +
                    "Sexo,Curp,Rfc," +
                    "Estatus,FechaRegistro,Tipo) " +
                    "values (@Id,@ApellidoPaterno,@ApellidoMaterno,@Nombre,@FechaNacimiento,@Sexo,@Curp,@Rfc,@Estatus,@FechaRegistro,@Tipo) ";
            }

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str, "Insert");

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Update(strPersona str, strPersona.eTipo tipo)
        {
            int save = 0;

            string query = string.Empty;

            if (strPersona.eTipo.Proveedor == tipo)
            {
                query = "Update persona set Rfc=@Rfc," +
                    "RazonSocial=@RazonSocial,NombreComercial=@NombreComercial,Estatus=@Estatus " +
                    "where Id=@Id ";
            }
            else
            {
                query = "Update persona set ApellidoPaterno=@ApellidoPaterno,ApellidoMaterno=@ApellidoMaterno," +
                    "Nombre=@Nombre,FechaNacimiento=@FechaNacimiento," +
                    "Sexo=@Sexo,Curp=@Curp,Rfc=@Rfc," +
                    "Estatus=@Estatus where Id=@Id ";
            }

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            AddParameters(cmd, str, "Update");

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public int Delete(long Id)
        {
            int save = 0;

            string query = "Delete from persona where Id=@Id ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Id", Id);

            save = cmd.ExecuteNonQuery();

            dao.Dispose();

            return save;
        }

        public strPersona GetObject(long Id)
        {
            strPersona str = null;

            string query = "Select * from persona where Id=@Id ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            cmd.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = cmd.ExecuteReader();

            str = LoadObject(reader, str);

            reader.Close();

            dao.Dispose();

            return str;
        }

        public List<strPersona> GetAll(strPersona.eTipo tipo)
        {
            List<strPersona> lista = null;

            if (strPersona.eTipo.Proveedor == tipo)
            {
                string query = "Select * from persona where Tipo=1 order by RazonSocial asc ";

                daoConexion dao = new daoConexion(this.CadenaConexion);

                SqlCommand cmd = new SqlCommand(query, dao.GetSql());

                SqlDataReader reader = cmd.ExecuteReader();

                lista = LoadList(reader, lista);

                reader.Close();

                dao.Dispose();
            }
            else
            {
                string query = "Select * from persona where Tipo=0 order by ApellidoPaterno,ApellidoMaterno,Nombre asc ";

                daoConexion dao = new daoConexion(this.CadenaConexion);

                SqlCommand cmd = new SqlCommand(query, dao.GetSql());

                SqlDataReader reader = cmd.ExecuteReader();

                lista = LoadList(reader, lista);

                reader.Close();

                dao.Dispose();
            }

            return lista;
        }

        public List<strPersona> GetAll()
        {
            List<strPersona> lista = null;

            string query = "Select * from persona order by ApellidoPaterno,ApellidoMaterno,Nombre,RazonSocial asc ";

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
            long Id = 0;

            string query = "Select Id from persona order by Id desc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlCommand cmd = new SqlCommand(query, dao.GetSql());

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.Read())
            {
                Id = long.Parse(reader["Id"].ToString());

                Id = Id + 1;
            }
            else
                Id = 1;

            reader.Close();

            dao.Dispose();

            return Id;
        }

        private List<strPersona> LoadList(SqlDataReader reader, List<strPersona> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strPersona>();
                lista.Add(new strPersona()
                {
                    ApellidoMaterno = reader["ApellidoMaterno"].ToString(),
                    ApellidoPaterno = reader["ApellidoPaterno"].ToString(),
                    Estatus = ConvertToStr(reader["Estatus"].ToString()),
                    Curp = reader["Curp"].ToString(),
                    Id = long.Parse(reader["Id"].ToString()),
                    FechaNacimiento = (reader["FechaNacimiento"] != DBNull.Value) ? DateTime.Parse(reader["FechaNacimiento"].ToString()) : DateTime.MinValue,
                    FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    NombreComercial = reader["NombreComercial"].ToString(),
                    RazonSocial = reader["RazonSocial"].ToString(),
                    Rfc = reader["Rfc"].ToString(),
                    Sexo = reader["Sexo"].ToString(),
                    Tipo = ConvertToStrType(reader["Tipo"].ToString())
                });
            }
            return lista;
        }

        private strPersona LoadObject(SqlDataReader reader, strPersona str)
        {
            if (reader != null && reader.Read())
            {
                if (str == null) str = new strPersona();
                str.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                str.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                str.Estatus = ConvertToStr(reader["Estatus"].ToString());
                str.Curp = reader["Curp"].ToString();
                str.Id = long.Parse(reader["Id"].ToString());
                str.FechaNacimiento = (reader["FechaNacimiento"] != DBNull.Value) ? DateTime.Parse(reader["FechaNacimiento"].ToString()) : DateTime.MinValue;
                str.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                str.Nombre = reader["Nombre"].ToString();
                str.NombreComercial = reader["NombreComercial"].ToString();
                str.RazonSocial = reader["RazonSocial"].ToString();
                str.Rfc = reader["Rfc"].ToString();
                str.Sexo = reader["Sexo"].ToString();
                str.Tipo = ConvertToStrType(reader["Tipo"].ToString());
            }
            return str;
        }

        private strPersona.eTipo ConvertToStrType(string tipo)
        {
            if (tipo == "0")
                return strPersona.eTipo.Cliente;
            else
                return strPersona.eTipo.Proveedor;
        }

        private strPersona.eEstatus ConvertToStr(string estatus)
        {
            switch (estatus)
            {
                case "1":
                    {
                        return strPersona.eEstatus.ACTIVO;
                    }
                case "2":
                    {
                        return strPersona.eEstatus.INACTIVO;
                    }
                case "3":
                    {
                        return strPersona.eEstatus.BAJA;
                    }
                default:
                    {
                        return strPersona.eEstatus.Error;
                    }
            }
        }

        private void AddParameters(SqlCommand cmd, strPersona str, string Insert)
        {
            if (Insert == "Insert")
            {
                cmd.Parameters.AddWithValue("@Id", str.Id);

                if (strPersona.eTipo.Cliente == str.Tipo)
                {
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", str.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", str.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Nombre", str.Nombre);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", str.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Sexo", str.Sexo);
                    cmd.Parameters.AddWithValue("@Curp", str.Curp);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@RazonSocial", str.RazonSocial);
                    cmd.Parameters.AddWithValue("@NombreComercial", str.NombreComercial);
                }

                cmd.Parameters.AddWithValue("@Rfc", str.Rfc);
                cmd.Parameters.AddWithValue("@Estatus", str.Estatus);

                cmd.Parameters.AddWithValue("@FechaRegistro", str.FechaRegistro);
                cmd.Parameters.AddWithValue("@Tipo", str.Tipo);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Id", str.Id);

                if (strPersona.eTipo.Cliente == str.Tipo)
                {
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", str.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", str.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Nombre", str.Nombre);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", str.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Sexo", str.Sexo);
                    cmd.Parameters.AddWithValue("@Curp", str.Curp);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@RazonSocial", str.RazonSocial);
                    cmd.Parameters.AddWithValue("@NombreComercial", str.NombreComercial);
                }

                cmd.Parameters.AddWithValue("@Rfc", str.Rfc);
                cmd.Parameters.AddWithValue("@Estatus", str.Estatus);
            }
        }
    }
}