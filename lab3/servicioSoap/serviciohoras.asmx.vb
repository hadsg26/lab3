Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class serviciohoras
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function GetDedicacionMedia(ByVal asignatura As String) As Double
        Dim con As New SqlConnection("Server=tcp:hads26.database.windows.net,1433;Initial Catalog=HADS26-TAREAS;Persist Security Info=False;User ID=HADS26@hads26;Password=InigoSergio26;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        con.Open()
        Dim cm As New SqlCommand("SELECT AVG(HREALES) FROM ESTUDIANTESTAREAS A INNER JOIN TAREASGENERICAS B ON (A.CODTAREA = B.CODIGO) WHERE CODASIG = '" & asignatura & "'", con)
        Dim res As Double = cm.ExecuteScalar
        Return res
    End Function

End Class