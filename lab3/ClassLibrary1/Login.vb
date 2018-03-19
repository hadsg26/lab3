Imports System.Collections.Specialized.BitVector32
Imports System.Data.SqlClient
Imports conexiones.accesoDatosSQL

Public Class Login

    Function entrar(ByVal email As String, ByRef pass As String) As String
        Dim res As String
        Dim passDB As String = vbNull
        Dim estado As Byte = 0
        Dim rol As String = vbNull
        Dim RS As SqlDataReader
        conectar()
        res = "hola"
        Try
            RS = obtenerUsuario(email)
            While (RS.Read)
                passDB = RS.Item("pass")
                estado = RS.Item("confirmado")
                rol = RS.Item("tipo")
            End While
            RS.Close()

            If (estado <> 0) Then
                If (passDB = pass) Then

                    If (rol.Equals("Alumno")) Then
                        res = "SIA"
                    Else
                        res = "SIP"
                    End If
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
