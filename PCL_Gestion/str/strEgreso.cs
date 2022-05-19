using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_Gestion.str
{
    public class strEgreso
    {
        public long Id { get; set; }
        public string NoCheque { get; set; }
        public string CtaBanco { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoEgreso { get; set; }
        public string SubTipoEgreso { get; set; }
        public string Concepto { get; set; }
        public long Proveedor { get; set; }
        public decimal Subtotal { get; set; }
        public string Impuesto { get; set; }
        public decimal Total { get; set; }
        public eEstatus Estatus { get; set; }
        public enum eEstatus
        {
            Error=0,Activo=1,Cancelado=2
        }
        public override string ToString()
        {
            return this.NoCheque + " " + this.CtaBanco;
        }
    }
}