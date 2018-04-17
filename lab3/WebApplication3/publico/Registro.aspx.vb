Imports System.Security.Cryptography
Imports conexiones.accesoDatosSQL
Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conectar()
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        cerrarconexion()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Using md5Hash As MD5 = MD5.Create()

            Dim registro As New clases.Register
            If registro.compararPass(password.Text, password2.Text) = True Then
                Dim res As Boolean = False
                Randomize()
                Dim NumConf = CLng(Rnd() * 9000000) + 1000000

                Dim [pass1] As String = password.Text
                Dim hash As String = GetMdHash(md5Hash, pass1)
                res = registro.registrar(email.Text, nombre.Text, apellidos.Text, NumConf, rol.Text, hash)
                MsgBox(hash)
                If (res) Then
                    mensaje1.Text = "Estas registrado, ahora debes confirmar tu email. Revisa tu bandeja"
                    HyperLink1.NavigateUrl = "https://hads1826.azurewebsites.net/Confirmacion.aspx?mbr=" & email.Text & "&numConf=" & NumConf
                    HyperLink1.Visible = True
                Else
                    mensaje1.Text = "No te has podido registrar, mas suerte la proxima vez"
                End If
            Else
                mensaje1.Text = "Las contraseñas introducidas no coinciden, fijate mas."

            End If
        End Using

    End Sub

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