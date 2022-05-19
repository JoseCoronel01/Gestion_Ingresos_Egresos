using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Gestion.Models
{
    public class strSubTipoEgresoIngreso
    {
        [Key]
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Clave_Tipo { get; set; }
    }
}