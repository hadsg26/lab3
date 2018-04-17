Imports conexiones.accesoDatosSQL

Public Class WebForm5
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim res As Boolean = False
        res = banear(email.Text)
        If (res) Then
            resultado.text = "Ha baneado al usuario. Ya no tendrá acceso a la página"
        Else
            resultado.text = "No se ha podido banear a ese usuario"
        End If
    End Sub

    Protected Sub HyperLink1_Click(sender As Object, e As EventArgs) Handles HyperLink1.Click
        Session.Abandon()
        System.Web.Security.FormsAuthentication.SignOut()
        Response.Redirect("../../publico/Inicio.aspx")
    End Sub
End Class