<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArmarios
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
        Me.dgvFuncionarios = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvArmarios = New System.Windows.Forms.DataGridView()
        Me.TxtNome = New System.Windows.Forms.TextBox()
        Me.txtCodFunc = New System.Windows.Forms.TextBox()
        Me.TxtObs = New System.Windows.Forms.TextBox()
        Me.TxtArmario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnApagar = New System.Windows.Forms.Button()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.btnAlterar = New System.Windows.Forms.Button()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.btnPrintArmario = New System.Windows.Forms.Button()
        Me.btnSavArqArmario = New System.Windows.Forms.Button()
        Me.btnAbrArqArmario = New System.Windows.Forms.Button()
        Me.btnProcArqArmario = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.mskCPF = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpArmario = New System.Windows.Forms.DateTimePicker()
        Me.PrintDialog = New System.Windows.Forms.PrintDialog()
        Me.txtDepart = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnFiltrarCodFunc = New System.Windows.Forms.Button()
        CType(Me.dgvFuncionarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvArmarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvFuncionarios
        '
        Me.dgvFuncionarios.AllowUserToAddRows = False
        Me.dgvFuncionarios.AllowUserToDeleteRows = False
        Me.dgvFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFuncionarios.Location = New System.Drawing.Point(412, 12)
        Me.dgvFuncionarios.Name = "dgvFuncionarios"
        Me.dgvFuncionarios.ReadOnly = True
        Me.dgvFuncionarios.Size = New System.Drawing.Size(482, 269)
        Me.dgvFuncionarios.TabIndex = 155
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(281, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 154
        Me.Label2.Text = "Armário"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(15, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = "Codigo"
        '
        'dgvArmarios
        '
        Me.dgvArmarios.AllowUserToAddRows = False
        Me.dgvArmarios.AllowUserToDeleteRows = False
        Me.dgvArmarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArmarios.Location = New System.Drawing.Point(412, 12)
        Me.dgvArmarios.Name = "dgvArmarios"
        Me.dgvArmarios.ReadOnly = True
        Me.dgvArmarios.Size = New System.Drawing.Size(482, 269)
        Me.dgvArmarios.TabIndex = 152
        '
        'TxtNome
        '
        Me.TxtNome.Enabled = False
        Me.TxtNome.Location = New System.Drawing.Point(61, 48)
        Me.TxtNome.Name = "TxtNome"
        Me.TxtNome.Size = New System.Drawing.Size(345, 20)
        Me.TxtNome.TabIndex = 3
        '
        'txtCodFunc
        '
        Me.txtCodFunc.Enabled = False
        Me.txtCodFunc.Location = New System.Drawing.Point(61, 12)
        Me.txtCodFunc.Name = "txtCodFunc"
        Me.txtCodFunc.Size = New System.Drawing.Size(77, 20)
        Me.txtCodFunc.TabIndex = 149
        '
        'TxtObs
        '
        Me.TxtObs.Location = New System.Drawing.Point(61, 101)
        Me.TxtObs.Name = "TxtObs"
        Me.TxtObs.Size = New System.Drawing.Size(345, 20)
        Me.TxtObs.TabIndex = 5
        '
        'TxtArmario
        '
        Me.TxtArmario.Location = New System.Drawing.Point(329, 12)
        Me.TxtArmario.Name = "TxtArmario"
        Me.TxtArmario.Size = New System.Drawing.Size(77, 20)
        Me.TxtArmario.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(12, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 157
        Me.Label3.Text = "Nome"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 158
        Me.Label4.Text = "Obs."
        '
        'btnApagar
        '
        Me.btnApagar.BackgroundImage = Global.GIPP.My.Resources.Resources.DeleteButtonBlue
        Me.btnApagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnApagar.Location = New System.Drawing.Point(212, 233)
        Me.btnApagar.Name = "btnApagar"
        Me.btnApagar.Size = New System.Drawing.Size(94, 48)
        Me.btnApagar.TabIndex = 156
        Me.btnApagar.UseVisualStyleBackColor = True
        '
        'btnLimpar
        '
        Me.btnLimpar.BackgroundImage = Global.GIPP.My.Resources.Resources.ClearButtonBlue
        Me.btnLimpar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpar.Location = New System.Drawing.Point(312, 233)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(94, 48)
        Me.btnLimpar.TabIndex = 148
        Me.btnLimpar.UseVisualStyleBackColor = True
        '
        'btnAlterar
        '
        Me.btnAlterar.BackgroundImage = Global.GIPP.My.Resources.Resources.UpdateButtonBlue
        Me.btnAlterar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAlterar.Location = New System.Drawing.Point(112, 233)
        Me.btnAlterar.Name = "btnAlterar"
        Me.btnAlterar.Size = New System.Drawing.Size(94, 48)
        Me.btnAlterar.TabIndex = 147
        Me.btnAlterar.UseVisualStyleBackColor = True
        '
        'btnGravar
        '
        Me.btnGravar.BackgroundImage = Global.GIPP.My.Resources.Resources.SaveButtonBlue
        Me.btnGravar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGravar.Location = New System.Drawing.Point(12, 233)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(94, 48)
        Me.btnGravar.TabIndex = 146
        Me.btnGravar.UseVisualStyleBackColor = True
        '
        'btnPrintArmario
        '
        Me.btnPrintArmario.BackgroundImage = Global.GIPP.My.Resources.Resources.PrintFilesBlue
        Me.btnPrintArmario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPrintArmario.Location = New System.Drawing.Point(153, 160)
        Me.btnPrintArmario.Name = "btnPrintArmario"
        Me.btnPrintArmario.Size = New System.Drawing.Size(40, 40)
        Me.btnPrintArmario.TabIndex = 223
        Me.btnPrintArmario.UseVisualStyleBackColor = True
        '
        'btnSavArqArmario
        '
        Me.btnSavArqArmario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSavArqArmario.Image = Global.GIPP.My.Resources.Resources.SaveFileBlue
        Me.btnSavArqArmario.Location = New System.Drawing.Point(15, 159)
        Me.btnSavArqArmario.Name = "btnSavArqArmario"
        Me.btnSavArqArmario.Size = New System.Drawing.Size(40, 40)
        Me.btnSavArqArmario.TabIndex = 220
        Me.btnSavArqArmario.UseVisualStyleBackColor = True
        '
        'btnAbrArqArmario
        '
        Me.btnAbrArqArmario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbrArqArmario.Image = Global.GIPP.My.Resources.Resources.SearchFileBlue
        Me.btnAbrArqArmario.Location = New System.Drawing.Point(61, 159)
        Me.btnAbrArqArmario.Name = "btnAbrArqArmario"
        Me.btnAbrArqArmario.Size = New System.Drawing.Size(40, 40)
        Me.btnAbrArqArmario.TabIndex = 221
        Me.btnAbrArqArmario.UseVisualStyleBackColor = True
        '
        'btnProcArqArmario
        '
        Me.btnProcArqArmario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnProcArqArmario.Image = Global.GIPP.My.Resources.Resources.ExplorerFilesBlue
        Me.btnProcArqArmario.Location = New System.Drawing.Point(107, 159)
        Me.btnProcArqArmario.Name = "btnProcArqArmario"
        Me.btnProcArqArmario.Size = New System.Drawing.Size(40, 40)
        Me.btnProcArqArmario.TabIndex = 222
        Me.btnProcArqArmario.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        '
        'mskCPF
        '
        Me.mskCPF.Enabled = False
        Me.mskCPF.Location = New System.Drawing.Point(61, 75)
        Me.mskCPF.Mask = "000.000.000-00"
        Me.mskCPF.Name = "mskCPF"
        Me.mskCPF.Size = New System.Drawing.Size(86, 20)
        Me.mskCPF.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(20, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 225
        Me.Label5.Text = "CPF"
        '
        'dtpArmario
        '
        Me.dtpArmario.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpArmario.Location = New System.Drawing.Point(199, 160)
        Me.dtpArmario.Name = "dtpArmario"
        Me.dtpArmario.Size = New System.Drawing.Size(84, 20)
        Me.dtpArmario.TabIndex = 226
        Me.dtpArmario.Value = New Date(2015, 8, 14, 0, 0, 0, 0)
        '
        'PrintDialog
        '
        Me.PrintDialog.UseEXDialog = True
        '
        'txtDepart
        '
        Me.txtDepart.Location = New System.Drawing.Point(256, 74)
        Me.txtDepart.Name = "txtDepart"
        Me.txtDepart.Size = New System.Drawing.Size(150, 20)
        Me.txtDepart.TabIndex = 227
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(176, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 228
        Me.Label6.Text = "Departamento"
        '
        'btnFiltrarCodFunc
        '
        Me.btnFiltrarCodFunc.BackgroundImage = Global.GIPP.My.Resources.Resources.PersonsButtonBlue
        Me.btnFiltrarCodFunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnFiltrarCodFunc.Location = New System.Drawing.Point(412, 241)
        Me.btnFiltrarCodFunc.Name = "btnFiltrarCodFunc"
        Me.btnFiltrarCodFunc.Size = New System.Drawing.Size(40, 40)
        Me.btnFiltrarCodFunc.TabIndex = 229
        Me.btnFiltrarCodFunc.UseVisualStyleBackColor = True
        '
        'frmArmarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 288)
        Me.Controls.Add(Me.btnFiltrarCodFunc)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDepart)
        Me.Controls.Add(Me.dtpArmario)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.mskCPF)
        Me.Controls.Add(Me.btnPrintArmario)
        Me.Controls.Add(Me.btnSavArqArmario)
        Me.Controls.Add(Me.btnAbrArqArmario)
        Me.Controls.Add(Me.btnProcArqArmario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnApagar)
        Me.Controls.Add(Me.dgvFuncionarios)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvArmarios)
        Me.Controls.Add(Me.TxtNome)
        Me.Controls.Add(Me.btnLimpar)
        Me.Controls.Add(Me.btnAlterar)
        Me.Controls.Add(Me.btnGravar)
        Me.Controls.Add(Me.txtCodFunc)
        Me.Controls.Add(Me.TxtObs)
        Me.Controls.Add(Me.TxtArmario)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmArmarios"
        Me.Text = "Armários"
        CType(Me.dgvFuncionarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvArmarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnApagar As Button
    Friend WithEvents dgvFuncionarios As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvArmarios As DataGridView
    Friend WithEvents TxtNome As TextBox
    Friend WithEvents btnLimpar As Button
    Friend WithEvents btnAlterar As Button
    Friend WithEvents btnGravar As Button
    Friend WithEvents txtCodFunc As TextBox
    Friend WithEvents TxtObs As TextBox
    Friend WithEvents TxtArmario As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnPrintArmario As Button
    Friend WithEvents btnSavArqArmario As Button
    Friend WithEvents btnAbrArqArmario As Button
    Friend WithEvents btnProcArqArmario As Button
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents mskCPF As MaskedTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpArmario As DateTimePicker
    Friend WithEvents PrintDialog As PrintDialog
    Friend WithEvents txtDepart As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnFiltrarCodFunc As Button
End Class
