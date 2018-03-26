Imports System.Data.SqlClient
Imports conexiones.accesoDatosSQL



Public Class InstanciarTarea
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            usuario.Text = Session("email")
            tarea.Text = Request.QueryString("codigo")
            usuario.Enabled = False
            tarea.Enabled = False
            Dim Hestimadas As Integer = obtenerHorasEstimadas(Request.QueryString("codigo"))
            hestimada.Text = Hestimadas.ToString
            hestimada.Enabled = False
            Session("adapter") = obtenerTareasEstudiante(Session("email"))
            Dim cm As New SqlCommandBuilder(Session("Adapter"))
            Dim ds As DataSet = New DataSet()
            Session("adapter").Fill(ds, "tabla")
            Session("dataadapterInstanciar") = obtenerTareasEstudiante(Session("email"))
            Dim dv As DataView
            dv = New DataView(ds.Tables("tabla"))
            GridView1.DataSource = dv
            GridView1.DataBind()
        End If


    End Sub

    Protected Sub crearTarea_Click(sender As Object, e As EventArgs) Handles crearTarea.Click
        If (posibilidadDeInstanciar(Request.QueryString("codigo"))) Then

            Dim da As SqlDataAdapter = Session("dataadapterInstanciar")
            Dim cm As New SqlCommandBuilder(da)
            Dim ds As DataSet = New DataSet
            da.Fill(ds, "tabla")
            Dim dt As DataTable = ds.Tables("tabla")
            Dim dRow As DataRow = dt.NewRow()
            dRow("email") = Session("email")
            dRow("codTarea") = Request.QueryString("codigo")
            dRow("HEstimadas") = obtenerHorasEstimadas(Request.QueryString("codigo"))
            dRow("HReales") = hreales.Text
            dt.Rows.Add(dRow)
            da.Update(ds, "tabla")
            ds.AcceptChanges()
            Session("dataadapterInstanciar") = da
            GridView1.DataSource = dt
            GridView1.DataBind()

        Else

        End If



    End Sub
End Class