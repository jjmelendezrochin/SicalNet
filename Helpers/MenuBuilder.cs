using System.Collections.Generic;
using System.Web;
using UserInterface.Menu;

namespace UserInterface.Helpers
{
    public static class MenuBuilder
    {
        public static List<MenuItem> CrearMenu(HttpContext context)
        {
            List<MenuItem> menu = new List<MenuItem>();

            // =====================================================
            // 0.0 INICIO
            // =====================================================

            MenuItem inicio = new MenuItem();

            inicio.Id = "i0.0";
            inicio.Label = "Inicio";
            inicio.Url = VirtualPathUtility.ToAbsolute("~/Forms/NewMenu.aspx");
            inicio.Icon = "grayDots.gif";

            menu.Add(inicio);


            // =====================================================
            // 1.0 ADMINISTRACIÓN
            // =====================================================

            if (context.User.IsInRole("1.0"))
            {
                MenuItem administracion = new MenuItem();

                administracion.Id = "g_Administracion";
                administracion.Label = "Administración";
                administracion.Icon = "grayDots.gif";


                // -------------------------------------------------
                // 1.1 Usuarios
                // -------------------------------------------------

                if (context.User.IsInRole("1.1"))
                {
                    MenuItem usuarios = new MenuItem();

                    usuarios.Id = "i1.1";
                    usuarios.Label = "Usuarios";
                    usuarios.Url = VirtualPathUtility.ToAbsolute(
                        "~/Forms/Administration/UsersList.aspx"
                    );
        //            usuarios.Url =
        //                        "~/Forms/Administration/UsersList.aspx";
                    usuarios.Icon = "grayDots.gif";

                    administracion.Children.Add(usuarios);
                }


                // -------------------------------------------------
                // 1.2 Perfiles
                // -------------------------------------------------

                if (context.User.IsInRole("1.2"))
                {
                    MenuItem perfiles = new MenuItem();

                    perfiles.Id = "i1.2";
                    perfiles.Label = "Perfiles";
                    perfiles.Url = VirtualPathUtility.ToAbsolute(
                        "~/Forms/Administration/Profiles.aspx");
                    perfiles.Icon = "grayDots.gif";

                    administracion.Children.Add(perfiles);
                }


                // -------------------------------------------------
                // 1.3 Desbloqueo de cuentas
                // -------------------------------------------------

                if (context.User.IsInRole("1.3"))
                {
                    MenuItem desbloqueo = new MenuItem();

                    desbloqueo.Id = "i1.3";
                    desbloqueo.Label = "Desbloqueo de Cuentas";
                    desbloqueo.Url = VirtualPathUtility.ToAbsolute(
                        "~/Forms/Administration/UnlockAccounts.aspx");
                    desbloqueo.Icon = "grayDots.gif";

                    administracion.Children.Add(desbloqueo);
                }


                // -------------------------------------------------
                // 1.4 Bitácora
                // -------------------------------------------------

                if (context.User.IsInRole("1.4"))
                {
                    MenuItem bitacora = new MenuItem();

                    bitacora.Id = "i1.4";
                    bitacora.Label = "Bitácora de Sucesos";
                    bitacora.Url = VirtualPathUtility.ToAbsolute(
                        "~/Forms/Administration/ConsultBitacora.aspx");
                    bitacora.Icon = "grayDots.gif";

                    administracion.Children.Add(bitacora);
                }


                // -------------------------------------------------
                // 1.5 Desconectar cuentas
                // -------------------------------------------------

                if (context.User.IsInRole("1.5"))
                {
                    MenuItem desconectar = new MenuItem();

                    desconectar.Id = "i1.5";
                    desconectar.Label = "Desconectar Cuentas";
                    desconectar.Url = VirtualPathUtility.ToAbsolute(
                        "~/Forms/Administration/DisconnectAccounts.aspx");
                    desconectar.Icon = "grayDots.gif";

                    administracion.Children.Add(desconectar);
                }


                // Solamente agregamos Administración si contiene
                // al menos una opción autorizada.
                if (administracion.Children.Count > 0)
                {
                    menu.Add(administracion);
                }
            }


            // =====================================================
            // 2.0 CATÁLOGOS
            // =====================================================

            if (context.User.IsInRole("2.0"))
            {
                MenuItem catalogos = new MenuItem();

                catalogos.Id = "g_Catalogos";
                catalogos.Label = "Catálogos";
                catalogos.Icon = "grayDots.gif";


                // 2.1 Plantas
                if (context.User.IsInRole("2.1"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i2.1";
                    item.Label = "Plantas";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/Plant.aspx");
                    item.Icon = "grayDots.gif";

                    catalogos.Children.Add(item);
                }


                // 2.2 Líneas de Producción
                if (context.User.IsInRole("2.2"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i2.2";
                    item.Label = "Líneas de Producción";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/Linea.aspx");
                    item.Icon = "grayDots.gif";

                    catalogos.Children.Add(item);
                }


                // 2.3 Presentaciones
                if (context.User.IsInRole("2.3"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i2.3";
                    item.Label = "Presentaciones";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/Presentacion.aspx");
                    item.Icon = "grayDots.gif";

                    catalogos.Children.Add(item);
                }


                // 2.4 Medidas
                if (context.User.IsInRole("2.4"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i2.4";
                    item.Label = "Medidas";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/Medida.aspx");
                    item.Icon = "grayDots.gif";

                    catalogos.Children.Add(item);
                }


                // 2.5 Espesores
                if (context.User.IsInRole("2.5"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i2.5";
                    item.Label = "Espesores";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/Espesor.aspx");
                    item.Icon = "grayDots.gif";

                    catalogos.Children.Add(item);
                }


                // 2.6 Colores
                if (context.User.IsInRole("2.6"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i2.6";
                    item.Label = "Colores";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/Colour.aspx");
                    item.Icon = "grayDots.gif";

                    catalogos.Children.Add(item);
                }


                // 2.7 Familias de Producto
                if (context.User.IsInRole("2.7"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i2.7";
                    item.Label = "Familias de Producto";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/FamiliaProductos.aspx");
                    item.Icon = "grayDots.gif";

                    catalogos.Children.Add(item);
                }


                // 2.8 Tipos de Prepolímero (PMMA)
                if (context.User.IsInRole("2.8"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i2.8";
                    item.Label = "Tipos de Prepolímero (PMMA)";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/TipoPMMA.aspx");
                    item.Icon = "grayDots.gif";

                    catalogos.Children.Add(item);
                }


                // 2.9 Lotes
                if (context.User.IsInRole("2.9"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i2.9";
                    item.Label = "Lotes";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/Lotes.aspx");
                    item.Icon = "grayDots.gif";

                    catalogos.Children.Add(item);
                }


                // 2.10 Ollas
                if (context.User.IsInRole("2.10"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i2.10";
                    item.Label = "Ollas";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/Ollas.aspx");
                    item.Icon = "grayDots.gif";

                    catalogos.Children.Add(item);
                }


                // 2.11 Cubas Área de Curado
                if (context.User.IsInRole("2.11"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i2.11";
                    item.Label = "Cubas Área de Curado";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/Cubas.aspx");
                    item.Icon = "grayDots.gif";

                    catalogos.Children.Add(item);
                }


                // 2.12 Cubas Área de Post Curado
                if (context.User.IsInRole("2.12"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i2.12";
                    item.Label = "Cubas Área de Post Curado";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/Zonas.aspx");
                    item.Icon = "grayDots.gif";

                    catalogos.Children.Add(item);
                }


                // 2.13 Vidrios
                if (context.User.IsInRole("2.13"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i2.13";
                    item.Label = "Vidrios";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/VidriosTamanio.aspx");
                    item.Icon = "grayDots.gif";

                    catalogos.Children.Add(item);
                }


                // 2.14 Aforo
                if (context.User.IsInRole("2.14"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i2.14";
                    item.Label = "Aforo";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/Aforo.aspx");
                    item.Icon = "grayDots.gif";

                    catalogos.Children.Add(item);
                }


                // 2.15 Anillos
                if (context.User.IsInRole("2.15"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i2.15";
                    item.Label = "Anillos";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/Anillos.aspx");
                    item.Icon = "grayDots.gif";

                    catalogos.Children.Add(item);
                }

                // =====================================================
                // SUBMENÚ FORMULACIÓN
                // =====================================================

                if (context.User.IsInRole("2.11") ||
                    context.User.IsInRole("2.12"))
                {
                    MenuItem formulacion = new MenuItem();

                    formulacion.Id = "i2.0";
                    formulacion.Label = "Formulación";
                    formulacion.Icon = "grayDots.gif";


                    // 2.11 Folios Color
                    if (context.User.IsInRole("2.11"))
                    {
                        MenuItem item = new MenuItem();

                        item.Id = "i2.11_folios_color";
                        item.Label = "Folios Color";
                        item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/FoliosColor.aspx");
                        item.Icon = "grayDots.gif";

                        formulacion.Children.Add(item);
                    }


                    // 2.12 Folios Aditivos
                    if (context.User.IsInRole("2.12"))
                    {
                        MenuItem item = new MenuItem();

                        item.Id = "i2.12_folios_aditivos";
                        item.Label = "Folios Aditivos";
                        item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/FoliosAditivos.aspx");
                        item.Icon = "grayDots.gif";

                        formulacion.Children.Add(item);
                    }


                    if (formulacion.Children.Count > 0)
                    {
                        catalogos.Children.Add(formulacion);
                    }
                }

                if (catalogos.Children.Count > 0)
                {
                    menu.Add(catalogos);
                }
            }


            // =====================================================
            // 3.0 ESTRUCTURAS
            // =====================================================

            if (context.User.IsInRole("3.0"))
            {
                MenuItem estructuras = new MenuItem();

                estructuras.Id = "g_Estructuras";
                estructuras.Label = "Estructuras";
                estructuras.Icon = "grayDots.gif";


                // 3.1 Catálogo de Materiales
                if (context.User.IsInRole("3.1"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i3.1";
                    item.Label = "Catálogo de Materiales";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/Material.aspx");
                    item.Icon = "grayDots.gif";

                    estructuras.Children.Add(item);
                }


                // 3.2 Formulación de Color para SAP
                if (context.User.IsInRole("3.2"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i3.2";
                    item.Label = "Formulación de Color para SAP";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/ListOfMaterial.aspx");
                    item.Icon = "grayDots.gif";

                    estructuras.Children.Add(item);
                }


                // 3.3 Actualizar Lista de Materiales SAP
                if (context.User.IsInRole("3.3"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i3.3";
                    item.Label = "Actualizar Lista de Materiales para SAP";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/UpdateMaterialList.aspx");
                    item.Icon = "grayDots.gif";

                    estructuras.Children.Add(item);
                }


                // 3.3.1 Actualizar Lista de Materiales Datasul
                if (context.User.IsInRole("3.3.1"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i3.3.1";
                    item.Label = "Actualizar Lista de Materiales";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/UpdateMaterialListDta.aspx");
                    item.Icon = "grayDots.gif";

                    estructuras.Children.Add(item);
                }


                // 3.4 Cargar Materiales Fantasmas
                if (context.User.IsInRole("3.4"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i3.4";
                    item.Label = "Cargar Materiales Fantasmas";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/CargarFantasmas.aspx");
                    item.Icon = "grayDots.gif";

                    estructuras.Children.Add(item);
                }


                // 3.4.1 Especificaciones de Empaques de PVC y EPDM
                if (context.User.IsInRole("3.4.1"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i3.4.1";
                    item.Label = "Especificaciones de Empaques de PVC y EPDM";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/EspecificacionesEmpaquesPvc.aspx");
                    item.Icon = "grayDots.gif";

                    estructuras.Children.Add(item);
                }


                // 3.5 Tabla de Pesos
                if (context.User.IsInRole("3.5"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i3.5";
                    item.Label = "Tabla de Pesos";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/Peso.aspx");
                    item.Icon = "grayDots.gif";

                    estructuras.Children.Add(item);
                }


                // 3.6 Formulación de Color
                if (context.User.IsInRole("3.6"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i3.6";
                    item.Label = "Formulación de Color";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/FormColor.aspx");
                    item.Icon = "grayDots.gif";

                    estructuras.Children.Add(item);
                }


                // 3.7 Formulación de Aditivos
                if (context.User.IsInRole("3.7"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i3.7";
                    item.Label = "Formulación de Aditivos";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/FormAditivos.aspx");
                    item.Icon = "grayDots.gif";

                    estructuras.Children.Add(item);
                }


                // 3.8 Formulación de PVC
                if (context.User.IsInRole("3.8"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i3.8";
                    item.Label = "Formulación de PVC";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/FormPVC.aspx");
                    item.Icon = "grayDots.gif";

                    estructuras.Children.Add(item);
                }


                // 3.9 Formulación de Presentaciones
                if (context.User.IsInRole("3.9"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i3.9";
                    item.Label = "Formulación de Presentaciones";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/FormPresentacion.aspx");
                    item.Icon = "grayDots.gif";

                    estructuras.Children.Add(item);
                }


                // 3.10 Formulación de Cintas
                if (context.User.IsInRole("3.10"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i3.10";
                    item.Label = "Formulación de Cintas";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/FormCintas.aspx");
                    item.Icon = "grayDots.gif";

                    estructuras.Children.Add(item);
                }


                // 3.11 Formulación de Temperaturas
                if (context.User.IsInRole("3.11"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i3.11";
                    item.Label = "Formulación de Temperaturas";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/FormTemperatura.aspx");
                    item.Icon = "grayDots.gif";

                    estructuras.Children.Add(item);
                }


                // 3.13 Inventario de Vidrios
                if (context.User.IsInRole("3.13"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i3.13";
                    item.Label = "Inventario de Vidrios";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Structures/invVidrios.aspx");
                    item.Icon = "grayDots.gif";

                    estructuras.Children.Add(item);
                }


                if (estructuras.Children.Count > 0)
                {
                    menu.Add(estructuras);
                }
            }

            // =====================================================
            // 4.0 LOGÍSTICA
            // =====================================================

            if (context.User.IsInRole("4.0"))
            {
                MenuItem logistica = new MenuItem();

                logistica.Id = "g_Logistica";
                logistica.Label = "Logística";
                logistica.Icon = "grayDots.gif";


                // 4.1 Cargar Programa de Producción
                if (context.User.IsInRole("4.1"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i4.1";
                    item.Label = "Cargar Programa de Producción";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Logistics/LoadProduccionPrograma.aspx");
                    item.Icon = "grayDots.gif";

                    logistica.Children.Add(item);
                }


                // 4.2 Consultar Programa de Producción
                if (context.User.IsInRole("4.2"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i4.2";
                    item.Label = "Consultar Programa de Producción";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Logistics/ProgrammaProduction.aspx");
                    item.Icon = "grayDots.gif";

                    logistica.Children.Add(item);
                }


                // 4.3 Generar Órdenes de Trabajo
                if (context.User.IsInRole("4.3"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i4.3";
                    item.Label = "Generar Órdenes de Trabajo";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Logistics/OrdenesTrabajo.aspx");
                    item.Icon = "grayDots.gif";

                    logistica.Children.Add(item);
                }


                // 4.4 Combinar Secuencias
                if (context.User.IsInRole("4.4"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i4.4";
                    item.Label = "Combinar Secuencias";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Logistics/SecuenciasCombinadas.aspx");
                    item.Icon = "grayDots.gif";

                    logistica.Children.Add(item);
                }


                // 4.5 Reactivar Secuencias
                if (context.User.IsInRole("4.5"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i4.5";
                    item.Label = "Reactivar Secuencias";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/Unliberer.aspx");
                    item.Icon = "grayDots.gif";

                    logistica.Children.Add(item);
                }


                // 4.6 Reporte de Ajustes al Programa de Producción
                if (context.User.IsInRole("4.6"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i4.6";
                    item.Label = "Reporte de Ajustes al Programa de Producción";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Reports/ReporteMotivosAjusteProgProd.aspx");
                    item.Icon = "grayDots.gif";

                    logistica.Children.Add(item);
                }


                if (logistica.Children.Count > 0)
                {
                    menu.Add(logistica);
                }
            }

            // =====================================================
            // 5.0 PRODUCCIÓN
            // =====================================================

            if (context.User.IsInRole("5.0"))
            {
                MenuItem produccion = new MenuItem();

                produccion.Id = "g_Produccion";
                produccion.Label = "Producción";
                produccion.Icon = "grayDots.gif";


                // 5.17 Consultar Programa de Producción
                if (context.User.IsInRole("5.17"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i5.17";
                    item.Label = "Consultar Programa de Producción";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/ConsultProgram.aspx");
                    item.Icon = "grayDots.gif";

                    produccion.Children.Add(item);
                }


                // =================================================
                // 5.1 CUARTO DE REACCIÓN
                // =================================================

                if (context.User.IsInRole("5.1"))
                {
                    MenuItem reaccion = new MenuItem();

                    reaccion.Id = "i5.1";
                    reaccion.Label = "Cuarto de Reacción";
                    reaccion.Icon = "grayDots.gif";


                    // 5.1.1 Consultar Órdenes de Trabajo
                    if (context.User.IsInRole("5.1.1"))
                    {
                        MenuItem item = new MenuItem();

                        item.Id = "i5.1.1";
                        item.Label = "Consultar Órdenes de Trabajo";
                        item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/ConsultReactionWO.aspx");
                        item.Icon = "grayDots.gif";

                        reaccion.Children.Add(item);
                    }


                    // 5.1.2 Ajustar Tanque de PMMA
                    if (context.User.IsInRole("5.1.2"))
                    {
                        MenuItem item = new MenuItem();

                        item.Id = "i5.1.2";
                        item.Label = "Ajustar Tanque de PMMA";
                        item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/AdjustTanque.aspx");
                        item.Icon = "grayDots.gif";

                        reaccion.Children.Add(item);
                    }


                    if (reaccion.Children.Count > 0)
                    {
                        produccion.Children.Add(reaccion);
                    }
                }


                // 5.2 Cuarto de Color
                if (context.User.IsInRole("5.2"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i5.2";
                    item.Label = "Cuarto de Color";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/WorkOrder/PartidasColor/ConsultColorWO.aspx");
                    item.Icon = "grayDots.gif";

                    produccion.Children.Add(item);
                }


                // 5.3 Cuarto de Aditivos
                if (context.User.IsInRole("5.3"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i5.3";
                    item.Label = "Cuarto de Aditivos";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/ConsultAditivosWO.aspx");
                    item.Icon = "grayDots.gif";

                    produccion.Children.Add(item);
                }


                // 5.4 Cuarto de PVC
                if (context.User.IsInRole("5.4"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i5.4";
                    item.Label = "Cuarto de PVC";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/ConsultPVCWO.aspx");
                    item.Icon = "grayDots.gif";

                    produccion.Children.Add(item);
                }


                // 5.5 Cuarto de Mezclas
                if (context.User.IsInRole("5.5"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i5.5";
                    item.Label = "Cuarto de Mezclas";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/ConsultMixturesWO.aspx");
                    item.Icon = "grayDots.gif";

                    produccion.Children.Add(item);
                }


                // 5.6 Fase de Armado
                if (context.User.IsInRole("5.6"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i5.6";
                    item.Label = "Fase de Armado";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/ConsultAssembleWO.aspx");
                    item.Icon = "grayDots.gif";

                    produccion.Children.Add(item);
                }


                // 5.7 Fase de Llenado
                if (context.User.IsInRole("5.7"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i5.7";
                    item.Label = "Fase de Llenado";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/ConsultFillingWO.aspx");
                    item.Icon = "grayDots.gif";

                    produccion.Children.Add(item);
                }


                // 5.8 Fase de Curado
                if (context.User.IsInRole("5.8"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i5.8";
                    item.Label = "Fase de Curado";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/ConsultarCured.aspx");
                    item.Icon = "grayDots.gif";

                    produccion.Children.Add(item);
                }


                // 5.9 Fase de Post-Curado
                if (context.User.IsInRole("5.9"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i5.9";
                    item.Label = "Fase de Post-Curado";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/WorkOrder/PartidasPostCurado/Consultar_PostCured.aspx");
                    item.Icon = "grayDots.gif";

                    produccion.Children.Add(item);
                }


                // 5.10 Fase de Preseparación
                if (context.User.IsInRole("5.10"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i5.10";
                    item.Label = "Fase de Preseparación";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/ConsultPreseparationWO.aspx");
                    item.Icon = "grayDots.gif";

                    produccion.Children.Add(item);
                }


                // 5.11 Fase de Separación
                if (context.User.IsInRole("5.11"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i5.11";
                    item.Label = "Fase de Separación";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/ConsultSeparacionWO.aspx");
                    item.Icon = "grayDots.gif";

                    produccion.Children.Add(item);
                }


                // 5.12 Fase de Inspección
                if (context.User.IsInRole("5.12"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i5.12";
                    item.Label = "Fase de Inspección";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/WorkOrder/InspectionPhase/ConsultInspectionWO.aspx");
                    item.Icon = "grayDots.gif";

                    produccion.Children.Add(item);
                }


                // 5.125 Fase de Liberación
                if (context.User.IsInRole("5.125"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i5.125";
                    item.Label = "Fase de Liberación";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/WorkOrder/LiberationPhase/ConsultLiberationWO.aspx");
                    item.Icon = "grayDots.gif";

                    produccion.Children.Add(item);
                }


                // 5.13 Fase de Pendientes / Cuarentena
                if (context.User.IsInRole("5.13"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i5.13";
                    item.Label = "Fase de Pendientes/Cuarentena";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/ConsultQuarantineWO.aspx");
                    item.Icon = "grayDots.gif";

                    produccion.Children.Add(item);
                }


                // 5.14 Entrega de Producto Terminado
                if (context.User.IsInRole("5.14"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i5.14";
                    item.Label = "Entrega de Producto Terminado";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/WorkOrder/PartidasEnvioPT/ConsultEnvioPT.aspx");
                    item.Icon = "grayDots.gif";

                    produccion.Children.Add(item);
                }


                // 5.15 Recepción de Producto Terminado
                if (context.User.IsInRole("5.15"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i5.15";
                    item.Label = "Recepción de Producto Terminado";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/WorkOrder/PartidasRecepcionPT/ConsultRecepcionPT.aspx");
                    item.Icon = "grayDots.gif";

                    produccion.Children.Add(item);
                }


                // 5.16 Interfaz SAP
                if (context.User.IsInRole("5.16"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i5.16";
                    item.Label = "Interfaz SAP";
                    item.Url = VirtualPathUtility.ToAbsolute( "~/Forms/Production/WorkOrder/InterfaceSAP/ConsultInterfaceSAP.aspx");
                    item.Icon = "grayDots.gif";

                    produccion.Children.Add(item);
                }


                if (produccion.Children.Count > 0)
                {
                    menu.Add(produccion);
                }
            }

            // =====================================================
            // 6.0 REPORTES
            // =====================================================

            if (context.User.IsInRole("6.0"))
            {
                MenuItem reportes = new MenuItem();

                reportes.Id = "g_Reportes";
                reportes.Label = "Reportes";
                reportes.Icon = "grayDots.gif";


                // =================================================
                // FASE DE COLOR
                // Roles 6.1 y 6.2
                // =================================================

                if (context.User.IsInRole("6.1") ||
                    context.User.IsInRole("6.2"))
                {
                    MenuItem faseColor = new MenuItem();

                    faseColor.Id = "g_SubRepColor";
                    faseColor.Label = "Fase de Color";
                    faseColor.Icon = "grayDots.gif";


                    // 6.1 Consumos por Secuencia
                    if (context.User.IsInRole("6.1"))
                    {
                        MenuItem item = new MenuItem();

                        item.Id = "i6.1";
                        item.Label = "Consumos por Secuencia";
                        item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/Report.aspx?Title=Color");
                        item.Icon = "grayDots.gif";

                        faseColor.Children.Add(item);
                    }


                    // 6.2 Consumos Globales
                    if (context.User.IsInRole("6.2"))
                    {
                        MenuItem item = new MenuItem();

                        item.Id = "i6.2";
                        item.Label = "Consumos Globales";
                        item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/Report.aspx?Title=Consumo de Color");
                        item.Icon = "grayDots.gif";

                        faseColor.Children.Add(item);
                    }


                    if (faseColor.Children.Count > 0)
                    {
                        reportes.Children.Add(faseColor);
                    }
                }


                // =================================================
                // FASE DE ADITIVOS
                // Roles 6.3 y 6.4
                // =================================================

                if (context.User.IsInRole("6.3") ||
                    context.User.IsInRole("6.4"))
                {
                    MenuItem faseAditivos = new MenuItem();

                    faseAditivos.Id = "g_SubRepAditivos";
                    faseAditivos.Label = "Fase de Aditivos";
                    faseAditivos.Icon = "grayDots.gif";


                    // 6.3 Consumos por Secuencia
                    if (context.User.IsInRole("6.3"))
                    {
                        MenuItem item = new MenuItem();

                        item.Id = "i6.3";
                        item.Label = "Consumos por Secuencia";
                        item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/Report.aspx?Title=Aditivos");
                        item.Icon = "grayDots.gif";

                        faseAditivos.Children.Add(item);
                    }


                    // 6.4 Consumos Globales
                    if (context.User.IsInRole("6.4"))
                    {
                        MenuItem item = new MenuItem();

                        item.Id = "i6.4";
                        item.Label = "Consumos Globales";
                        item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/Report.aspx?Title=Consumo de Aditivos");
                        item.Icon = "grayDots.gif";

                        faseAditivos.Children.Add(item);
                    }


                    if (faseAditivos.Children.Count > 0)
                    {
                        reportes.Children.Add(faseAditivos);
                    }
                }


                // 6.5 Reporte de Producción
                if (context.User.IsInRole("6.5"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i6.5";
                    item.Label = "Reporte de Producción";
                    item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/ProduccionRpt.aspx");
                    item.Icon = "grayDots.gif";

                    reportes.Children.Add(item);
                }


                // 6.6 Reporte de Rastreabilidad
                if (context.User.IsInRole("6.6"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i6.6";
                    item.Label = "Reporte de Rastreabilidad";
                    item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/RastreabilidadRpt.aspx");
                    item.Icon = "grayDots.gif";

                    reportes.Children.Add(item);
                }


                // 6.7 Reporte de Consulta de Mezclas
                if (context.User.IsInRole("6.7"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i6.7";
                    item.Label = "Reporte de Consulta de Mezclas";
                    item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/Report.aspx?Title=Mezclas");
                    item.Icon = "grayDots.gif";

                    reportes.Children.Add(item);
                }


                // 6.8 Reporte de Consumo de Mezclas
                if (context.User.IsInRole("6.8"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i6.8";
                    item.Label = "Reporte de Consumo de Mezclas";
                    item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/Report.aspx?Title=Consumo de Mezclas");
                    item.Icon = "grayDots.gif";

                    reportes.Children.Add(item);
                }


                // 6.9 Reporte de Reacción
                if (context.User.IsInRole("6.9"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i6.9";
                    item.Label = "Reporte de Reacción";
                    item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/Report.aspx?Title=Reacción");
                    item.Icon = "grayDots.gif";

                    reportes.Children.Add(item);
                }


                // 6.10 Reporte de Llenado
                if (context.User.IsInRole("6.10"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i6.10";
                    item.Label = "Reporte de Llenado";
                    item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/Report.aspx?Title=Llenado");
                    item.Icon = "grayDots.gif";

                    reportes.Children.Add(item);
                }


                // 6.11 Reporte de Curado
                if (context.User.IsInRole("6.11"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i6.11";
                    item.Label = "Reporte de Curado";
                    item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/ConsultCuradoReport.aspx?Title=Curado");
                    item.Icon = "grayDots.gif";

                    reportes.Children.Add(item);
                }


                // 6.12 Reporte de Post-Curado
                if (context.User.IsInRole("6.12"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i6.12";
                    item.Label = "Reporte de Post-Curado";
                    item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/ConsultCuradoReport.aspx?Title=PostCurado");
                    item.Icon = "grayDots.gif";

                    reportes.Children.Add(item);
                }


                // 6.13 Reporte de Preseparación
                if (context.User.IsInRole("6.13"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i6.13";
                    item.Label = "Reporte de Preseparación";
                    item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/ConsultCuradoReport.aspx?Title=Preseparación");
                    item.Icon = "grayDots.gif";

                    reportes.Children.Add(item);
                }


                // 6.14 Reporte de Separación
                if (context.User.IsInRole("6.14"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i6.14";
                    item.Label = "Reporte de Separación";
                    item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/Report.aspx?Title=Separación");
                    item.Icon = "grayDots.gif";

                    reportes.Children.Add(item);
                }


                // 6.15 Reporte de Inspección
                if (context.User.IsInRole("6.15"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i6.15";
                    item.Label = "Reporte de Inspección";
                    item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/Report.aspx?Title=Inspección");
                    item.Icon = "grayDots.gif";

                    reportes.Children.Add(item);
                }


                // 6.16 Reporte de Variaciones de Peso
                if (context.User.IsInRole("6.16"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i6.16";
                    item.Label = "Reporte de Variaciones de Peso";
                    item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/Produccion/VariationofWeight.aspx");
                    item.Icon = "grayDots.gif";

                    reportes.Children.Add(item);
                }


                // 6.17 Reporte de UTEC
                if (context.User.IsInRole("6.17"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i6.17";
                    item.Label = "Reporte de UTEC";
                    item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/ProductionRptSAP.aspx");
                    item.Icon = "grayDots.gif";

                    reportes.Children.Add(item);
                }


                // 6.18 Reporte de Consumo PVC
                if (context.User.IsInRole("6.18"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i6.18";
                    item.Label = "Reporte de Consumo PVC";
                    item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/Report.aspx?Title=Materiales PVC");
                    item.Icon = "grayDots.gif";

                    reportes.Children.Add(item);
                }


                // 6.19 Reporte de Materiales
                if (context.User.IsInRole("6.19"))
                {
                    MenuItem item = new MenuItem();

                    item.Id = "i6.19";
                    item.Label = "Reporte de Materiales";
                    item.Url = VirtualPathUtility.ToAbsolute("~/Forms/Reports/top.aspx");
                    item.Icon = "grayDots.gif";

                    reportes.Children.Add(item);
                }


                if (reportes.Children.Count > 0)
                {
                    menu.Add(reportes);
                }
            }


            // =====================================================
            // 7.0 AYUDA
            // =====================================================

            MenuItem ayuda = new MenuItem();

            ayuda.Id = "i7.0";
            ayuda.Label = "Ayuda";
            ayuda.Url = VirtualPathUtility.ToAbsolute("~/SicalNet.chm");
            ayuda.Icon = "grayDots.gif";

            menu.Add(ayuda);


            // =====================================================
            // 8.0 SALIR
            // =====================================================
            MenuItem salir = new MenuItem();

            salir.Id = "i8.0";
            salir.Label = "Salir";
            salir.Url = VirtualPathUtility.ToAbsolute("~/LogOut.aspx");
            salir.Icon = "grayDots.gif";
            salir.Target = "_parent";

            menu.Add(salir);

            
            // *****************

            return menu;
        }
    }
}