using System.ComponentModel.DataAnnotations;

namespace UI_Gestion.Models
{
    public class strPProveedor
    {
        [Key]
        public long Id { get; set; }
        public string Rfc { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public eEstatus Estatus { get; set; }
        public enum eEstatus
        {
            ACTIVO=1,INACTIVO=2,BAJA=3,SN=4
        }
    }
}