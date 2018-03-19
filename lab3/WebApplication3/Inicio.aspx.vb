Imports conexiones.accesoDatosSQL
Public Class WebForm2
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = conectar()
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cerrarconexion()
    End Sub

    Protected Sub entrar_Click(sender As Object, e As EventArgs) Handles entrar.Click
        Dim login As New clases.Login
        resultado.Text = login.entrar(email.Text, password.Text)
        If ((resultado.Text).Equals("SIA")) Then
            Session("email") = email.Text
            Response.Redirect("Alumno.aspx")
        ElseIf (resultado.Text.Equals("SIP")) Then
            Session("email") = email.Text
            Response.Redirect("Profesor.aspx")
        End If
    End Sub

End Class