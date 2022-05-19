using System;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using PCL_Gestion.dao;

namespace PCL_Gestion.util
{
    public class CreaXML
    {
        private string cxn = string.Empty;

        public CreaXML(string sCxn)
        {
            this.cxn = sCxn;
        }

        public DataSet GeneraDataSet(string query = null, string fileName = null, string path = null, DataTable data = null)
        {
            daoConexion dao = new daoConexion(this.cxn);

            SqlDataAdapter adaptador = new SqlDataAdapter(query, dao.GetSql());

            DataSet ds = new DataSet(fileName);

            adaptador.Fill(ds);

            //string pathWithFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) 
            //    + @"\" + fileName + ".xsd";

            string pathWithFile = @"" + path + "/" + fileName + ".xsd";

            if (!File.Exists(pathWithFile))
            {
                ds.WriteXmlSchema(pathWithFile);
            }
            else
            {
                File.Delete(pathWithFile);
                ds.WriteXmlSchema(pathWithFile);
            }

            CrearDataSetEmpresa(data, path);

            return ds;
        }

        public static void GeneraXSD(DataSet ds, string nombreReporte, string path, DataTable data = null)
        {
            //string pathWithFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            //    + @"\" + nombreReporte + ".xsd";

            string pathWithFile = @"" + path + "/" + nombreReporte + ".xsd";

            if (!File.Exists(pathWithFile))
            {
                ds.WriteXmlSchema(pathWithFile);
            }
            else
            {
                File.Delete(pathWithFile);
                ds.WriteXmlSchema(pathWithFile);
            }

            CrearDataSetEmpresa(data, path);
        }

        private static void CrearDataSetEmpresa(DataTable data, string path)
        {
            if (data != null)
            {
                //string dsFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Empresa.xsd";

                string dsFile = @"" + path + "/Empresa.xsd";

                if (File.Exists(dsFile))
                    File.Delete(dsFile);

                DataSet _ds = new DataSet("Empresa");
                _ds.Tables.Add(data);
                _ds.WriteXmlSchema(dsFile);
            }
        }
    }
}