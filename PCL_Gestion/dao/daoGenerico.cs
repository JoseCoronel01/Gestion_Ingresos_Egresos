using System.Data.SqlClient;
using System.Data;
using PCL_Gestion.util;

namespace PCL_Gestion.dao
{
    public class daoGenerico
    {
        public DataSet EjecutarConsulta(string query, string cadenaConexion)
        {
            //string cxn = Util.DesEncripta(cadenaConexion);

            SqlConnection cxn_ = new SqlConnection(cadenaConexion);

            cxn_.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(query, cxn_);

            DataSet ds = new DataSet("Consulta");

            adapter.Fill(ds);

            cxn_.Close();

            cxn_.Dispose();

            return ds;
        }
    }
}