<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ImportarEnDS.aspx.vb" Inherits="WebApplication3.ImportarEnDS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">OPCIONAL</div>
        <div>

            <asp:Label ID="Label1" runat="server" Text="Elige una asignatura:"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS26-TAREASConnectionString %>" SelectCommand="Select codigoasig from GruposClase inner join ProfesoresGrupo on GruposClase.codigo = ProfesoresGrupo.codigogrupo  where email = @email">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:Xml ID="Xml1" runat="server"></asp:Xml>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Importar" />
            <br />

        </div>
    </form>
</body>
</html>
