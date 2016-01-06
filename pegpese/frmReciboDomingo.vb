Imports System.IO

Public Class frmReciboDomingo
    Dim printer As New Printer
    Dim arquivos As New Arquivos

    Private Sub frmReciboDomingo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        printer.connect_base()
    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        frmPrinter.MdiParent = MdiGIPP
        frmPrinter.lblPrinter.Text = "Recibo De Domingo"
        frmPrinter.Show()
        frmPrinter.Focus()
    End Sub

    Private Sub btnRecDomingo_Click(sender As Object, e As EventArgs) Handles btnRecDomingo.Click
        Dim nomeArq
        Dim data As String
        data = dtpRecibo_Domingo.Value
        data = data.Replace("/", "-")

        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            nomeArq = OpenFileDialog.FileName
            arquivos.saveRecDomingo(nomeArq, data, "Recibo de domingo")
        End If
    End Sub

    Private Sub btnAbrirRec_Click(sender As Object, e As EventArgs) Handles btnAbrirRecDom.Click
        Dim data As String
        data = dtpRecibo_Domingo.Value
        data = data.Replace("/", "-")
        arquivos.openRecDomingo(data, "Recibo de domingo")
    End Sub

    Private Sub btnProcRecDom_Click(sender As Object, e As EventArgs) Handles btnProcRecDom.Click
        Dim nomeArq
        Dim path As String
        File.Exists("C:\path")
        path = My.Computer.FileSystem.ReadAllText("C:\path")
        OpenFileDialog.InitialDirectory = path + "\Arquivos\Recibo de domingo"
        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            nomeArq = OpenFileDialog.FileName
            Arquivos.Explorer(nomeArq)
        End If
    End Sub

End Class