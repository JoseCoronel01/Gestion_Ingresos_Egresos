using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Gestion.Models
{
    public class strRecibo
    {
        [Key]
        public string Serie { get; set; }
        public string Folio { get; set; }
        public string Descripcion { get; set; }
    }
}