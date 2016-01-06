Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Printer
    Dim Connection As New Connection
    Dim delete As New Delete
    Dim dados As New Dados
    Dim empresa As New Empresas
    Dim departamentos As New Departamentos
    Dim cat As New Cat
    Dim vCodEmpresas As Integer
    Public departamentos_codigo As Integer
    Public WithEvents document As New System.Drawing.Printing.PrintDocument
    Private objWord As Object
    Private objWord2 As Object
    Private achar As String
    Private substituir As String

    Public Sub connect_base()
        Connection.Connection()
    End Sub
    Private Function nomeData(data As Date) As String
        Dim mes As String = ""
        If data.Month.ToString = "1" Then
            mes = "Janeiro"
        ElseIf data.Month.ToString = "2" Then
            mes = "Fevereiro"
        ElseIf data.Month.ToString = "3" Then
            mes = "Março"
        ElseIf data.Month.ToString = "4" Then
            mes = "Abril"
        ElseIf data.Month.ToString = "5" Then
            mes = "Maio"
        ElseIf data.Month.ToString = "6" Then
            mes = "Junho"
        ElseIf data.Month.ToString = "7" Then
            mes = "Julho"
        ElseIf data.Month.ToString = "8" Then
            mes = "Agosto"
        ElseIf data.Month.ToString = "9" Then
            mes = "Setembro"
        ElseIf data.Month.ToString = "10" Then
            mes = "Outubro"
        ElseIf data.Month.ToString = "11" Then
            mes = "Novembro"
        ElseIf data.Month.ToString = "12" Then
            mes = "Dezembro"
        End If
        Return mes
    End Function

    Public Sub PrintPage_Funcionario(e As System.Drawing.Printing.PrintPageEventArgs, r As Integer)
        Dim printFont As New System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular)
        Dim g As Integer = 0 'frmFuncionarios.dgvFuncionarios.CurrentRow.Index
        Dim y As Integer = 60
        Dim x As Integer = 9

        Dim path As String
        If File.Exists(Connection.PathString) Then
            path = My.Computer.FileSystem.ReadAllText(Connection.PathString) + "\fotos\logo.png"
            '     e.Graphics.DrawImage(Image.FromFile(path), 10, 10, width:=140, height:=50)
        Else
            MessageBox.Show("Caminho do logo não encontrado na rede! ")
        End If

        e.Graphics.DrawString("RELATÓRIO DE FUNCIONÁRIOS", New Font("Verdana", 15, FontStyle.Regular), Brushes.Black, 200, y - 40)
        e.Graphics.DrawString("GIPP:", New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, 698, y - 40)
        e.Graphics.DrawString(Now.ToShortDateString, New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, 735, y - 40)
        'codigo,nome,empresa,data_nascimento,cpf,centro_custo,cargo
        e.Graphics.DrawString("Cod", New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, 10, y)
        e.Graphics.DrawString("Nome", New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, 100, y)
        e.Graphics.DrawString("Empresa", New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, 212, y)
        e.Graphics.DrawString("Nascimento", New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, 280, y)
        e.Graphics.DrawString("CPF", New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, 370, y)
        e.Graphics.DrawString("Centro Custo", New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, 445, y)
        e.Graphics.DrawString("Cargo", New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, 560, y)
        While x < 800
            e.Graphics.DrawString("_", New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, x, y + 5)
            x = x + 5
        End While
        x = 9
        y = 78
        While g < frmPrinter.dgvPrinter.RowCount
            e.Graphics.DrawString("|", New Font("Verdana", 8, FontStyle.Regular), Brushes.Black, x - 2, y)
            e.Graphics.DrawString((frmPrinter.dgvPrinter.Item(1, g).Value), New Font("Verdana", 6, FontStyle.Regular), Brushes.Black, x + 3, y + 3)

            e.Graphics.DrawString("|", New Font("Verdana", 8, FontStyle.Regular), Brushes.Black, x + 30, y)
            e.Graphics.DrawString((frmPrinter.dgvPrinter.Item(2, g).Value), New Font("Verdana", 6, FontStyle.Regular), Brushes.Black, x + 35, y + 3)

            e.Graphics.DrawString("|", New Font("Verdana", 8, FontStyle.Regular), Brushes.Black, x + 200, y)
            e.Graphics.DrawString((frmPrinter.dgvPrinter.Item(3, g).Value), New Font("Verdana", 6, FontStyle.Regular), Brushes.Black, x + 205, y + 3)

            e.Graphics.DrawString("|", New Font("Verdana", 8, FontStyle.Regular), Brushes.Black, x + 265, y)
            e.Graphics.DrawString((frmPrinter.dgvPrinter.Item(4, g).Value), New Font("Verdana", 6, FontStyle.Regular), Brushes.Black, x + 270, y + 3)

            e.Graphics.DrawString("|", New Font("Verdana", 8, FontStyle.Regular), Brushes.Black, x + 355, y)
            e.Graphics.DrawString((frmPrinter.dgvPrinter.Item(5, g).Value), New Font("Verdana", 6, FontStyle.Regular), Brushes.Black, x + 360, y + 3)

            e.Graphics.DrawString("|", New Font("Verdana", 8, FontStyle.Regular), Brushes.Black, x + 430, y)
            e.Graphics.DrawString((frmPrinter.dgvPrinter.Item(6, g).Value), New Font("Verdana", 6, FontStyle.Regular), Brushes.Black, x + 435, y + 3)

            e.Graphics.DrawString("|", New Font("Verdana", 8, FontStyle.Regular), Brushes.Black, x + 550, y)
            e.Graphics.DrawString((frmPrinter.dgvPrinter.Item(7, g).Value), New Font("Verdana", 6, FontStyle.Regular), Brushes.Black, x + 555, y + 3)

            'codigo,nome,empresa,data_nascimento,cpf,centro_custo,cargo
            e.Graphics.DrawString("|", New Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 800, y)
            While x < 800
                e.Graphics.DrawString("_", New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, x, y - 2)
                x = x + 5
            End While
            g = g + 1
            y = y + 11
            x = 9
        End While
    End Sub

    Public Sub PrintPage_Uniforme(e As System.Drawing.Printing.PrintPageEventArgs, r As Integer)
        Dim printFont As New System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular)
        Dim g As Integer = 0 'frmFuncionarios.dgvFuncionarios.CurrentRow.Index
        Dim y As Integer = 50
        Dim x As Integer = 120
        Dim data As Date = frmFuncionarios.dtpEntregaUnif.Text

        Dim path As String
        If File.Exists(Connection.PathString) Then
            path = My.Computer.FileSystem.ReadAllText(Connection.PathString) + "\fotos\Uniformes.jpg"
            e.Graphics.DrawImage(Image.FromFile(path), 10, 10)
        Else
            MessageBox.Show("Caminho do logo não encontrado na rede! ")
        End If

        e.Graphics.DrawString("Peg Pese Supermercados Importação e Exportação Ltda.", New Font("Calibri", 12, FontStyle.Regular), Brushes.Black, 280, y + 30)
        e.Graphics.DrawString("CNPJ:" + (frmFuncionarios.mskEnpCNPJ.Text).Replace(",", ".") + " – Inscr. Estadual: " + (frmFuncionarios.mskEnpInsc.Text).Replace(",", "."), New Font("Calibri", 12, FontStyle.Regular), Brushes.Black, 280, y + 50)
        e.Graphics.DrawString(frmFuncionarios.mskEnpEndereco.Text + "," + frmFuncionarios.mskEnpNumero.Text + " - CEP " + (frmFuncionarios.mskEnpCEP.Text).Replace(",", "."), New Font("Calibri", 12, FontStyle.Regular), Brushes.Black, 280, y + 70)

        e.Graphics.DrawString("Descrição do Uniforme", New Font("Calibri", 12, FontStyle.Regular), Brushes.Black, 120, y + 580)
        e.Graphics.DrawString("Qtde", New Font("Calibri", 12, FontStyle.Regular), Brushes.Black, 340, y + 580)
        e.Graphics.DrawString("TM", New Font("Calibri", 12, FontStyle.Regular), Brushes.Black, 385, y + 580)
        e.Graphics.DrawString("Dt.Entrega", New Font("Calibri", 12, FontStyle.Regular), Brushes.Black, 420, y + 580)
        e.Graphics.DrawString("Dt.Troca", New Font("Calibri", 12, FontStyle.Regular), Brushes.Black, 530, y + 580)
        e.Graphics.DrawString("Valor", New Font("Calibri", 12, FontStyle.Regular), Brushes.Black, 620, y + 580)

        e.Graphics.DrawString((frmFuncionarios.txtNome.Text), New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, x + 73, y + 251)

        e.Graphics.DrawString(data.Day.ToString + " de " + nomeData(data) + " de " + data.Year.ToString + ".", New Font("Calibri", 10, FontStyle.Regular), Brushes.Black, 200, y + 547)

        While x < 700
            e.Graphics.DrawString("_", New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, x, y + 589)
            x = x + 5
        End While
        x = 120
        y = 650
        While g < frmPrinter.dgvPrinter.RowCount

            e.Graphics.DrawString("|", New Font("Verdana", 12, FontStyle.Regular), Brushes.Black, x - 4, y)
            e.Graphics.DrawString((frmPrinter.dgvPrinter.Item(1, g).Value), New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, x + 5, y + 3)

            e.Graphics.DrawString("|", New Font("Verdana", 12, FontStyle.Regular), Brushes.Black, x + 220, y)
            e.Graphics.DrawString((frmPrinter.dgvPrinter.Item(2, g).Value), New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, x + 230, y + 3)

            e.Graphics.DrawString("|", New Font("Verdana", 12, FontStyle.Regular), Brushes.Black, x + 260, y)
            e.Graphics.DrawString((frmPrinter.dgvPrinter.Item(3, g).Value), New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, x + 270, y + 3)

            e.Graphics.DrawString("|", New Font("Verdana", 12, FontStyle.Regular), Brushes.Black, x + 290, y)
            e.Graphics.DrawString((frmPrinter.dgvPrinter.Item(4, g).Value), New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, x + 300, y + 3)

            e.Graphics.DrawString("|", New Font("Verdana", 12, FontStyle.Regular), Brushes.Black, x + 390, y)
            e.Graphics.DrawString(FormatCurrency((frmPrinter.dgvPrinter.Item(5, g).Value)), New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, x + 485, y + 3)

            e.Graphics.DrawString("|", New Font("Verdana", 12, FontStyle.Regular), Brushes.Black, x + 480, y)


            e.Graphics.DrawString("|", New Font("Verdana", 12, FontStyle.Regular), Brushes.Black, 700, y)
            While x < 700
                e.Graphics.DrawString("_", New Font("Verdana", 10, FontStyle.Regular), Brushes.Black, x, y + 4)
                x = x + 5
            End While
            g = g + 1
            y = y + 15
            x = 120
        End While
        e.Graphics.DrawString("___________________________", New Font("Calibri", 12, FontStyle.Regular), Brushes.Black, 125, 1070)
        e.Graphics.DrawString(frmFuncionarios.txtNome.Text, New Font("Calibri", 12, FontStyle.Regular), Brushes.Black, 125, 1085)

        e.Graphics.DrawString("CTPS:" + frmFuncionarios.mskCTPS.Text, New Font("Calibri", 12, FontStyle.Regular), Brushes.Black, 125, 1100)
        e.Graphics.DrawString("Série:" + frmFuncionarios.mskSerie.Text, New Font("Calibri", 12, FontStyle.Regular), Brushes.Black, 215, 1100)

    End Sub

    Private Sub WordClose(ex As Exception)
        MessageBox.Show("Houve um erro ao manipular o arquivo, salve todos seus documentos do Word pois todos seram fechados! " & ex.Message)
        Shell("cmd.exe /C " & "taskkill /F /IM winword.exe")
    End Sub

    Public Sub troca(achar As String, substituir As String)
        Try
            With objWord.Selection.Find
                .Text = achar.ToString
                .Replacement.Text = substituir.ToString
                .Forward = True
                .Format = False
                .MatchCase = False
                .MatchWholeWord = False
                .MatchWildcards = False
                .MatchSoundsLike = False
                .MatchAllWordForms = False

                While .Execute = True
                    objWord.Selection.Select()
                    System.Windows.Forms.Clipboard.SetDataObject(substituir)
                    objWord.Selection.Paste()
                End While
            End With
        Catch ex As Exception
            objWord.Quit()
            MessageBox.Show("Nao pode alterar o arquivo! " + ex.Message)
        End Try
    End Sub

    Public Sub PrintArmario()
        Try
            Dim vStringPath As String

            vStringPath = My.Computer.FileSystem.ReadAllText(Connection.PathModels)

            objWord = CreateObject("Word.Application") 'Instancia a Aplicação Word.
            objWord.Documents.Open(vStringPath + "\armario.docx") 'Abre o documento aviso.doc do Microsoft Word.

            'procura a variável e substitui o valor
            dados.connect_base()

            Dim codEmpresa As String = dados.BuscarCampo(frmArmarios.txtCodFunc.Text, "empresas_codigo", "dados")
            Dim cnpj As String = dados.BuscarCampo(codEmpresa, "cnpj", "empresas")
            Dim insc_estadual As String = dados.BuscarCampo(codEmpresa, "Insc_Estadual", "empresas")
            Dim endereco As String = dados.BuscarCampo(codEmpresa, "endereco", "empresas")
            Dim numero As String = dados.BuscarCampo(codEmpresa, "numero", "empresas")
            Dim cep As String = dados.BuscarCampo(codEmpresa, "cep", "empresas")
            Dim nomeEmpresa As String = dados.BuscarCampo(codEmpresa, "nome", "empresas")
            Dim ctps As String = dados.BuscarOutros(frmArmarios.txtCodFunc.Text, "ctps", "documentos")
            Dim matricula As String = dados.BuscarCampo(frmArmarios.txtCodFunc.Text, "matricula", "dados")

            Dim data As Date = frmArmarios.dtpArmario.Text
            troca("@cnpj", cnpj.Substring(0, 2) + "." + cnpj.Substring(2, 3) + "." + cnpj.Substring(5, 3) + "/" + cnpj.Substring(8, 4) + "-" + cnpj.Substring(12, 2))
            troca("@InscEstadual", insc_estadual.Substring(0, 3) + "." + insc_estadual.Substring(3, 3) + "." + insc_estadual.Substring(6, 3) + "." + insc_estadual.Substring(9, 3))
            troca("@endereco", endereco)
            troca("@numero", numero)
            troca("@cep", Left(cep, 5) + "-" + Right(cep, 3) + " - " + nomeEmpresa)
            troca("@nome1", frmArmarios.TxtNome.Text + ", CPF " + frmArmarios.mskCPF.Text.Replace(",", ".") + ", Matricula " + matricula)
            troca("@armario", frmArmarios.TxtArmario.Text)
            troca("@data", data.Day.ToString + " de " + nomeData(data) + " de " + data.Year.ToString + ".")
            troca("@nome", frmArmarios.TxtNome.Text)
            troca("@ctps", ctps)

            objWord.ActiveDocument.SaveAs("C:\Users\Public\Documents\Armario_" + frmArmarios.TxtNome.Text) 'Salva as alteracoes feitas no arquivo
            objWord.Quit() 'fecha o processo do word que foi usado para alteracao
            objWord = Nothing
            Try
                objWord2 = CreateObject("Word.Application")
                objWord2.Documents.Open("C:\Users\Public\Documents\Armario_" + frmArmarios.TxtNome.Text + ".docx") 'abre o novo arquivo que foi alterado e salvo

                objWord2.visible = True 'torna o Word visivel
            Catch ex As Exception
                WordClose(ex)
            End Try
        Catch ex As Exception
            WordClose(ex)
        End Try

    End Sub

    Public Sub PrintSusp()

        Try
            Dim vStringPath As String

            vStringPath = My.Computer.FileSystem.ReadAllText(Connection.PathModels)

            objWord = CreateObject("Word.Application")
            objWord.Documents.Open(vStringPath + "\suspensao.docx")

            dados.connect_base()
            Dim codEmpresa As String = dados.BuscarCampo(frmFuncionarios.mskCodigo.Text, "empresas_codigo", "dados")
            Dim cnpj As String = dados.BuscarCampo(codEmpresa, "cnpj", "empresas")
            Dim insc_estadual As String = dados.BuscarCampo(codEmpresa, "Insc_Estadual", "empresas")
            Dim endereco As String = dados.BuscarCampo(codEmpresa, "endereco", "empresas")
            Dim numero As String = dados.BuscarCampo(codEmpresa, "numero", "empresas")
            Dim cep As String = dados.BuscarCampo(codEmpresa, "cep", "empresas")
            Dim nomeEmpresa As String = dados.BuscarCampo(codEmpresa, "nome", "empresas")
            Dim data As Date = frmFuncionarios.dtpAdv_Susp.Text

            troca("@cnpj@", cnpj.Substring(0, 2) + "." + cnpj.Substring(2, 3) + "." + cnpj.Substring(5, 3) + "/" + cnpj.Substring(8, 4) + "-" + cnpj.Substring(12, 2) + " – Inscr. Estadual: " + insc_estadual.Substring(0, 3) + "." + insc_estadual.Substring(3, 3) + "." + insc_estadual.Substring(6, 3) + "." + insc_estadual.Substring(9, 3))
            troca("@endereco@", endereco + "," + numero + " - " + Left(cep, 5) + "-" + Right(cep, 3) + " - " + nomeEmpresa)

            troca("@data@", data.Day.ToString + " de " + nomeData(data) + " de " + data.Year.ToString)
            troca("@nome@", frmFuncionarios.txtNome.Text)

            troca("@datax@", data.Day.ToString + " de " + nomeData(data) + " de " + data.Year.ToString)

            troca("@dias@", frmFuncionarios.txtDiasSusp.Text + " (" + frmFuncionarios.txtDiasSuspExt.Text + ") dias,")
            troca("@motivo@", frmFuncionarios.rtbMotivoAdvSusp.Text + ",")
            troca("@retorno@", frmFuncionarios.dtpRetSusp.Text)
            troca("@nomex@", frmFuncionarios.txtNome.Text)
            troca("@ctps@", frmFuncionarios.mskCTPS.Text)

            objWord.ActiveDocument.SaveAs("C:\Users\Public\Documents\Suspensao_" + frmArmarios.TxtNome.Text)
            objWord.Quit()
            objWord = Nothing
            Try
                objWord2 = CreateObject("Word.Application")
                objWord2.Documents.Open("C:\Users\Public\Documents\Suspensao_" + frmArmarios.TxtNome.Text + ".docx")
                objWord2.visible = True
            Catch ex As Exception
                WordClose(ex)
            End Try
        Catch ex As Exception
            WordClose(ex)
        End Try
    End Sub

    Public Sub PrintAdv()

        Try
            Dim vStringPath As String

            vStringPath = My.Computer.FileSystem.ReadAllText(Connection.PathModels)

            objWord = CreateObject("Word.Application")
            objWord.Documents.Open(vStringPath + "\advertencia.docx")

            dados.connect_base()
            Dim codEmpresa As String = dados.BuscarCampo(frmFuncionarios.mskCodigo.Text, "empresas_codigo", "dados")
            Dim cnpj As String = dados.BuscarCampo(codEmpresa, "cnpj", "empresas")
            Dim insc_estadual As String = dados.BuscarCampo(codEmpresa, "Insc_Estadual", "empresas")
            Dim endereco As String = dados.BuscarCampo(codEmpresa, "endereco", "empresas")
            Dim numero As String = dados.BuscarCampo(codEmpresa, "numero", "empresas")
            Dim cep As String = dados.BuscarCampo(codEmpresa, "cep", "empresas")
            Dim nomeEmpresa As String = dados.BuscarCampo(codEmpresa, "nome", "empresas")
            Dim data As Date = frmFuncionarios.dtpAdv_Susp.Text

            troca("@cnpj@", cnpj.Substring(0, 2) + "." + cnpj.Substring(2, 3) + "." + cnpj.Substring(5, 3) + "/" + cnpj.Substring(8, 4) + "-" + cnpj.Substring(12, 2) + " – Inscr. Estadual: " + insc_estadual.Substring(0, 3) + "." + insc_estadual.Substring(3, 3) + "." + insc_estadual.Substring(6, 3) + "." + insc_estadual.Substring(9, 3))
            troca("@endereco@", endereco + "," + numero + " - " + Left(cep, 5) + "-" + Right(cep, 3) + " - " + nomeEmpresa)

            troca("@data@", data.Day.ToString + " de " + nomeData(data) + " de " + data.Year.ToString)
            troca("@nome@", frmFuncionarios.txtNome.Text + "           CTPS: " + frmFuncionarios.mskCTPS.Text)
            troca("@datax@", frmFuncionarios.dtpAdv_Susp.Text)
            troca("@motivo@", frmFuncionarios.rtbMotivoAdvSusp.Text + ".")
            troca("@nomex@", frmFuncionarios.txtNome.Text)
            troca("@ctps@", frmFuncionarios.mskCTPS.Text)

            objWord.ActiveDocument.SaveAs("C:\Users\Public\Documents\Advertencia_" + frmArmarios.TxtNome.Text)
            objWord.Quit()
            objWord = Nothing

            Try
                objWord2 = CreateObject("Word.Application")
                objWord2.Documents.Open("C:\Users\Public\Documents\Advertencia_" + frmArmarios.TxtNome.Text + ".docx")
                objWord2.visible = True
            Catch ex As Exception
                WordClose(ex)
            End Try

        Catch ex As Exception
            WordClose(ex)
        End Try

    End Sub

    Public Sub PrintEPI()

        Try
            Dim vStringPath As String

            vStringPath = My.Computer.FileSystem.ReadAllText(Connection.PathModels)

            objWord = CreateObject("Word.Application")
            objWord.Documents.Open(vStringPath + "\epi.docx")

            dados.connect_base()
            Dim codEmpresa As String = dados.BuscarCampo(frmFuncionarios.mskCodigo.Text, "empresas_codigo", "dados")
            Dim cnpj As String = dados.BuscarCampo(codEmpresa, "cnpj", "empresas")
            Dim insc_estadual As String = dados.BuscarCampo(codEmpresa, "Insc_Estadual", "empresas")
            Dim endereco As String = dados.BuscarCampo(codEmpresa, "endereco", "empresas")
            Dim numero As String = dados.BuscarCampo(codEmpresa, "numero", "empresas")
            Dim cep As String = dados.BuscarCampo(codEmpresa, "cep", "empresas")
            Dim nomeEmpresa As String = dados.BuscarCampo(codEmpresa, "nome", "empresas")
            Dim data As Date = frmFuncionarios.dtpEntregaEPI.Text

            troca("@cnpj@", cnpj.Substring(0, 2) + "." + cnpj.Substring(2, 3) + "." + cnpj.Substring(5, 3) + "/" + cnpj.Substring(8, 4) + "-" + cnpj.Substring(12, 2) + " – Inscr. Estadual: " + insc_estadual.Substring(0, 3) + "." + insc_estadual.Substring(3, 3) + "." + insc_estadual.Substring(6, 3) + "." + insc_estadual.Substring(9, 3))
            troca("@endereco@", endereco + "," + numero + " - " + Left(cep, 5) + "-" + Right(cep, 3) + " - " + nomeEmpresa)

            troca("@nome@", frmFuncionarios.txtNome.Text)
            troca("@registro@", frmFuncionarios.mskMat.Text)
            troca("@cargo@", frmFuncionarios.txtCargo.Text)
            troca("@setor@", frmFuncionarios.txtDepartamento.Text)
            troca("@dataAdmissao@", frmFuncionarios.dtpAdmissao.Text)

            troca("@dataEntrega@", frmFuncionarios.dtpEntregaEPI.Text)
            troca("@quantidade@", frmFuncionarios.txtqtdeEPI.Text)
            troca("@nCA@", frmFuncionarios.txtNCA.Text)
            troca("@codFornecimento@", frmFuncionarios.cmbCodFornEPI.Text)
            troca("@descricao@", frmFuncionarios.rtbDescEpi.Text)

            troca("@nomex@", frmFuncionarios.txtNome.Text)
            troca("@ctps@", frmFuncionarios.mskCTPS.Text)

            objWord.ActiveDocument.SaveAs("C:\Users\Public\Documents\Epi_" + frmArmarios.TxtNome.Text)
            objWord.Quit()
            objWord = Nothing

            Try
                objWord2 = CreateObject("Word.Application")
                objWord2.Documents.Open("C:\Users\Public\Documents\Epi_" + frmArmarios.TxtNome.Text + ".docx")
                objWord.visible = True
            Catch ex As Exception
                WordClose(ex)
            End Try

        Catch ex As Exception
            WordClose(ex)
        End Try
    End Sub
    Public Sub PrintCAT()
        empresa.connect_base()
        departamentos.connect_base()
        cat.connect_base()
        Try
            Dim vStringPath As String

            vStringPath = My.Computer.FileSystem.ReadAllText(Connection.PathModels)

            objWord = CreateObject("Word.Application")
            objWord.Documents.Open(vStringPath + "\modeloCAT.docx")

            troca("@numCat@", frmFuncionarios.msknumCAT.Text)

            troca("@emitente@", frmFuncionarios.txtEmitente.Text)
            troca("@dataAdmissao@", frmFuncionarios.dtpAdmissao.Text)
            troca("@tipoCAT@", frmFuncionarios.txttipoCAT.Text)
            troca("@comObito@", frmFuncionarios.txtComObito.Text)
            troca("@filiacao@", frmFuncionarios.txtFiliacao.Text)
            troca("@email@", frmFuncionarios.txtEmailCat.Text)

            troca("@nomeEmp@", empresa.BuscarEmpresa(frmFuncionarios.cmbEmpresa.Text, "razao_social", "empresas"))
            troca("@docEmp@", empresa.BuscarEmpresa(frmFuncionarios.cmbEmpresa.Text, "cnpj", "empresas"))
            troca("@cepEmp@", empresa.BuscarEmpresa(frmFuncionarios.cmbEmpresa.Text, "cep", "empresas"))
            troca("@endEmp@", empresa.BuscarEmpresa(frmFuncionarios.cmbEmpresa.Text, "endereco", "empresas"))
            troca("@bairroEmp@", empresa.BuscarEmpresa(frmFuncionarios.cmbEmpresa.Text, "bairro", "empresas"))
            troca("@estEmp@", empresa.BuscarEmpresa(frmFuncionarios.cmbEmpresa.Text, "estado", "empresas"))
            troca("@munEmp@", empresa.BuscarEmpresa(frmFuncionarios.cmbEmpresa.Text, "municipio", "empresas"))
            troca("@telEmp@", empresa.BuscarEmpresa(frmFuncionarios.cmbEmpresa.Text, "telefone", "empresas"))

            troca("@nomeAcid@", frmFuncionarios.txtNome.Text)
            troca("@nascAcid@", frmFuncionarios.dtpNasc.Text)
            troca("@maeAcid@", frmFuncionarios.txtMae.Text)
            troca("@sexoAcid@", frmFuncionarios.cmbSexo.Text)
            troca("@instruAcid@", frmFuncionarios.cmbGrauInstru.Text)
            troca("@civilAcid@", frmFuncionarios.cmbEstCivil.Text)
            troca("@remunAcid@", frmFuncionarios.txtBase.Text)
            troca("@ctpsAcid@", frmFuncionarios.mskCTPS.Text)
            troca("@identAcid@", frmFuncionarios.txtRG.Text)
            troca("@pisAcid@", frmFuncionarios.mskPIS.Text)
            troca("@endAcid@", frmFuncionarios.txtEndereco.Text)
            troca("@bairroAcid@", frmFuncionarios.txtBairro.Text)
            troca("@cepAcid@", frmFuncionarios.mskCEP.Text)
            troca("@estAcid@", frmFuncionarios.txtCidade.Text)
            troca("@muniAcid@", frmFuncionarios.txtCidade.Text)
            troca("@telAcid@", frmFuncionarios.mskFixo.Text)
            troca("@cboAcid@", departamentos.Buscar(frmFuncionarios.txtDepartamento.Text, "cbo", "departamentos"))
            troca("@aposenAcid@", frmFuncionarios.cmbStatus.Text)

            troca("@dataAcidente@", frmFuncionarios.dtpCAT.Text)
            troca("@horaAcidente@", frmFuncionarios.mskHora.Text)
            troca("@horasAcidente@", frmFuncionarios.mskHorasTrabalho.Text)
            troca("@tipoAcidente@", frmFuncionarios.txtTipoAcidente.Text)
            troca("@afastAcidente@", frmFuncionarios.cmbAfastamento.Text)
            troca("@regAcidente@", frmFuncionarios.cmbRegPolicial.Text)
            troca("@localAcidente@", frmFuncionarios.txtLocal.Text)
            troca("@espAcidente@", frmFuncionarios.txtExpLocal.Text)
            troca("@cgcAcidente@", frmFuncionarios.txtCGC.Text)
            troca("@ufAcidente@", frmFuncionarios.cmbUFacidente.Text)
            troca("@municipioAcidente@", frmFuncionarios.txtMunAcidente.Text)
            troca("@ultDiaTrabAcidente@", frmFuncionarios.dtpUltDia.Text)
            troca("@corpoAcidente@", frmFuncionarios.txtPtCorpo.Text)
            troca("@causadorAcidente@", frmFuncionarios.txtAgCausador.Text)
            troca("@geradorAcidente@", frmFuncionarios.txtSitGerador.Text)
            troca("@morteAcidente@", frmFuncionarios.cmbMorte.Text)
            troca("@obitoAcidente@", frmFuncionarios.mskObito.Text)

            troca("@unidadeAtestado@", cat.BuscarAtestado(frmFuncionarios.vCodAtestado, "unidade", "atestados"))
            troca("@dataAtendAtestado@", cat.BuscarAtestado(frmFuncionarios.vCodAtestado, "data", "atestados"))
            troca("@atendAtestado@", cat.BuscarAtestado(frmFuncionarios.vCodAtestado, "hora_atendimento", "atestados"))

            Dim internacao As Boolean = cat.BuscarAtestado(frmFuncionarios.vCodAtestado, "int_sim", "atestados")
            Dim res As String
            If internacao = True Then
                res = "Sim"
            Else
                res = "Não"
            End If
            troca("@internacaoAtestado@", res)

            Dim afastamento As Boolean = cat.BuscarAtestado(frmFuncionarios.vCodAtestado, "afast_sim", "atestados")
            If afastamento = True Then
                res = "Sim"
            Else
                res = "Não"
            End If
            troca("@tratAtestado@", res)
            troca("@lesaoAtestado@", cat.BuscarAtestado(frmFuncionarios.vCodAtestado, "nat_lesao", "atestados"))
            troca("@cidAtestado@", cat.BuscarAtestado(frmFuncionarios.vCodAtestado, "cid", "atestados"))
            troca("@obsAtestado@", cat.BuscarAtestado(frmFuncionarios.vCodAtestado, "obs", "atestados"))
            troca("@crmAtestado@", cat.BuscarAtestado(frmFuncionarios.vCodAtestado, "crm", "atestados"))

            objWord.ActiveDocument.SaveAs("C:\Users\Public\Documents\NOME_" + frmFuncionarios.txtNome.Text)
            objWord.Quit()
            objWord = Nothing

            Try
                objWord2 = CreateObject("Word.Application")
                objWord2.Documents.Open("C:\Users\Public\Documents\NOME_" + frmFuncionarios.txtNome.Text + ".docx")
                objWord.visible = True
            Catch ex As Exception
                WordClose(ex)
            End Try

        Catch ex As Exception
            WordClose(ex)
        End Try
    End Sub

    Public Sub PrintPage_TD(e As System.Drawing.Printing.PrintPageEventArgs)
        Dim printFont As New System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular)
        Dim path As String
        If File.Exists(Connection.PathString) Then
            path = My.Computer.FileSystem.ReadAllText(Connection.PathString) + "\fotos\Certificado.jpg"
            e.Graphics.DrawImage(Image.FromFile(path), 0, -5)
        Else
            MessageBox.Show("Caminho do logo não encontrado na rede! ")
        End If

        Dim data As Date = frmFuncionarios.dtpTD.Text

        e.Graphics.DrawString(frmFuncionarios.mskRegTD.Text, New Font("Calibri", 12, FontStyle.Regular), Brushes.Black, 985, 250)
        e.Graphics.DrawString(frmFuncionarios.txtNome.Text + ",", New Font("Calibri", 18, FontStyle.Regular), Brushes.Black, 475, 339)
        e.Graphics.DrawString(frmFuncionarios.txtTreinamTD.Text + ".", New Font("Calibri", 18, FontStyle.Regular), Brushes.Black, 500, 378)
        e.Graphics.DrawString(frmFuncionarios.dtpTD.Text + ",", New Font("Calibri", 18, FontStyle.Regular), Brushes.Black, 405, 485)
        e.Graphics.DrawString(frmFuncionarios.mskCargTD.Text, New Font("Calibri", 18, FontStyle.Regular), Brushes.Black, 720, 485)

        e.Graphics.DrawString(data.Day.ToString + " de " + nomeData(data) + " de " + data.Year.ToString + ".", New Font("Calibri", 18, FontStyle.Regular), Brushes.Black, 193, 562)
        e.Graphics.DrawString(frmFuncionarios.txtMinistTD.Text, New Font("Calibri", 18, FontStyle.Regular), Brushes.Black, 125, 690)

    End Sub

    Public Sub PrintPage_ReciboPagamento(e As System.Drawing.Printing.PrintPageEventArgs)
        Dim printFont As New System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular)
        Dim path As String
        If File.Exists(Connection.PathString) Then
            path = My.Computer.FileSystem.ReadAllText(Connection.PathString) + "\fotos\ReciboPagamento.jpg"
            e.Graphics.DrawImage(Image.FromFile(path), 10, 10)
        Else
            MessageBox.Show("Caminho do logo não encontrado na rede! ")
        End If

        dados.connect_base()
        Dim codEmpresa As String = dados.BuscarCampo(frmFuncionarios.mskCodigo.Text, "empresas_codigo", "dados")
        Dim cnpj As String = dados.BuscarCampo(codEmpresa, "cnpj", "empresas")
        Dim insc_estadual As String = dados.BuscarCampo(codEmpresa, "Insc_Estadual", "empresas")
        Dim endereco As String = dados.BuscarCampo(codEmpresa, "endereco", "empresas")
        Dim numero As String = dados.BuscarCampo(codEmpresa, "numero", "empresas")
        Dim cep As String = dados.BuscarCampo(codEmpresa, "cep", "empresas")

        Dim desc As Double
        desc = frmFuncionarios.txtDesc.Text / 100
        desc = desc * frmFuncionarios.txtProvent.Text

        e.Graphics.DrawString("Peg Pese Supermercados Importação e Exportação Ltda.", New Font("Calibri", 8, FontStyle.Regular), Brushes.Black, 120, 192)
        e.Graphics.DrawString(cnpj.Substring(0, 2) + "." + cnpj.Substring(2, 3) + "." + cnpj.Substring(5, 3) + "/" + cnpj.Substring(8, 4) + "-" + cnpj.Substring(12, 2), New Font("Calibri", 8, FontStyle.Regular), Brushes.Black, 121, 232)
        e.Graphics.DrawString(endereco + "," + numero + " - CEP " + Left(cep, 5) + "-" + Right(cep, 3), New Font("Calibri", 8, FontStyle.Regular), Brushes.Black, 121, 210)


        Dim data As Date = frmFuncionarios.dtpRecibo_Pagamento.Text
        e.Graphics.DrawString(nomeData(data) + " de " + data.Year.ToString, New Font("Calibri", 8, FontStyle.Regular), Brushes.Black, 561, 210)
        e.Graphics.DrawString(frmFuncionarios.mskCodigo.Text, New Font("Calibri", 8, FontStyle.Regular), Brushes.Black, 90, 270)

        e.Graphics.DrawString(frmFuncionarios.txtNome.Text, New Font("Calibri", 8, FontStyle.Regular), Brushes.Black, 140, 270)
        e.Graphics.DrawString(frmFuncionarios.txtCargo.Text, New Font("Calibri", 8, FontStyle.Regular), Brushes.Black, 481, 270)

        e.Graphics.DrawString(frmFuncionarios.txtRef.Text, New Font("Calibri", 8, FontStyle.Regular), Brushes.Black, 405, 350)

        e.Graphics.DrawString(frmFuncionarios.txtProvent.Text, New Font("Calibri", 8, FontStyle.Regular), Brushes.Black, 490, 350)
        e.Graphics.DrawString(frmFuncionarios.txtProvent.Text, New Font("Calibri", 8, FontStyle.Regular), Brushes.Black, 490, 580)

        e.Graphics.DrawString(frmFuncionarios.txtDesc.Text + "%", New Font("Calibri", 8, FontStyle.Regular), Brushes.Black, 580, 350)
        e.Graphics.DrawString(FormatCurrency(desc), New Font("Calibri", 8, FontStyle.Regular), Brushes.Black, 580, 580)

        e.Graphics.DrawString(frmFuncionarios.txtTotal.Text, New Font("Calibri", 8, FontStyle.Regular), Brushes.Black, 580, 610)
        e.Graphics.DrawString(frmFuncionarios.rtbDesc.Text, New Font("Calibri", 8, FontStyle.Regular), Brushes.Black, 80, 350)
        e.Graphics.DrawString(frmFuncionarios.rtbMens.Text, New Font("Calibri", 8, FontStyle.Regular), Brushes.Black, 75, 575)

    End Sub


    Public Sub CarregaFuncionario()
        Using da As New MySqlDataAdapter("select dados.codigo,dados.nome,empresas.nome,documentos.data_nascimento,documentos.cpf,departamentos.centro_custo,departamentos.cargo from dados inner join empresas on empresas.codigo = dados.empresas_codigo inner join documentos on documentos.dados_codigo = dados.codigo inner join departamentos on departamentos.codigo = dados.departamentos_codigo", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmPrinter.dgvPrinter.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Sub CarregarUniformes(codigo As Integer)
        'Descrição do Uniforme	Qtde	TM	Dt. Entr.	Dt. Troca	Valor
        Using da As New MySqlDataAdapter("SELECT desc_uniforme,qtde,tm,entrega,valor " +
                "FROM uniformes where dados_codigo='" + codigo.ToString + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmPrinter.dgvPrinter.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Sub CarregarArmario(codigo As Integer)
        'Nome cpf armario
        Using da As New MySqlDataAdapter("select dados.nome,cpf,n_armario from dados inner join documentos on documentos.dados_codigo = dados.codigo inner join armarios on armarios.dados_codigo = dados.codigo where dados.codigo =" + codigo.ToString + "", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmPrinter.dgvPrinter.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Sub CarregarAdvSusp(codigo As Integer)
        Using da As New MySqlDataAdapter("SELECT data_adv_susp, adv, susp, dias, retorno, motivo " +
                "FROM adv_susp where dados_codigo='" + codigo.ToString + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmPrinter.dgvPrinter.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Sub CarregarArmarios(codigo As Integer)
        'Descrição do Uniforme	Qtde	TM	Dt. Entr.	Dt. Troca	Valor
        Using da As New MySqlDataAdapter("SELECT desc_uniforme,qtde,tm,entrega,valor " +
                "FROM uniformes where dados_codigo='" + codigo.ToString + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmPrinter.dgvPrinter.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Function BuscarCampo(codigo As String, campo As String, tabela As String) As String
        Connection.Query = "Select " + campo + " FROM " + tabela + " where codigo='" + codigo + "'"
        Connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()
        Connection.Connect.Close()
        Return Scalar
    End Function

    Public Sub CarregarEmpresa(empresa As String)
        Using da As New MySqlDataAdapter("select dados.codigo,dados.nome,empresas.nome,documentos.data_nascimento,documentos.cpf,departamentos.centro_custo,departamentos.cargo from dados inner join empresas on empresas.codigo = dados.empresas_codigo inner join documentos on documentos.dados_codigo = dados.codigo inner join departamentos on departamentos.codigo = dados.departamentos_codigo where empresas.nome = '" + empresa + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmPrinter.dgvPrinter.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Sub CarregarDepartamentos(departamento As String)
        Using da As New MySqlDataAdapter("select dados.codigo,dados.nome,empresas.nome,documentos.data_nascimento,documentos.cpf,departamentos.centro_custo,departamentos.cargo from dados inner join empresas on empresas.codigo = dados.empresas_codigo inner join documentos on documentos.dados_codigo = dados.codigo inner join departamentos on departamentos.codigo = dados.departamentos_codigo where departamentos.centro_custo = '" + departamento + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmPrinter.dgvPrinter.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Sub CarregaCombo()
        Connection.Connect.Open()
        Dim reader As MySqlDataReader
        Dim cmd As MySqlCommand
        cmd = New MySqlCommand("select nome from empresas", Connection.Connect)
        reader = cmd.ExecuteReader

        While reader.Read
            frmPrinter.cmbEmpresa.Items.Add(reader.Item("nome"))
        End While
        Connection.Connect.Close()
    End Sub
End Class
