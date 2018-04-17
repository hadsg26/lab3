Public Class ImportarEnDS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim ds As New DataSet

            Dim a As Integer = ds.Tables(0).Columns.Count

            MsgBox(a)

            ds.Tables(0).Columns.Add("CodAsig")
            MsgBox(ds.Tables(0).Columns.Count)
        Catch ex As Exception
            MsgBox(ex.Message
                   )
        End Try
    End Sub
End Class