<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="TestMenu.aspx.cs"
    Inherits="UserInterface.Forms.TestMenu"
    ResponseEncoding="utf-8" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Prueba Menú SICAL</title>
    <meta charset="utf-8" />
    <link rel="stylesheet"
          type="text/css"
          href="/SicalNet/Css/sical-menu.css" />
</head>

<body>
    <form id="form1" runat="server">
        <div id="sicalMenu"></div>
        <br />
        <br />
    </form>


        <script type="text/javascript"
                src="/SicalNet/Scripts/sical-menu.js"></script>

        <script type="text/javascript">
            document.addEventListener(
                "DOMContentLoaded",
                function () {
                    SicalMenu.init("sicalMenu");
                }
            );

        </script>
</body>
</html>