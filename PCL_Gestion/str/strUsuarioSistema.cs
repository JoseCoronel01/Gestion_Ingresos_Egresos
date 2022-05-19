namespace PCL_Gestion.str
{
    public class strUsuarioSistema
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public eTipo Tipo { get; set; }
        public enum eTipo
        {
            AUDITOR=0,SUPERVISOR = 1,OPERADOR=2
        }
    }
}