<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TareasAlumno.aspx.vb" Inherits="WebApplication3.TareasAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 358px">
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:LinkButton ID="HyperLink1" runat="server" NavigateUrl="~/Inicio.aspx">Cerrar Sesión</asp:LinkButton>
        <div align="center">
            ALUMNO<br />
            GESTIÓN DE TAREAS GENÉRICAS
        </div>
        <div style="height: 271px">

            <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="111px">
            </asp:DropDownList>
            <asp:GridView ID="GridView1" runat="server" OnSorting="SortRecords" AllowSorting="True" Width="353px">
                <columns>
                <asp:commandfield selecttext="Instanciar" showselectbutton="True" ButtonType="Button" />
                </columns>
            </asp:GridView>

        &nbsp;<asp:Label ID="Label1" runat="server" Text="Aproximadamente te quedan"></asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="horas" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="  horas de trabajo para completar las tareas de esta asignatura "></asp:Label>
        </div>
        </form>
</body>
</html>
