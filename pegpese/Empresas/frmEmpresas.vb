Public Class frmEmpresas
    Dim empresa As New Empresas
    Dim delete As New Delete

    Dim vCodEmpresa As Integer
    Private Sub frmEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        empresa.connect_base()
        empresa.CarregarGrade()
        delete.connect_base()

        btnAlterar.Enabled = MdiGIPP.vAlterarRH
        btnApagar.Enabled = MdiGIPP.vAdminRH
        txtNome.Enabled = MdiGIPP.vAdminRH

    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        Dim cnpj As String = Replaces(mskCNPJ.Text)
        Dim cep As String = Replaces(mskCEP.Text)
        Dim InscEstadual As String = Replaces(mskIncEstadual.Text)
        Dim telefone As String = Replaces(mskTelefone.Text)
        If txtNome.Text = "" Or txtEndereco.Text = "" Or txtNumero.Text = "" Or cnpj = "" Or Len(cnpj) <> 14 Then
            MessageBox.Show("Preeencha todos os campos corretamente!")
        Else
            empresa.Gravar(txtNome.Text, txtRazaoSocial.Text, txtEndereco.Text, txtNumero.Text, txtBairro.Text, txtMunicipio.Text, cnpj, cep, InscEstadual, txtEstado.Text, telefone)
            empresa.CarregarGrade()
            Clear()
        End If
    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        If MsgBox("Deseja realmentente alterar?", vbYesNo, "Confirmação") = vbNo Then Return
        Dim cnpj As String = Replaces(mskCNPJ.Text)
        Dim cep As String = Replaces(mskCEP.Text)
        Dim InscEstadual As String = Replaces(mskIncEstadual.Text)
        Dim telefone As String = Replaces(mskTelefone.Text)
        If txtNome.Text = "" Or txtEndereco.Text = "" Or txtNumero.Text = "" Or cnpj = "" Or Len(cnpj) <> 14 Then
            MessageBox.Show("Preeencha todos os campos corretamente!")
        Else
            empresa.Alterar(txtNome.Text, txtRazaoSocial.Text, txtEndereco.Text, txtNumero.Text, txtBairro.Text, txtMunicipio.Text, cnpj, cep, InscEstadual, txtEstado.Text, telefone, vCodEmpresa)
            empresa.CarregarGrade()
            Clear()
        End If
    End Sub
    Private Sub btnApagar_Click(sender As Object, e As EventArgs) Handles btnApagar.Click
        If MsgBox("Deseja realmentente apagar?", vbYesNo, "Confirmação") = vbNo Then Return
        delete.Apagar(vCodEmpresa, "empresas")
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
            txtRazaoSocial.Text = dgvEmpresa.Item(2, y).Value
            txtEndereco.Text = dgvEmpresa.Item(3, y).Value
            txtNumero.Text = dgvEmpresa.Item(4, y).Value
            txtBairro.Text = dgvEmpresa.Item(5, y).Value
            txtMunicipio.Text = dgvEmpresa.Item(6, y).Value
            mskCNPJ.Text = dgvEmpresa.Item(7, y).Value
            mskCEP.Text = dgvEmpresa.Item(8, y).Value
            mskIncEstadual.Text = dgvEmpresa.Item(9, y).Value
            txtEstado.Text = dgvEmpresa.Item(10, y).Value
            mskTelefone.Text = dgvEmpresa.Item(11, y).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function Replaces(val As String) As String
        val = val.Replace("-", "")
        val = val.Replace(",", "")
        val = val.Replace(".", "")
        val = val.Replace("/", "")
        val = val.Replace(" ", "")
        Return val
    End Function

    Public Sub Clear()
        vCodEmpresa = 0
        txtNome.Text = ""
        txtRazaoSocial.Text = ""
        txtEndereco.Text = ""
        txtNumero.Text = ""
        txtBairro.Text = ""
        txtMunicipio.Text = ""
        mskCNPJ.Text = ""
        mskCEP.Text = ""
        mskIncEstadual.Text = ""
        txtEstado.Text = ""
        mskTelefone.Text = ""
    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged
        If Not IsNumeric(txtNumero.Text) Then
            txtNumero.Text = ""
        End If
    End Sub

End Class