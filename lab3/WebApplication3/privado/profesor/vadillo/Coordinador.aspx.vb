Public Class WebForm6
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub DropDownList1_DataBound(sender As Object, e As EventArgs) Handles DropDownList1.DataBound
        DropDownList1.Items.Add("---Elige una asignatura---")
        DropDownList1.SelectedValue = "---Elige una asignatura---"
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim servicioHoras As New FINALONLINE.serviciohoras
        If (Not (DropDownList1.SelectedValue.Equals("---Elige una asignatura---"))) Then
            horas.Text = servicioHoras.GetDedicacionMedia(DropDownList1.SelectedValue)
        Else
            horas.Text = "0"

        End If


    End Sub
End Class