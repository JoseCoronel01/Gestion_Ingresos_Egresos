using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Gestion.Models
{
    public class strTipoEgresoIngreso
    {
        [Key]
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public eTipo Tipo { get; set; }
        public enum eTipo
        {
            Ingreso=0,Egreso=1,TipoC=2
        }
    }
}