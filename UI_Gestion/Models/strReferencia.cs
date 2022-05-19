using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Gestion.Models
{
    public class strReferencia
    {
        [Key]
        public string Clave { get; set; }
        public long Persona { get; set; }
        public string Nombre { get; set; }
        public int Tipo { get; set; }

        public string PersonaNombre { get; set; }
        public string TipoNombre { get; set; }
    }
}