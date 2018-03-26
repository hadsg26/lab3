<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ImportarTareas.aspx.vb" Inherits="WebApplication3.ImportarTareas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 288px">
    <form id="form1" runat="server">
        <div align="center">
        Profesor <br />
            Importar Tareas Genericas
        </div>
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Seleccionar Asignatura a Importar"></asp:Label>
        <br />
        <asp:DropDownList ID="asignaturas" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig" Height="17px" Width="134px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS26-TAREASConnectionString %>" SelectCommand="Select codigoasig from GruposClase inner join ProfesoresGrupo on GruposClase.codigo = ProfesoresGrupo.codigogrupo  where email = @email">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="email" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Label ID="resultado" runat="server" Text="Lista de tareas de la asignatura seleccionada"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Importar (XMLD)" />
        <asp:Xml ID="Xml1" runat="server"></asp:Xml>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Profesor.aspx">Menu Profesor</asp:HyperLink>
        <br />
        <br />
    </form>
</body>
</html>
