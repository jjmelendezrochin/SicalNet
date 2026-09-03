<%@ Page Language="c#" 
    Codebehind="Login.aspx.cs" 
    AutoEventWireup="false" 
    Inherits="UserInterface.Login" 
    ResponseEncoding="utf-8" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>SICAL.Net - Inicio de Sesión</title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="stylesheet" type="text/css" href="Css/login.css" />
</head>

<body>

    <form id="WebForm" method="post" runat="server" autocomplete="off">

        <div class="login-page">

            <!-- Encabezado / Marca -->
            <div class="login-brand">

                <div class="brand-logo">
                    SICAL<span>.Net</span>
                </div>

                <div class="brand-subtitle">
                    Sistema de Control de Producción Plastiglas-Verzatec</div>

            </div>


            <!-- Tarjeta de Login -->
            <div class="login-card">

                <div class="login-card-header">

                    <div class="login-icon">
                        &#128100;
                    </div>

                    <h1>Inicio de sesión</h1>

                    <p>
                        Ingrese sus credenciales para acceder al sistema
                    </p>

                </div>


                <div class="login-card-body">

                    <!-- Usuario -->
                    <div class="login-field">

                        <label for="txtLogin">
                            Nombre de usuario
                        </label>

                        <div class="input-container">

                            <span class="input-icon">
                                &#128100;
                            </span>

                            <asp:TextBox
                                ID="txtLogin"
                                runat="server"
                                CssClass="login-input"
                                MaxLength="20">
                            </asp:TextBox>

                        </div>

                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2"
                            runat="server"
                            ControlToValidate="txtLogin"
                            CssClass="validation-message"
                            Display="Dynamic"
                            ErrorMessage="Ingrese su nombre de usuario">
                        </asp:RequiredFieldValidator>

                    </div>


                    <!-- Contraseña -->
                    <div class="login-field">

                        <label for="txtPassword">
                            Contraseña
                        </label>

                        <div class="input-container">

                            <span class="input-icon">
                                &#128274;
                            </span>

                            <asp:TextBox
                                ID="txtPassword"
                                runat="server"
                                CssClass="login-input"
                                MaxLength="16"
                                TextMode="Password">
                            </asp:TextBox>

                        </div>

                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1"
                            runat="server"
                            ControlToValidate="txtPassword"
                            CssClass="validation-message"
                            Display="Dynamic"
                            ErrorMessage="Ingrese su contraseña">
                        </asp:RequiredFieldValidator>

                    </div>


                    <!-- Mensaje de Error -->
                    <asp:Label
                        ID="lblErrorMessage"
                        runat="server"
                        CssClass="login-error"
                        Visible="False">
                    </asp:Label>


                    <!-- Botón -->
                    <div class="login-button-container">

                        <asp:Button
                            ID="cmdSignIn"
                            runat="server"
                            CssClass="login-button"
                            Text="Iniciar sesión"
                            OnClick="cmdSignIn_Click1">
                        </asp:Button>

                    </div>


                    <!-- Versión -->
                    <div class="login-version">

                        Versión

                        <asp:TextBox
                            ID="txtVersion"
                            runat="server"
                            CssClass="version-value"
                            MaxLength="16"
                            Enabled="False">
                        </asp:TextBox>

                    </div>

                </div>

            </div>


            <!-- Pie -->
            <div class="login-footer">

                <span>SICAL.Net</span>

                <span class="footer-separator">•</span>

                Sistema Integral de Control

            </div>

        </div>

    </form>

</body>
</html>