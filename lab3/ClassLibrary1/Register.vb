Imports System.Net.Mail
Imports System.Net.NetworkCredentials
Imports conexiones.accesoDatosSQL

Public Class Register
    Function compararPass(ByVal pass1 As String, ByVal pass2 As String) As Boolean
        If pass1.Equals(pass2) Then
            compararPass = True
        Else
            compararPass = False
        End If
    End Function

    Function registrar(ByVal email As String, ByVal nombre As String, ByVal apellidos As String, ByVal NumConf As Integer, ByVal rol As String, ByVal pass As String) As Boolean
        If enviareMail(email, NumConf) = True Then
            insertar(email, nombre, apellidos, NumConf, rol, pass)
        End If
        Return True
    End Function




    Function enviareMail(email As String, numConf As Integer) As Boolean
        Try
            Dim enlace As String
            enlace = "<a href = 'https://hads1826.azurewebsites.net/Confirmacion.aspx?mbr=" & email & "&numConf=" & numConf & "' > este link</a>"
            'Direccion de origen 
            Dim from_address As New MailAddress("@ikasle.ehu.eus", "HADS GRUPO 26")
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
            Message.Subject = "Bienvenido a la aplicación"
            'Concatenamos el cuerpo del mensaje a la plantilla 
            Message.Body = "<html><head></head><body>" + "Para dar de alta tu usuario, accede a " & enlace & "</body></html>"
            'Definimos el cuerpo como html para poder escoger mejor como lo mandamos  
            Message.IsBodyHtml = True
            'Se envia el correo  
            smtp.Send(Message)
        Catch e As Exception
            Return False
        End Try
        Return True
    End Function
End Class
