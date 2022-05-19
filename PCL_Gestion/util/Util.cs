using System;
using System.Text;
using System.Configuration;
using System.Collections.Generic;

namespace PCL_Gestion.util
{
    public class Util
    {
        public static string Encripta(string texto)
        {
            byte[] clave = Encoding.UTF8.GetBytes(texto);

            return Convert.ToBase64String(clave);
        }

        public static string DesEncripta(string texto)
        {
            byte[] clave = Convert.FromBase64String(texto);

            return UTF8Encoding.UTF8.GetString(clave);
        }

        public static void GuardaVariableConfiguracion(string nombreVariable, string valor)
        {
            string encriptado = Util.Encripta(valor);

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            KeyValueConfigurationElement variable = config.AppSettings.Settings[nombreVariable];

            if (variable == null)
            {
                variable = new KeyValueConfigurationElement(nombreVariable, encriptado);

                config.AppSettings.Settings.Add(variable);
            }
            else
                config.AppSettings.Settings[nombreVariable].Value = encriptado;

            config.Save(ConfigurationSaveMode.Full);
        }

        public static int CalcularEdad(DateTime fechaNacimiento)
        {
            //Obtengo la diferencia en años.
            int edad = DateTime.Now.Year - fechaNacimiento.Year;

            //Obtengo la fecha de cumpleaños de este año.
            DateTime nacimientoAhora = fechaNacimiento.AddYears(edad);

            //Le resto un año si la fecha actual es anterior al día de nacimiento.
            if (DateTime.Now.CompareTo(nacimientoAhora) < 0)
                edad--;

            return edad;
        }

        public static string GeneraRfc(string apePat, string apeMat, string nombre, DateTime fechaNac)
        {
            if (String.IsNullOrEmpty(apePat) == true) return String.Empty;

            string sApePat = apePat.Substring(0, 2);

            string sApeMat = apeMat.Substring(0, 1);

            string[] sNombre = nombre.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string sNombre2 = String.Empty;

            if (sNombre.Length == 1)
            {
                sNombre2 = sNombre[0].Substring(0, 1);
            }
            else if (sNombre.Length > 1)
            {
                if (!(sNombre[0].ToUpper() == "JOSE" || sNombre[0].ToUpper() == "MARIA" ||
                    sNombre[0].ToUpper() == "JOSÉ" || sNombre[0].ToUpper() == "MARÍA"))
                {
                    sNombre2 = sNombre[0].Substring(0, 1);
                }
                else
                {
                    sNombre2 = sNombre[1].Substring(0, 1);
                }
            }

            string sDia = fechaNac.Day.ToString("00");

            string sMes = fechaNac.Month.ToString("00");

            string sAnio = fechaNac.Year.ToString().Substring(2, 2);

            return sApePat + sApeMat + sNombre2 + sAnio + sMes + sDia;
        }

        public static string GeneraCurp(string apePat, string apeMat, string nombre, DateTime fechaNac, 
            string sexo, string estado)
        {
            if (String.IsNullOrEmpty(apePat) == true) return String.Empty;

            string sApePat = apePat.Substring(0, 2);

            string sApeMat = apeMat.Substring(0, 1);

            string[] sNombre = nombre.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string sNombre2 = String.Empty;

            string sNombre3 = String.Empty;

            if (sNombre.Length == 1)
            {
                sNombre2 = sNombre[0].Substring(0, 1);
                sNombre3 = sNombre[0];
            }
            else if (sNombre.Length > 1)
            {
                if (!(sNombre[0].ToUpper() == "JOSE" || sNombre[0].ToUpper() == "MARIA" ||
                    sNombre[0].ToUpper() == "JOSÉ" || sNombre[0].ToUpper() == "MARÍA"))
                {
                    sNombre2 = sNombre[0].Substring(0, 1);
                    sNombre3 = sNombre[0];
                }
                else
                {
                    sNombre2 = sNombre[1].Substring(0, 1);
                    sNombre3 = sNombre[1];
                }
            }

            string sDia = fechaNac.Day.ToString("00");

            string sMes = fechaNac.Month.ToString("00");

            string sAnio = fechaNac.Year.ToString().Substring(2, 2);

            string sApePat2 = obtenPrimeraConsonante(apePat);

            string sApeMat2 = obtenPrimeraConsonante(apeMat);

            sNombre3 = obtenPrimeraConsonante(sNombre3);

            return sApePat + sApeMat + sNombre2 + sAnio + sMes + sDia + sexo + estado + sApePat2 + sApeMat2 + sNombre3;
        }

        private static string obtenPrimeraConsonante(string texto)
        {
            string Texto = String.Empty;

            for (int i = 0; i < texto.Length; i++)
            {
                if (i > 0)
                {
                    string sAux = texto[i].ToString();

                    if (!(sAux.ToUpper() == "A" || sAux.ToUpper() == "E" || sAux.ToUpper() == "I" ||
                        sAux.ToUpper() == "O" || sAux.ToUpper() == "U"))
                    {
                        Texto = sAux;
                        break;
                    }
                }
            }

            return Texto.ToUpper();
        }

        public static List<ElementoComboBox> Genero()
        {
            return new List<ElementoComboBox>()
            {
                CrearGenero("H", "HOMBRE"),
                CrearGenero("M", "MUJER")
            };
        }

        private static ElementoComboBox CrearGenero(string value, string text)
        {
            return new ElementoComboBox() { value = value, text = text };
        }

        public static List<ElementoComboBox> EstatusEgreso()
        {
            return new List<ElementoComboBox>()
            {
                CrearEstatus("1", "Activo"),
                CrearEstatus("2", "Cancelado")
            };
        }

        public static List<ElementoComboBox> EstatusIngreso()
        {
            return new List<ElementoComboBox>()
            {
                CrearEstatus("1", "Emitido"),
                CrearEstatus("2", "Pagado"),
                CrearEstatus("3", "Cancelado")
            };
        }

        public static List<ElementoComboBox> TipoPersona()
        {
            return new List<ElementoComboBox>()
            {
                CrearEstatus("0", "Cliente"),
                CrearEstatus("1", "Proveedor")
            };
        }

        public static List<ElementoComboBox> TipoMovimiento()
        {
            return new List<ElementoComboBox>()
            {
                CrearEstatus("0", "Ingreso"),
                CrearEstatus("1", "Egreso")
            };
        }

        public static List<ElementoComboBox> Estatus()
        {
            return new List<ElementoComboBox>()
            {
                CrearEstatus("1", "ACTIVO"),
                CrearEstatus("2", "INACTIVO"),
                CrearEstatus("3", "BAJA")
            };
        }

        private static ElementoComboBox CrearEstatus(string value, string text)
        {
            return new ElementoComboBox() { value = value, text = text };
        }
    }

    public class ElementoComboBox
    {
        public object value { get; set; }
        public string text { get; set; }
    }
}