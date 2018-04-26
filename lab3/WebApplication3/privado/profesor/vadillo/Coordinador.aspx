<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Coordinador.aspx.vb" Inherits="WebApplication3.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig" AutoPostBack="True">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS26-TAREASConnectionString %>" SelectCommand="Select codigoasig from GruposClase inner join ProfesoresGrupo on GruposClase.codigo = ProfesoresGrupo.codigogrupo  where email = @email">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            Horas dedicadas de media:
            <asp:Label ID="horas" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
