' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
' NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.vb en el Explorador de soluciones e inicie la depuración.
Imports System.Data.SqlClient
Imports servicio

Public Class Service1
    Implements IService1

    Public Sub New()
    End Sub

    Public Function GetData(ByVal value As Integer) As String Implements IService1.GetData
        Return String.Format("You entered: {0}", value)
    End Function

    Public Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType Implements IService1.GetDataUsingDataContract
        If composite Is Nothing Then
            Throw New ArgumentNullException("composite")
        End If
        If composite.BoolValue Then
            composite.StringValue &= "Suffix"
        End If
        Return composite
    End Function

    Public Function GetDedicacionMedia(ByVal asignatura As String) As Double Implements IService1.GetDedicacionMedia
        Dim con As New SqlConnection("Server=tcp:hads26.database.windows.net,1433;Initial Catalog=HADS26-TAREAS;Persist Security Info=False;User ID=HADS26@hads26;Password=InigoSergio26;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        con.Open()
        Dim cm As New SqlCommand("Select avg(HReales) from TareasPersonales a inner join TareasGenericas b on (a.codigo = b.codigo ) where codasig = '" & asignatura & "'", con)
        Dim res As Double = cm.ExecuteScalar
        Return 1.2
    End Function

End Class
