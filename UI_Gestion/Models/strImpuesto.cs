using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Gestion.Models
{
    public class strImpuesto
    {
        [Key]
        public string Clave { get; set; }
        public decimal Tasa { get; set; }
    }
}