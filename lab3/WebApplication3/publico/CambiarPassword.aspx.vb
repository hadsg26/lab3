Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Web.Mail
Imports conexiones.accesoDatosSQL


Public Class WebForm3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conectar()
        codigo.Enabled = False
        comprobar.Enabled = False
        newPass.Enabled = False
        newPass2.Enabled = False
        cambiar.Enabled = False


    End Sub

    Protected Sub solicitar_Click(sender As Object, e As EventArgs) Handles solicitar.Click
        Dim cambio As New clases.CambiarPassword
        Dim codigoNum = cambio.enviarCodigo(email.Text)
        Resultado1.Text = cambio.enviarEmail(email.Text, codigoNum)
        If (Resultado1.Text = "Email enviado. Revisa tu bandeja de entrada") Then
            email.Enabled = False
            solicitar.Enabled = False
            codigo.Enabled = True
            comprobar.Enabled = True
        End If
    End Sub

    Protected Sub comprobar_Click(sender As Object, e As EventArgs) Handles comprobar.Click
        Resultado1.Text = ""
        Dim CodigoRecogido = enviarCodigo(email.Text)
        Dim res As Boolean = verificar(codigo.Text, CodigoRecogido)
        If res.Equals(True) Then
            Resultado2.Text = "El codigo es correcto, siga con el proceso."
            codigo.Enabled = False
            comprobar.Enabled = False
            newPass.Enabled = True
            newPass2.Enabled = True
            cambiar.Enabled = True
        Else
            Resultado2.Text = "El codigo introdcido no coincide con el codigo del email"
            comprobar.Enabled = True
            codigo.Enabled = True
        End If
    End Sub

    Protected Sub cambiar_Click(sender As Object, e As EventArgs) Handles cambiar.Click
        Dim [passN] As String
        Using md5Hash As MD5 = MD5.Create()
            passN = newPass.Text
            Resultado2.Text = ""
            Dim cambiarC As New clases.CambiarPassword
            If (cambiarC.comprobar(newPass.Text, newPass2.Text)) Then
                If (newPass.Text <> "") Then
                    cambiarPass(email.Text, GetMdHash(md5Hash, passN))

                    Resultado3.Text = "Ha cambiado correctamente su contraseña"
                    link.Visible = True
                Else
                    Resultado3.Text = "La contraseña es vacia"
                    newPass.Enabled = True
                    newPass2.Enabled = True
                End If
            Else
                Resultado3.Text = "Las contraseñas introducidas no coinciden"
                newPass.Enabled = True
                newPass2.Enabled = True
            End If
        End Using
    End Sub


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
                Dim enlace As String
                'Direccion de origen 
                Dim from_address As New MailAddress("scavia002@ikasle.ehu.eus", "HADS GRUPO 26")
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
                Dim Message As New Net.Mail.MailMessage(from_address, to_address)
                'Añadimos el asunto' 
                Message.Subject = "Bienvenido a la aplicación"
                'Concatenamos el cuerpo del mensaje a la plantilla 
                Message.Body = "<html><head></head><body> Tu codigo para cambiar la contraseña es el siguiente:" & codigo & "</body></html>"
                'Definimos el cuerpo como html para poder escoger mejor como lo mandamos  
                Message.IsBodyHtml = True
                'Se envia el correo  
                smtp.Send(Message)
            Catch e As Exception
                MsgBox(e.Message)
                MsgBox(e.StackTrace)
                Return "El email no se ha podido enviar :("
            End Try
            Return "Email enviado. Revisa tu bandeja de entrada"
        Else
            Return "El email no esta en la base datos, no te intentes colar, pillin"
        End If
    End Function

    Function verificar(ByVal codigo As String, ByVal codigo2 As String) As Boolean
        If (codigo.Equals(codigo2)) Then
            Return True
        Else
            Return False
        End If
    End Function

    Shared Function GetMdHash(ByVal md5hash As MD5, ByVal input As String) As String
        Dim data As Byte() = md5hash.ComputeHash(Encoding.UTF8.GetBytes(input))
        Dim sBuilder As New StringBuilder()
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i
        Return sBuilder.ToString()
    End Function


End Class