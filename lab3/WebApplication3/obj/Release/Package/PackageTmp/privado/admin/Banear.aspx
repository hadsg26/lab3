<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Banear.aspx.vb" Inherits="WebApplication3.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 183px">
            <asp:LinkButton ID="HyperLink1" runat="server" NavigateUrl="~/Inicio.aspx">Cerrar Sesión</asp:LinkButton>
            <div align="center">
                <p>Admin </br> Banear de forma permanente a un usuario
                </p>
            </div>
            <asp:Label ID="Label1" runat="server" Text="Introduce el email del usuario que desee banear"></asp:Label>
            <br />
            <asp:TextBox ID="email" runat="server" Width="272px"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Banear" Width="283px" />
            <br />
            <asp:Label ID="resultado" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
