using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_Gestion.str
{
    public class strTipoEgresoIngreso
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public eTipo Tipo { get; set; }
        public enum eTipo
        {
            Ingreso=0,Egreso=1,TipoC=2
        }
        public override string ToString()
        {
            return this.Clave + " " + this.Nombre + " " + this.Tipo;
        }
    }
}