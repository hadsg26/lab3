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
        Dim comprobarC As New clases.CambiarPassword
        Dim CodigoRecogido = comprobarC.enviarCodigo(email.Text)
        Dim res As Boolean = comprobarC.comprobar(codigo.Text, CodigoRecogido)
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
        Resultado2.Text = ""
        Dim cambiarC As New clases.CambiarPassword
        If (cambiarC.comprobar(newPass.Text, newPass2.Text)) Then
            If (newPass.Text <> "") Then
                cambiarPass(email.Text, newPass.Text)

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

    End Sub
End Class