Imports System.Data.SqlClient

Public Class accesoDatosSQL
    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand

    Public Shared Function conectar() As String
        Try
            conexion.ConnectionString = "Server=tcp:hads26.database.windows.net,1433;Initial Catalog=HADS26-TAREAS;Persist Security Info=False;User ID=HADS26@hads26;Password=InigoSergio26;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            conexion.Open()
        Catch ex As Exception
            Return "ERROR DE CONEXION:" + ex.Message
        End Try
        Return "CONEXION OK"
    End Function

    Public Shared Sub cerrarconexion()
        conexion.Close()
    End Sub

    Public Shared Function insertar(ByVal email As String, ByVal nombre As String, ByVal apellidos As String, ByVal numConfir As Integer, ByVal password As String, ByVal rol As String) As String

        Dim st = "insert into usuarios values ('" & email & "','" & nombre & "','" & apellidos & "', " & numConfir & " ,0, '" & password & "' , '" & rol & "')"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteNonQuery()
        Catch ex As Exception
            Return ex.Message
        End Try
        Return (numregs & " registro(s) insertado(s) en la BD ")
    End Function

    Public Shared Function cambiarEstado(ByVal email As String) As String
        Dim st = "update usuarios set confirmado = 1 where email = '" & email & "' "
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteNonQuery()
        Catch ex As Exception
            Return ex.Message
        End Try
        Return (numregs & " registro(s) insertado(s) en la BD ")
    End Function


    Public Shared Function obtenerCodigo(ByVal email As String) As SqlDataReader
        Dim st = "select numconfir, confirmado from usuarios where email = '" & email & "'"
        comando = New SqlCommand(st, conexion)
        Return (comando.ExecuteReader())
    End Function


    ' Protected Sub Contar_Click()(ByVal sender As Object, ByVal e As System.EventArgs) Handles Contar.Click
    'Dim numreg As Integer
    'Try
    '      numreg = contar()
    '  Catch ex As Exception
    '      Label1.Text = ex.Message
    '       Exit Sub
    'End Try
    '    Label3.Text = "La tabla tiene: " & numreg & " nombres"
    ' End Sub

    Public Shared Function cambiarPass(ByVal email As String, ByVal pass As String) As Boolean
        Dim st = "update usuarios set pass ='" & pass & "' where email = '" & email & "' "
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteNonQuery()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Shared Function obtenerUsuario(ByVal email As String) As SqlDataReader
        Dim st = "select confirmado, pass from usuarios where email='" & email & "'"
        comando = New SqlCommand(st, conexion)
        Return (comando.ExecuteReader())
    End Function

End Class
