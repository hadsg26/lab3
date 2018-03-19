<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InsertarTarea.aspx.vb" Inherits="WebApplication3.InsertarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div align ="center">
                Profesor </br> Gestion de tareas genericas
            </div>
            <div style="height: 345px">

                <asp:Label ID="Label1" runat="server" Text="Codigo"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="codigo" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="descripcion" runat="server" Height="58px" Width="534px"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Asignatura"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="asignatura" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS26-TAREASConnectionString %>" SelectCommand="Select codigoasig from GruposClase inner join ProfesoresGrupo on GruposClase.codigo = ProfesoresGrupo.codigogrupo  where email = @email">
                    <SelectParameters>
                        <asp:SessionParameter Name="email" SessionField="email" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <asp:Label ID="Label4" runat="server" Text="HEstimadas"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="hestimadas" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label5" runat="server" Text="Tipo Tarea"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="tipotarea" runat="server" DataSourceID="SqlDataSource2" DataTextField="TipoTarea" DataValueField="TipoTarea">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS26-TAREASConnectionString %>" SelectCommand="select distinct TipoTarea from tareasgenericas "></asp:SqlDataSource>
                <br />
                <asp:Button ID="Button1" runat="server" Text="Añadir Tarea" />

                <br />
                <asp:Label ID="resultado" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TareasProfesor.aspx">Ver tareas</asp:HyperLink>

            </div>
        </div>
    </form>
</body>
</html>
