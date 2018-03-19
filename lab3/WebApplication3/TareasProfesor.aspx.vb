Public Class TareasProfesor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("InsertarTarea.aspx")
    End Sub

    Protected Sub HyperLink1_Click(sender As Object, e As EventArgs) Handles HyperLink1.Click
        Session.Abandon()
        Response.Redirect("Inicio.aspx")
    End Sub
End Class