Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.IO
Imports conexiones.accesoDatosSQL


Public Class ExportarTareas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub asignaturas_DataBound(sender As Object, e As EventArgs) Handles asignaturas.DataBound
        Try
            Session("adapter") = obtenerTareas()
            Dim cm As New SqlCommandBuilder(Session("adapter"))
            Dim ds As DataSet = New DataSet
            Session("adapter").Fill(ds, "Tarea")
            ds.DataSetName = "Tareas"
            Dim dt As DataTable = New DataTable
            dt = ds.Tables("Tarea")
            dt.Columns("Codigo").ColumnMapping = MappingType.Attribute
            dt.Columns("CodAsig").ColumnMapping = MappingType.Hidden
            Session("tabla") = dt
            Session("dataset") = ds
            Dim dv As DataView = New DataView(dt)
            dv.RowFilter = "CodAsig='" & asignaturas.SelectedValue & "'"
            Session("dataview") = dv
            GridView1.DataSource = dv
            GridView1.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub asignaturas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles asignaturas.SelectedIndexChanged
        Dim dv As DataView = New DataView(Session("tabla"))
        dv.RowFilter = "CodAsig='" & asignaturas.SelectedValue & "'"
        Session("dataview") = dv
        GridView1.DataSource = dv
        GridView1.DataBind()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ds As DataSet = New DataSet
        ds.DataSetName = "Tareas"
        Dim dv As DataView = Session("dataview")
        Dim dt As DataTable = dv.ToTable
        ds.Tables.Add(dt)
        dt.WriteXml(Server.MapPath(asignaturas.SelectedValue + ".xml"))
        GridView1.DataSource = Session("dataview")
        GridView1.DataBind()
    End Sub
End Class