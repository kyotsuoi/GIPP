Public Class frmFerias
    Dim ferias As New Ferias
    Private Sub frmFerias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ferias.connect_base()
    End Sub

    Private Sub btnFiltrarFerias_Click(sender As Object, e As EventArgs) Handles btnFiltrarFerias.Click
        ferias.avisoFerias(dtpFerias.Value)
        ferias.avisoFerias2(dtpFerias.Value)
    End Sub
End Class