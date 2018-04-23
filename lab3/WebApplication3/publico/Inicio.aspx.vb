Imports System.Data.SqlClient
Imports System.Security.Cryptography
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
        resultado.Text = acceder(email.Text, password.Text)
        If ((resultado.Text).Equals("SIA")) Then
            Dim emailsAlumnos(50) As String
            Application.Contents("numAlumnos") = Application.Contents("numAlumnos") + 1
            Application.Contents("alumnos").add(email.Text)
            System.Web.Security.FormsAuthentication.SetAuthCookie("alumno", False)
            Session("email") = email.Text
            Session("rol") = "alumno"
            Response.Redirect("../privado/alumno/Alumno.aspx")
        ElseIf (resultado.Text.Equals("SIP")) Then
            Application.Contents("profesores").add(email.Text)
            Application.Contents("numProfesores") = Application.Contents("numProfesores") + 1
            Session("email") = email.Text
            Session("rol") = "profesor"

            If (email.Text = "vadillo@ehu.es") Then
                System.Web.Security.FormsAuthentication.SetAuthCookie("vadillo", False)
                Response.Redirect("../privado/profesor/Profesor.aspx")
            ElseIf (email.Text = "admin@ehu.es") Then
                System.Web.Security.FormsAuthentication.SetAuthCookie("admin", False)
                Response.Redirect("../privado/admin/Banear.aspx")
            Else
                System.Web.Security.FormsAuthentication.SetAuthCookie("profesor", False)
                Response.Redirect("../privado/profesor/Profesor.aspx")
            End If
        End If
    End Sub

    Function acceder(ByVal email As String, ByRef pass As String) As String
        Using md5Hash As MD5 = MD5.Create()
            Dim [pass1] As String = pass
            Dim res As String
            Dim passDB As String = vbNull
            Dim estado As Byte = 0
            Dim rol As String = vbNull
            Dim RS As SqlDataReader
            conectar()
            res = "hola"
            Try
                RS = obtenerUsuario(email)
                While (RS.Read)
                    passDB = RS.Item("pass")
                    estado = RS.Item("confirmado")
                    rol = RS.Item("tipo")
                End While
                RS.Close()
                If (estado <> 0) Then
                    If (VerifyMd5Hash(md5Hash, pass1, passDB)) Then
                        If (rol.Equals("Alumno")) Then

                            res = "SIA"
                        Else
                            res = "SIP"
                        End If
                    Else
                        res = "Contraseña incorrecta"
                    End If
                Else
                    res = "El correo no esta activado en la base de datos, no te intentes colar"
                End If
            Catch ex As Exception
                res = "Ha ocurrido algún fallo, vuelva a intentarlo"
                Return res
            End Try
            Return res
        End Using
    End Function


    Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))
        Dim sBuilder As New StringBuilder()
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i
        Return sBuilder.ToString()
    End Function

    Shared Function VerifyMd5Hash(ByVal md5Hash As MD5, ByVal input As String, ByVal hash As String) As Boolean
        Dim hashOfInput As String = GetMd5Hash(md5Hash, input)
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase
        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If
    End Function

End Class