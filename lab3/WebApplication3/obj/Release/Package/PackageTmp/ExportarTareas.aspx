<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExportarTareas.aspx.vb" Inherits="WebApplication3.ExportarTareas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
        Profesor <br />
            Exportar Tareas Genericas
        </div>
        <div>

            <asp:Label ID="Label1" runat="server" Text="Seleccionar asignatura a exportar"></asp:Label>

        </div>
        <asp:DropDownList ID="asignaturas" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig" Height="16px" Width="185px" AutoPostBack="True">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS26-TAREASConnectionString %>" SelectCommand="Select codigoasig from GruposClase inner join ProfesoresGrupo on GruposClase.codigo = ProfesoresGrupo.codigogrupo  where email = @email">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="email" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" Width="113px" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Tareas exportadas en el fichero: "></asp:Label>
&nbsp;
        <br />
        <asp:Label ID="fichero" runat="server"></asp:Label>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Profesor.aspx">Menu Profesor</asp:HyperLink>
    </form>
</body>
</html>
