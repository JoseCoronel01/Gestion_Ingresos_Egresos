using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_Gestion.str
{
    public class strBanco
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string CtaBanco { get; set; }
        public override string ToString()
        {
            return (this.Nombre + "_" + this.CtaBanco).Trim();
        }
    }
}