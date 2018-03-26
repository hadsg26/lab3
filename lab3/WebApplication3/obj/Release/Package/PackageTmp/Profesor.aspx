<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="WebApplication3.Profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 188px">
            <asp:Menu ID="Menu1" runat="server">
                <Items>
                    <asp:MenuItem Text="Asignaturas" Value="Asignaturas"></asp:MenuItem>
                    <asp:MenuItem Text="Tareas" Value="Tareas" NavigateUrl="TareasProfesor.aspx"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/ImportarTareas.aspx" Text="Importar v. XMLDocument" Value="Importar v. XMLDocument"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/ExportarTareas.aspx" Text="Exportar" Value="Exportar"></asp:MenuItem>
                </Items>
            </asp:Menu>
        </div>
    </form>
</body>
</html>
