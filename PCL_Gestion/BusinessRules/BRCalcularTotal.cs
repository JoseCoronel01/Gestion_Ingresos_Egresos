using System;
using PCL_Gestion.dao;

namespace PCL_Gestion.BusinessRules
{
    public class BRCalcularTotal
    {
        private string GetStringConnection = string.Empty;

        public BRCalcularTotal() { }

        public BRCalcularTotal(string getStringConnection)
        {
            this.GetStringConnection = getStringConnection;
        }

        public decimal GenerarCalculo(string impuesto, string subtotal)
        {
            decimal total = 0;

            if (String.IsNullOrEmpty(impuesto) == false && String.IsNullOrEmpty(subtotal) == false)
            {
                daoImpuestos dao = new daoImpuestos(this.GetStringConnection);

                decimal tasa = dao.GetObject(impuesto).Tasa;

                decimal interes = (decimal.Parse(subtotal) * tasa) / 100;

                total = decimal.Parse(subtotal) + interes;

                return total;
            }
            else
                return total;
        }
    }
}