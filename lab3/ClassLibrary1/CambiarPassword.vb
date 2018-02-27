Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net.NetworkCredentials
Imports conexiones.accesoDatosSQL


Public Class CambiarPassword

    Function enviarCodigo(ByVal email As String) As String
        Dim codigo As String = "no"
        Dim estado As Byte = 0
        Dim RS As SqlDataReader
        Try
            RS = obtenerCodigo(email)
        Catch ex As Exception
            Return ex.StackTrace & ex.Message
            Exit Function
        End Try
        While RS.Read
            codigo = (RS.Item("numConfir"))
            estado = (RS.Item("confirmado"))
        End While
        RS.Close()
        If (estado <> 0) Then
            Return codigo
        Else
            Return "no"
        End If
    End Function


    Function enviarEmail(ByVal email As String, ByVal codigo As String) As String
        If (codigo <> "no") Then


            Try
                'Direccion de origen 
                Dim from_address As New MailAddress("", "HADS GRUPO 26")
                'Direccion de destino 
                Dim to_address As New MailAddress(email)
                'Password de la cuenta  
                Dim from_pass As String = ""
                'Objeto para el cliente smtp
                Dim smtp As New SmtpClient
            'Host en este caso el servidor de gmail
            smtp.Host = "smtp.ehu.es"
            'Puerto 
            smtp.Port = 587
            'SSL activado para que se manden correos de manera segura 
            smtp.EnableSsl = True
            'No usar los credenciales por defecto ya que si no no funciona
            smtp.UseDefaultCredentials = False
            'Credenciales 
            smtp.Credentials = New System.Net.NetworkCredential(from_address.Address, from_pass)
            'Creamos el mensaje con los  parametros de origen y destino 
            Dim Message As New MailMessage(from_address, to_address)
            'Añadimos el asunto' 
            Message.Subject = "subject"
            'Concatenamos el cuerpo del mensaje a la plantilla 
            Message.Body = "<html><head></head><body> Tu codigo para cambiar la contraseña es el siguiente:" & codigo & "</body></html>"
            'Definimos el cuerpo como html para poder escoger mejor como lo mandamos  
            Message.IsBodyHtml = True
            'Se envia el correo  
            smtp.Send(Message)
        Catch e As Exception
            Return "El email no se ha podido enviar :("
        End Try
            Return "Email enviado. Revisa tu bandeja de entrada"
        Else
            Return "El email no esta en la base datos, no te intentes colar, pillin"
        End If
    End Function

    Function comprobar(ByVal codigo As String, ByVal codigo2 As String) As Boolean
        If (codigo.Equals(codigo2)) Then
            Return True
        Else
            Return False
        End If
    End Function


End Class
