<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CambiarPassword.aspx.vb" Inherits="WebApplication3.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 316px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Cambiar contraseña"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="email" EnableTheming="True" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" ErrorMessage="No es un correo valido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <asp:Button ID="solicitar" runat="server" Text="Solicitar cambio" />
            <br />
            <asp:Label ID="Resultado1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Codigo "></asp:Label>
            <asp:TextBox ID="codigo" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="comprobar" runat="server" Text="Comprobar Codigo" />
            <br />
            <asp:Label ID="Resultado2" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Nueva Contraseña"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="newPass" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="newPass" ErrorMessage="Contraseña no valida. al menos  6 caracteres, con 1 numero y una letra" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,50})$"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Repite Nueva Contraseña"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="newPass2" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="newPass2" ErrorMessage="Contraseña no valida. al menos  6 caracteres, con 1 numero y una letra" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,50})$"></asp:RegularExpressionValidator>
            <br />
            <asp:Button ID="cambiar" runat="server" Text="Cambiar Constraseña" />
            <br />
            <asp:Label ID="Resultado3" runat="server"></asp:Label>
            <br />
            <asp:HyperLink ID="link" runat="server" NavigateUrl="~/Inicio.aspx" Visible="False">Para ir a la pantalla de inicio pulse aqui</asp:HyperLink>
            <br />
        </div>
    </form>
</body>
</html>
