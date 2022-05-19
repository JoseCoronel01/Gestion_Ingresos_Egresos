using System;
using System.Collections.Generic;
using PCL_Gestion.str;
using PCL_Gestion.dao;

namespace PCL_Gestion.BusinessRules
{
    public class BRCreditoDetalle
    {
        private string GetStringConnection = string.Empty;

        public BRCreditoDetalle(string getStringConnection)
        {
            this.GetStringConnection = getStringConnection;
        }

        public List<strCreditoDetalle> ListarDetalleDelCredito(strCredito str)
        {
            List<strCreditoDetalle> lista = null;
            switch (str.Periodicidad)
            {
                case 2://MENSUAL
                    {
                        daoCreditosDetalle dao = new daoCreditosDetalle(this.GetStringConnection);
                        long id = dao.CreateId(str.Id);
                        var I = (str.Interes / 100);
                        var capitalDesglosado = (str.Capital / 4);

                        while (str.Emision < str.Vencimiento)
                        {
                            DateTime fecha = str.Emision.AddMonths(1);

                            TimeSpan dias = fecha - str.Emision;

                            if (lista == null) lista = new List<strCreditoDetalle>();

                            lista.Add(new strCreditoDetalle()
                            {
                                Id = id,
                                Credito = str.Id,
                                Capital = Math.Round(capitalDesglosado, 2),
                                Interes = Math.Round((((I / 36000) * dias.Days) * capitalDesglosado), 2),
                                Saldo = Math.Round(capitalDesglosado),
                                Estatus = strCreditoDetalle.eEstatus.PorPagar
                            });

                            id = id + 1;

                            str.Emision = str.Emision.AddMonths(1);
                        }
                        break;
                    }
                case 5://ANUAL
                    {
                        daoCreditosDetalle dao = new daoCreditosDetalle(this.GetStringConnection);
                        long id = dao.CreateId(str.Id);
                        int meses = 0;
                        DateTime fechaE = str.Emision;
                        for (DateTime fecha = fechaE; fechaE < str.Vencimiento; fechaE = fechaE.AddMonths(1))
                            meses = meses + 1;

                        var P = str.Capital;
                        var N = (meses / 12);
                        var I = str.Interes;
                        var i = (I / 100);
                        var Z = 1 + i;
                        double r = Math.Round(Math.Pow(Z, N), 4);

                        var exp = Math.Round(r, 4);
                        var num = exp * i;
                        var den = exp - 1;
                        num = Math.Round(num, 4);
                        den = Math.Round(den, 4);
                        var A = P * (num / den);
                        A = Math.Round(A, 2);

                        while (P > 0)
                        {
                            var Ii = P * i;
                            var Aci = A - Ii;
                            var Si = P - Aci;

                            if (Si > 0)
                            {
                                if (lista == null) lista = new List<strCreditoDetalle>();
                                lista.Add(new strCreditoDetalle()
                                {
                                    Id = id,
                                    Credito = str.Id,
                                    Capital = Math.Round(Aci, 2),
                                    Interes = Math.Round(Ii, 2),
                                    Saldo = Math.Round(Si, 2),
                                    Estatus = strCreditoDetalle.eEstatus.PorPagar
                                });
                            }

                            P = Si;
                            id = id + 1;
                        }
                        break;
                    }
            }
            return lista;
        }
    }
}