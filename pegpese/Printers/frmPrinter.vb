Public Class frmPrinter
    Public r, rest As Integer
    Public p As Integer
    Dim Printer As New Printer
    Dim empresa As New Empresas
    Dim Dados As New Dados
    Public WithEvents docToPrint As New Printing.PrintDocument
    Private WithEvents document As New System.Drawing.Printing.PrintDocument
    Private Sub frmPrinter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dados.connect_base()
        Printer.connect_base()
        CriarCheckCol()
        If lblPrinter.Text = "Uniformes" Then
            Printer.CarregarUniformes(frmFuncionarios.mskCodigo.Text)
        ElseIf lblPrinter.Text = "Armarios" Then
            Printer.CarregarArmario(Integer.Parse(frmArmarios.txtCodFunc.Text))
        ElseIf lblPrinter.Text = "Suspensao" Then
            Printer.CarregarAdvSusp(frmFuncionarios.mskCodigo.Text)
        End If
        Printer.CarregaCombo()

    End Sub

    Private Sub btnFiltrarEmpresa_Click(sender As Object, e As EventArgs) Handles btnFiltrarEmpresa.Click
        If cmbEmpresa.Text = "" Then Return
        Printer.CarregarEmpresa(cmbEmpresa.Text)
    End Sub
    Private Sub btnFiltrarDepartamento_Click(sender As Object, e As EventArgs) Handles btnFiltrarDepartamento.Click
        If txtDepartamento.Text = "" Then Return
        Printer.CarregarDepartamentos(txtDepartamento.Text)
    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        Dim vTeste As Boolean
        Dim i As Integer = dgvPrinter.RowCount - 1
        While i >= 0
            vTeste = dgvPrinter.Item(0, i).Value
            If vTeste = False Then
                dgvPrinter.Rows.RemoveAt(i)
            End If
            i = i - 1
        End While
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If dgvPrinter.RowCount = 0 Then Return
        PrintDialog.AllowSomePages = True
        PrintDialog.ShowHelp = True
        PrintDialog.Document = docToPrint

        Dim result As DialogResult = PrintDialog.ShowDialog()
        If (result = DialogResult.OK) Then
            p = 0
            r = dgvPrinter.RowCount
            While r > 98 'conta a quantidade de paginas 
                r = r - 98
                p = p + 1
            End While

            If r > 0 Then ' conta se ouver uma ultima panina com menos de 98 linhas 
                p = p + 1
            End If

            If p = 1 Then 'Qtd de linhas da da ultima pagina 
                r = dgvPrinter.RowCount
            End If
            rest = r

            r = 0
            docToPrint.Print()
        End If
    End Sub

    Private Sub CriarCheckCol()

        Dim colX As New DataGridViewCheckBoxColumn
        colX.HeaderText = "Check"
        colX.Name = "Check"
        dgvPrinter.Columns.Add(colX)
        colX.DisplayIndex = 0
        For i As Int32 = 0 To dgvPrinter.Columns.Count - 1
            dgvPrinter.Columns(i).ReadOnly = True
        Next
        colX.ReadOnly = False

    End Sub

    Private Sub document_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docToPrint.PrintPage
        If lblPrinter.Text = "Funcionario" Then
            r = r + 98
            If p > 1 Then 'Enquanto paginas for > 1 imprimi pagina completa
                Printer.PrintPage_Funcionario(e, r)
                p = p - 1
                e.HasMorePages = True
            Else ' Imprime o resto
                Printer.PrintPage_Funcionario(e, rest)
                e.HasMorePages = False
            End If
        ElseIf lblPrinter.Text = "Uniformes"
            r = r + 98
            If p > 1 Then 'Enquanto paginas for > 1 imprimi pagina completa
                Printer.PrintPage_Uniforme(e, r)
                p = p - 1
                e.HasMorePages = True
            Else ' Imprime o resto
                Printer.PrintPage_Uniforme(e, rest)
                e.HasMorePages = False
            End If
            r = r + 98

        ElseIf lblPrinter.Text = "TD"
            r = r + 98
            If p > 1 Then 'Enquanto paginas for > 1 imprimi pagina completa
                Printer.PrintPage_TD(e)
                p = p - 1
                e.HasMorePages = True
            Else ' Imprime o resto
                Printer.PrintPage_TD(e)
                e.HasMorePages = False
            End If
        ElseIf lblPrinter.Text = "ReciboPagamento"
            r = r + 98
            If p > 1 Then 'Enquanto paginas for > 1 imprimi pagina completa
                Printer.PrintPage_ReciboPagamento(e)
                p = p - 1
                e.HasMorePages = True
            Else ' Imprime o resto
                Printer.PrintPage_ReciboPagamento(e)
                e.HasMorePages = False
            End If
        End If

    End Sub
End Class