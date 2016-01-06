Imports System.IO

Public Class frmArmarios
    Dim Dados As New Dados
    Dim departamento As New Departamentos
    Dim armarios As New Armarios
    Dim connection As New Connection
    Dim delete As New Delete
    Dim Arquivos As New Arquivos
    Dim printer As New Printer


    Private Sub BtnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        If txtCodFunc.Text = "" Or TxtArmario.Text = "" Then
            MessageBox.Show("O campos codigo de funcionário ou numero do armário está vazio!")
        ElseIf armarios.BuscarArmario(txtCodFunc.Text, TxtArmario.Text) <> "" Then
            MessageBox.Show("Este funcionário já possui um armário, ou este armário já está ocupado!")
        Else
            armarios.Gravar(TxtNome.Text, TxtObs.Text, TxtArmario.Text, txtCodFunc.Text)
            armarios.CarregaGrade()
            Limpar()
            btnGravar.Enabled = False
        End If
    End Sub

    Private Sub BtnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        If MsgBox("Deseja realmentente alterar?", vbYesNo, "Confirmação") = vbNo Then Return
        If txtCodFunc.Text = "" Or TxtArmario.Text = "" Then
            MessageBox.Show("Os campos codigo de funcionário e número do armário estão vazios!")
        Else
            armarios.Alterar(TxtNome.Text, TxtObs.Text, TxtArmario.Text, txtCodFunc.Text)
            armarios.CarregaGrade()
            Limpar()
            btnGravar.Enabled = True
        End If
    End Sub

    Private Sub txtApagar_Click(sender As Object, e As EventArgs) Handles btnApagar.Click
        If MsgBox("Deseja realmentente apagar?", vbYesNo, "Confirmação") = vbNo Then Return
        If txtCodFunc.Text = "" Then
            MessageBox.Show("Armário não selecionado!")
        Else
            delete.ApagarOutros(txtCodFunc.Text, "armarios")
            armarios.CarregaGrade()
            Limpar()
            btnGravar.Enabled = True
        End If
    End Sub

    Private Sub btnFiltrarCodFunc_Click(sender As Object, e As EventArgs) Handles btnFiltrarCodFunc.Click
        If dgvFuncionarios.Visible = False Then
            btnGravar.Enabled = True
            armarios.CarregarGradeF()
            dgvFuncionarios.Visible = True
        Else
            dgvFuncionarios.Visible = False
            armarios.CarregaGrade()
        End If

        Dim column As DataGridViewColumn

        column = dgvFuncionarios.Columns(0)
        column.Width = 50
        column = dgvFuncionarios.Columns(1)
        column.Width = 380
    End Sub

    Private Sub dgvFuncionarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFuncionarios.CellClick
        Dim y As Integer
        Dim vCod = New Departamentos
        dgvFuncionarios.Enabled = True
        y = dgvFuncionarios.CurrentRow.Index
        txtCodFunc.Text = dgvFuncionarios.Item(0, y).Value
        TxtNome.Text = dgvFuncionarios.Item(1, y).Value
        mskCPF.Text = Dados.BuscarOutros(txtCodFunc.Text, "cpf", "documentos")
        dgvFuncionarios.Visible = False
        armarios.CarregaGrade()

        txtDepart.Text = armarios.BuscarDepart(txtCodFunc.Text)

    End Sub

    Private Sub frmArmarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        armarios.connect_base()
        delete.connect_base()
        Dados.connect_base()
        dgvFuncionarios.Visible = False
        btnGravar.Enabled = False
        armarios.CarregaGrade()

        btnAlterar.Enabled = MdiGIPP.vAlterarRH
        btnApagar.Enabled = MdiGIPP.vAdminRH

        txtDepart.Enabled = False

        Dim column As DataGridViewColumn

        column = dgvArmarios.Columns(0)
        column.Width = 50
        column = dgvArmarios.Columns(1)
        column.Width = 180
        column = dgvArmarios.Columns(2)
        column.Width = 170
        column = dgvArmarios.Columns(3)
        column.Width = 30
    End Sub

    Private Sub dgvArmarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArmarios.CellClick
        Dim y As Integer
        btnGravar.Enabled = False
        Try
            y = dgvArmarios.CurrentRow.Index
            txtCodFunc.Text = dgvArmarios.Item(0, y).Value
            TxtNome.Text = dgvArmarios.Item(1, y).Value
            TxtObs.Text = dgvArmarios.Item(2, y).Value
            TxtArmario.Text = dgvArmarios.Item(3, y).Value
            txtDepart.Text = armarios.BuscarDepart(txtCodFunc.Text)
        Catch ex As Exception
            MessageBox.Show("Erro na busca por armarios, talvez não existam armarios cadastrados! " + ex.Message)
        End Try
    End Sub

    Public Sub Limpar()
        txtCodFunc.Text = ""
        TxtArmario.Text = ""
        TxtNome.Text = ""
        TxtObs.Text = ""
        txtDepart.Clear()
    End Sub

    Private Sub BtnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        Limpar()
        btnGravar.Enabled = True
    End Sub

    Private Sub TxtArmario_TextChanged(sender As Object, e As EventArgs) Handles TxtArmario.TextChanged
        If (Not IsNumeric(TxtArmario.Text) And TxtArmario.Text <> "") Then
            TxtArmario.Text = ""
        End If
    End Sub

    Private Sub TxtArmario_LostFocus(sender As Object, e As EventArgs) Handles TxtArmario.LostFocus
        If Len(TxtArmario.Text) > 5 Then
            TxtArmario.Text = ""
            MessageBox.Show("Numero do armário muito grande!")
        End If
    End Sub

    Private Sub btnSavArqArmario_Click(sender As Object, e As EventArgs) Handles btnSavArqArmario.Click
        If txtCodFunc.Text <> "" Then
            Dim nomeArq As String
            OpenFileDialog.Filter = ("Text Files (*.pdf)|*.pdf")
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                nomeArq = OpenFileDialog.FileName
                Arquivos.saveArq(nomeArq, txtCodFunc.Text, "", "Armarios")
            End If
        Else
            MessageBox.Show("Selecione um registro")
        End If
    End Sub

    Private Sub btnAbrArqArmario_Click(sender As Object, e As EventArgs) Handles btnAbrArqArmario.Click
        If txtCodFunc.Text Then
            Arquivos.openArq(txtCodFunc.Text, "", "Armarios")
        Else
            MessageBox.Show("Selecione um registro para abrir arquivo")
        End If
    End Sub

    Private Sub btnProcArqArmario_Click(sender As Object, e As EventArgs) Handles btnProcArqArmario.Click
        Dim nomeArq
        Dim path As String
        File.Exists("C:\path")
        path = My.Computer.FileSystem.ReadAllText("C:\path")
        OpenFileDialog.InitialDirectory = path + "\Arquivos\Armarios"
        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            nomeArq = OpenFileDialog.FileName
            Arquivos.Explorer(nomeArq)
        End If
    End Sub

    Private Sub txtCodFunc_TextChanged(sender As Object, e As EventArgs) Handles txtCodFunc.TextChanged
        mskCPF.Text = Dados.BuscarOutros(txtCodFunc.Text, "cpf", "documentos")
    End Sub

    Private Sub btnPrintArmario_Click(sender As Object, e As EventArgs) Handles btnPrintArmario.Click
        If txtCodFunc.Text <> "" Then
            Printer.PrintArmario()
        Else
            MessageBox.Show("Selecione um registro")
        End If
    End Sub
End Class