Imports System.Data.SqlClient
Imports conexiones.accesoDatosSQL
Public Class TareasAlumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DropDownList1.AutoPostBack = True
        If Not (IsPostBack) Then
            Dim RS As SqlDataReader
            RS = obtenerAsignaturasMatriculado(Session("email"))
            While RS.Read
                DropDownList1.Items.Add(RS.Item("codigoAsig"))
            End While
            RS.Close()
            Dim RS2 As DataSet
            RS2 = obtenerTareasGenericas(DropDownList1.SelectedValue, Session("email"))
            GridView1.DataSource = RS2.Tables("tabla")
            GridView1.DataBind()
            Session("dataset") = RS2
            Try
                Dim suma As Object = RS2.Tables("tabla").Compute("sum(Hestimadas)", "")
                If (suma.ToString.Equals("")) Then
                    horas.Text = "0"
                Else
                    horas.Text = suma.ToString
                End If
            Catch ex As Exception
                Label1.Text = "No se han podido calcular las horas"
                Label3.Text = ""

            End Try
        End If
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim RS As DataSet
        RS = obtenerTareasGenericas(DropDownList1.SelectedValue, Session("email"))
        GridView1.DataSource = RS.Tables("tabla")
        GridView1.DataBind()
        Session("dataset") = RS
        Try
            Dim suma As Object = Session("dataset").Tables("tabla").Compute("sum(Hestimadas)", "")
            If (suma.ToString.Equals("")) Then
                horas.Text = "0"
            Else
                horas.Text = suma.ToString
            End If
        Catch ex As Exception
            Label1.Text = "No se han podido calcular las horas"
            Label3.Text = ""

        End Try
    End Sub



    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim ds As DataSet = New DataSet
        ds = Session("dataset")
        Dim dt As DataTable = New DataTable
        dt = ds.Tables("tabla")
        Dim codigo As String
        codigo = dt.Rows(GridView1.SelectedIndex).Item("codigo").ToString
        Response.Redirect(“InstanciarTarea.aspx?codigo=" & codigo & "&email=" & Session("email"))
    End Sub

    Protected Sub SortRecords(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
        Dim sortExpression As String = e.SortExpression
        Dim direction As String = String.Empty
        If SortDirection = SortDirection.Ascending Then
            SortDirection = SortDirection.Descending
            direction = " DESC"
        Else
            SortDirection = SortDirection.Ascending
            direction = " ASC"
        End If

        Dim table As DataTable = Me.GetData()

        table.DefaultView.Sort = sortExpression & direction

        GridView1.DataSource = table

        GridView1.DataBind()

    End Sub



    Public Property SortDirection() As SortDirection

        Get

            If ViewState("SortDirection") Is Nothing Then

                ViewState("SortDirection") = SortDirection.Ascending

            End If

            Return DirectCast(ViewState("SortDirection"), SortDirection)

        End Get

        Set(ByVal value As SortDirection)

            ViewState("SortDirection") = value

        End Set

    End Property



    Private Function GetData() As DataTable

        Dim table As New DataTable()
        Dim dataset As DataSet = Session("dataset")
        table = dataset.Tables("tabla")
        Return table

    End Function

    Protected Sub HyperLink1_Click(sender As Object, e As EventArgs) Handles HyperLink1.Click
        Session.Abandon()
        Response.Redirect("Inicio.aspx")
    End Sub
End Class
