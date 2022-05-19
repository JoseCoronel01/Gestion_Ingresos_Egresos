using System.Data.SqlClient;
using System.Data;
using PCL_Gestion.util;

namespace PCL_Gestion.BusinessRules
{
    public class BRPortal
    {
        private string cxn = string.Empty;

        public BRPortal(string sCxn)
        {
            this.cxn = sCxn;
        }

        public string GetPortal(string clave)
        {
            SqlConnection cxn = new SqlConnection(this.cxn);

            SqlDataAdapter adapter = new SqlDataAdapter("Select CadenaConexion from BDS where Clave='" + clave + "'", cxn);

            DataSet ds = new DataSet();

            adapter.Fill(ds);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["CadenaConexion"].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}