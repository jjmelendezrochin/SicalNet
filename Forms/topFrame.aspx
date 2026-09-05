<%@ Page Language="c#"
    CodeBehind="topFrame.aspx.cs"
    AutoEventWireup="false"
    Inherits="UserInterface.Forms.topFrame" %>

<!DOCTYPE html>

<html>
<head>
    <title>SICAL - Plastiglas de México</title>

    <meta http-equiv="Content-Type"
        content="text/html; charset=utf-8" />

    <meta http-equiv="refresh"
        content="300" />

    <style type="text/css">
        /* =========================================================
           CONFIGURACIÓN GENERAL
           ========================================================= */

        html,
        body {
            margin: 0;
            padding: 0;
            width: 100%;
            height: 90px;
            overflow: hidden;
        }


        /* =========================================================
           ENCABEZADO PRINCIPAL SICAL
           ========================================================= */

        .sical-header {
            position: relative;
            width: 100%;
            height: 90px;
            display: flex;
            align-items: center;
            box-sizing: border-box;
            padding-left: 22px;
            padding-right: 25px;
            /*
             * Degradado corporativo
            */
            background: linear-gradient( 110deg, #031b2e 0%, #06385d 50%, #075a86 100% );
            /*background-color: #06385d;*/
            /*
             * Línea naranja inferior
             */
            border-bottom: 2px solid #f15a24;
            overflow: hidden;
        }


        /* =========================================================
        EFECTO DECORATIVO DEL FONDO
        ========================================================= */

        .sical-header::after {
            content: "";
            position: absolute;
            right: -120px;
            top: -180px;
            width: 520px;
            height: 420px;
            border-radius: 50%;
            background: radial-gradient( circle, rgba(255,255,255,0.10) 0%, rgba(255,255,255,0.03) 45%, rgba(255,255,255,0) 70% );
            pointer-events: none;
        }


        /* =========================================================
           LOGOTIPO
           ========================================================= */

        .sical-logo {
            position: relative;
            z-index: 2;
            display: block;
            max-height: 68px;
            max-width: 300px;
            width: auto;
            height: auto;
        }


        /* =========================================================
           INFORMACIÓN DEL SISTEMA
           ========================================================= */

        .sical-title {
            position: relative;
            z-index: 2;
            margin-left: 30px;
            padding-left: 25px;
            border-left: 1px solid rgba(255,255,255,0.30);
            font-family: Arial, Helvetica, sans-serif;
            color: #ffffff;
        }


        /* Nombre principal */
        .sical-title-main {
            margin: 0;
            font-size: 21px;
            font-weight: normal;
            letter-spacing: 1px;
        }


        /* Descripción */
        .sical-title-sub {
            margin-top: 4px;
            font-size: 11px;
            color: #c9dbe7;
            letter-spacing: 0.5px;
        }


        /* =========================================================
           TEXTO DEL LADO DERECHO
           ========================================================= */

        .sical-company {
            position: relative;
            z-index: 2;
            margin-left: auto;
            padding-right: 10px;
            text-align: right;
            font-family: Arial, Helvetica, sans-serif;
            color: rgba(255,255,255,0.80);
        }


        .sical-company-name {
            font-size: 12px;
            font-weight: bold;
        }


        .sical-company-system {
            margin-top: 3px;
            font-size: 12px;
            color: #f6a623;            
        }

        .sical-user {
            margin-top: 6px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-weight: normal;
            color: #f6c453;
        }

        .sical-user-name {
            margin-left: 3px;
            font-size: 12px;
            font-weight: bold;
            color: #ffffff;
        }
    </style>

</head>


<body>
    <form id="frmTopFrame" runat="server">
        <div class="sical-header">


            <!-- =====================================================
             NUEVO LOGOTIPO
             ===================================================== -->

            <img
                src="../images/PG_Verzatec.png"
                alt="Plastiglas de México"
                class="sical-logo" />


            <!-- =====================================================
             NOMBRE DEL SISTEMA
             ===================================================== -->

            <div class="sical-title">

                <div class="sical-title-main">
                    SICALNet
                </div>

                <div class="sical-title-sub">
                    Sistema de Control de Producción de Plastiglas-Verzatec
                </div>

            </div>


            <!-- =====================================================
             INFORMACIÓN CORPORATIVA
             ===================================================== -->

            <div class="sical-company">

                <div class="sical-company-name">
                    PLASTIGLAS DE MÉXICO, EMPRESA DE VERZATEC
                </div>

                <div class="sical-company-system">
                    Sistema de Control de Producción
                </div>

                <div class="sical-user">
                    Usuario:
       
                <asp:Label ID="lblUsuario"
                    runat="server"
                    CssClass="sical-user-name">
                </asp:Label>
                </div>

            </div>

        </div>
    </form>
</body>

</html>
