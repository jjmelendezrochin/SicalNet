using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserInterface.Helpers
{
    public class Funciones
    {
        public string ConvertirFechaMesNumero(string fecha)
        {
            if (string.IsNullOrEmpty(fecha))
                return fecha;

            return fecha
                .ToLower()
                .Replace("ene", "01")
                .Replace("feb", "02")
                .Replace("mar", "03")
                .Replace("abr", "04")
                .Replace("may", "05")
                .Replace("jun", "06")
                .Replace("jul", "07")
                .Replace("ago", "08")
                .Replace("sep", "09")
                .Replace("oct", "10")
                .Replace("nov", "11")
                .Replace("dic", "12");
        }
    }
}