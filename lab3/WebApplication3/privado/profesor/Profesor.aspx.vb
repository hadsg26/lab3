Public Class Profesor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            pro.Text = Application.Contents("numProfesores")
            alum.Text = Application.Contents("numAlumnos")
            Dim emailAlumn As String
            For Each emailAlumn In Application.Contents("alumnos")
                ListBox4.Items.Add(emailAlumn)
            Next

            Dim emailProf As String
            For Each emailProf In Application.Contents("profesores")
                ListBox5.Items.Add(emailProf)
            Next
        End If

    End Sub

    Protected Sub Menu1_MenuItemClick(sender As Object, e As MenuEventArgs)

    End Sub

    Protected Sub Menu1_MenuItemClick1(sender As Object, e As MenuEventArgs)

    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        pro.Text = Application.Contents("numProfesores")
        alum.Text = Application.Contents("numAlumnos")
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()

        Dim emailAlumn As String
        For Each emailAlumn In Application.Contents("alumnos")
            ListBox4.Items.Add(emailAlumn)
        Next

        Dim emailProf As String
        For Each emailProf In Application.Contents("profesores")
            ListBox5.Items.Add(emailProf)
        Next
    End Sub

    Protected Sub ListBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox4.SelectedIndexChanged

    End Sub
End Class