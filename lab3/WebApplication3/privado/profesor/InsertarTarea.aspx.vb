Imports System.Data.SqlClient
Imports conexiones.accesoDatosSQL


Public Class InsertarTarea
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim da As SqlDataAdapter = New SqlDataAdapter
        da = obtenerTareasAsignatura(asignatura.SelectedValue)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "tabla")
        Dim comando As New SqlCommandBuilder(da)
        Dim dRow As DataRow = ds.Tables("tabla").NewRow()
        dRow("codigo") = codigo.Text
        dRow("descripcion") = descripcion.Text
        dRow("codasig") = asignatura.SelectedValue
        dRow("Hestimadas") = hestimadas.Text
        dRow("TipoTarea") = tipotarea.SelectedValue
        Try
            ds.Tables("tabla").Rows.Add(dRow)
            da.Update(ds, "tabla")
            ds.AcceptChanges()
            resultado.Text = "Se ha podido insertar la nueva tarea"
        Catch ex As Exception
            resultado.Text = "No se ha podido insertar la nueva tarea"
        End Try




    End Sub
End Class