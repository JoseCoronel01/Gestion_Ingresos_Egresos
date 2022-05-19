using System;

namespace PCL_Gestion.str
{
    public class strCredito
    {
        public long Id { get; set; }
        public DateTime Emision { get; set; }
        public DateTime Vencimiento { get; set; }
        public double Capital { get; set; }
        public double Interes { get; set; }
        public int Periodicidad { get; set; }
    }
}