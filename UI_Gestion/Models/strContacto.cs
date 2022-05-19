using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Gestion.Models
{
    public class strContacto
    {
        [Key]
        public long Persona { get; set; }
        public string Direccion { get; set; }
        public string TelefonoCasa { get; set; }
        public string TelefonoOficina { get; set; }
        public string TelefonoCelular { get; set; }
        public string Correo { get; set; }
        public string CorreoAlt { get; set; }

        public string Nombre { get; set; }
    }
}