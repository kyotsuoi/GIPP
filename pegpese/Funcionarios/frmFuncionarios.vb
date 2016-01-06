Imports System.IO

Public Class frmFuncionarios
    Dim departamentos As New Departamentos
    Dim dados As New Dados
    Dim documentos As New Documentos
    Dim contratos As New Contratos
    Dim habilitacao As New Habilitacao
    Dim beneficios As New Beneficios
    Dim delete As New Delete
    Dim dependentes As New Dependentes
    Dim Arquivos As New Arquivos
    Dim atestados As New Atestados
    Dim faltas As New Faltas
    Dim epi As New EPI
    Dim uniformes As New Uniformes
    Dim advsusp As New AdvSusp
    Dim afastamento As New Afastamento
    Dim ferias As New Ferias
    Dim reciboPagamento As New ReciboPagamento
    Dim td As New TD
    Dim contribuicao As New Contribuicao
    Dim empresa As New Empresas
    Dim Printer As New Printer
    Dim cat As New Cat

    Dim connection As New Connection

    Dim vCodDependentes As Integer
    Dim vCodDepartamento As Integer
    Dim vCodEmpresas As Integer
    Public vCodAtestado As Integer
    Dim vCodFaltas As Integer
    Dim vCodEPI As Integer
    Dim vCodUniformes As Integer
    Dim vCodAdvSusp As Integer
    Dim vCodAfastamento As Integer
    Dim vCodFerias As Integer
    Dim vDataFinalAfastamento As String
    Dim vCodTD As Integer
    Dim vCodContribuicao As Integer
    Dim vCodReciboPagamento As Integer
    Dim vCodHabilit As Integer
    Dim vCodCAT As Integer

    Private Sub frmFuncionarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dados.connect_base()
        empresa.connect_base()

        Clear()
        cmbNacionalidade.Text = "Brasil"
        dgvFuncionarios.Visible = False
        dgvDepartamentos.Visible = False
        rbValeT.Checked = True
        dtpDemitido.Enabled = False

        dgvDepartamentos.Location = New System.Drawing.Point(629, 224)
        dgvFuncionarios.Location = New System.Drawing.Point(15, 15)
        cat.connect_base()
        departamentos.connect_base()
        documentos.connect_base()
        contratos.connect_base()
        habilitacao.connect_base()
        beneficios.connect_base()
        delete.connect_base()
        dependentes.connect_base()
        atestados.connect_base()
        faltas.connect_base()
        epi.connect_base()
        uniformes.connect_base()
        advsusp.connect_base()
        afastamento.connect_base()
        ferias.connect_base()
        reciboPagamento.connect_base()
        td.connect_base()
        contribuicao.connect_base()
        empresa.CarregaCombo()

        btnAlterar.Enabled = MdiGIPP.vAlterarRH
        btnApagar.Enabled = MdiGIPP.vAdminRH
        tbpRelatorio.Enabled = MdiGIPP.vRelatorios

        tpFuncionarios.SelectTab(2)
        tpFuncionarios.SelectTab(1)
        tpFuncionarios.SelectTab(0)

    End Sub

    Private Sub frmFuncionarios_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If frmLogin.Visible = True Then Return
        If MsgBox("Deseja realmentente fechar?", vbYesNo, "Confirmação") = vbNo Then e.Cancel = True
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click

        If mskCodigo.Enabled = False Then
            MessageBox.Show("Use o botão alterar para atualizar este funcionario!")
            Return
        End If

        If Verify() = False Then Return

        Dim vDate As String = dtpAdmissao.Value.ToShortDateString
        Dim codigo As String = Replaces(mskCodigo.Text)
        Dim vNomeLen As Integer = Len(txtNome.Text)
        Dim vCpfLen As String = Len(Replaces(mskCPF.Text))

        Try
            dados.Gravar(codigo, mskMat.Text, txtNome.Text, vDate, cmbTipo.Text, vCodDepartamento, vCodEmpresas)

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Erro em dados")
            Return
        End Try

        Try

            Dim cpf As String = (Replaces(mskCPF.Text)).Replace(",", ".")
            Dim fixo As String = (Replaces(mskFixo.Text)).Replace(",", ".")
            Dim cep As String = (Replaces(mskCEP.Text)).Replace(",", ".")
            Dim celular As String = (Replaces(mskCelular.Text)).Replace(",", ".")
            Dim ctps As String = (Replaces(mskCTPS.Text)).Replace(",", ".")
            Dim serie As String = (Replaces(mskSerie.Text)).Replace(",", ".")
            Dim pis As String = (Replaces(mskPIS.Text)).Replace(",", ".")
            Dim agencia As String = (Replaces(mskAgencia.Text)).Replace(",", ".")
            Dim conta As String = (Replaces(mskConta.Text)).Replace(",", ".")

            Dim vChegBrasil, vDispReser As String

            If dtpChegBrasil.Value.ToShortDateString = Now.ToShortDateString Then
                vChegBrasil = ""
            Else
                vChegBrasil = dtpChegBrasil.Text
            End If
            If dtpDispReser.Value.ToShortDateString = Now.ToShortDateString Then
                vDispReser = ""
            Else
                vDispReser = dtpDispReser.Text
            End If

            documentos.Gravar(codigo, txtRG.Text, dtpRG.Text, cmbOE.Text, txtPai.Text, txtMae.Text,
                              cpf, txtLocalNasc.Text, txtNaturalidade.Text, cmbRacaCor.Text, cmbNacionalidade.Text, cmbGrauInstru.Text, dtpNasc.Text, cmbEstCivil.Text, cmbSexo.Text, vChegBrasil, cmbStatInstruc.Text,
                              txtRegHabilit.Text, dtp1habilit.Text, cmbCatHabilit.Text, dtpValHabilitacao.Text,
                              txtEndereco.Text, txtNumero.Text, txtComp.Text, txtBairro.Text, txtCidade.Text, fixo, cep, cmbUFEndereco.Text, celular, txtEmail.Text, txtOutros.Text,
                              mskNReser.Text, mskRAReser.Text, mskSerieReser.Text, vDispReser,
                              ctps, serie, pis, dtpCarteira.Text, cmbUFCarteira.Text,
                              mskInscrEleitor.Text, mskZona.Text, mskSecao.Text, txtMunicipio.Text, dtpEmissEleitor.Text,
                              cmbBanco.Text, agencia, conta, codigo)
        Catch ex As Exception
            MessageBox.Show(ex.Message + "Erro em documentos")
            delete.Apagar(codigo, "dados")
            Return
        End Try

        Try

            Dim salario, vExp1, vExp2 As String

            If txtDias1Exp.Text = 0 Then
                vExp1 = ""
            Else
                vExp1 = dtpExp1.Text
            End If
            If txtDias2Exp.Text = 0 Then
                vExp2 = ""
            Else
                vExp2 = dtpExp2.Text
            End If

            salario = ReplaceCurrency(txtBase.Text)
            contratos.Gravar(codigo, salario, txtDias1Exp.Text, vExp1, txtDias2Exp.Text, vExp2, cmbStatus.Text, dtpDemitido.Text, cmbInsalub.Text, txtHorario.Text, dtpContrado_Trabalho.Text, codigo)
        Catch ex As Exception
            MessageBox.Show(ex.Message + " ThenErro em contratos")
            delete.ApagarOutros(mskCodigo.Text, "documentos")
            delete.Apagar(codigo, "dados")
            Return
        End Try

        Try
            Dim valeTranporte As Integer = 0
            Dim auxCombustivel As Integer = 0
            If rbValeT.Checked = True Then
                valeTranporte = 1
            ElseIf rbAuxComb.Checked = True
                auxCombustivel = 1
            End If

            Dim vt1, vt2, vt3, combustivel, vr, va As String

            vt1 = ReplaceCurrency(txtVT1.Text)
            vt2 = ReplaceCurrency(txtVT2.Text)
            vt3 = ReplaceCurrency(txtVT3.Text)
            combustivel = ReplaceCurrency(txtCombustivel.Text)
            vr = ReplaceCurrency(txtVR.Text)
            va = ReplaceCurrency(txtVA.Text)

            beneficios.Gravar(valeTranporte, cmbBilhete1.Text, vt1, cmbBilhete2.Text, vt2, cmbBilhete3.Text, vt3, auxCombustivel, combustivel, vr, va, codigo)
        Catch ex As Exception
            MessageBox.Show(ex.Message + "Erro em beneficios")
            delete.ApagarOutros(mskCodigo.Text, "contratos")
            delete.ApagarOutros(mskCodigo.Text, "documentos")
            delete.Apagar(codigo, "dados")
            Return
        End Try

        VerifyPicture()

        mskCodigo.Enabled = False
        MessageBox.Show("Dados gravados com sucesso!")

    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        If MsgBox("Deseja realmentente alterar?", vbYesNo, "Confirmação") = vbNo Then Return
        If Verify() = False Then Return

        Dim valeTranporte As Integer
        Dim auxCombustivel As Integer
        If rbValeT.Checked = True Then
            valeTranporte = 1
        Else
            valeTranporte = 0
        End If
        If rbAuxComb.Checked = True Then
            auxCombustivel = 1
        Else
            auxCombustivel = 0
        End If

        Dim cpf As String = Replaces(mskCPF.Text)
        Dim fixo As String = Replaces(mskFixo.Text)
        Dim cep As String = Replaces(mskCEP.Text)
        Dim celular As String = Replaces(mskCelular.Text)
        Dim ctps As String = Replaces(mskCTPS.Text)
        Dim serie As String = Replaces(mskSerie.Text)
        Dim pis As String = Replaces(mskPIS.Text)
        Dim agencia As String = Replaces(mskAgencia.Text)
        Dim conta As String = Replaces(mskConta.Text)

        Dim base, vt1, vt2, vt3, combustivel, vr, va As String

        base = (ReplaceCurrency(txtBase.Text)).Replace(".", "").Replace(",", ".")
        vt1 = (ReplaceCurrency(txtVT1.Text)).Replace(".", "").Replace(",", ".")
        vt2 = (ReplaceCurrency(txtVT2.Text)).Replace(".", "").Replace(",", ".")
        vt3 = (ReplaceCurrency(txtVT3.Text)).Replace(".", "").Replace(",", ".")
        combustivel = (ReplaceCurrency(txtCombustivel.Text)).Replace(".", "").Replace(",", ".")
        vr = (ReplaceCurrency(txtVR.Text)).Replace(".", "").Replace(",", ".")
        va = (ReplaceCurrency(txtVA.Text)).Replace(".", "").Replace(",", ".")

        Dim dataAdmissao, dataEmissaoRG, dataNasc, dataCarte, dataTitulo As String
        Dim demitido, contrato As String

        dataAdmissao = dtpAdmissao.Text
        dataEmissaoRG = dtpRG.Text
        dataNasc = dtpNasc.Text
        dataCarte = dtpCarteira.Text
        dataTitulo = dtpEmissEleitor.Text

        Dim vChegBrasil, vDispReser, vExp1, vExp2 As String

        If dtpChegBrasil.Value.ToShortDateString = Now.ToShortDateString Then
            vChegBrasil = ""
        Else
            vChegBrasil = dtpChegBrasil.Text
        End If
        If dtpDispReser.Value.ToShortDateString = Now.ToShortDateString Then
            vDispReser = ""
        Else
            vDispReser = dtpDispReser.Text
        End If

        If txtDias1Exp.Text = 0 Then
            vExp1 = ""
        Else
            vExp1 = dtpExp1.Text
        End If
        If txtDias2Exp.Text = 0 Then
            vExp2 = ""
        Else
            vExp2 = dtpExp2.Text
        End If

        demitido = dtpDemitido.Text
        contrato = dtpContrado_Trabalho.Text

        'tpDocumentos
        dados.Alterar(mskMat.Text, txtNome.Text, dataAdmissao, cmbTipo.Text, vCodDepartamento.ToString, vCodEmpresas.ToString,
                        txtRG.Text, dataEmissaoRG, cmbOE.Text, txtPai.Text, txtMae.Text, cpf, txtLocalNasc.Text, txtNaturalidade.Text, cmbRacaCor.Text, cmbNacionalidade.Text, cmbGrauInstru.Text, dataNasc, cmbEstCivil.Text, cmbSexo.Text, vChegBrasil, cmbStatInstruc.Text, txtEndereco.Text, txtNumero.Text, txtComp.Text, txtBairro.Text, txtCidade.Text, fixo, cep, cmbUFEndereco.Text, celular, txtEmail.Text, txtOutros.Text, mskNReser.Text, mskRAReser.Text, mskSerieReser.Text, vDispReser, ctps, serie, pis, dataCarte, cmbUFCarteira.Text, mskInscrEleitor.Text, mskZona.Text, mskSecao.Text, txtMunicipio.Text, dataTitulo, cmbBanco.Text, agencia, conta,
                        base, txtDias1Exp.Text, vExp1, txtDias2Exp.Text, vExp2, cmbStatus.Text, demitido, cmbInsalub.Text, txtHorario.Text, contrato,
                        valeTranporte.ToString, cmbBilhete1.Text, vt1, cmbBilhete2.Text, vt2, cmbBilhete3.Text, vt3, auxCombustivel, combustivel, vr, va, mskCodigo.Text)

        VerifyPicture()

        MessageBox.Show("Dados alterados com sucesso!")

    End Sub

    Private Function Verify() As Boolean

        If txtBase.Text = "" Then
            txtBase.Text = 0
        End If
        If txtDias1Exp.Text = "" Then
            txtDias1Exp.Text = "0"
        End If
        If txtDias2Exp.Text = "" Then
            txtDias2Exp.Text = "0"
        End If

        If txtVT1.Text = "" Then
            txtVT1.Text = 0
        End If
        If txtVT2.Text = "" Then
            txtVT2.Text = 0
        End If
        If txtVT3.Text = "" Then
            txtVT3.Text = 0
        End If
        If txtCombustivel.Text = "" Then
            txtCombustivel.Text = 0
        End If
        If txtVR.Text = "" Then
            txtVR.Text = 0
        End If
        If txtVA.Text = "" Then
            txtVA.Text = 0
        End If

        If OldCalc() = False Then
            Return False
        End If

        If mskMat.Text = "" Or mskMat.TextLength < 5 Then
            MessageBox.Show("Algo esta errado no campo da matricula!")
            Return False
        End If
        If mskCodigo.Text = "" Or mskCodigo.Text = "0" Or cmbEmpresa.Text = "" Or txtNome.Text = "" Or txtDepartamento.Text = "" Or cmbTipo.Text = "" Then
            MessageBox.Show("Formulario dados esta incompleto!")
            Return False
        End If

        If txtRG.Text = "" Or dtpRG.Value.Date >= Now.Date Or cmbOE.Text = "" Then
            MessageBox.Show("Verifique informações de RG")
            Return False
        ElseIf mskCPF.Text = "" Or mskCPF.Text.Length < 14 Or txtLocalNasc.Text = "" Or txtNaturalidade.Text = "" Or cmbRacaCor.Text = "" Or
            cmbGrauInstru.Text = "" Or dtpNasc.Value.Date >= Now.Date Or cmbEstCivil.Text = "" Or cmbSexo.Text = "" Or cmbStatInstruc.Text = ""
            MessageBox.Show("Verifique informações")
            Return False
        ElseIf txtEndereco.Text = "" Or txtNumero.Text = "" Or mskFixo.Text.Length < 14 Or mskCelular.Text.Length < 15 Or txtBairro.Text = "" Or
            txtCidade.Text = "" Or mskCEP.Text = "" Or mskCEP.Text.Length < 8 Or cmbUFEndereco.Text = ""
            MessageBox.Show("Verifique Endereço e contato")
            Return False
        ElseIf mskCTPS.Text = "" Or mskCTPS.Text.Length < 5 Or mskSerie.Text = "" Or mskSerie.Text.Length < 3 Or cmbUFCarteira.Text = "" Or
            dtpCarteira.Value.Date >= Now.Date Or mskPIS.Text = "" Or mskPIS.Text.Length < 14
            MessageBox.Show("Verifique Carteira Profissional")
            Return False
        ElseIf mskInscrEleitor.Text = "" Or txtMunicipio.Text = "" Or mskZona.Text = "" Or mskSecao.Text = ""
            MessageBox.Show("Verifique Titulo de Eleitor")
            Return False
        ElseIf cmbBanco.Text = "" Or mskAgencia.Text = "" Or mskConta.Text = ""
            MessageBox.Show("Verifique Dados Bancários")
            Return False
        End If
        If txtBase.Text = "" Or cmbStatus.Text = "" Or cmbInsalub.Text = "" Or txtHorario.Text = "" Then
            MessageBox.Show("Verifique o formulario de Contrato")
            Return False
        End If

        If mskCTPS.Text = "" Then
            MessageBox.Show("O campo CTPS não foi preenchido")
            Return False
        End If
        If mskSerie.Text = "" Then
            MessageBox.Show("O campo Serie não foi preenchido")
        End If
        If txtNumero.Text = "" Then
            MessageBox.Show("O campo Numero não foi preenchido")
            Return False
        End If

        Return True

    End Function

    Private Sub VerifyPicture()
        Dim path As String
        If File.Exists(connection.PathString) Then
            path = My.Computer.FileSystem.ReadAllText(connection.PathString)
            Dim vFoto As String = path + "\Fotos\" + mskCodigo.Text + ".png"
            Try
                pbFoto.Image.Save(vFoto)
            Catch ex As Exception
                'MessageBox.Show("Nenhuma foto foi selecionada! " + ex.Message)
            End Try
        Else
            MessageBox.Show("Caminho da rede não encontrado!")
        End If
    End Sub

    '>>>>>>>>>>>>>>>Inicio Habilitação<<<<<<<<<<<<<<<<<
    Private Sub btnSalvarHabilit_Click(sender As Object, e As EventArgs) Handles btnSalvarHabilit.Click
        Dim codigo As String = Replaces(mskCodigo.Text)
        habilitacao.Gravar(txtRegHabilit.Text, dtp1habilit.Value, cmbCatHabilit.Text, dtpValHabilitacao.Value, codigo)
        habilitacao.CarregarGrade(mskCodigo.Text)
    End Sub

    '>>>>>>>>>>>>>>>Fim Habilitação<<<<<<<<<<<<<<<<<
    Private Sub btnDepart_Click(sender As Object, e As EventArgs) Handles btnDepart.Click
        If dgvDepartamentos.Visible = False Then
            departamentos.CarregarGradeF()
            dgvDepartamentos.Visible = True

            dgvDepartamentos.Columns(0).Width = 50
            dgvDepartamentos.Columns(1).Width = 160
            dgvDepartamentos.Columns(2).Width = 160
        Else
            dgvDepartamentos.Visible = False
        End If
    End Sub

    Private Sub dgvDepartamento_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDepartamentos.CellClick
        dgvDepartamentos.Visible = False
        Dim y As Integer
        Try
            y = dgvDepartamentos.CurrentRow.Index

            vCodDepartamento = dgvDepartamentos.Item(0, y).Value
            txtDepartamento.Text = dgvDepartamentos.Item(1, y).Value
            txtCargo.Text = dgvDepartamentos.Item(2, y).Value
        Catch ex As Exception
            MessageBox.Show("Erro na ao buscar departamentos, talvez não exitem departamentos cadastrados! " + ex.Message)
            frmDepartamentos.Show()
        End Try

    End Sub

    Private Function Replaces(val As String) As String
        val = val.Replace(",", "")
        val = val.Replace("-", "")
        val = val.Replace("(", "")
        val = val.Replace(")", "")
        val = val.Replace(" ", "")
        val = val.Replace("_", "")
        val = val.Replace("/", "")
        val = val.Replace(":", "")
        Return val
    End Function

    Private Sub btnGrade_Click(sender As Object, e As EventArgs) Handles btnGrade.Click
        If dgvFuncionarios.Visible = False Then
            dados.CarregarGrade()
            dgvFuncionarios.Visible = True
            Resize_DGV_Columns()
        Else
            dgvFuncionarios.Visible = False
        End If
    End Sub

    Private Sub Resize_DGV_Columns()

        dgvFuncionarios.Columns(0).Width = 50
        dgvFuncionarios.Columns(1).Width = 50
        dgvFuncionarios.Columns(2).Width = 500

    End Sub

    Private Sub dgvFuncionarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFuncionarios.CellClick

        Clear()

        dgvFuncionarios.Visible = False
        Dim y As Integer
        mskCodigo.Enabled = False

        txtNome.Enabled = MdiGIPP.vAdminRH
        txtRG.Enabled = MdiGIPP.vAdminRH
        cmbOE.Enabled = MdiGIPP.vAdminRH
        mskCPF.Enabled = MdiGIPP.vAdminRH
        dtpNasc.Enabled = MdiGIPP.vAdminRH
        cmbRacaCor.Enabled = MdiGIPP.vAdminRH
        cmbSexo.Enabled = MdiGIPP.vAdminRH

        Try
            y = dgvFuncionarios.CurrentRow.Index

            '>>>>>>>>>>Inicio Dados<<<<<<<<<<<<<<<<<<<<<
            mskCodigo.Text = dgvFuncionarios.Item(0, y).Value
            mskMat.Text = dgvFuncionarios.Item(1, y).Value
            txtNome.Text = dgvFuncionarios.Item(2, y).Value
            dtpAdmissao.Text = dgvFuncionarios.Item(3, y).Value
            cmbTipo.Text = dgvFuncionarios.Item(4, y).Value
            vCodDepartamento = dgvFuncionarios.Item(5, y).Value
            txtDepartamento.Text = dados.BuscarCampo(vCodDepartamento, "centro_custo", "departamentos")
            txtCargo.Text = dados.BuscarCampo(vCodDepartamento, "cargo", "departamentos")
            cmbEmpresa.Text = dados.BuscarCampo(dgvFuncionarios.Item(6, y).Value, "nome", "empresas")

            Me.Text = "Matricula: " + mskCodigo.Text + "               Nome: " + txtNome.Text +
                "                                                     Empresa: " + cmbEmpresa.Text

            Dim path As String
            If File.Exists(connection.PathString) Then
                path = My.Computer.FileSystem.ReadAllText(connection.PathString)
                Dim vFoto As String = path + "\Fotos\" + mskCodigo.Text + ".png"
                If vFoto <> "" Then
                    If File.Exists(vFoto) Then
                        pbFoto.Image = Image.FromFile(vFoto)
                    Else
                        MessageBox.Show("Foto não encontrada!")
                    End If
                End If
            Else
                MessageBox.Show("Caminho da rede não encontrado!")
            End If

            '>>>>>>>>>Fim Dados<<<<<<<<<<<<<<<<<<<<<<

            '>>>>>>>>>Inicio Documentos<<<<<<<<<<<<<
            txtRG.Text = dados.BuscarOutros(mskCodigo.Text, "rg", "documentos")
            dtpRG.Text = dados.BuscarOutros(mskCodigo.Text, "data_emissao", "documentos")
            cmbOE.Text = dados.BuscarOutros(mskCodigo.Text, "orgao_emissor", "documentos")
            txtPai.Text = dados.BuscarOutros(mskCodigo.Text, "pai", "documentos")
            txtMae.Text = dados.BuscarOutros(mskCodigo.Text, "mae", "documentos")
            mskCPF.Text = dados.BuscarOutros(mskCodigo.Text, "cpf", "documentos")
            txtLocalNasc.Text = dados.BuscarOutros(mskCodigo.Text, "local_nascimento", "documentos")
            txtNaturalidade.Text = dados.BuscarOutros(mskCodigo.Text, "naturalidade", "documentos")
            cmbRacaCor.Text = dados.BuscarOutros(mskCodigo.Text, "cor_raca", "documentos")
            cmbNacionalidade.Text = dados.BuscarOutros(mskCodigo.Text, "nacionalidade", "documentos")
            cmbGrauInstru.Text = dados.BuscarOutros(mskCodigo.Text, "grau_instrucao", "documentos")

            dtpNasc.Text = dados.BuscarOutros(mskCodigo.Text, "data_nascimento", "documentos")
            cmbEstCivil.Text = dados.BuscarOutros(mskCodigo.Text, "estado_civil", "documentos")
            cmbSexo.Text = dados.BuscarOutros(mskCodigo.Text, "sexo", "documentos")
            dtpChegBrasil.Text = dados.BuscarOutros(mskCodigo.Text, "cheg_brasil", "documentos")
            cmbStatInstruc.Text = dados.BuscarOutros(mskCodigo.Text, "status_inst", "documentos")
            txtEndereco.Text = dados.BuscarOutros(mskCodigo.Text, "endereco", "documentos")
            txtNumero.Text = dados.BuscarOutros(mskCodigo.Text, "numero", "documentos")
            txtComp.Text = dados.BuscarOutros(mskCodigo.Text, "complemento", "documentos")
            txtBairro.Text = dados.BuscarOutros(mskCodigo.Text, "bairro", "documentos")
            txtCidade.Text = dados.BuscarOutros(mskCodigo.Text, "cidade", "documentos")
            mskFixo.Text = dados.BuscarOutros(mskCodigo.Text, "fixo", "documentos")
            mskCEP.Text = dados.BuscarOutros(mskCodigo.Text, "cep", "documentos")
            cmbUFEndereco.Text = dados.BuscarOutros(mskCodigo.Text, "uf", "documentos")
            mskCelular.Text = dados.BuscarOutros(mskCodigo.Text, "celular", "documentos")
            txtEmail.Text = dados.BuscarOutros(mskCodigo.Text, "email", "documentos")
            txtOutros.Text = dados.BuscarOutros(mskCodigo.Text, "outros", "documentos")
            mskNReser.Text = dados.BuscarOutros(mskCodigo.Text, "n_reservista", "documentos")
            mskRAReser.Text = dados.BuscarOutros(mskCodigo.Text, "ra_reservista", "documentos")
            mskSerieReser.Text = dados.BuscarOutros(mskCodigo.Text, "serie_reservista", "documentos")
            dtpDispReser.Text = dados.BuscarOutros(mskCodigo.Text, "dispensado", "documentos")
            mskCTPS.Text = dados.BuscarOutros(mskCodigo.Text, "ctps", "documentos")
            mskSerie.Text = dados.BuscarOutros(mskCodigo.Text, "serie_carteira", "documentos")
            mskPIS.Text = dados.BuscarOutros(mskCodigo.Text, "pis", "documentos")
            dtpCarteira.Text = dados.BuscarOutros(mskCodigo.Text, "data_emissao_carteira", "documentos")
            cmbUFCarteira.Text = dados.BuscarOutros(mskCodigo.Text, "uf_carteira", "documentos")
            mskInscrEleitor.Text = dados.BuscarOutros(mskCodigo.Text, "insc_titulo", "documentos")
            mskZona.Text = dados.BuscarOutros(mskCodigo.Text, "zona_titulo", "documentos")
            mskSecao.Text = dados.BuscarOutros(mskCodigo.Text, "secao_titulo", "documentos")
            txtMunicipio.Text = dados.BuscarOutros(mskCodigo.Text, "municipio_titulo", "documentos")
            dtpEmissEleitor.Text = dados.BuscarOutros(mskCodigo.Text, "emissao_titulo", "documentos")
            cmbBanco.Text = dados.BuscarOutros(mskCodigo.Text, "banco", "documentos")
            mskAgencia.Text = dados.BuscarOutros(mskCodigo.Text, "agencia", "documentos")
            mskConta.Text = dados.BuscarOutros(mskCodigo.Text, "conta", "documentos")
            habilitacao.CarregarGrade(mskCodigo.Text)

            OldCalc()
            '>>>>>>>>>>>>Fim Documentos<<<<<<<<<<<<<

            '>>>>>>>>>>>>Inicio Contrato<<<<<<<<<<<<
            vDataFinalAfastamento = afastamento.dataAfastamento
            If vDataFinalAfastamento < Now.ToShortDateString Then
                afastamento.AlterarContrato("status", "Ativo", mskCodigo.Text)
            End If
            txtBase.Text = FormatCurrency(dados.BuscarOutros(mskCodigo.Text, "salario", "contratos").Replace(".", ","))
            txtDias1Exp.Text = dados.BuscarOutros(mskCodigo.Text, "dias_exp1", "contratos")
            dtpExp1.Text = dados.BuscarOutros(mskCodigo.Text, "exp1", "contratos")
            txtDias2Exp.Text = dados.BuscarOutros(mskCodigo.Text, "dias_exp2", "contratos")
            dtpExp2.Text = dados.BuscarOutros(mskCodigo.Text, "exp2", "contratos")
            cmbStatus.Text = dados.BuscarOutros(mskCodigo.Text, "status", "contratos")
            dtpDemitido.Text = dados.BuscarOutros(mskCodigo.Text, "demitido", "contratos")
            cmbInsalub.Text = dados.BuscarOutros(mskCodigo.Text, "insalubridade", "contratos")
            txtHorario.Text = dados.BuscarOutros(mskCodigo.Text, "horario_trabalho", "contratos")
            dtpContrado_Trabalho.Text = dados.BuscarOutros(mskCodigo.Text, "data_contrato", "contratos")
            '>>>>>>>>>>>>Fim Contrato<<<<<<<<<<<<<<<

            '>>>>>>>>>>>>Inicio Beneficios<<<<<<<<<<
            rbValeT.Checked = dados.BuscarOutros(mskCodigo.Text, "vale_transporte", "beneficios")
            cmbBilhete1.Text = dados.BuscarOutros(mskCodigo.Text, "bilhete1", "beneficios")
            txtVT1.Text = FormatCurrency(dados.BuscarOutros(mskCodigo.Text, "vt1", "beneficios"))
            cmbBilhete2.Text = dados.BuscarOutros(mskCodigo.Text, "bilhete2", "beneficios")
            txtVT2.Text = FormatCurrency(dados.BuscarOutros(mskCodigo.Text, "vt2", "beneficios"))
            cmbBilhete3.Text = dados.BuscarOutros(mskCodigo.Text, "bilhete3", "beneficios")
            txtVT3.Text = FormatCurrency(dados.BuscarOutros(mskCodigo.Text, "vt3", "beneficios"))
            rbAuxComb.Checked = dados.BuscarOutros(mskCodigo.Text, "aux_combustivel", "beneficios")
            txtCombustivel.Text = FormatCurrency(dados.BuscarOutros(mskCodigo.Text, "valor", "beneficios"))
            txtVR.Text = FormatCurrency(dados.BuscarOutros(mskCodigo.Text, "valor_vr", "beneficios"))
            txtVA.Text = FormatCurrency(dados.BuscarOutros(mskCodigo.Text, "valor_va", "beneficios"))
            '>>>>>>>>>>>>Fim Beneficios<<<<<<<<<<

            '>>>>>>>>>>>>Inicio Dependentes<<<<<<
            dependentes.CarregarGrade(mskCodigo.Text)
            '>>>>>>>>>>>>Fim Dependentes<<<<<<

            '>>>>>>>>>>>>Inicio EPI<<<<<<<<<<
            epi.CarregarGrade(mskCodigo.Text)
            '>>>>>>>>>>>>Fim EPI<<<<<<<<<<<<<

            '>>>>>>>>>>>>Inicio Uniformes<<<<<<<<<<
            uniformes.CarregarGrade(mskCodigo.Text)
            '>>>>>>>>>>>>Fim Uniformes<<<<<<<<<<

            '>>>>>>>>>>>>Inicio Atestado<<<<<<
            atestados.CarregarGrade(mskCodigo.Text)
            '>>>>>>>>>>>>Fim Atestado<<<<<<

            '>>>>>>>>>>>>Inicio Faltas<<<<<<
            faltas.CarregarGrade(mskCodigo.Text)
            '>>>>>>>>>>>>Fim Faltas<<<<<<<<<

            '>>>>>>>>>>>>Inicio AdvSusp<<<<<
            advsusp.CarregarGrade(mskCodigo.Text)
            '>>>>>>>>>>>>Fim AdvSusp<<<<<

            '>>>>>>>>>Inicio Afastamento<<<<<
            afastamento.CarregarGrade(mskCodigo.Text)
            '>>>>>>>>>Fim Afastamento<<<<<

            '>>>>>>>>>Inicio Ferias<<<<<<<<<
            ferias.CarregarGrade(mskCodigo.Text)
            periodoFerias()
            '>>>>>>>>>Fim Ferias<<<<<<<<<<<<<

            '>>>>>>>>Inicio Recibo Pagamento<<<<
            reciboPagamento.CarregarGrade(mskCodigo.Text)
            '>>>>>>>>Fim Recibo Pagamento<<<<

            '>>>>>>>>>Inicio T&D<<<<<<<<<<<<<
            td.CarregarGrade(mskCodigo.Text)
            '>>>>>>>>>Fim T&D<<<<<<<<<<<<<

            '>>>>>>>>>Inicio Contribuição<<<<
            contribuicao.CarregarGrade(mskCodigo.Text)
            '>>>>>>>>>Fim Contribuição<<<<

            '>>>>>>>>>Inicio CAT<<<<<<<<<<<<<<<
            cat.CarregarGrade(mskCodigo.Text)
            '>>>>>>>>>Fim CAT<<<<<<<<<<<<<<<<<<

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvHabiliti_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHabilit.CellClick
        dgvFuncionarios.Visible = False
        Dim y As Integer
        mskCodigo.Enabled = False

        Try
            y = dgvHabilit.CurrentRow.Index
            vCodHabilit = dgvHabilit.Item(0, y).Value
            txtRegHabilit.Text = dgvHabilit.Item(1, y).Value
            dtp1habilit.Text = dgvHabilit.Item(2, y).Value
            cmbCatHabilit.Text = dgvHabilit.Item(3, y).Value
            dtpValHabilitacao.Text = dgvHabilit.Item(4, y).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnApagar_Click(sender As Object, e As EventArgs) Handles btnApagar.Click
        If MsgBox("Deseja realmentente apagar?", vbYesNo, "Confirmação") = vbNo Then Return
        delete.ApagarOutros(mskCodigo.Text, "documentos")
        delete.ApagarOutros(mskCodigo.Text, "contratos")
        delete.ApagarOutros(mskCodigo.Text, "beneficios")
        delete.ApagarOutros(mskCodigo.Text, "dependentes")
        delete.ApagarOutros(mskCodigo.Text, "epi")
        delete.ApagarOutros(mskCodigo.Text, "uniformes")
        delete.ApagarOutros(mskCodigo.Text, "atestados")
        delete.ApagarOutros(mskCodigo.Text, "faltas")
        delete.ApagarOutros(mskCodigo.Text, "adv_susp")
        delete.ApagarOutros(mskCodigo.Text, "afastamentos")
        delete.ApagarOutros(mskCodigo.Text, "ferias")
        delete.ApagarOutros(mskCodigo.Text, "recibo_pagamentos")
        delete.ApagarOutros(mskCodigo.Text, "td")
        delete.ApagarOutros(mskCodigo.Text, "contribuicoes")
        delete.ApagarOutros(mskCodigo.Text, "usuarios")
        delete.ApagarOutros(mskCodigo.Text, "armarios")

        delete.Apagar(mskCodigo.Text, "dados")

        Clear()

    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        If MsgBox("Deseja realmentente limpar?", vbYesNo, "Confirmação") = vbNo Then Return
        Clear()
    End Sub

    '>>>>>>>>>>>Inicio Clear<<<<<<<<<<<<<
    Public Sub limparDados()
        cmbEmpresa.Text = ""
        mskCodigo.Text = ""
        txtNome.Text = ""
        dtpAdmissao.Text = ""
        cmbTipo.Text = ""
        txtDepartamento.Text = ""
        txtCargo.Text = ""
        vCodDepartamento = 0
        pbFoto.Image = Nothing
        mskEnpEndereco.Text = ""
        mskEnpNumero.Text = ""
        mskEnpCNPJ.Text = ""
        mskEnpCEP.Text = ""
        mskEnpInsc.Text = ""
        mskCodigo.Enabled = True
        mskMat.Text = ""
        mskMat.Focus()

        rtbRelatorio.Text = Nothing

        Try
            mskCodigo.Text = Integer.Parse(dados.LastCod) + 1
        Catch ex As Exception
            MessageBox.Show("Nenhum codigo encontrado no banco, o codigo atual sera o 1!")
            mskCodigo.Text = 1
        End Try
    End Sub
    Public Sub limparDocumentos()
        txtRG.Text = ""
        dtpRG.Text = ""
        cmbOE.Text = ""
        txtPai.Text = ""
        txtMae.Text = ""

        mskCPF.Text = ""
        txtLocalNasc.Text = ""
        txtNaturalidade.Text = ""
        cmbRacaCor.Text = ""
        cmbNacionalidade.Text = ""
        cmbGrauInstru.Text = ""
        dtpNasc.Text = ""
        cmbEstCivil.Text = ""
        cmbSexo.Text = ""
        dtpChegBrasil.Text = ""
        cmbStatInstruc.Text = ""

        txtRegHabilit.Text = ""
        dtp1habilit.Text = ""
        cmbCatHabilit.Text = ""
        dtpValHabilitacao.Text = ""

        txtEndereco.Text = ""
        txtNumero.Text = ""
        txtBairro.Text = ""
        txtCidade.Text = ""
        mskFixo.Text = ""
        txtComp.Text = ""
        mskCEP.Text = ""
        cmbUFEndereco.Text = ""
        mskCelular.Text = ""
        txtEmail.Text = ""
        txtOutros.Text = ""

        mskNReser.Text = ""
        mskRAReser.Text = ""
        mskSerieReser.Text = ""
        dtpDispReser.Text = ""

        mskCTPS.Text = ""
        mskSerie.Text = ""
        mskPIS.Text = ""
        dtpCarteira.Text = ""
        cmbUFCarteira.Text = ""

        mskInscrEleitor.Text = ""
        mskZona.Text = ""
        mskSecao.Text = ""
        txtMunicipio.Text = ""
        dtpEmissEleitor.Text = ""

        cmbBanco.Text = ""
        mskAgencia.Text = ""
        mskConta.Text = ""

    End Sub
    Public Sub limparContratos()
        txtBase.Text = ""
        txtDias1Exp.Text = ""
        dtpExp1.Text = ""
        txtDias2Exp.Text = ""
        dtpExp2.Text = ""
        cmbStatus.Text = ""
        dtpDemitido.Text = ""
        cmbInsalub.Text = ""
        txtHorario.Text = ""
        dtpContrado_Trabalho.Text = ""
    End Sub
    Public Sub limparBeneficios()
        rbValeT.Checked = False
        cmbBilhete1.Text = ""
        txtVT1.Text = ""
        cmbBilhete2.Text = ""
        txtVT2.Text = ""
        cmbBilhete3.Text = ""
        txtVT3.Text = ""
        rbAuxComb.Checked = False
        txtCombustivel.Text = ""
        txtVR.Text = ""
        txtVA.Text = ""
    End Sub
    Public Sub limparDependentes()
        txtNomeDepen.Text = ""
        txtPensAliment.Text = ""
        dtpNascimentoDepen.Text = ""
        cmbParentesco.Text = ""
        rtbObsDepend.Text = ""
        dtpDataDepen.Text = ""

    End Sub
    Public Sub limparEPI()
        txtNomeEPI.Text = ""
        txtNCA.Text = ""
        txtqtdeEPI.Text = ""
        dtpEntregaEPI.Text = ""
        cmbCodFornEPI.Text = ""
        rtbDescEpi.Text = ""

    End Sub
    Public Sub limparUniformes()
        cmbDescUniform.Text = ""
        dtpEntregaUnif.Text = ""
        txtQtde.Text = ""
        cmbTM.Text = ""
        rtbDescUnif.Text = ""
        txtValorUniforme.Text = ""

    End Sub
    Public Sub limparAtestados()
        dtpAtestado.Text = ""
        rbInjust.Checked = False
        rbJusti.Checked = False
        rbDeclar.Checked = False
        rbAtest.Checked = False
        rbSim.Checked = False
        rbNao.Checked = False
        rtbMotivo.Text = ""
        rtbAtestado.Text = ""
        txtDias.Text = ""
        mskHoras.Text = ""
        dtpAtestadoRet.Text = Nothing
        txtUnidade.Text = ""
        rbIntSim.Checked = False
        rbIntNao.Checked = False
        mskHoraAtendimento.Text = ""
        rbAfastSim.Checked = False
        rbAfastNao.Checked = False
        txtNatLesao.Text = ""
        txtCID.Text = ""
        txtCRM.Text = ""
    End Sub
    Public Sub limparFaltas()
        dtpFaltas.Text = ""
        mskDiasHorasFaltas.Text = ""
        rtbFalta.Text = ""

    End Sub
    Public Sub limparAdvSusp()
        dtpAdv_Susp.Text = ""
        rbAdv.Checked = False
        rbSusp.Checked = False
        txtDiasSusp.Text = ""
        txtDiasSuspExt.Text = ""
        dtpRetSusp.Text = ""
        rtbMotivoAdvSusp.Text = ""

    End Sub
    Public Sub limparAfastamento()
        cmbMA.Text = ""
        dtpInicio_Afast.Text = ""
        dtpFinal_Afast.Text = ""
        rtbObsAfast.Text = ""
        dtpArq_Exa_Afast.Text = ""
        dtpAfastRetorno.Text = ""

    End Sub
    Public Sub limparFerias()
        dtpInicial.Text = ""
        dtpFinal.Text = ""
        lblVencimento.Text = ""
        lblLimite.Text = ""

    End Sub
    Public Sub limparReciboPagamento()
        dtpRecibo_Pagamento.Text = ""
        rtbDesc.Text = ""
        rtbMens.Text = ""
        txtRef.Text = ""
        txtProvent.Text = ""
        txtDesc.Text = ""
        txtTotal.Text = ""

    End Sub
    Public Sub limparTD()
        txtTreinamTD.Text = ""
        dtpTD.Text = ""
        mskCargTD.Text = ""
        mskRegTD.Text = ""
        txtMinistTD.Text = ""

    End Sub
    Public Sub limparContribuicao()
        dtpCont.Text = ""
        cmbTipRecibo.Text = ""
        txtSindicato.Text = ""
        txtValorCont.Text = ""
    End Sub
    Public Sub limparCAT()
        msknumCAT.Text = ""
        dtpCAT.Text = ""
        mskHora.Text = ""
        mskHorasTrabalho.Text = ""
        txtTipoAcidente.Text = ""
        cmbAfastamento.Text = ""
        cmbRegPolicial.Text = ""
        txtLocal.Text = ""
        txtExpLocal.Text = ""
        txtCGC.Text = ""
        cmbUFacidente.Text = ""
        txtMunAcidente.Text = ""
        dtpUltDia.Text = ""
        txtPtCorpo.Text = ""
        txtAgCausador.Text = ""
        txtSitGerador.Text = ""
        cmbMorte.Text = ""
        mskObito.Text = ""
        txtEmitente.Text = ""
        txttipoCAT.Text = ""
        txtFiliacao.Text = ""
        dtpEmissaoCAT.Text = ""
        txtComObito.Text = ""
        txtEmailCat.Text = ""
    End Sub

    Public Sub Clear()
        dgvDependentes.DataSource = vbNull
        dgvEPI.DataSource = vbNull
        dgvUniformes.DataSource = vbNull
        dgvAtestados.DataSource = vbNull
        dgvFaltas.DataSource = vbNull
        dgvAdvertencia.DataSource = vbNull
        dgvAfastamento.DataSource = vbNull
        dgvFerias.DataSource = vbNull
        dgvReciboPagamento.DataSource = vbNull
        dgvTD.DataSource = vbNull
        dgvCont.DataSource = vbNull
        dgvHabilit.DataSource = vbNull
        dgvCAT.DataSource = vbNull
        limparDados()
        limparDocumentos()
        limparContratos()
        limparBeneficios()
        limparDependentes()
        limparEPI()
        limparUniformes()
        limparAtestados()
        limparFaltas()
        limparAdvSusp()
        limparAfastamento()
        limparFerias()
        limparReciboPagamento()
        limparTD()
        limparContribuicao()
        limparCAT()
        Me.Text = "Funcionarios"
    End Sub
    '>>>>>>>>>>>Fim Clear<<<<<<<<<<<<<

    Private Sub btnFoto_Click(sender As Object, e As EventArgs) Handles btnFoto.Click
        pbFoto.Image = Nothing
        GC.Collect()
        Me.Refresh()

        Dim path As String
        If File.Exists(connection.PathString) Then
            path = My.Computer.FileSystem.ReadAllText(connection.PathString)
            OpenFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*png"
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                pbFoto.Image = Image.FromFile(OpenFileDialog.FileName)
            End If
        Else
            MessageBox.Show("Caminho da rede não encontrado!")
        End If
    End Sub

    Private Sub txtDias1Exp_LostFocus(sender As Object, e As EventArgs) Handles txtDias1Exp.LostFocus
        If txtDias1Exp.Text <> "" Then
            dtpExp1.Text = dtpAdmissao.Value.AddDays(txtDias1Exp.Text)
        End If
    End Sub

    Private Sub txtDias1Exp_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDias1Exp.KeyDown
        If e.KeyCode = Keys.Enter Then txtDias1Exp_LostFocus(sender, e)
    End Sub

    Private Sub txtDias2Exp_LostFocus(sender As Object, e As EventArgs) Handles txtDias2Exp.LostFocus
        If txtDias2Exp.Text <> "" Then
            dtpExp2.Text = dtpExp1.Value.AddDays(txtDias2Exp.Text)
        End If
    End Sub

    Private Sub txtDias2Exp_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDias2Exp.KeyDown
        If e.KeyCode = Keys.Enter Then txtDias2Exp_LostFocus(sender, e)
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged
        If cmbStatus.Text = "Desligado" Then
            dtpDemitido.Enabled = True
        Else
            dtpDemitido.Enabled = False
        End If
    End Sub




    '>>>>>>>>>>>>>>>Inicio Dependentes<<<<<<<<<<<

    Private Sub btnGravarDpen_Click(sender As Object, e As EventArgs) Handles btnGravarDpen.Click
        If mskCodigo.Enabled = False Then
            Dim codigo As String = Replaces(mskCodigo.Text)
            Dim vdependentes As Boolean
            Dim pensao As String

            pensao = ReplaceCurrency(txtPensAliment.Text)

            vdependentes = dependentes.Gravar(txtNomeDepen.Text, pensao, dtpNascimentoDepen.Text, cmbParentesco.Text, rtbObsDepend.Text, dtpDataDepen.Text, codigo)
            If vdependentes = True Then
                MessageBox.Show("Dependente Salvo!")
            Else
                MessageBox.Show("Erro ao salvar dependente")
            End If
            limparDependentes()
            dependentes.CarregarGrade(codigo)
        Else
            MessageBox.Show("Selecione o Funcionário")
        End If

    End Sub

    Private Sub btnAlterarDepen_Click(sender As Object, e As EventArgs) Handles btnAlterarDepen.Click
        If mskCodigo.Enabled = False Then
            Dim codigo As String = Replaces(mskCodigo.Text)
            Dim pensao As String

            pensao = ReplaceCurrency(txtPensAliment.Text)
            dependentes.Alterar(txtNomeDepen.Text, pensao, dtpNascimentoDepen.Text, cmbParentesco.Text, rtbObsDepend.Text, dtpDataDepen.Text, codigo)
            dependentes.CarregarGrade(codigo)
            limparDependentes()
        Else
            MessageBox.Show("Selecione um registro")
        End If

    End Sub

    Private Sub dgvDependentes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDependentes.CellClick
        Dim y As Integer
        Try
            y = dgvDependentes.CurrentRow.Index
            vCodDependentes = dgvDependentes.Item(0, y).Value
            txtNomeDepen.Text = dgvDependentes.Item(1, y).Value
            txtPensAliment.Text = FormatCurrency(dgvDependentes.Item(2, y).Value)
            dtpNascimentoDepen.Text = dgvDependentes.Item(3, y).Value
            cmbParentesco.Text = dgvDependentes.Item(4, y).Value
            rtbObsDepend.Text = dgvDependentes.Item(5, y).Value
            dtpDataDepen.Text = dgvDependentes.Item(6, y).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnApagarDepen_Click(sender As Object, e As EventArgs) Handles btnApagarDepen.Click
        If vCodDependentes > 0 Then
            delete.Apagar(vCodDependentes, "dependentes")
            dependentes.CarregarGrade(mskCodigo.Text)
            Dim path As String
            Dim vNomeArq As String
            vNomeArq = mskCodigo.Text & "-" & vCodDependentes
            File.Exists(connection.PathString)
            path = My.Computer.FileSystem.ReadAllText(connection.PathString)
            Arquivos.deleteArq("dependentes", vNomeArq)
            limparDependentes()
        Else
            MessageBox.Show("Selecione um registro para excluir")
        End If
    End Sub

    Private Sub btnSavArqDepen_Click(sender As Object, e As EventArgs) Handles btnSavArqDepen.Click
        If vCodDependentes > 0 Then
            Dim nomeArq
            OpenFileDialog.Filter = ("Text Files (*.pdf)|*.pdf")
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                nomeArq = OpenFileDialog.FileName
                Arquivos.saveArq(nomeArq, mskCodigo.Text, vCodDependentes, "Dependentes")
            End If
        Else
            MessageBox.Show("Selecione um registro para anexar arquivo")
        End If
    End Sub

    Private Sub btnAbrArqDepen_Click(sender As Object, e As EventArgs) Handles btnAbrArqDepen.Click
        If vCodDependentes > 0 Then
            Arquivos.openArq(mskCodigo.Text, vCodDependentes, "Dependentes")
        Else
            MessageBox.Show("Selecione um registro para abrir arquivo")
        End If
    End Sub

    Private Sub btnProcArqDepen_Click(sender As Object, e As EventArgs) Handles btnProcArqDepen.Click
        Dim nomeArq
        Dim path As String
        File.Exists(connection.PathString)
        path = My.Computer.FileSystem.ReadAllText(connection.PathString)
        OpenFileDialog.InitialDirectory = path + "\Arquivos\Dependentes"
        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            nomeArq = OpenFileDialog.FileName
            Arquivos.Explorer(nomeArq)
        End If
    End Sub
    '>>>>>>>>>>>>>>>Fim Dependentes<<<<<<<<<<<

    '>>>>>>>>>>>>>>>Inicio Epi<<<<<<<<<<<<<<<<
    Private Sub btnSavEPI_Click(sender As Object, e As EventArgs) Handles btnSavEPI.Click
        If mskCodigo.Enabled = False Then
            epi.Gravar(txtNomeEPI.Text, txtNCA.Text, txtqtdeEPI.Text, dtpEntregaEPI.Text, cmbCodFornEPI.Text, rtbDescEpi.Text, mskCodigo.Text)
            epi.CarregarGrade(mskCodigo.Text)
            limparEPI()
        Else
            MessageBox.Show("Selecione o Funcionário")
        End If

    End Sub

    Private Sub dgvEPI_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEPI.CellClick
        Dim y As Integer
        Try
            y = dgvEPI.CurrentRow.Index
            vCodEPI = dgvEPI.Item(0, y).Value
            txtNomeEPI.Text = dgvEPI.Item(1, y).Value
            txtNCA.Text = dgvEPI.Item(2, y).Value
            txtqtdeEPI.Text = dgvEPI.Item(3, y).Value
            dtpEntregaEPI.Text = dgvEPI.Item(4, y).Value
            cmbCodFornEPI.Text = dgvEPI.Item(5, y).Value
            rtbDescEpi.Text = dgvEPI.Item(6, y).Value

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnAltEPI_Click(sender As Object, e As EventArgs) Handles btnAltEPI.Click
        If mskCodigo.Enabled = False Then
            epi.Alterar(txtNomeEPI.Text, txtNCA.Text, txtqtdeEPI.Text, dtpEntregaEPI.Text, cmbCodFornEPI.Text, rtbDescEpi.Text, vCodEPI)
            epi.CarregarGrade(mskCodigo.Text)
            limparEPI()
        Else
            MessageBox.Show("Selecione um registro")
        End If
    End Sub
    Private Sub btnExcEPI_Click(sender As Object, e As EventArgs) Handles btnExcEPI.Click
        If vCodEPI > 0 Then
            delete.Apagar(vCodEPI, "epi")
            epi.CarregarGrade(mskCodigo.Text)
            Dim path As String
            Dim vNomeArq As String
            vNomeArq = mskCodigo.Text & "-" & vCodEPI
            File.Exists(connection.PathString)
            path = My.Computer.FileSystem.ReadAllText(connection.PathString)
            Arquivos.deleteArq("epi", vNomeArq)
            limparEPI()
        Else
            MessageBox.Show("Selecione um registro para excluir")
        End If

    End Sub
    Private Sub btnSavArqEPI_Click(sender As Object, e As EventArgs) Handles btnSavArqEPI.Click
        If vCodEPI > 0 Then
            Dim nomeArq
            OpenFileDialog.Filter = ("Text Files (*.pdf)|*.pdf")
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                nomeArq = OpenFileDialog.FileName
                Arquivos.saveArq(nomeArq, mskCodigo.Text, vCodEPI, "EPI")
            End If
        Else
            MessageBox.Show("Selecione um registro para anexar arquivo")
        End If

    End Sub
    Private Sub btnAbrEPI_Click(sender As Object, e As EventArgs) Handles btnAbrEPI.Click
        If vCodEPI > 0 Then
            Arquivos.openArq(mskCodigo.Text, vCodEPI, "EPI")
        Else
            MessageBox.Show("Selecione um registro para abrir arquivo")
        End If

    End Sub
    Private Sub btnProcEPI_Click(sender As Object, e As EventArgs) Handles btnProcEPI.Click
        Dim nomeArq
        Dim path As String
        File.Exists(connection.PathString)
        path = My.Computer.FileSystem.ReadAllText(connection.PathString)
        OpenFileDialog.InitialDirectory = path + "\Arquivos\EPI"
        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            nomeArq = OpenFileDialog.FileName
            Arquivos.Explorer(nomeArq)
        End If
    End Sub
    '>>>>>>>>>>>>>>>Fim Epi<<<<<<<<<<<<<<<<<<<

    '>>>>>>>>>>>>>>>Inicio Uniformes<<<<<<<<<<
    Private Sub btnSavUniforme_Click(sender As Object, e As EventArgs) Handles btnSavUniforme.Click
        If mskCodigo.Enabled = False Then

            Dim Valor As String
            Valor = ReplaceCurrency(txtValorUniforme.Text)

            uniformes.Gravar(cmbDescUniform.Text, dtpEntregaUnif.Text, txtQtde.Text, cmbTM.Text, rtbDescUnif.Text, Valor, mskCodigo.Text)
            uniformes.CarregarGrade(mskCodigo.Text)
            limparUniformes()
        Else
            MessageBox.Show("Selecione o Funcionário")
        End If

    End Sub
    Private Sub dgvUniformes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUniformes.CellClick
        Dim y As Integer
        Try
            y = dgvUniformes.CurrentRow.Index
            vCodUniformes = dgvUniformes.Item(0, y).Value
            cmbDescUniform.Text = dgvUniformes.Item(1, y).Value
            dtpEntregaUnif.Text = dgvUniformes.Item(2, y).Value
            txtQtde.Text = dgvUniformes.Item(3, y).Value
            cmbTM.Text = dgvUniformes.Item(4, y).Value
            rtbDescUnif.Text = dgvUniformes.Item(5, y).Value
            txtValorUniforme.Text = dgvUniformes.Item(6, y).Value
            txtValorUniforme_LostFocus(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnAltUniforme_Click(sender As Object, e As EventArgs) Handles btnAltUniforme.Click
        If vCodUniformes > 0 Then
            Dim Valor As String
            Valor = ReplaceCurrency(txtValorUniforme.Text)
            uniformes.Alterar(cmbDescUniform.Text, dtpEntregaUnif.Text, txtQtde.Text, cmbTM.Text, rtbDescUnif.Text, Valor, vCodUniformes)
            uniformes.CarregarGrade(mskCodigo.Text)
            limparUniformes()
        Else
            MessageBox.Show("Selecione um registro")
        End If
    End Sub
    Private Sub btnExcUniform_Click(sender As Object, e As EventArgs) Handles btnExcUniform.Click
        If vCodUniformes > 0 Then
            delete.Apagar(vCodUniformes, "uniformes")
            uniformes.CarregarGrade(mskCodigo.Text)
            Dim path As String
            Dim vNomeArq As String
            vNomeArq = mskCodigo.Text & "-" & vCodUniformes
            File.Exists(connection.PathString)
            path = My.Computer.FileSystem.ReadAllText(connection.PathString)
            Arquivos.deleteArq("uniformes", vNomeArq)
            limparUniformes()
        Else
            MessageBox.Show("Selecione um registro para excluir")
        End If
    End Sub
    Private Sub btnSavArqUniforme_Click(sender As Object, e As EventArgs) Handles btnSavArqUniforme.Click
        If mskCodigo.Text <> "" Then
            Dim nomeArq
            OpenFileDialog.Filter = ("Text Files (*.pdf)|*.pdf")
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                nomeArq = OpenFileDialog.FileName
                Arquivos.saveArq(nomeArq, mskCodigo.Text, vCodUniformes, "Uniformes")
            End If
        Else
            MessageBox.Show("Selecione um registro para anexar arquivo")
        End If
    End Sub
    Private Sub btnAbrArqUniforme_Click(sender As Object, e As EventArgs) Handles btnAbrArqUniforme.Click
        If mskCodigo.Text <> "" Then
            Arquivos.openArq(mskCodigo.Text, vCodUniformes, "Uniformes")
        Else
            MessageBox.Show("Selecione um registro para abrir arquivo")
        End If
    End Sub
    Private Sub btnProArqUniforme_Click(sender As Object, e As EventArgs) Handles btnProArqUniforme.Click
        Dim nomeArq
        Dim path As String
        File.Exists(connection.PathString)
        path = My.Computer.FileSystem.ReadAllText(connection.PathString)
        OpenFileDialog.InitialDirectory = path + "\Arquivos\Uniformes"
        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            nomeArq = OpenFileDialog.FileName
            Arquivos.Explorer(nomeArq)
        End If
    End Sub

    Private Sub txtValorUniforme_Keydown(sender As Object, e As KeyEventArgs) Handles txtValorUniforme.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtValorUniforme_LostFocus(sender, e)
        End If
    End Sub

    '>>>>>>>>>>>>>>>Fim Uniformes<<<<<<<<<<<<<

    '>>>>>>>>>>>>>>>Inicio Atestados<<<<<<<<<<
    Private Sub btnSavAtestado_Click(sender As Object, e As EventArgs) Handles btnSavAtestado.Click
        If mskCodigo.Enabled = False Then
            Dim injustificado, justificado, declaracao, atestado, sim, nao, intSim, intNao, afastSim, afastNao As Integer
            If rbInjust.Checked = True Then
                injustificado = 1
            Else
                injustificado = 0
            End If
            If rbJusti.Checked = True Then
                justificado = 1
            Else
                justificado = 0
            End If
            If rbDeclar.Checked = True Then
                declaracao = 1
            Else
                declaracao = 0
            End If
            If rbAtest.Checked = True Then
                atestado = 1
            Else
                atestado = 0
            End If
            If rbSim.Checked = True Then
                sim = 1
            Else
                sim = 0
            End If
            If rbNao.Checked = True Then
                nao = 1
            Else
                nao = 0
            End If
            If rbIntSim.Checked = True Then
                intSim = 1
            Else
                intSim = 0
            End If
            If rbIntNao.Checked = True Then
                intNao = 1
            Else
                intNao = 0
            End If
            If rbAfastSim.Checked = True Then
                afastSim = 1
            Else
                afastSim = 0
            End If
            If rbAfastNao.Checked = True Then
                afastNao = 1
            Else
                afastNao = 0
            End If
            If txtDias.Text = "" Then
                txtDias.Text = 0
            End If


            atestados.Gravar(dtpAtestado.Text, txtDias.Text, mskHoras.Text, injustificado, justificado, declaracao, atestado, sim, nao, rtbMotivo.Text, rtbAtestado.Text, txtUnidade.Text, intSim, intNao, mskHoraAtendimento.Text, afastSim, afastNao, txtNatLesao.Text, txtCID.Text, txtCRM.Text, mskCodigo.Text)
            limparAtestados()
                atestados.CarregarGrade(mskCodigo.Text)
            Else
                MessageBox.Show("Selecione o Funcionário")
        End If

    End Sub

    Private Sub dgvAtestados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAtestados.CellClick
        Dim y As Integer
        Try
            y = dgvAtestados.CurrentRow.Index
            vCodAtestado = dgvAtestados.Item(0, y).Value
            dtpAtestado.Text = dgvAtestados.Item(1, y).Value
            txtDias.Text = dgvAtestados.Item(2, y).Value
            mskHoras.Text = dgvAtestados.Item(3, y).Value
            rbInjust.Checked = dgvAtestados.Item(4, y).Value
            rbJusti.Checked = dgvAtestados.Item(5, y).Value
            rbDeclar.Checked = dgvAtestados.Item(6, y).Value
            rbAtest.Checked = dgvAtestados.Item(7, y).Value
            rbSim.Checked = dgvAtestados.Item(8, y).Value
            rbNao.Checked = dgvAtestados.Item(9, y).Value
            rtbMotivo.Text = dgvAtestados.Item(10, y).Value
            rtbAtestado.Text = dgvAtestados.Item(11, y).Value
            txtUnidade.Text = dgvAtestados.Item(12, y).Value
            rbIntSim.Checked = dgvAtestados.Item(13, y).Value
            rbIntNao.Checked = dgvAtestados.Item(14, y).Value
            mskHoraAtendimento.Text = dgvAtestados.Item(15, y).Value
            rbAfastSim.Checked = dgvAtestados.Item(16, y).Value
            rbAfastNao.Checked = dgvAtestados.Item(17, y).Value
            txtNatLesao.Text = dgvAtestados.Item(18, y).Value
            txtCID.Text = dgvAtestados.Item(19, y).Value
            txtCRM.Text = dgvAtestados.Item(20, y).Value

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnAltAtestado_Click(sender As Object, e As EventArgs) Handles btnAltAtestado.Click
        If vCodAtestado > 0 Then
            Dim injustificado, justificado, declaracao, atestado, sim, nao, intSim, intNao, afastSim, afastNao As Integer
            If rbInjust.Checked = True Then
                injustificado = 1
            Else
                injustificado = 0
            End If
            If rbJusti.Checked = True Then
                justificado = 1
            Else
                justificado = 0
            End If
            If rbDeclar.Checked = True Then
                declaracao = 1
            Else
                declaracao = 0
            End If
            If rbAtest.Checked = True Then
                atestado = 1
            Else
                atestado = 0
            End If
            If rbSim.Checked = True Then
                sim = 1
            Else
                sim = 0
            End If
            If rbNao.Checked = True Then
                nao = 1
            Else
                nao = 0
            End If
            If rbIntSim.Checked = True Then
                intSim = 1
            Else
                intSim = 0
            End If
            If rbIntNao.Checked = True Then
                intNao = 1
            Else
                intNao = 0
            End If
            If rbAfastSim.Checked = True Then
                afastSim = 1
            Else
                afastSim = 0
            End If
            If rbAfastNao.Checked = True Then
                afastNao = 1
            Else
                afastNao = 0
            End If
            If txtDias.Text = "" Then
                txtDias.Text = 0
            End If


            atestados.Alterar(dtpAtestado.Text, txtDias.Text, mskHoras.Text, injustificado, justificado, declaracao, atestado, sim, nao, rtbMotivo.Text, rtbAtestado.Text, txtUnidade.Text, intSim, intNao, mskHoraAtendimento.Text, afastSim, afastNao, txtNatLesao.Text, txtCID.Text, txtCRM.Text, vCodAtestado)
            atestados.CarregarGrade(mskCodigo.Text)
            limparAtestados()
        Else
            MessageBox.Show("Selecione um registro")
        End If
    End Sub

    Private Sub btnExcAtestado_Click(sender As Object, e As EventArgs) Handles btnExcAtestado.Click
        If vCodAtestado > 0 Then
            delete.Apagar(vCodAtestado, "atestados")
            atestados.CarregarGrade(mskCodigo.Text)
            Dim path As String
            Dim vNomeArq As String
            vNomeArq = mskCodigo.Text & "-" & vCodAtestado
            File.Exists(connection.PathString)
            path = My.Computer.FileSystem.ReadAllText(connection.PathString)
            Arquivos.deleteArq("atestados", vNomeArq)
            limparAtestados()
        Else
            MessageBox.Show("Selecione um registro para excluir")
        End If
    End Sub

    Private Sub btnSavArqAtestado_Click(sender As Object, e As EventArgs) Handles btnSavArqAtestado.Click
        If vCodAtestado > 0 Then
            Dim nomeArq
            OpenFileDialog.Filter = ("Text Files (*.pdf)|*.pdf")
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                nomeArq = OpenFileDialog.FileName
                Arquivos.saveArq(nomeArq, mskCodigo.Text, vCodAtestado, "Atestados")
            End If
        Else
            MessageBox.Show("Selecione um registro para anexar arquivo")
        End If

    End Sub

    Private Sub btnAbrAtestado_Click(sender As Object, e As EventArgs) Handles btnAbrAtestado.Click
        If vCodAtestado > 0 Then
            Arquivos.openArq(mskCodigo.Text, vCodAtestado, "Atestados")
        Else
            MessageBox.Show("Selecione um registro para abrir arquivo")
        End If
    End Sub

    Private Sub btnProcAtestado_Click(sender As Object, e As EventArgs) Handles btnProcAtestado.Click
        Dim nomeArq
        Dim path As String
        File.Exists(connection.PathString)
        path = My.Computer.FileSystem.ReadAllText(connection.PathString)
        OpenFileDialog.InitialDirectory = path + "\Arquivos\Atestados"
        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            nomeArq = OpenFileDialog.FileName
            Arquivos.Explorer(nomeArq)
        End If
    End Sub
    '>>>>>>>>>>>>>>>Fim Atestados<<<<<<<<<<

    '>>>>>>>>>>>>>>>Inicio Faltas<<<<<<<<<<
    Private Sub btnGravarFaltas_Click(sender As Object, e As EventArgs) Handles btnGravarFaltas.Click
        If mskCodigo.Enabled = False Then
            Dim DiasHoras As String

            DiasHoras = Replaces(mskDiasHorasFaltas.Text)
            'DiasHoras = 0
            faltas.Gravar(dtpFaltas.Text, DiasHoras, rtbFalta.Text, mskCodigo.Text)
            faltas.CarregarGrade(mskCodigo.Text)
            limparFaltas()
        Else
            MessageBox.Show("Selecione o Funcionário")
        End If
    End Sub

    Private Sub dgvFaltas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFaltas.CellClick
        Dim y As Integer
        Try
            y = dgvFaltas.CurrentRow.Index

            vCodFaltas = dgvFaltas.Item(0, y).Value
            dtpFaltas.Text = dgvFaltas.Item(1, y).Value
            mskDiasHorasFaltas.Text = dgvFaltas.Item(2, y).Value
            rtbFalta.Text = dgvFaltas.Item(3, y).Value

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnAlterarFaltas_Click(sender As Object, e As EventArgs) Handles btnAlterarFaltas.Click
        If vCodFaltas > 0 Then
            Dim DiasHoras As String

            DiasHoras = Replaces(mskDiasHorasFaltas.Text)
            faltas.Alterar(dtpFaltas.Text, DiasHoras, rtbFalta.Text, vCodFaltas)
            faltas.CarregarGrade(mskCodigo.Text)
            limparFaltas()
        Else
            MessageBox.Show("Selecione um registro")
        End If
    End Sub

    Private Sub btnApagarFaltas_Click(sender As Object, e As EventArgs) Handles btnApagarFaltas.Click
        If vCodFaltas > 0 Then
            delete.Apagar(vCodFaltas, "faltas")
            faltas.CarregarGrade(mskCodigo.Text)
            limparFaltas()
        Else
            MessageBox.Show("Selecione um registro para excluir")
        End If
    End Sub
    '>>>>>>>>>>>>>>>Fim Faltas<<<<<<<<<<<<<

    '>>>>>>>>>>>>>>>Inicio AdvSusp<<<<<<<<<
    Private Sub btnSavAdvSusp_Click(sender As Object, e As EventArgs) Handles btnSavAdvSusp.Click
        If mskCodigo.Enabled = False Then
            Dim adv As Integer
            Dim susp As Integer
            If rbAdv.Checked = True Then
                adv = 1
            End If
            If rbSusp.Checked = True Then
                susp = 1
            End If
            advsusp.Gravar(dtpAdv_Susp.Text, adv, susp, txtDiasSusp.Text, txtDiasSuspExt.Text, dtpRetSusp.Text, rtbMotivoAdvSusp.Text, mskCodigo.Text)
            advsusp.CarregarGrade(mskCodigo.Text)
            limparAdvSusp()
        Else
            MessageBox.Show("Selecione o Funcionário")
        End If

    End Sub

    Private Sub btnAltAdvSusp_Click(sender As Object, e As EventArgs) Handles btnAltAdvSusp.Click
        If vCodAdvSusp > 0 Then
            Dim adv As Integer
            Dim susp As Integer
            If rbAdv.Checked = True Then
                adv = 1
            End If
            If rbSusp.Checked = True Then
                susp = 1
            End If
            advsusp.Alterar(vCodAdvSusp, dtpAdv_Susp.Text, adv, susp, txtDiasSusp.Text, txtDiasSuspExt.Text, dtpRetSusp.Text, rtbMotivoAdvSusp.Text)
            advsusp.CarregarGrade(mskCodigo.Text)
            limparAdvSusp()
        Else
            MessageBox.Show("Selecione um registro")
        End If
    End Sub

    Private Sub btnExcAdvSusp_Click(sender As Object, e As EventArgs) Handles btnExcAdvSusp.Click
        If vCodAdvSusp > 0 Then
            delete.Apagar(vCodAdvSusp, "adv_susp")
            advsusp.CarregarGrade(mskCodigo.Text)
            Dim path As String
            Dim vNomeArq As String
            vNomeArq = mskCodigo.Text & "-" & vCodAdvSusp
            File.Exists(connection.PathString)
            path = My.Computer.FileSystem.ReadAllText(connection.PathString)
            Arquivos.deleteArq("Advertencia", vNomeArq)
            limparAdvSusp()
        Else
            MessageBox.Show("Selecione um registro para excluir")
        End If
    End Sub

    Private Sub btnSavArqAdvSusp_Click(sender As Object, e As EventArgs) Handles btnSavArqAdvSusp.Click
        If mskCodigo.Text <> "" Then
            Dim nomeArq
            OpenFileDialog.Filter = ("Text Files (*.pdf)|*.pdf")
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                nomeArq = OpenFileDialog.FileName
                Arquivos.saveArq(nomeArq, mskCodigo.Text, vCodAdvSusp, "Advertencia")
            End If
        Else
            MessageBox.Show("Selecione um registro para anexar arquivo")
        End If

    End Sub

    Private Sub btnAbrArqAdvSusp_Click(sender As Object, e As EventArgs) Handles btnAbrArqAdvSusp.Click
        If mskCodigo.Text <> "" Then
            Arquivos.openArq(mskCodigo.Text, vCodAdvSusp, "Advertencia")
        Else
            MessageBox.Show("Selecione um registro para abrir arquivo")
        End If
    End Sub

    Private Sub btnProAdvSusp_Click(sender As Object, e As EventArgs) Handles btnProAdvSusp.Click
        Dim nomeArq
        Dim path As String
        File.Exists(connection.PathString)
        path = My.Computer.FileSystem.ReadAllText(connection.PathString)
        OpenFileDialog.InitialDirectory = path + "\Arquivos\Advertencia"
        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            nomeArq = OpenFileDialog.FileName
            Arquivos.Explorer(nomeArq)
        End If
    End Sub

    Private Sub dgvAdvertencia_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAdvertencia.CellClick
        Dim y As Integer
        Try
            y = dgvAdvertencia.CurrentRow.Index

            vCodAdvSusp = dgvAdvertencia.Item(0, y).Value
            dtpAdv_Susp.Text = dgvAdvertencia.Item(1, y).Value
            rbAdv.Checked = dgvAdvertencia.Item(2, y).Value
            rbSusp.Checked = dgvAdvertencia.Item(3, y).Value
            txtDiasSusp.Text = dgvAdvertencia.Item(4, y).Value
            txtDiasSuspExt.Text = dgvAdvertencia.Item(5, y).Value
            dtpRetSusp.Text = dgvAdvertencia.Item(6, y).Value
            rtbMotivoAdvSusp.Text = dgvAdvertencia.Item(7, y).Value

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '>>>>>>>>>>>>>>>Fim AdvSusp<<<<<<<<<

    '>>>>>>>>>>>>Inicio Afastamento<<<<<
    Private Sub btnIncluir_Afast_Click(sender As Object, e As EventArgs) Handles btnIncluir_Afast.Click
        If mskCodigo.Enabled = False Then
            afastamento.Gravar(cmbMA.Text, dtpInicio_Afast.Text, dtpFinal_Afast.Text, dtpAfastRetorno.Text, rtbObsAfast.Text, dtpArq_Exa_Afast.Text, mskCodigo.Text)
            afastamento.AlterarContrato("status", "Afastado", mskCodigo.Text)
            cmbStatus.Text = dados.BuscarOutros(mskCodigo.Text, "status", "contratos")
            afastamento.CarregarGrade(mskCodigo.Text)
            limparAfastamento()
        Else
            MessageBox.Show("Selecione o Funcionário")
        End If

    End Sub

    Private Sub btnAlterar_Afast_Click(sender As Object, e As EventArgs) Handles btnAlterar_Afast.Click
        If vCodAfastamento > 0 Then
            afastamento.Alterar(cmbMA.Text, dtpInicio_Afast.Text, dtpFinal_Afast.Text, dtpAfastRetorno.Text, rtbObsAfast.Text, dtpArq_Exa_Afast.Text, vCodAfastamento)
            afastamento.AlterarContrato("status", "Afastado", mskCodigo.Text)
            cmbStatus.Text = dados.BuscarOutros(mskCodigo.Text, "status", "contratos")
            afastamento.CarregarGrade(mskCodigo.Text)
            limparAfastamento()
        Else
            MessageBox.Show("Selecione um registro")
        End If
    End Sub

    Private Sub btnExcluir_Afast_Click(sender As Object, e As EventArgs) Handles btnExcluir_Afast.Click
        If vCodAfastamento > 0 Then
            delete.Apagar(vCodAfastamento, "afastamentos")
            afastamento.AlterarContrato("status", "Ativo", mskCodigo.Text)
            cmbStatus.Text = dados.BuscarOutros(mskCodigo.Text, "status", "contratos")
            afastamento.CarregarGrade(mskCodigo.Text)
            Dim path As String
            Dim vNomeArq As String
            vNomeArq = mskCodigo.Text & "-" & vCodAfastamento
            File.Exists(connection.PathString)
            path = My.Computer.FileSystem.ReadAllText(connection.PathString)
            Arquivos.deleteArq("afastamentos", vNomeArq)
            limparAfastamento()
        Else
            MessageBox.Show("Selecione um registro para excluir")
        End If
    End Sub

    Private Sub dgvAfastamento_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAfastamento.CellClick
        Dim y As Integer
        Try
            y = dgvAfastamento.CurrentRow.Index

            vCodAfastamento = dgvAfastamento.Item(0, y).Value
            cmbMA.Text = dgvAfastamento.Item(1, y).Value
            dtpInicio_Afast.Text = dgvAfastamento.Item(2, y).Value
            dtpFinal_Afast.Text = dgvAfastamento.Item(3, y).Value
            dtpAfastRetorno.Text = dgvAfastamento.Item(4, y).Value
            rtbObsAfast.Text = dgvAfastamento.Item(5, y).Value
            dtpArq_Exa_Afast.Text = dgvAfastamento.Item(6, y).Value

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnGravarArq_Click(sender As Object, e As EventArgs) Handles btnGravarArq.Click
        If mskCodigo.Text <> "" Then
            Dim nomeArq
            OpenFileDialog.Filter = ("Text Files (*.pdf)|*.pdf")
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                nomeArq = OpenFileDialog.FileName
                Arquivos.saveArq(nomeArq, mskCodigo.Text, vCodAfastamento, "Afastamentos")
            End If
        Else
            MessageBox.Show("Selecione um registro para anexar arquivo")
        End If
    End Sub

    Private Sub btnAbrirArq_Click(sender As Object, e As EventArgs) Handles btnAbrirArq.Click
        If mskCodigo.Text <> "" Then
            Arquivos.openArq(mskCodigo.Text, vCodAfastamento, "Afastamentos")
        Else
            MessageBox.Show("Selecione um registro para abrir arquivo")
        End If
    End Sub

    Private Sub btnExplorarArq_Click(sender As Object, e As EventArgs) Handles btnExplorarArq.Click
        Dim nomeArq
        Dim path As String
        File.Exists(connection.PathString)
        path = My.Computer.FileSystem.ReadAllText(connection.PathString)
        OpenFileDialog.InitialDirectory = path + "\Arquivos\Afastamentos"
        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            nomeArq = OpenFileDialog.FileName
            Arquivos.Explorer(nomeArq)
        End If
    End Sub

    '>>>>>>>>>>>>Fim Afastamento<<<<<

    '>>>>>>>>>>>>Inicio Ferias<<<<<<<<<
    Private Sub btnIncluirFerias_Click(sender As Object, e As EventArgs) Handles btnIncluirFerias.Click

        If dtpFinal.Value <= dtpInicial.Value Then
            MessageBox.Show("Data final não pode ser menor ou igual a data inicial!")
            Return
        End If

        If dgvFerias.RowCount = 1 Then
            If mskCodigo.Enabled = False Then
                Dim vCheck As Integer
                Dim vCodFerias As Integer = ferias.Check(mskCodigo.Text)
                If vCodFerias <> Nothing Then
                    vCheck = 1
                    ferias.AlterarCheck(vCodFerias, vCheck)
                End If
                vCheck = 0
                ferias.Gravar(dtpInicial.Text, dtpFinal.Text, mskCodigo.Text, vCheck)
                ferias.CarregarGrade(mskCodigo.Text)
                ferias.AlterarCheck1(mskCodigo.Text)
                periodoFerias()
            Else
                MessageBox.Show("Selecione o Funcionário")
            End If
        Else
            Dim data As Date = dgvFerias.Item(2, dgvFerias.RowCount - 2).Value
            If data >= dtpInicial.Value Or dtpInicial.Value >= dtpFinal.Value Then
                MessageBox.Show("Data de inicio de férias é menor que a volta Do ultimo periodo de férias ou a data inicial é maior que a data final")
            Else
                If mskCodigo.Enabled = False Then
                    Dim vCheck As Integer
                    Dim vCodFerias As Integer = ferias.Check(mskCodigo.Text)
                    If vCodFerias <> Nothing Then
                        vCheck = 1
                        ferias.AlterarCheck(vCodFerias, vCheck)
                    End If
                    vCheck = 0
                    ferias.Gravar(dtpInicial.Text, dtpFinal.Text, mskCodigo.Text, vCheck)
                    ferias.CarregarGrade(mskCodigo.Text)
                    ferias.AlterarCheck1(mskCodigo.Text)
                    periodoFerias()
                Else
                    MessageBox.Show("Selecione o Funcionário")
                End If
            End If
        End If


    End Sub

    Private Sub btnAlterarFerias_Click(sender As Object, e As EventArgs) Handles btnAlterarFerias.Click

        If dtpFinal.Value <= dtpInicial.Value Then
            MessageBox.Show("Data final não pode ser menor ou igual a data inicial!")
            Return
        End If
        If vCodFerias > 0 Then
            ferias.Alterar(dtpInicial.Text, dtpFinal.Text, vCodFerias)
            ferias.CarregarGrade(mskCodigo.Text)
            periodoFerias()
        Else
            MessageBox.Show("Selecione um registro")
        End If
    End Sub

    Private Sub btnExcluirFerias_Click(sender As Object, e As EventArgs) Handles btnExcluirFerias.Click
        If vCodFerias > 0 Then
            delete.Apagar(vCodFerias, "ferias")
            ferias.CarregarGrade(mskCodigo.Text)
            Dim ultCodFerias As String = ferias.UltimoCodFerias(mskCodigo.Text)
            ferias.AlterarCheck2(ultCodFerias)
            periodoFerias()
        Else
            MessageBox.Show("Selecione um registro para excluir")
        End If
    End Sub

    Private Sub dgvFerias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFerias.CellClick
        Dim y As Integer
        Try
            y = dgvFerias.CurrentRow.Index

            vCodFerias = dgvFerias.Item(0, y).Value
            dtpInicial.Text = dgvFerias.Item(1, y).Value
            dtpFinal.Text = dgvFerias.Item(2, y).Value

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub periodoFerias()
        Dim data_ultima As Date
        If ferias.Ferias(mskCodigo.Text) <> Nothing Then
            data_ultima = ferias.Ferias(mskCodigo.Text)
            lblVencimento.Text = data_ultima.AddMonths(12).ToShortDateString
            lblLimite.Text = data_ultima.AddMonths(23).ToShortDateString
        Else
            lblVencimento.Text = dtpAdmissao.Value.AddMonths(12).ToShortDateString
            lblLimite.Text = dtpAdmissao.Value.AddMonths(23).ToShortDateString
        End If
    End Sub
    '>>>>>>>>>>>>Fim Ferias<<<<<<<<<

    '>>>>>>>>>>>>Inicio Recibo Pagamento<<<<
    Private Sub btnSavRecPag_Click(sender As Object, e As EventArgs) Handles btnSavRecPag.Click
        If mskCodigo.Enabled = False Then
            Dim provento, total As String
            provento = ReplaceCurrency(txtProvent.Text)
            total = ReplaceCurrency(txtTotal.Text)

            If rtbDesc.Text.Length > 90 Then
                MessageBox.Show("Quantidade de caracteres excedido")
                Return
            ElseIf rtbMens.Text.Length > 100 Then
                MessageBox.Show("Quantidade de caracteres excedido")
                Return
            End If
            If txtProvent.Text = "" Then
                txtProvent.Text = "0"
            ElseIf txtDesc.Text = "" Then
                txtDesc.Text = "0"
            ElseIf txtTotal.Text = "" Then
                txtTotal.Text = "0"
            End If
            reciboPagamento.Gravar(dtpRecibo_Pagamento.Text, rtbDesc.Text, rtbMens.Text, txtRef.Text, txtProvent.Text, txtDesc.Text, txtTotal.Text, mskCodigo.Text)
            reciboPagamento.CarregarGrade(mskCodigo.Text)
            limparReciboPagamento()
        Else
            MessageBox.Show("Selecione o Funcionário")
        End If
    End Sub

    Private Sub btnAltRecPag_Click(sender As Object, e As EventArgs) Handles btnAltRecPag.Click
        If vCodReciboPagamento > 0 Then
            Dim provento, total As String
            provento = ReplaceCurrency(txtProvent.Text)
            total = ReplaceCurrency(txtTotal.Text)

            If rtbDesc.Text.Length > 90 Then
                MessageBox.Show("Quantidade de caracteres excedido")
                Return
            ElseIf rtbMens.Text.Length > 100 Then
                MessageBox.Show("Quantidade de caracteres excedido")
                Return
            End If

            reciboPagamento.Alterar(dtpRecibo_Pagamento.Text, rtbDesc.Text, rtbMens.Text, txtRef.Text, txtProvent.Text, txtDesc.Text, txtTotal.Text, vCodReciboPagamento)
            reciboPagamento.CarregarGrade(mskCodigo.Text)
            limparReciboPagamento()
        Else
            MessageBox.Show("Selecione um registro")
        End If
    End Sub

    Private Sub btnExcRecPag_Click(sender As Object, e As EventArgs) Handles btnExcRecPag.Click
        If vCodReciboPagamento > 0 Then
            delete.Apagar(vCodReciboPagamento, "recibo_pagamentos")
            reciboPagamento.CarregarGrade(mskCodigo.Text)
            Dim path As String
            Dim vNomeArq As String
            vNomeArq = mskCodigo.Text & "-" & vCodReciboPagamento
            File.Exists(connection.PathString)
            path = My.Computer.FileSystem.ReadAllText(connection.PathString)
            Arquivos.deleteArq("Recibo de pagamento", vNomeArq)
            limparReciboPagamento()
        Else
            MessageBox.Show("Selecione um registro para excluir")
        End If
    End Sub

    Private Sub btnSavArqRecPag_Click(sender As Object, e As EventArgs) Handles btnSavArqRecPag.Click
        If mskCodigo.Text <> "" Then
            Dim nomeArq
            OpenFileDialog.Filter = ("Text Files (*.pdf)|*.pdf")
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                nomeArq = OpenFileDialog.FileName
                Arquivos.saveArq(nomeArq, mskCodigo.Text, vCodReciboPagamento, "Recibo de pagamento")
            End If
        Else
            MessageBox.Show("Selecione um registro para anexar arquivo")
        End If
    End Sub

    Private Sub btnAbrArqRecPag_Click(sender As Object, e As EventArgs) Handles btnAbrArqRecPag.Click
        If mskCodigo.Text <> "" Then
            Arquivos.openArq(mskCodigo.Text, vCodReciboPagamento, "Recibo de pagamento")
        Else
            MessageBox.Show("Selecione um registro para abrir arquivo")
        End If
    End Sub

    Private Sub btnProcArqRecPag_Click(sender As Object, e As EventArgs) Handles btnProcArqRecPag.Click
        Dim nomeArq
        Dim path As String
        File.Exists(connection.PathString)
        path = My.Computer.FileSystem.ReadAllText(connection.PathString)
        OpenFileDialog.InitialDirectory = path + "\Arquivos\Recibo de pagamento"
        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            nomeArq = OpenFileDialog.FileName
            Arquivos.Explorer(nomeArq)
        End If
    End Sub

    Private Sub txtDesc_TextChanged(sender As Object, e As EventArgs) Handles txtDesc.TextChanged
        If Not IsNumeric(txtDesc.Text) Then
            txtDesc.Text = ""
        ElseIf txtDesc.Text <> "" Then
            Dim desc As Double
            desc = txtDesc.Text / 100
            desc = desc * txtProvent.Text
            txtTotal.Text = FormatCurrency(txtProvent.Text - desc)
        Else
            txtTotal.Text = FormatCurrency(txtProvent.Text)
        End If
    End Sub

    Private Sub dgvReciboPagamento_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReciboPagamento.CellClick
        Dim y As Integer
        Try
            y = dgvReciboPagamento.CurrentRow.Index

            vCodReciboPagamento = dgvReciboPagamento.Item(0, y).Value
            dtpRecibo_Pagamento.Text = dgvReciboPagamento.Item(1, y).Value
            rtbDesc.Text = dgvReciboPagamento.Item(2, y).Value
            rtbMens.Text = dgvReciboPagamento.Item(3, y).Value
            txtRef.Text = dgvReciboPagamento.Item(4, y).Value
            txtProvent.Text = FormatCurrency(dgvReciboPagamento.Item(5, y).Value)
            txtDesc.Text = dgvReciboPagamento.Item(6, y).Value
            txtTotal.Text = FormatCurrency(dgvReciboPagamento.Item(7, y).Value)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    '>>>>>>>>>>>>Fim Recibo Pagamento<<<<<<<

    '>>>>>>>>>>>>Inicio T&D<<<<<<<<<
    Private Sub btnSavTD_Click(sender As Object, e As EventArgs) Handles btnSavTD.Click
        If mskCodigo.Enabled = False Then
            Dim cargTD As String = Replaces(mskCargTD.Text)
            Dim regTD As String = Replaces(mskRegTD.Text)
            td.Gravar(txtTreinamTD.Text, dtpTD.Text, cargTD, regTD, txtMinistTD.Text, mskCodigo.Text)
            td.CarregarGrade(mskCodigo.Text)
            limparTD()
        Else
            MessageBox.Show("Selecione o Funcionário")
        End If
    End Sub

    Private Sub btnAltTD_Click(sender As Object, e As EventArgs) Handles btnAltTD.Click
        If vCodTD > 0 Then
            Dim cargTD As String = Replaces(mskCargTD.Text)
            Dim regTD As String = Replaces(mskRegTD.Text)
            td.Alterar(txtTreinamTD.Text, dtpTD.Text, cargTD, regTD, txtMinistTD.Text, vCodTD)
            td.CarregarGrade(mskCodigo.Text)
            limparTD()
        Else
            MessageBox.Show("Selecione um registro")
        End If
    End Sub

    Private Sub btnExcTD_Click(sender As Object, e As EventArgs) Handles btnExcTD.Click
        If vCodTD > 0 Then
            delete.Apagar(vCodTD, "td")
            td.CarregarGrade(mskCodigo.Text)
            Dim path As String
            Dim vNomeArq As String
            vNomeArq = mskCodigo.Text & "-" & vCodTD
            File.Exists(connection.PathString)
            path = My.Computer.FileSystem.ReadAllText(connection.PathString)
            Arquivos.deleteArq("T&D", vNomeArq)
            limparTD()
        Else
            MessageBox.Show("Selecione um registro para excluir")
        End If
    End Sub

    Private Sub dgvTD_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTD.CellClick
        Dim y As Integer
        Try
            y = dgvTD.CurrentRow.Index

            vCodTD = dgvTD.Item(0, y).Value
            txtTreinamTD.Text = dgvTD.Item(1, y).Value
            dtpTD.Text = dgvTD.Item(2, y).Value
            mskCargTD.Text = dgvTD.Item(3, y).Value
            mskRegTD.Text = dgvTD.Item(4, y).Value
            txtMinistTD.Text = dgvTD.Item(5, y).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSavArqTD_Click(sender As Object, e As EventArgs) Handles btnSavArqTD.Click
        If mskCodigo.Text <> "" Then
            Dim nomeArq
            OpenFileDialog.Filter = ("Text Files (*.pdf)|*.pdf")
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                nomeArq = OpenFileDialog.FileName
                Arquivos.saveArq(nomeArq, mskCodigo.Text, vCodTD, "T&D")
            End If
        Else
            MessageBox.Show("Selecione um registro para anexar arquivo")
        End If

    End Sub

    Private Sub btnAbrArqTD_Click(sender As Object, e As EventArgs) Handles btnAbrArqTD.Click
        If mskCodigo.Text <> "" Then
            Arquivos.openArq(mskCodigo.Text, vCodTD, "T&D")
        Else
            MessageBox.Show("Selecione um registro para abrir arquivo")
        End If
    End Sub

    Private Sub btnProcArqTD_Click(sender As Object, e As EventArgs) Handles btnProcArqTD.Click
        If mskCodigo.Text <> "" Then
            Dim nomeArq
            Dim path As String
            File.Exists(connection.PathString)
            path = My.Computer.FileSystem.ReadAllText(connection.PathString)
            OpenFileDialog.InitialDirectory = path + "\Arquivos\T&D"
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                nomeArq = OpenFileDialog.FileName
                Arquivos.Explorer(nomeArq)
            End If
        Else
            MessageBox.Show("Selecione um registro")
        End If

    End Sub
    '>>>>>>>>>>>>Fim T&D<<<<<<<<<<<<

    '>>>>>>>>>Inicio Contribuição<<<
    Private Sub btnSavCont_Click(sender As Object, e As EventArgs) Handles btnSavCont.Click
        If mskCodigo.Enabled = False Then
            Dim valor As String
            valor = ReplaceCurrency(txtValorCont.Text)
            If valor = "" Then
                valor = 0
            End If
            contribuicao.Gravar(dtpCont.Text, cmbTipRecibo.Text, txtSindicato.Text, valor, mskCodigo.Text)
            contribuicao.CarregarGrade(mskCodigo.Text)
            limparContribuicao()
        Else
            MessageBox.Show("Selecione o Funcionário")
        End If
    End Sub

    Private Sub btnAltCont_Click(sender As Object, e As EventArgs) Handles btnAltCont.Click
        If vCodContribuicao > 0 Then
            Dim valor As String
            valor = ReplaceCurrency(txtValorCont.Text)

            contribuicao.Alterar(dtpCont.Text, cmbTipRecibo.Text, txtSindicato.Text, valor, vCodContribuicao)
            contribuicao.CarregarGrade(mskCodigo.Text)
            limparContribuicao()
        Else
            MessageBox.Show("Selecione um registro")
        End If
    End Sub

    Private Sub btnExcCont_Click(sender As Object, e As EventArgs) Handles btnExcCont.Click
        If vCodContribuicao > 0 Then
            delete.Apagar(vCodContribuicao, "contribuicoes")
            contribuicao.CarregarGrade(mskCodigo.Text)
            Dim path As String
            Dim vNomeArq As String
            vNomeArq = mskCodigo.Text & "-" & vCodContribuicao
            File.Exists(connection.PathString)
            path = My.Computer.FileSystem.ReadAllText(connection.PathString)
            Arquivos.deleteArq("contribuicao", vNomeArq)
            limparContribuicao()
        Else
            MessageBox.Show("Selecione um registro para excluir")
        End If
    End Sub
    Private Sub dgvCont_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCont.CellClick
        Dim y As Integer
        Try
            y = dgvCont.CurrentRow.Index

            vCodContribuicao = dgvCont.Item(0, y).Value
            dtpCont.Text = dgvCont.Item(1, y).Value
            cmbTipRecibo.Text = dgvCont.Item(2, y).Value
            txtSindicato.Text = dgvCont.Item(3, y).Value
            txtValorCont.Text = FormatCurrency(dgvCont.Item(4, y).Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSavArqCont_Click(sender As Object, e As EventArgs) Handles btnSavArqCont.Click
        If mskCodigo.Text <> "" Then
            Dim nomeArq
            OpenFileDialog.Filter = ("Text Files (*.pdf)|*.pdf")
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                nomeArq = OpenFileDialog.FileName
                Arquivos.saveArq(nomeArq, mskCodigo.Text, vCodContribuicao, "Contribuicao")
            End If
        Else
            MessageBox.Show("Selecione um registro para anexar arquivo")
        End If
    End Sub

    Private Sub btnAbrArqCont_Click(sender As Object, e As EventArgs) Handles btnAbrArqCont.Click
        If mskCodigo.Text <> "" Then
            Arquivos.openArq(mskCodigo.Text, vCodContribuicao, "Contribuicao")
        Else
            MessageBox.Show("Selecione um registro para abrir arquivo")
        End If
    End Sub
    Private Sub btnProcArqCont_Click_1(sender As Object, e As EventArgs) Handles btnProcArqCont.Click
        If mskCodigo.Text <> "" Then
            Dim nomeArq
            Dim path As String
            File.Exists(connection.PathString)
            path = My.Computer.FileSystem.ReadAllText(connection.PathString)
            OpenFileDialog.InitialDirectory = path + "\Arquivos\Contribuicao"
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                nomeArq = OpenFileDialog.FileName
                Arquivos.Explorer(nomeArq)
            End If
        Else
            MessageBox.Show("Selecione um registro")
        End If
    End Sub

    Private Sub btnProcArqCont_Click(sender As Object, e As EventArgs) Handles btnProcCont.Click
        Dim nomeArq
        Dim path As String
        File.Exists(connection.PathString)
        path = My.Computer.FileSystem.ReadAllText(connection.PathString)
        OpenFileDialog.InitialDirectory = path + "\Arquivos\Contribuicao"
        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            nomeArq = OpenFileDialog.FileName
            Arquivos.Explorer(nomeArq)
        End If
    End Sub
    '>>>>>>>>>Fim Contribuição<<<

    Private Sub rbValeT_CheckedChanged(sender As Object, e As EventArgs) Handles rbValeT.CheckedChanged
        If rbValeT.Checked = True Then
            txtCombustivel.Text = ""
            txtCombustivel.Enabled = False

            cmbBilhete1.Enabled = True
            cmbBilhete2.Enabled = True
            cmbBilhete3.Enabled = True
            txtVT1.Enabled = True
            txtVT2.Enabled = True
            txtVT3.Enabled = True
        End If

    End Sub

    Private Sub rbAuxComb_CheckedChanged(sender As Object, e As EventArgs) Handles rbAuxComb.CheckedChanged
        If rbAuxComb.Checked = True Then
            cmbBilhete1.Text = ""
            cmbBilhete1.Enabled = False
            cmbBilhete2.Text = ""
            cmbBilhete2.Enabled = False
            cmbBilhete3.Text = ""
            cmbBilhete3.Enabled = False
            txtVT1.Text = ""
            txtVT1.Enabled = False
            txtVT2.Text = ""
            txtVT2.Enabled = False
            txtVT3.Text = ""
            txtVT3.Enabled = False

            txtCombustivel.Enabled = True
        End If
    End Sub

    Private Function ReplaceCurrency(val As String) As String
        val = val.Replace("R$", "")
        Return val
    End Function

    Private Function Lost_Focus(vTest As String) As String
        vTest = ReplaceCurrency(vTest)
        If vTest = "" Then vTest = 0
        If Not IsNumeric(vTest) Then
            MessageBox.Show("Formato incorreto!")
            Return ""
        Else
            If Len(vTest) <= 10 Then
                vTest = (Decimal.Parse(vTest)).ToString("C")
                Return FormatCurrency(vTest)
            Else
                MessageBox.Show("Tamanho maximo exedido!")
                Return ""
            End If
        End If
    End Function

    Private Sub txtBase_GotFocus(sender As Object, e As EventArgs) Handles txtBase.GotFocus
        txtBase.Text = ""
    End Sub

    Private Sub txtBase_LostFocus(sender As Object, e As EventArgs) Handles txtBase.LostFocus
        Dim vTest As String = Lost_Focus(txtBase.Text)

        If vTest <> "" Then
            txtBase.Text = vTest
        Else
            txtBase.Text = ""
        End If
    End Sub

    Private Sub txtVT1_GotFocus(sender As Object, e As EventArgs) Handles txtVT1.GotFocus
        txtVT1.Text = ""
    End Sub

    Private Sub txtVT1_LostFocus(sender As Object, e As EventArgs) Handles txtVT1.LostFocus
        Dim vTest As String = Lost_Focus(txtVT1.Text)

        If vTest <> "" Then
            txtVT1.Text = vTest
        Else
            txtVT1.Text = ""
        End If
    End Sub

    Private Sub txtVT1_Keydown(sender As Object, e As KeyEventArgs) Handles txtVT1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVT1_LostFocus(sender, e)
        End If
    End Sub

    Private Sub txtVT2_GotFocus(sender As Object, e As EventArgs) Handles txtVT2.GotFocus
        txtVT2.Text = ""
    End Sub

    Private Sub txtVT2_LostFocus(sender As Object, e As EventArgs) Handles txtVT2.LostFocus
        Dim vTest As String = Lost_Focus(txtVT2.Text)

        If vTest <> "" Then
            txtVT2.Text = vTest
        Else
            txtVT2.Text = ""
        End If
    End Sub

    Private Sub txtVT2_Keydown(sender As Object, e As KeyEventArgs) Handles txtVT2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVT2_LostFocus(sender, e)
        End If
    End Sub

    Private Sub txtVT3_GotFocus(sender As Object, e As EventArgs) Handles txtVT3.GotFocus
        txtVT3.Text = ""
    End Sub

    Private Sub txtVT3_Keydown(sender As Object, e As KeyEventArgs) Handles txtVT3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVT3_LostFocus(sender, e)
        End If
    End Sub

    Private Sub txtVT3_LostFocus(sender As Object, e As EventArgs) Handles txtVT3.LostFocus
        Dim vTest As String = Lost_Focus(txtVT3.Text)

        If vTest <> "" Then
            txtVT3.Text = vTest
        Else
            txtVT3.Text = ""
        End If
    End Sub

    Private Sub txtCombustivel_GotFocus(sender As Object, e As EventArgs) Handles txtCombustivel.GotFocus
        txtCombustivel.Text = ""
    End Sub

    Private Sub txtCombustivel_LostFocus(sender As Object, e As EventArgs) Handles txtCombustivel.LostFocus
        Dim vTest As String = Lost_Focus(txtCombustivel.Text)

        If vTest <> "" Then
            txtCombustivel.Text = vTest
        Else
            txtCombustivel.Text = ""
        End If
    End Sub

    Private Sub txtCombustivel_Keydown(sender As Object, e As KeyEventArgs) Handles txtCombustivel.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCombustivel_LostFocus(sender, e)
        End If
    End Sub

    Private Sub txtVR_GotFocus(sender As Object, e As EventArgs) Handles txtVR.GotFocus
        txtVR.Text = ""
    End Sub

    Private Sub txtVR_LostFocus(sender As Object, e As EventArgs) Handles txtVR.LostFocus
        Dim vTest As String = Lost_Focus(txtVR.Text)

        If vTest <> "" Then
            txtVR.Text = vTest
        Else
            txtVR.Text = ""
        End If
    End Sub

    Private Sub txtVR_Keydown(sender As Object, e As KeyEventArgs) Handles txtVR.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVR_LostFocus(sender, e)
        End If
    End Sub

    Private Sub txtVA_GotFocus(sender As Object, e As EventArgs) Handles txtVA.GotFocus
        txtVA.Text = ""
    End Sub

    Private Sub txtVA_LostFocus(sender As Object, e As EventArgs) Handles txtVA.LostFocus
        Dim vTest As String = Lost_Focus(txtVA.Text)

        If vTest <> "" Then
            txtVA.Text = vTest
        Else
            txtVA.Text = ""
        End If
    End Sub

    Private Sub txtVA_Keydown(sender As Object, e As KeyEventArgs) Handles txtVA.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVA_LostFocus(sender, e)
        End If
    End Sub

    Private Sub txtValorUniforme_GotFocus(sender As Object, e As EventArgs) Handles txtValorUniforme.GotFocus
        txtValorUniforme.Text = ""
    End Sub

    Private Sub txtValorUniforme_LostFocus(sender As Object, e As EventArgs) Handles txtValorUniforme.LostFocus
        Dim vTest As String = Lost_Focus(txtValorUniforme.Text)

        If vTest <> "" Then
            txtValorUniforme.Text = vTest
        Else
            txtValorUniforme.Text = ""
        End If
    End Sub

    Private Sub txtPensAliment_GotFocus(sender As Object, e As EventArgs) Handles txtPensAliment.GotFocus
        txtPensAliment.Text = ""
    End Sub

    Private Sub txtPensAliment_LostFocus(sender As Object, e As EventArgs) Handles txtPensAliment.LostFocus
        Dim vTest As String = Lost_Focus(txtPensAliment.Text)

        If vTest <> "" Then
            txtPensAliment.Text = vTest
        Else
            txtPensAliment.Text = ""
        End If
    End Sub

    Private Sub txtPensAliment_Keydown(sender As Object, e As KeyEventArgs) Handles txtPensAliment.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPensAliment_LostFocus(sender, e)
        End If
    End Sub

    Private Sub txtProvent_GotFocus(sender As Object, e As EventArgs) Handles txtProvent.GotFocus
        txtProvent.Text = ""
    End Sub

    Private Sub txtProvent_LostFocus(sender As Object, e As EventArgs) Handles txtProvent.LostFocus
        Dim vTest As String = Lost_Focus(txtProvent.Text)

        If vTest <> "" Then
            txtProvent.Text = vTest
        Else
            txtProvent.Text = ""
        End If
    End Sub

    Private Sub txtProvent_Keydown(sender As Object, e As KeyEventArgs) Handles txtProvent.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtProvent_LostFocus(sender, e)
        End If
    End Sub

    Private Sub txtValorCont_GotFocus(sender As Object, e As EventArgs) Handles txtValorCont.GotFocus
        txtValorCont.Text = ""
    End Sub

    Private Sub txtValorCont_LostFocus(sender As Object, e As EventArgs) Handles txtValorCont.LostFocus
        Dim vTest As String = Lost_Focus(txtValorCont.Text)

        If vTest <> "" Then
            txtValorCont.Text = vTest
        Else
            txtValorCont.Text = ""
        End If
    End Sub

    Private Sub txtValorCont_Keydown(sender As Object, e As KeyEventArgs) Handles txtValorCont.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtValorCont_LostFocus(sender, e)
        End If
    End Sub

    Private Sub btnFiltrarEmpresa_Click(sender As Object, e As EventArgs) Handles btnFiltrarEmpresa.Click
        If cmbEmpresa.Text <> "" Then
            dados.CarregarEmpresa(vCodEmpresas)
            dgvFuncionarios.Visible = True
            Resize_DGV_Columns()
        Else
            MessageBox.Show("Escolha a empresa para filtrar!")
        End If
    End Sub

    Private Sub btnFiltrarNome_Click(sender As Object, e As EventArgs) Handles btnFiltrarNome.Click
        If txtNome.Text <> "" Then
            dados.BuscarNome(txtNome.Text)
            dgvFuncionarios.Visible = True
            Resize_DGV_Columns()
        End If
    End Sub

    Private Sub btnFiltNasc_Click(sender As Object, e As EventArgs) Handles btnFiltNasc.Click
        dados.CarregarNascimento(dtpNasc.Text)
        dgvFuncionarios.Visible = True
        Resize_DGV_Columns()
    End Sub

    Private Sub btnFiltrarStatus_Click(sender As Object, e As EventArgs) Handles btnFiltrarStatus.Click
        If cmbStatus.Text <> "" Then
            dados.CarregarStatus(cmbStatus.Text)
            dgvFuncionarios.Visible = True
            Resize_DGV_Columns()
        Else
            MessageBox.Show("Escolha um status para filtrar!")
        End If
    End Sub

    Public Sub carregaComboEmpresa()
        cmbEmpresa.Items.Clear()
        cmbEmpresa.Items.Add("")
        empresa.CarregaCombo()
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        If cmbEmpresa.Text <> "" Then
            vCodEmpresas = empresa.BuscarEmpresa(cmbEmpresa.Text, "codigo", "empresas")
            mskEnpEndereco.Text = empresa.BuscarEmpresa(cmbEmpresa.Text, "endereco", "empresas")
            mskEnpNumero.Text = empresa.BuscarEmpresa(cmbEmpresa.Text, "numero", "empresas")
            mskEnpCNPJ.Text = empresa.BuscarEmpresa(cmbEmpresa.Text, "cnpj", "empresas")
            mskEnpCEP.Text = empresa.BuscarEmpresa(cmbEmpresa.Text, "cep", "empresas")
            mskEnpInsc.Text = empresa.BuscarEmpresa(cmbEmpresa.Text, "Insc_Estadual", "empresas")
        End If
    End Sub

    Private Sub cmbEmpresa_Click(sender As Object, e As EventArgs) Handles cmbEmpresa.Click
        carregaComboEmpresa()
        ClearEmpresa()
    End Sub

    Private Sub ClearEmpresa()
        mskEnpEndereco.Text = ""
        mskEnpNumero.Text = ""
        mskEnpCNPJ.Text = ""
        mskEnpCEP.Text = ""
        mskEnpInsc.Text = ""
    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged
        If Not IsNumeric(txtNumero.Text) Then
            txtNumero.Text = ""
        End If
    End Sub

    Private Sub dtpNasc_LostFocus(sender As Object, e As EventArgs) Handles dtpNasc.LostFocus
        OldCalc()
    End Sub

    Private Function OldCalc() As Boolean
        Dim vNascimento As Date
        Dim cont As Double = 0

        vNascimento = dtpNasc.Value

        While vNascimento < Now
            vNascimento = vNascimento.AddDays(1)
            cont = cont + 1
        End While
        cont = (cont - 1) / 365
        If cont < 15 Then
            MessageBox.Show("Idade muito baixa para ser cadastrada!")
            lblIdade.Text = "Idade"
            Return False
        Else
            lblIdade.Text = cont.ToString.Substring(0, 2)
            Return True
        End If
    End Function

    Private Sub btnPrintUniforme_Click(sender As Object, e As EventArgs) Handles btnPrintUniforme.Click
        If dgvUniformes.RowCount > 0 Then
            frmPrinter.docToPrint.DefaultPageSettings.Landscape = False
            frmPrinter.lblPrinter.Text = "Uniformes"
            frmPrinter.Show()
            frmPrinter.Focus()
        End If
    End Sub

    Private Sub btnPrintAdvSusp_Click(sender As Object, e As EventArgs) Handles btnPrintAdvSusp.Click
        If rbSusp.Checked = True Then
            Printer.PrintSusp()
        ElseIf rbAdv.Checked = True Then
            Printer.PrintAdv()
        Else
            MessageBox.Show("Selecione um registro")
        End If
    End Sub

    Private Sub btnPrintTD_Click(sender As Object, e As EventArgs) Handles btnPrintTD.Click
        If txtTreinamTD.Text <> "" Then
            frmPrinter.docToPrint.DefaultPageSettings.Landscape = True
            PrintDialog.AllowSomePages = True
            PrintDialog.ShowHelp = True

            Dim result As DialogResult = PrintDialog.ShowDialog()
            If (result = DialogResult.OK) Then
                frmPrinter.lblPrinter.Text = "TD"
                frmPrinter.docToPrint.Print()
            End If
        End If
    End Sub

    Private Sub txtRegHabilit_TextChanged(sender As Object, e As EventArgs) Handles txtRegHabilit.TextChanged
        If Not IsNumeric(txtRegHabilit.Text) Then
            txtRegHabilit.Text = ""
        End If
    End Sub

    Private Sub txtBase_TextChanged(sender As Object, e As EventArgs) Handles txtBase.TextChanged
        If Not IsNumeric(txtBase.Text) Then
            txtBase.Text = ""
        End If
    End Sub

    Private Sub txtDias1Exp_TextChanged(sender As Object, e As EventArgs) Handles txtDias1Exp.TextChanged
        If Not IsNumeric(txtDias1Exp.Text) Then
            txtDias1Exp.Text = ""
        End If
    End Sub

    Private Sub txtDias2Exp_TextChanged(sender As Object, e As EventArgs) Handles txtDias2Exp.TextChanged
        If Not IsNumeric(txtDias2Exp.Text) Then
            txtDias2Exp.Text = ""
        End If
    End Sub

    Private Sub txtPensAliment_TextChanged(sender As Object, e As EventArgs) Handles txtPensAliment.TextChanged
        If Not IsNumeric(txtPensAliment.Text) Then
            txtPensAliment.Text = ""
        End If
    End Sub

    Private Sub txtqtdeEPI_TextChanged(sender As Object, e As EventArgs) Handles txtqtdeEPI.TextChanged
        If Not IsNumeric(txtqtdeEPI.Text) Then
            txtqtdeEPI.Text = ""
        End If
    End Sub

    Private Sub txtTotal_TextChanged(sender As Object, e As EventArgs) Handles txtTotal.TextChanged
        If Not IsNumeric(txtTotal.Text) Then
            txtTotal.Text = ""
        End If
    End Sub

    Private Sub txtBase_Keydown(sender As Object, e As KeyEventArgs) Handles txtBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBase_LostFocus(sender, e)
        End If
    End Sub

    Private Sub btnPrintRecibo_Click(sender As Object, e As EventArgs) Handles btnPrintRecibo.Click
        If txtRef.Text <> "" Then
            frmPrinter.docToPrint.DefaultPageSettings.Landscape = True
            PrintDialog.AllowSomePages = True
            PrintDialog.ShowHelp = True

            Dim result As DialogResult = PrintDialog.ShowDialog()
            If (result = DialogResult.OK) Then
                frmPrinter.lblPrinter.Text = "ReciboPagamento"
                frmPrinter.docToPrint.Print()
            End If
        End If
    End Sub

    Private Sub cmbSexo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSexo.SelectedIndexChanged
        If cmbSexo.Text = "Masculino" Then
            gbReservista.Enabled = True
        Else
            gbReservista.Enabled = False
        End If
    End Sub

    Private Sub rbAdv_CheckedChanged(sender As Object, e As EventArgs) Handles rbAdv.CheckedChanged
        If rbAdv.Checked = True Then
            txtDiasSusp.Enabled = False
            txtDiasSuspExt.Enabled = False
        Else
            txtDiasSusp.Enabled = True
            txtDiasSuspExt.Enabled = True
        End If
    End Sub

    Private Sub txtDiasSusp_TextChanged(sender As Object, e As EventArgs) Handles txtDiasSusp.TextChanged
        If Not IsNumeric(txtDiasSusp.Text) Then
            txtDiasSusp.Text = ""
            dtpRetSusp.Text = ""
        ElseIf txtDiasSusp.Text <> "" Then
            Dim retorno As Date = dtpRetSusp.Text
            dtpRetSusp.Text = retorno.AddDays(txtDiasSusp.Text)
        End If
    End Sub

    Private Sub txtDias_TextChanged(sender As Object, e As EventArgs) Handles txtDias.TextChanged
        If txtDias.Text <> "" Then
            Dim data As Date = dtpAtestadoRet.Text
            dtpAtestadoRet.Text = data.AddDays(txtDias.Text)
        ElseIf txtDias.Text = "" Then
            dtpAtestadoRet.Text = ""
        End If
    End Sub

    Private Sub btnFiltrarDepart_Click(sender As Object, e As EventArgs) Handles btnFiltrarDepart.Click
        If txtDepartamento.Text <> "" Then
            Dim vCod As Integer = dados.BuscarByDepartamento(txtDepartamento.Text)
            dados.CarregarByDepart(vCod)
            dgvFuncionarios.Visible = True
        End If
    End Sub

    Private Sub btnSalvarTexto_Click(sender As Object, e As EventArgs) Handles btnSalvarTexto.Click

        If MsgBox("Deseja realmentente salvar?", vbYesNo, "Confirmação") = vbNo Then Return

        If mskCodigo.Text <> "" And mskCodigo.Enabled = False Then
            Dim dir As New SaveFileDialog
            Dim path As String

            If File.Exists(connection.PathString) Then
                path = My.Computer.FileSystem.ReadAllText(connection.PathString)
                dir.FileName = path + "\Arquivos\Relatorios\" + mskCodigo.Text
                Using sw As New StreamWriter(dir.FileName)
                    sw.Write(rtbRelatorio.Text)
                    sw.Close()
                End Using
                MessageBox.Show("Salvo!")
            Else
                MessageBox.Show("Caminho não encontrado!")
            End If
        Else
            MessageBox.Show("Cadastre o funcionarios antes de de gravar um relatorio!")
        End If
    End Sub

    Private Sub btnAbrirRelat_Click(sender As Object, e As EventArgs) Handles btnAbrirRelat.Click
        If mskCodigo.Text <> "" And mskCodigo.Enabled = False Then
            Dim path As String
            If File.Exists(connection.PathString) Then
                path = My.Computer.FileSystem.ReadAllText(connection.PathString)
                path = path + "\Arquivos\Relatorios\" + mskCodigo.Text
                Try
                    rtbRelatorio.Text = My.Computer.FileSystem.ReadAllText(path)
                Catch ex As Exception
                    MessageBox.Show("Erro ao abrir o arquivo!")
                End Try
            End If
        Else
            MessageBox.Show("Busque o funcionarios antes de de buscar um relatorio!")
        End If

    End Sub

    Private Sub btnAlterarHabilit_Click(sender As Object, e As EventArgs) Handles btnAlterarHabilit.Click
        habilitacao.Alterar(txtRegHabilit.Text, dtp1habilit.Text, cmbCatHabilit.Text, dtpValHabilitacao.Text, vCodHabilit)
        habilitacao.CarregarGrade(mskCodigo.Text)
    End Sub

    Private Sub btnExcluirHabilit_Click(sender As Object, e As EventArgs) Handles btnExcluirHabilit.Click
        delete.Apagar(vCodHabilit.ToString, "habilitacao")
        habilitacao.CarregarGrade(mskCodigo.Text)
    End Sub

    Private Sub btnPrintEPI_Click(sender As Object, e As EventArgs) Handles btnPrintEPI.Click
        If txtNomeEPI.Text <> "" Then
            Printer.PrintEPI()
        End If
    End Sub

    Private Sub rbAfastSim_CheckedChanged(sender As Object, e As EventArgs) Handles rbAfastSim.CheckedChanged
        If rbAfastSim.Checked = True Then
            txtDias.Enabled = True
        Else
            txtDias.Enabled = False
        End If
    End Sub

    Private Sub btnSalvarCAT_Click(sender As Object, e As EventArgs) Handles btnSalvarCAT.Click
        Dim numCAT As String = Replaces(msknumCAT.Text)
        If vCodAtestado <> 0 Then
            cat.Gravar(numCAT, txtEmitente.Text, txtEmailCat.Text, txttipoCAT.Text, txtFiliacao.Text, dtpEmissaoCAT.Text, txtComObito.Text, dtpCAT.Text, mskHora.Text, mskHorasTrabalho.Text, txtTipoAcidente.Text, cmbAfastamento.Text, cmbRegPolicial.Text, txtLocal.Text, txtExpLocal.Text, txtCGC.Text, cmbUFacidente.Text, txtMunAcidente.Text, dtpUltDia.Text, txtPtCorpo.Text, txtAgCausador.Text, txtAgCausador.Text, cmbMorte.Text, mskObito.Text, mskCodigo.Text, vCodAtestado)
            If cmbAfastamento.Text = "Sim" Then
                cat.AltContrato("Afastado", mskCodigo.Text)
            End If
            cat.CarregarGrade(mskCodigo.Text)
            limparCAT()
        Else
            MessageBox.Show("Selecione um atestado antes de gravar o CAT, entre na aba de 'Atestados' e logo apos selecione o atestado referente ao CAT, então retorne para a aba 'CAT'.")
        End If
    End Sub


    Private Sub dgvCAT_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCAT.CellClick
        Dim y As Integer
        Try
            y = dgvCAT.CurrentRow.Index
            vCodCAT = dgvCAT.Item(0, y).Value
            msknumCAT.Text = dgvCAT.Item(1, y).Value
            txtEmitente.Text = dgvCAT.Item(2, y).Value
            txtEmailCat.Text = dgvCAT.Item(3, y).Value
            txttipoCAT.Text = dgvCAT.Item(4, y).Value
            txtFiliacao.Text = dgvCAT.Item(5, y).Value
            dtpEmissaoCAT.Text = dgvCAT.Item(6, y).Value
            txtComObito.Text = dgvCAT.Item(7, y).Value
            dtpCAT.Text = dgvCAT.Item(8, y).Value
            mskHora.Text = dgvCAT.Item(9, y).Value
            mskHorasTrabalho.Text = dgvCAT.Item(10, y).Value
            txtTipoAcidente.Text = dgvCAT.Item(11, y).Value
            cmbAfastamento.Text = dgvCAT.Item(12, y).Value
            cmbRegPolicial.Text = dgvCAT.Item(13, y).Value
            txtLocal.Text = dgvCAT.Item(14, y).Value
            txtExpLocal.Text = dgvCAT.Item(15, y).Value
            txtCGC.Text = dgvCAT.Item(16, y).Value
            cmbUFacidente.Text = dgvCAT.Item(17, y).Value
            txtMunAcidente.Text = dgvCAT.Item(18, y).Value
            dtpUltDia.Text = dgvCAT.Item(19, y).Value
            txtPtCorpo.Text = dgvCAT.Item(20, y).Value
            txtAgCausador.Text = dgvCAT.Item(21, y).Value
            txtSitGerador.Text = dgvCAT.Item(22, y).Value
            cmbMorte.Text = dgvCAT.Item(23, y).Value
            mskObito.Text = dgvCAT.Item(24, y).Value
            vCodAtestado = dgvCAT.Item(26, y).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmbMorte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMorte.SelectedIndexChanged
        If cmbMorte.Text = "Sim" Then
            mskObito.Enabled = True
        Else
            mskObito.Enabled = False
        End If
    End Sub

    Private Sub btnAlterarCAT_Click(sender As Object, e As EventArgs) Handles btnAlterarCAT.Click
        If vCodCAT <> 0 Then
            Dim numCAT As String = Replaces(msknumCAT.Text)
            cat.Alterar(numCAT, txtEmitente.Text, txtEmailCat.Text, txttipoCAT.Text, txtFiliacao.Text, dtpEmissaoCAT.Text, txtComObito.Text, dtpCAT.Text, mskHora.Text, mskHorasTrabalho.Text, txtTipoAcidente.Text, cmbAfastamento.Text, cmbRegPolicial.Text, txtLocal.Text, txtExpLocal.Text, txtCGC.Text, cmbUFacidente.Text, txtMunAcidente.Text, dtpUltDia.Text, txtPtCorpo.Text, txtAgCausador.Text, txtSitGerador.Text, cmbMorte.Text, mskObito.Text, vCodCAT)
            cat.CarregarGrade(mskCodigo.Text)
        Else
            MessageBox.Show("Selecione um registro")
        End If
        limparCAT()
    End Sub

    Private Sub btnExcluirCAT_Click(sender As Object, e As EventArgs) Handles btnExcluirCAT.Click
        If vCodCAT <> 0 Then
            delete.Apagar(vCodCAT, "cat")
            cat.CarregarGrade(mskCodigo.Text)
            Dim path As String
            Dim vNomeArq As String
            vNomeArq = mskCodigo.Text & "-" & vCodCAT
            File.Exists(connection.PathString)
            path = My.Computer.FileSystem.ReadAllText(connection.PathString)
            Arquivos.deleteArq("cat", vNomeArq)
        Else
            MessageBox.Show("Selecione um registro")
        End If
        limparCAT()
    End Sub

    Private Sub btnAnexCAT_Click(sender As Object, e As EventArgs) Handles btnAnexCAT.Click
        If vCodCAT > 0 Then
            Dim nomeArq
            OpenFileDialog.Filter = ("Text Files (*.pdf)|*.pdf")
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                nomeArq = OpenFileDialog.FileName
                Arquivos.saveArq(nomeArq, mskCodigo.Text, vCodCAT, "CAT")
            End If
        Else
            MessageBox.Show("Selecione um registro para anexar arquivo")
        End If
    End Sub

    Private Sub btnAbrCAT_Click(sender As Object, e As EventArgs) Handles btnAbrCAT.Click
        If vCodCAT > 0 Then
            Arquivos.openArq(mskCodigo.Text, vCodCAT, "CAT")
        Else
            MessageBox.Show("Selecione um registro para abrir arquivo")
        End If
    End Sub

    Private Sub btnProCAT_Click(sender As Object, e As EventArgs) Handles btnProCAT.Click
        Dim nomeArq
        Dim path As String
        File.Exists(connection.PathString)
        path = My.Computer.FileSystem.ReadAllText(connection.PathString)
        OpenFileDialog.InitialDirectory = path + "\Arquivos\CAT"
        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            nomeArq = OpenFileDialog.FileName
            Arquivos.Explorer(nomeArq)
        End If
    End Sub

    Private Sub btnPrinCAT_Click(sender As Object, e As EventArgs) Handles btnPrinCAT.Click
        Printer.PrintCAT()
    End Sub
End Class

