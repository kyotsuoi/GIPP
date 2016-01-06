Public Class frmAniver
    Dim aniver As New Aniver

    Private Sub frmAniver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        aniver.connect_base()
    End Sub

    Private Sub btnFiltrarAniver_Click(sender As Object, e As EventArgs) Handles btnFiltrarAniver.Click
        aniver.BuscaAniver(dtpAniver.Value)
    End Sub
End Class