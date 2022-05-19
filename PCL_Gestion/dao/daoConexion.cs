using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PCL_Gestion.util;

namespace PCL_Gestion.dao
{
    public class daoConexion
    {
        private SqlConnection cxn = null;
        private string CadenaConexion = string.Empty;

        public daoConexion(string cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion;
        }

        public SqlConnection GetSql()
        {
            try
            {
                cxn = new SqlConnection(this.CadenaConexion);

                if (cxn.State == ConnectionState.Open) cxn.Close();

                cxn.Open();
            }
            catch { }
            finally { }

            return cxn;
        }

        public void Dispose()
        {
            if (cxn != null)
            {
                cxn.Close();
                cxn.Dispose();
            }
        }
    }
}