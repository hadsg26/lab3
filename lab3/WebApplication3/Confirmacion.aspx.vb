Imports System.Data.SqlClient
Imports conexiones.accesoDatosSQL

Public Class WebForm4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conectar()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim email As String = Request.QueryString("mbr")
        Dim codigoDeUrl As String = Request.QueryString("numConf")
        Dim codigo As String = ""
        Dim RS As SqlDataReader
        Try
            RS = obtenerCodigo(email)
        Catch ex As Exception
            Exit Sub
        End Try
        While RS.Read
            codigo = (RS.Item("numConfir"))
        End While
        RS.Close()
        If (codigoDeUrl.Equals(codigo)) Then
            cambiarEstado(email)
            Response.Redirect("Inicio.aspx")
        Else

        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        cerrarconexion()
    End Sub
End Class