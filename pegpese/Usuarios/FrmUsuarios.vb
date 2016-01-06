Public Class FrmUsuarios
    Dim usuarios As New usuarios
    Dim funcionarios As New Dados
    Dim login As New Login

    Private Sub FrmUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCodigo.Enabled = False
        txtCodFunc.Enabled = False
        txtNome.Enabled = False

        dgvUsuarios.RowHeadersWidth = 5
        dgvFuncionarios.Visible = False

        usuarios.connect_base()
        usuarios.CarregarGrade()

        dgvUsuarios.Columns(0).Width = 50
        dgvUsuarios.Columns(1).Width = 200
        dgvUsuarios.Columns(2).Visible = False
        dgvUsuarios.Columns(3).Width = 50
        dgvUsuarios.Columns(4).Width = 50
        dgvUsuarios.Columns(5).Width = 50
        dgvUsuarios.Columns(6).Width = 50
        dgvUsuarios.Columns(7).Width = 50
        dgvUsuarios.Columns(8).Width = 50
        dgvUsuarios.Columns(9).Width = 50
        dgvUsuarios.Columns(10).Width = 50
        dgvUsuarios.Columns(11).Width = 50
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        Dim exitente As Integer = usuarios.Exixtente(txtCodFunc.Text)
        If exitente > 0 Then
            MessageBox.Show("Funcionario ja possui usuario")
        Else
            Dim vTestLoginLen As Integer = Len(txtLogin.Text)
            Dim vTestSenhaLen As Integer = Len(txtSenha1.Text)
            If txtCodFunc.Text = "" Or txtLogin.Text = "" Or txtSenha1.Text = "" Then
                MessageBox.Show("Preencha o codigo do funcionário, o usuario e a senha para gravar!")
            ElseIf vTestLoginLen < 4 Then
                MessageBox.Show("O campo de login precisa ter um tamanho de 8 caracteres no mínimo!")
            ElseIf vTestSenhaLen < 4 Then
                MessageBox.Show("O campo de senha precisa ter um tamanho de 4 caracteres no mínimo!")
            ElseIf txtSenha1.Text <> txtSenha2.Text Then
                MessageBox.Show("A senha e a senha de confirmação não coinsidem!")
            ElseIf txtLogin.Text = login.BuscarLogin(txtLogin.Text) Then
                MessageBox.Show("Este login já está cadastrado!")
            Else
                Dim vFuncionarios, vArmarios, vDepartamentos, vAdministrador, vRelatorios, vRecibos, vEmpresas, vAdminRH, vAlterarRH As Integer

                If cbFuncionarios.Checked = True Then
                    vFuncionarios = 1
                Else
                    vFuncionarios = 0
                End If
                If cbArmarios.Checked = True Then
                    vArmarios = 1
                Else
                    vArmarios = 0
                End If
                If cbDepartamentos.Checked = True Then
                    vDepartamentos = 1
                Else
                    vDepartamentos = 0
                End If
                If cbAdminRH.Checked = True Then
                    vAdministrador = 1
                Else
                    vAdministrador = 0
                End If
                If cbRelatorios.Checked = True Then
                    vRelatorios = 1
                Else
                    vRelatorios = 0
                End If
                If cbRecibos.Checked = True Then
                    vRecibos = 1
                Else
                    vRecibos = 0
                End If
                If cbEmpresas.Checked = True Then
                    vEmpresas = 1
                Else
                    vEmpresas = 0
                End If

                If cbAdminRH.Checked = True Then
                    vAdminRH = 1
                Else
                    vAdminRH = 0
                End If
                If cbAlterarRH.Checked = True Then
                    vAlterarRH = 1
                Else
                    vAlterarRH = 0
                End If

                usuarios.Gravar(Integer.Parse(txtCodFunc.Text), txtLogin.Text, txtSenha1.Text, vAdministrador, vFuncionarios, vDepartamentos, vArmarios,
                                vRelatorios, vRecibos, vEmpresas, vAdminRH, vAlterarRH)
                usuarios.CarregarGrade()
                Clear_All()
            End If
        End If
    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        If MsgBox("Deseja realmentente alterar?", vbYesNo, "Confirmação") = vbNo Then Return
        If txtCodigo.Text <> "" Then
            Dim vTestLoginLen As Integer = Len(txtLogin.Text)
            Dim vTestSenhaLen As Integer = Len(txtSenha1.Text)
            If txtCodFunc.Text = "" Or txtLogin.Text = "" Or txtSenha1.Text = "" Then
                MessageBox.Show("Preencha o codigo do funcionário, o usuario e a senha para gravar!")
            ElseIf vTestLoginLen < 4 Then
                MessageBox.Show("O campo de login precisa ter um tamanho de 4 caracteres no mínimo!")
            ElseIf vTestSenhaLen < 4 Then
                MessageBox.Show("O campo de senha precisa ter um tamanho de 4 caracteres no mínimo!")
            ElseIf txtSenha1.Text <> txtSenha2.Text Then
                MessageBox.Show("A senha e a senha de confirmação não coinsidem!")
            Else

                Dim vFuncionarios, vArmarios, vDepartamentos, vAdministrador, vRelatorios, vRecibos, vEmpresas, vAdminRH, vAlterarRH As Integer

                If cbFuncionarios.Checked = True Then
                    vFuncionarios = 1
                Else
                    vFuncionarios = 0
                End If
                If cbArmarios.Checked = True Then
                    vArmarios = 1
                Else
                    vArmarios = 0
                End If
                If cbDepartamentos.Checked = True Then
                    vDepartamentos = 1
                Else
                    vDepartamentos = 0
                End If
                If cbAdministrador.Checked = True Then
                    vAdministrador = 1
                Else
                    vAdministrador = 0
                End If
                If cbRelatorios.Checked = True Then
                    vRelatorios = 1
                Else
                    vRelatorios = 0
                End If
                If cbRecibos.Checked = True Then
                    vRecibos = 1
                Else
                    vRecibos = 0
                End If
                If cbEmpresas.Checked = True Then
                    vEmpresas = 1
                Else
                    vEmpresas = 0
                End If

                If cbAdminRH.Checked = True Then
                    vAdminRH = 1
                Else
                    vAdminRH = 0
                End If
                If cbAlterarRH.Checked = True Then
                    vAlterarRH = 1
                Else
                    vAlterarRH = 0
                End If

                usuarios.Alterar(txtLogin.Text, txtSenha1.Text, vAdministrador, vFuncionarios, vDepartamentos, vArmarios, vRelatorios, vRecibos, vEmpresas,
                                 vAdminRH, vAlterarRH, Integer.Parse(txtCodigo.Text))
                usuarios.CarregarGrade()
                Clear_All()
            End If
        Else
            MessageBox.Show("Grave ou busque um usuário para apagar!")
        End If
    End Sub

    Private Sub dgvUsuarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellClick
        Dim y As Integer
        Try
            y = dgvUsuarios.CurrentRow.Index

            txtCodigo.Text = dgvUsuarios.Item(0, y).Value
            txtCodFunc.Text = dgvUsuarios.Item(12, y).Value
            txtSenha1.Text = usuarios.BuscaSenha(txtCodFunc.Text)
            txtSenha2.Text = usuarios.BuscaSenha(txtCodFunc.Text)
            txtNome.Text = usuarios.BuscarNome(Integer.Parse(txtCodFunc.Text))
            txtLogin.Text = dgvUsuarios.Item(1, y).Value
            cbFuncionarios.Checked = dgvUsuarios.Item(3, y).Value
            cbDepartamentos.Checked = dgvUsuarios.Item(4, y).Value
            cbArmarios.Checked = dgvUsuarios.Item(5, y).Value
            cbAdministrador.Checked = dgvUsuarios.Item(6, y).Value
            cbRelatorios.Checked = dgvUsuarios.Item(7, y).Value
            cbRecibos.Checked = dgvUsuarios.Item(8, y).Value
            cbEmpresas.Checked = dgvUsuarios.Item(9, y).Value
            cbAdminRH.Checked = dgvUsuarios.Item(10, y).Value
            cbAlterarRH.Checked = dgvUsuarios.Item(11, y).Value

            txtLogin.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Erro na busca por usuarios, talvez não existam usuarios cadastrados! " + ex.Message)
        End Try
    End Sub

    Private Sub btnFiltrarNome_Click(sender As Object, e As EventArgs) Handles btnFiltrarNome.Click
        usuarios.CarregarGradeF()
        dgvFuncionarios.Visible = True
    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        Clear_All()
    End Sub

    Private Sub Clear_All()
        txtCodigo.Text = ""
        txtCodFunc.Text = ""
        txtNome.Text = ""
        txtLogin.Text = ""
        txtSenha1.Text = ""
        txtSenha2.Text = ""
        txtLogin.Enabled = True
        cbArmarios.Checked = False
        cbFuncionarios.Checked = False
        cbDepartamentos.Checked = False
        cbAdministrador.Checked = False
        cbRelatorios.Checked = False
        cbRecibos.Checked = False
        cbEmpresas.Checked = False
        cbAdminRH.Checked = False
        cbAlterarRH.Checked = False
    End Sub

    Private Sub dgvFuncionarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFuncionarios.CellClick
        dgvFuncionarios.Visible = False
        Dim y As Integer
        Clear_All()

        y = dgvFuncionarios.CurrentRow.Index

        txtCodFunc.Text = dgvFuncionarios.Item(0, y).Value
        txtNome.Text = dgvFuncionarios.Item(1, y).Value
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If MsgBox("Deseja realmentente apagar?", vbYesNo, "Confirmação") = vbNo Then Return
        If txtCodigo.Text = "" Then
            MsgBox("Não há registro para apagar!")
        Else
            If MsgBox("Deseja realmentente apagar este cadastro?", vbYesNo, "Confirmação") = vbYes Then
                usuarios.Apagar(txtCodigo.Text)
                Clear_All()
            End If
        End If
    End Sub

    Private Sub cbAdministrador_CheckedChanged(sender As Object, e As EventArgs) Handles cbAdministrador.CheckedChanged
        If cbAdministrador.Checked = True Then
            cbAdminRH.Checked = True
            cbAdminRH.Enabled = False
        Else
            cbAdminRH.Checked = False
            cbAdminRH.Enabled = True
        End If
    End Sub

    Private Sub cbAdminRH_CheckedChanged(sender As Object, e As EventArgs) Handles cbAdminRH.CheckedChanged
        If cbAdminRH.Checked = True Then
            cbFuncionarios.Checked = True
            cbDepartamentos.Checked = True
            cbArmarios.Checked = True
            cbEmpresas.Checked = True
            cbRecibos.Checked = True
            cbRelatorios.Checked = True
            cbAlterarRH.Checked = True

            cbFuncionarios.Enabled = False
            cbDepartamentos.Enabled = False
            cbArmarios.Enabled = False
            cbEmpresas.Enabled = False
            cbRecibos.Enabled = False
            cbRelatorios.Enabled = False
            cbAlterarRH.Enabled = False
        Else
            cbFuncionarios.Enabled = True
            cbDepartamentos.Enabled = True
            cbArmarios.Enabled = True
            cbEmpresas.Enabled = True
            cbRecibos.Enabled = True
            cbRelatorios.Enabled = True
            cbAlterarRH.Enabled = True
        End If
    End Sub
End Class