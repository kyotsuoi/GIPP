Public Class frmDepartamentos
    Dim departamentos As New Departamentos

    Private Sub frmDepartamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        departamentos.connect_base()
        departamentos.CarregarGrade()
        mskCodigo.Enabled = False

        btnAlterar.Enabled = MdiGIPP.vAlterarRH
        btnApagar.Enabled = MdiGIPP.vAdminRH

    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        If txtDepartamento.Text = "" Or txtCargo.Text = "" Then
            MessageBox.Show("Preencha os campos de departamento e cargo!")
        ElseIf departamentos.BuscarDepartamento(txtDepartamento.Text, txtCargo.Text) <> "" Then
            MessageBox.Show("Já exite este departamento e cargo!")
        Else
            departamentos.Gravar(txtDepartamento.Text, txtCargo.Text, txtCBO.Text)
            departamentos.CarregarGrade()
            Limpar()
        End If
    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        If MsgBox("Deseja realmentente alterar?", vbYesNo, "Confirmação") = vbNo Then Return
        If txtDepartamento.Text = "" Or txtCargo.Text = "" Then
            MessageBox.Show("Preencha os campos de departamento e cargo!")
        ElseIf Departamentos.BuscarDepartamento(txtDepartamento.Text, txtCargo.Text) <> "" Then
            MessageBox.Show("Já exitem este departamento e cargo!")
        Else
            If mskCodigo.Text <> "" Then
                departamentos.Alterar(mskCodigo.Text, txtDepartamento.Text, txtCargo.Text, txtCBO.Text)
                departamentos.CarregarGrade()
                Limpar()
            End If
        End If
    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        Limpar()
    End Sub
    Private Sub Limpar()
        mskCodigo.Text = ""
        txtDepartamento.Text = ""
        txtCargo.Text = ""
    End Sub

    Private Sub dgvDepartamento_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDepartamentos.CellClick
        Dim y As Integer

        y = dgvDepartamentos.CurrentRow.Index
        Try
            mskCodigo.Text = dgvDepartamentos.Item(0, y).Value
            txtDepartamento.Text = dgvDepartamentos.Item(1, y).Value
            txtCargo.Text = dgvDepartamentos.Item(2, y).Value
            txtCBO.Text = dgvDepartamentos.Item(3, y).Value

        Catch ex As Exception
            MessageBox.Show("Erro na busca por departamentos, talvez não existam departamentos cadastrados! " + ex.Message)
        End Try
    End Sub

    Private Sub btnApagar_Click(sender As Object, e As EventArgs) Handles btnApagar.Click
        If mskCodigo.Text = "" Then
            MessageBox.Show("Não há registro para apagar!")
        Else
            If MsgBox("Deseja realmentente apagar este cadastro?", vbYesNo, "Confirmação") = vbYes Then
                departamentos.Apagar(mskCodigo.Text)
            End If
            Limpar()
        End If

    End Sub

End Class