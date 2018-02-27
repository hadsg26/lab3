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
        Dim registro As New clases.Register
        If registro.compararPass(password.Text, password2.Text) = True Then
            Dim res As Boolean
            Randomize()
            Dim NumConf = CLng(Rnd() * 9000000) + 1000000
            res = registro.registrar(email.Text, nombre.Text, apellidos.Text, NumConf, rol.Text, password.Text)
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

    End Sub

End Class