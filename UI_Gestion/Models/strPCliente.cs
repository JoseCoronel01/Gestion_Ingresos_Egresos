using System;
using System.ComponentModel.DataAnnotations;

namespace UI_Gestion.Models
{
    public class strPCliente
    {
        [Key]
        public long Id { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Curp { get; set; }
        public string Rfc { get; set; }
        public eEstatus Estatus { get; set; }
        public enum eEstatus
        {
            ACTIVO = 1, INACTIVO = 2, BAJA = 3, SN=4
        }
    }
}