<%@ Page Language="c#" 
    Codebehind="Calendar.aspx.cs" 
    AutoEventWireup="false" 
    Inherits="WebApplication1.Calendar" %>

<!DOCTYPE html>
<html>
<head>
    <title>Seleccionar fecha - SicalNet</title>

    <meta charset="utf-8" />

    <!-- Estilo general del nuevo SicalNet -->
    <link rel="stylesheet" type="text/css" href="../../Css/nuevoestilo.css" />

    <script type="text/javascript">

        function ReturnDate() {
            if (window.opener && !window.opener.closed) {
                window.opener.document.forms[0]
                    .elements["<%= Request.QueryString["CtrlName"] %>"].value =
                    "<%= strSelectedDate %>";
            }

            window.close();
        }

        function Close() {
            window.close();
        }

    </script>

    <style type="text/css">

        html,
        body {
            margin: 0;
            padding: 0;
            background: #f4f6f8;
            font-family: "Segoe UI", Arial, Helvetica, sans-serif;
            color: #333333;
        }


        /* =====================================================
           VENTANA PRINCIPAL
           ===================================================== */

        .calendar-page {
            width: 100%;
            min-height: 100vh;
            display: flex;
            justify-content: center;
            align-items: flex-start;
            padding-top: 18px;
            box-sizing: border-box;
        }


        .calendar-container {
            width: 360px;
            background: #ffffff;
            border: 1px solid #d8dee5;
            border-radius: 8px;
            overflow: hidden;

            box-shadow:
                0 4px 12px rgba(0, 0, 0, 0.10);
        }


        /* =====================================================
           ENCABEZADO
           ===================================================== */

        .calendar-header {
            background: #06385d;
            border-top: 4px solid #F15C31;
            color: #ffffff;
            padding: 14px 18px;
            display: flex;
            align-items: center;
        }


        .calendar-header-icon {
            width: 38px;
            height: 38px;
            margin-right: 12px;

            border-radius: 6px;
            background: #ffffff;

            display: flex;
            justify-content: center;
            align-items: center;

            color: #06385d;
            font-size: 22px;
            font-weight: bold;
        }


        .calendar-header-text {
            flex: 1;
        }


        .calendar-title {
            font-size: 18px;
            font-weight: 600;
            line-height: 20px;
        }


        .calendar-subtitle {
            margin-top: 3px;
            font-size: 11px;
            color: #d7e4ec;
        }


        /* =====================================================
           FILTRO MES / AÑO
           ===================================================== */

        .calendar-filters {
            background: #f7f9fa;
            padding: 15px 18px;
            border-bottom: 1px solid #e1e6ea;

            display: flex;
            align-items: flex-end;
            gap: 12px;
        }


        .calendar-filter {
            flex: 1;
        }


        .calendar-filter label {
            display: block;
            font-size: 11px;
            font-weight: 600;
            color: #06385d;
            margin-bottom: 5px;
        }


        .calendar-select {
            width: 100%;
            height: 32px;

            padding: 4px 8px;

            background: #ffffff;
            border: 1px solid #bdc7cf;
            border-radius: 4px;

            font-family: "Segoe UI", Arial;
            font-size: 12px;
            color: #333333;

            box-sizing: border-box;
        }


        .calendar-select:focus {
            border-color: #276187;
            outline: none;

            box-shadow:
                0 0 0 2px rgba(39, 97, 135, 0.12);
        }


        /* =====================================================
           ÁREA DEL CALENDARIO
           ===================================================== */

        .calendar-body {
            padding: 18px;
            text-align: center;
        }


        .calendar-control {
            width: 100% !important;
            border-collapse: separate !important;
            border-spacing: 0 !important;
            border: 1px solid #d8dee5 !important;
            border-radius: 5px;
            overflow: hidden;
        }


        .calendar-control td {
            font-family: "Segoe UI", Arial, sans-serif;
        }


        /* =====================================================
           BOTONES
           ===================================================== */

        .calendar-footer {
            padding: 14px 18px;
            background: #f7f9fa;
            border-top: 1px solid #e1e6ea;

            text-align: center;
        }


        .calendar-button {
            min-width: 110px;
            height: 34px;

            border: none;
            border-radius: 4px;

            cursor: pointer;

            font-family: "Segoe UI", Arial, sans-serif;
            font-size: 12px;
            font-weight: 600;

            margin: 0 4px;

            transition:
                background-color .15s ease,
                box-shadow .15s ease;
        }


        /* Seleccionar */
        .calendar-button-primary {
            background: #F15C31;
            color: #ffffff;
        }


        .calendar-button-primary:hover {
            background: #d94d25;
            box-shadow:
                0 2px 5px rgba(0, 0, 0, 0.18);
        }


        /* Cerrar */
        .calendar-button-secondary {
            background: #5f6b73;
            color: #ffffff;
        }


        .calendar-button-secondary:hover {
            background: #475158;
            box-shadow:
                0 2px 5px rgba(0, 0, 0, 0.18);
        }


        /* =====================================================
           PIE
           ===================================================== */

        .calendar-brand {
            padding: 7px 10px;
            background: #031b2e;
            color: #bdcbd5;

            font-size: 9px;
            text-align: center;
            letter-spacing: .3px;
        }

    </style>

