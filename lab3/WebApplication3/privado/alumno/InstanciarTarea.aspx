<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InstanciarTarea.aspx.vb" Inherits="WebApplication3.InstanciarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div align="center">
                <p>Alumno </br> Instanciar tarea generica</p>
            </div>

        </div>
        <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="usuario" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Tarea"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tarea" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="H Estimadas"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="hestimada" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="H Reales"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="hreales" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="hreales" ErrorMessage="*"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="hreales" ErrorMessage="Tiene que ser un número " ValidationExpression="\d*"></asp:RegularExpressionValidator>
        <br />
        <asp:Button ID="crearTarea" runat="server" Text="Crear Tarea" />
        <div>


            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>


            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TareasAlumno.aspx">Pagina anterior</asp:HyperLink>
&nbsp;</div>
    </form>
</body>
</html>
