Public Class frmPath

    Private Sub btnSet_Click(sender As Object, e As EventArgs) Handles btnSet.Click
        If txtPath.Text <> "" Then
            MdiGIPP.path = txtPath.Text
            Me.Close()
        Else
            MessageBox.Show("Insira o caminho!")
        End If
    End Sub

    Private Sub frmPath_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        MdiGIPP.vClosingPath = True
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class