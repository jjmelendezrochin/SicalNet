using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
using UserInterface.Helpers;
using UserInterface.Menu;

namespace UserInterface.Forms
{
    public partial class MenuData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/json";
            Response.ContentEncoding = Encoding.UTF8;

            try
            {
                // Si no hay usuario autenticado, no devolvemos menú.
                if (Context.User == null ||
                    Context.User.Identity == null ||
                    !Context.User.Identity.IsAuthenticated)
                {
                    Response.StatusCode = 401;

                    Response.Write(
                        "{\"success\":false,\"message\":\"Sesión no válida\"}"
                    );

                    Context.ApplicationInstance.CompleteRequest();
                    return;
                }

                // Generar menú según los roles del usuario.
                List<MenuItem> menu =
                    MenuBuilder.CrearMenu(Context);

                JavaScriptSerializer serializer =
                    new JavaScriptSerializer();

                string json = serializer.Serialize(menu);

                Response.Write(json);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;

                JavaScriptSerializer serializer =
                    new JavaScriptSerializer();

                var error = new
                {
                    success = false,
                    message = ex.Message
                };

                Response.Write(
                    serializer.Serialize(error)
                );
            }

            Context.ApplicationInstance.CompleteRequest();
        }
    }
}