using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_Gestion.str
{
    public class strPersona
    {
        public long Id { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Curp { get; set; }
        public string Rfc { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public eTipo Tipo { get; set; }
        public eEstatus Estatus { get; set; }
        public enum eTipo
        {
            Cliente=0,Proveedor=1
        }
        public enum eEstatus
        {
            Error=0,ACTIVO=1,INACTIVO=2,BAJA=3
        }
        public override string ToString()
        {
            return this.ApellidoPaterno + " " + this.ApellidoMaterno + " " + this.Nombre + " " + this.NombreComercial;
        }
    }
}