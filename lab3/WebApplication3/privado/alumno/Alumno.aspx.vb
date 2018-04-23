Public Class Alumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            profesores.Text = Application.Contents("numProfesores")
            alumnos.Text = Application.Contents("numAlumnos")
            Dim emailAlumn As String
            For Each emailAlumn In Application.Contents("alumnos")
                alum.Items.Add(emailAlumn)
            Next

            Dim emailProf As String
            For Each emailProf In Application.Contents("profesores")
                prof.Items.Add(emailProf)
            Next
        End If
    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        profesores.Text = Application.Contents("numProfesores")
        alumnos.Text = Application.Contents("numAlumnos")
        alum.Items.Clear()
        prof.Items.Clear()

        Dim emailAlumn As String
        For Each emailAlumn In Application.Contents("alumnos")
            alum.Items.Add(emailAlumn)
        Next

        Dim emailProf As String
        For Each emailProf In Application.Contents("profesores")
            prof.Items.Add(emailProf)
        Next
    End Sub
End Class