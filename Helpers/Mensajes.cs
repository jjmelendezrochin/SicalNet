using System;
using System.Web;
using System.Web.UI;

namespace UserInterface
{
    public static class Mensajes
    {
        public static void Mostrar(
            Page pagina,
            string mensaje,
            string tipo)
        {
            if (pagina == null)
                return;

            if (string.IsNullOrEmpty(tipo))
                tipo = "info";

            string mensajeSeguro =
                HttpUtility.JavaScriptStringEncode(
                    mensaje ?? string.Empty
                );

            string tipoSeguro =
                HttpUtility.JavaScriptStringEncode(
                    tipo
                );

            string script =
                "SicalAlert.mostrar('" +
                mensajeSeguro +
                "','" +
                tipoSeguro +
                "');";

            pagina.ClientScript.RegisterStartupScript(
                pagina.GetType(),
                Guid.NewGuid().ToString(),
                script,
                true
            );
        }


        public static void Informacion(
            Page pagina,
            string mensaje)
        {
            Mostrar(
                pagina,
                mensaje,
                "info"
            );
        }


        public static void Advertencia(
            Page pagina,
            string mensaje)
        {
            Mostrar(
                pagina,
                mensaje,
                "advertencia"
            );
        }


        public static void Error(
            Page pagina,
            string mensaje)
        {
            Mostrar(
                pagina,
                mensaje,
                "error"
            );
        }


        public static void Exito(
            Page pagina,
            string mensaje)
        {
            Mostrar(
                pagina,
                mensaje,
                "exito"
            );
        }
    }
}