using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Gestion.Models
{
    public class strTipoReferencia
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}