</head>

<body>

<form id="Form1" runat="server">

    <div class="calendar-page">

        <div class="calendar-container">


            <!-- ==============================================
                 ENCABEZADO
                 ============================================== -->

            <div class="calendar-header">

                <div class="calendar-header-icon">
                    &#128197;
                </div>

                <div class="calendar-header-text">

                    <div class="calendar-title">
                        Seleccionar fecha
                    </div>

                    <div class="calendar-subtitle">
                        SicalNet · Calendario
                    </div>

                </div>

            </div>


            <!-- ==============================================
                 MES / AÑO
                 ============================================== -->

            <div class="calendar-filters">

                <div class="calendar-filter">

                    <asp:Label
                        ID="lblMes"
                        runat="server"
                        AssociatedControlID="ddlMonth"
                        Text="MES">
                    </asp:Label>

                    <asp:DropDownList
                        ID="ddlMonth"
                        runat="server"
                        CssClass="calendar-select"
                        AutoPostBack="True"
                        OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                    </asp:DropDownList>

                </div>


                <div class="calendar-filter">

                    <asp:Label
                        ID="lblAnio"
                        runat="server"
                        AssociatedControlID="ddlYear"
                        Text="AÑO">
                    </asp:Label>

                    <asp:DropDownList
                        ID="ddlYear"
                        runat="server"
                        CssClass="calendar-select"
                        AutoPostBack="True"
                        OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                    </asp:DropDownList>

                </div>

            </div>


            <!-- ==============================================
                 CALENDARIO
                 ============================================== -->

            <div class="calendar-body">

                <asp:Calendar
                    ID="cdrControl"
                    runat="server"

                    CssClass="calendar-control"

                    Width="100%"
                    Height="230px"

                    CellPadding="4"
                    CellSpacing="0"

                    BorderWidth="0"

                    Font-Names="Segoe UI"
                    Font-Size="9pt"

                    ForeColor="#333333"
                    BackColor="White"

                    DayNameFormat="FirstLetter"

                    OnSelectionChanged="myCalendar_SelectionChanged">
                    

                    <TodayDayStyle
                        BackColor="#e7f0f6"
                        ForeColor="#06385d"
                        Font-Bold="True" />



                    <SelectorStyle
                        BackColor="#e7edf1"
                        ForeColor="#06385d" />



                    <NextPrevStyle
                        Font-Size="10pt"
                        Font-Bold="True"
                        ForeColor="#FFFFFF"
                        VerticalAlign="Middle" />


                    <DayHeaderStyle
                        Height="28px"
                        BackColor="#e9eef2"
                        ForeColor="#06385d"
                        Font-Bold="True"
                        Font-Size="8pt" />

                    <SelectedDayStyle
                        BackColor="#F15C31"
                        ForeColor="#FFFFFF"
                        Font-Bold="True" />

                    <TitleStyle
                        Height="36px"
                        BackColor="#276187"
                        ForeColor="#FFFFFF"
                        Font-Bold="True"
                        Font-Size="11pt"
                        BorderWidth="0" />


                    <WeekendDayStyle
                        BackColor="#f7f9fa"
                        ForeColor="#475158" />


                    <OtherMonthDayStyle
                        ForeColor="#b0b7bd" />


                </asp:Calendar>

            </div>


            <div class="calendar-footer">

                <asp:Button
                    ID="btnReturnDate"
                    runat="server"
                    Text="✓ Seleccionar"
                    CssClass="calendar-button calendar-button-primary">
                </asp:Button>


                <asp:Button
                    ID="btnCloseWindow"
                    runat="server"
                    Text="Cerrar"
                    CausesValidation="False"
                    UseSubmitBehavior="False"
                    CssClass="calendar-button calendar-button-secondary">
                </asp:Button>

            </div>



            <div class="calendar-brand">
                SICALNET · Sistema Integral de Control
            </div>

        </div>

    </div>

</form>

</body>
</html>