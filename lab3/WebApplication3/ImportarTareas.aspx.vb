Imports System.Data.SqlClient
Imports System.Xml
Imports conexiones.accesoDatosSQL


Public Class ImportarTareas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub



    Protected Sub asignaturas_DataBound(sender As Object, e As EventArgs) Handles asignaturas.DataBound
        Try
            Dim xd As New XmlDocument
            xd.Load(Server.MapPath(asignaturas.SelectedValue + ".xml"))
            Xml1.DocumentSource = Server.MapPath(asignaturas.SelectedValue + ".xml")
            Xml1.TransformSource = Server.MapPath("XSLTFile.xsl")
        Catch ex As Exception
            resultado.Text = "Ha habido un problema o no hay tareas que importar"
        End Try

    End Sub

    Protected Sub asignaturas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles asignaturas.SelectedIndexChanged
        Try
            Dim xd As New XmlDocument
            xd.Load(Server.MapPath(asignaturas.SelectedValue + ".xml"))
            Xml1.DocumentSource = Server.MapPath(asignaturas.SelectedValue + ".xml")
            Xml1.TransformSource = Server.MapPath("XSLTFile.xsl")
            resultado.Text = ""
        Catch ex As Exception
            resultado.Text = "Ha habido un problema o no hay tareas que importar"
        End Try

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim xd As New XmlDocument
            xd.Load(Server.MapPath(asignaturas.SelectedValue + ".xml"))
            Session("adapter") = obtenerTareasAsignatura(asignaturas.SelectedValue)
            Dim cm As New SqlCommandBuilder(Session("adapter"))
            Dim ds As DataSet = New DataSet
            Session("adapter").Fill(ds, "tabla")
            Dim dt As DataTable = New DataTable
            dt = ds.Tables("tabla")
            Dim Tareas As XmlNodeList
            Tareas = xd.GetElementsByTagName("tarea")
            For i = 0 To Tareas.Count - 1
                Dim dRow As DataRow = dt.NewRow()
                dRow("Codigo") = Tareas(i).Attributes(0)
                dRow("Descripcion") = Tareas(i).ChildNodes(0).ChildNodes(0).Value
                dRow("HEstimadas") = Tareas(i).ChildNodes(1).ChildNodes(0).Value
                dRow("Explotacion") = Tareas(i).ChildNodes(2).ChildNodes(0).Value
                dRow("TipoTarea") = Tareas(i).ChildNodes(3).ChildNodes(0).Value
                dt.Rows.Add(dRow)
            Next
            Session("adapter").Update(ds, "tabla")
            ds.AcceptChanges()
            resultado.Text = "Se ha importado correctamente"
        Catch exp As System.Data.SqlClient.SqlException
            resultado.Text = "Las tareas que intentas añadir ya están añadidas"
        Catch ex As Exception
            resultado.Text = "Ha ocurrido un error"
        End Try
    End Sub

End Class