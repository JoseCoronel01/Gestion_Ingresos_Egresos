using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_Gestion.str
{
    public class strIngreso
    {
        public long Id { get; set; }
        public string Serie { get; set; }
        public string Folio { get; set; }
        public DateTime Emision { get; set; }
        public DateTime Pago { get; set; }
        public string TipoIngreso { get; set; }
        public string SubTipoIngreso { get; set; }
        public string Concepto { get; set; }
        public long Cliente { get; set; }
        public decimal Subtotal { get; set; }
        public string Impuesto { get; set; }
        public decimal Total { get; set; }
        public eEstatus Estatus { get; set; }
        public enum eEstatus
        {
            Error=0,Emitido=1,Pagado=2,Cancelado=3
        }
    }
}