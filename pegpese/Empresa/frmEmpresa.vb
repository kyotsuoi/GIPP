Public Class frmEmpresa
    Dim empresa As New Empresa
    Dim delete As New Delete

    Dim vCodEmpresa As Integer
    Private Sub frmEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        empresa.connect_base()
        empresa.CarregarGrade()
        delete.connect_base()
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        Dim cnpj As String = Replaces(mskCNPJ.Text)
        empresa.Gravar(txtNome.Text, txtEndereco.Text, txtNumero.Text, cnpj)
        empresa.CarregarGrade()
        Clear()
    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        Dim cnpj As String = Replaces(mskCNPJ.Text)
        empresa.Alterar(txtNome.Text, txtEndereco.Text, txtNumero.Text, cnpj, vCodEmpresa)
        empresa.CarregarGrade()
        Clear()
    End Sub
    Private Sub btnApagar_Click(sender As Object, e As EventArgs) Handles btnApagar.Click
        delete.Apagar(vCodEmpresa, "empresa")
        empresa.CarregarGrade()
        Clear()
    End Sub
    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        Clear()
    End Sub

    Private Sub dgvEmpresa_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpresa.CellClick
        Dim y As Integer
        Try
            y = dgvEmpresa.CurrentRow.Index

            vCodEmpresa = dgvEmpresa.Item(0, y).Value
            txtNome.Text = dgvEmpresa.Item(1, y).Value
            txtEndereco.Text = dgvEmpresa.Item(2, y).Value
            txtNumero.Text = dgvEmpresa.Item(3, y).Value
            mskCNPJ.Text = dgvEmpresa.Item(4, y).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function Replaces(val As String) As String
        val = val.Replace("-", "")
        val = val.Replace(",", "")
        val = val.Replace(".", "")
        val = val.Replace("/", "")
        Return val
    End Function

    Public Sub Clear()
        vCodEmpresa = 0
        txtNome.Text = ""
        txtEndereco.Text = ""
        txtNumero.Text = ""
        mskCNPJ.Text = ""
    End Sub

End Class