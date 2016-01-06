<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrinter
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.dgvPrinter = New System.Windows.Forms.DataGridView()
        Me.PrintDialog = New System.Windows.Forms.PrintDialog()
        Me.btnRecarregar = New System.Windows.Forms.Button()
        Me.lblPrinter = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnFiltrarEmpresa = New System.Windows.Forms.Button()
        Me.lblnome = New System.Windows.Forms.Label()
        Me.btnFiltrarDepartamento = New System.Windows.Forms.Button()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        CType(Me.dgvPrinter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLimpar
        '
        Me.btnLimpar.Location = New System.Drawing.Point(16, 562)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(146, 23)
        Me.btnLimpar.TabIndex = 148
        Me.btnLimpar.Text = "Limpar os não selecionados"
        Me.btnLimpar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(12, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 151
        Me.Label2.Text = "Empresa"
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Items.AddRange(New Object() {""})
        Me.cmbEmpresa.Location = New System.Drawing.Point(71, 7)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(121, 21)
        Me.cmbEmpresa.TabIndex = 149
        '
        'dgvPrinter
        '
        Me.dgvPrinter.AllowUserToAddRows = False
        Me.dgvPrinter.AllowUserToDeleteRows = False
        Me.dgvPrinter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrinter.Location = New System.Drawing.Point(10, 36)
        Me.dgvPrinter.Name = "dgvPrinter"
        Me.dgvPrinter.Size = New System.Drawing.Size(644, 508)
        Me.dgvPrinter.TabIndex = 154
        '
        'PrintDialog
        '
        Me.PrintDialog.UseEXDialog = True
        '
        'btnRecarregar
        '
        Me.btnRecarregar.Location = New System.Drawing.Point(168, 562)
        Me.btnRecarregar.Name = "btnRecarregar"
        Me.btnRecarregar.Size = New System.Drawing.Size(146, 23)
        Me.btnRecarregar.TabIndex = 156
        Me.btnRecarregar.Text = "Recarregar lista"
        Me.btnRecarregar.UseVisualStyleBackColor = True
        '
        'lblPrinter
        '
        Me.lblPrinter.AutoSize = True
        Me.lblPrinter.Location = New System.Drawing.Point(532, 10)
        Me.lblPrinter.Name = "lblPrinter"
        Me.lblPrinter.Size = New System.Drawing.Size(0, 13)
        Me.lblPrinter.TabIndex = 157
        '
        'btnImprimir
        '
        Me.btnImprimir.BackgroundImage = Global.GIPP.My.Resources.Resources.PrintFilesBlue
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnImprimir.Location = New System.Drawing.Point(614, 545)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(40, 40)
        Me.btnImprimir.TabIndex = 155
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnFiltrarEmpresa
        '
        Me.btnFiltrarEmpresa.BackgroundImage = Global.GIPP.My.Resources.Resources.MagnifierBlue
        Me.btnFiltrarEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFiltrarEmpresa.Location = New System.Drawing.Point(198, 2)
        Me.btnFiltrarEmpresa.Name = "btnFiltrarEmpresa"
        Me.btnFiltrarEmpresa.Size = New System.Drawing.Size(30, 28)
        Me.btnFiltrarEmpresa.TabIndex = 150
        Me.btnFiltrarEmpresa.UseVisualStyleBackColor = True
        '
        'lblnome
        '
        Me.lblnome.AutoSize = True
        Me.lblnome.ForeColor = System.Drawing.Color.Blue
        Me.lblnome.Location = New System.Drawing.Point(264, 9)
        Me.lblnome.Name = "lblnome"
        Me.lblnome.Size = New System.Drawing.Size(74, 13)
        Me.lblnome.TabIndex = 160
        Me.lblnome.Text = "Departamento"
        '
        'btnFiltrarDepartamento
        '
        Me.btnFiltrarDepartamento.BackgroundImage = Global.GIPP.My.Resources.Resources.MagnifierBlue
        Me.btnFiltrarDepartamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFiltrarDepartamento.Location = New System.Drawing.Point(450, 2)
        Me.btnFiltrarDepartamento.Name = "btnFiltrarDepartamento"
        Me.btnFiltrarDepartamento.Size = New System.Drawing.Size(30, 28)
        Me.btnFiltrarDepartamento.TabIndex = 159
        Me.btnFiltrarDepartamento.UseVisualStyleBackColor = True
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Location = New System.Drawing.Point(344, 7)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Size = New System.Drawing.Size(100, 20)
        Me.txtDepartamento.TabIndex = 161
        '
        'frmPrinter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 597)
        Me.Controls.Add(Me.txtDepartamento)
        Me.Controls.Add(Me.lblnome)
        Me.Controls.Add(Me.btnFiltrarDepartamento)
        Me.Controls.Add(Me.lblPrinter)
        Me.Controls.Add(Me.btnRecarregar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.dgvPrinter)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbEmpresa)
        Me.Controls.Add(Me.btnFiltrarEmpresa)
        Me.Controls.Add(Me.btnLimpar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmPrinter"
        Me.Text = "Printer"
        CType(Me.dgvPrinter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLimpar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbEmpresa As ComboBox
    Friend WithEvents btnFiltrarEmpresa As Button
    Friend WithEvents dgvPrinter As DataGridView
    Friend WithEvents btnImprimir As Button
    Friend WithEvents PrintDialog As PrintDialog
    Friend WithEvents btnRecarregar As Button
    Friend WithEvents lblPrinter As Label
    Friend WithEvents lblnome As Label
    Friend WithEvents btnFiltrarDepartamento As Button
    Friend WithEvents txtDepartamento As TextBox
End Class
