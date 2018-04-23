Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Application.Contents("numProfresores") = 0
        Application.Contents("numAlumnos") = 0
        Dim emailsProfesores As New List(Of String)
        Dim emailsAlumnos As New List(Of String)

        Application.Contents("profesores") = emailsProfesores
        Application.Contents("alumnos") = emailsAlumnos
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al comienzo de cada solicitud
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al intentar autenticar el uso
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando se produce un error
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        Application.Lock()
        If (Session("rol") = "profesor") Then
            Application.Contents("numProfesores") = Application.Contents("numProfesores") - 1
            Application.Contents("profesores").Remove(Session("email"))
        ElseIf Session("rol") = "alumno" Then
            Application.Contents("alumnos").Remove(Session("email"))
            Application.Contents("numAlumnos") = Application.Contents("numAlumnos") - 1
        End If
        Application.UnLock()
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la aplicación
    End Sub

End Class