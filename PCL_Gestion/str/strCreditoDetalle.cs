namespace PCL_Gestion.str
{
    public class strCreditoDetalle
    {
        public long Id { get; set; }
        public long Credito { get; set; }
        public double Capital { get; set; }
        public double Interes { get; set; }
        public double Saldo { get; set; }
        public eEstatus Estatus { get; set; }
        public enum eEstatus
        {
            Error=0,PorPagar=1,Pagado=2
        }
    }
}