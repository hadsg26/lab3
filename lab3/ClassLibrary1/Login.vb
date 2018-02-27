Imports System.Data.SqlClient
Imports conexiones.accesoDatosSQL

Public Class Login

    Function entrar(ByVal email As String, ByRef pass As String) As String
        Dim res As String
        Dim passDB As String = vbNull
        Dim estado As Byte = 0
        Dim RS As SqlDataReader
        conectar()
        res = "hola"
        Try
            RS = obtenerUsuario(email)
            While (RS.Read)
                passDB = RS.Item("pass")
                estado = RS.Item("confirmado")
            End While
            If (estado <> 0) Then
                If (passDB = pass) Then
                    res = "Ha entrado"
                Else
                    res = "Contraseña incorrecta"
                End If
            Else
                res = "El correo no esta activado en la base de datos, no te intentes colar"
                End If
        Catch ex As Exception
            res = "Ha ocurrido algún fallo, vuelva a intentarlo"
            Return res
        End Try
        Return res
    End Function





End Class
