<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="WebApplication3.Profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 333px">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Menu ID="Menu1" runat="server">
                <Items>
                    <asp:MenuItem Text="Asignaturas" Value="Asignaturas"></asp:MenuItem>
                    <asp:MenuItem Text="Tareas" Value="Tareas" NavigateUrl="TareasProfesor.aspx"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/privado/profesor/vadillo/ImportarTareas.aspx" Text="Importar v. XMLDocument" Value="Importar v. XMLDocument"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/privado/profesor/vadillo/ExportarTareas.aspx" Text="Exportar" Value="Exportar"></asp:MenuItem>
                </Items>
            </asp:Menu>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="2000">
                    </asp:Timer>
                    <br />
                    Alumnos Logueados:
                    <asp:Label ID="alum" runat="server"></asp:Label>
                    &nbsp; Profesores Logueados
                    <asp:Label ID="pro" runat="server"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:ListBox ID="ListBox4" runat="server"></asp:ListBox>
                    <asp:ListBox ID="ListBox5" runat="server"></asp:ListBox>
                    <br />
                    <br />
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
