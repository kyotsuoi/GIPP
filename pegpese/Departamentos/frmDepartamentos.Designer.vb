<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDepartamentos
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
        Me.mskCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCargo = New System.Windows.Forms.TextBox()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.dgvDepartamentos = New System.Windows.Forms.DataGridView()
        Me.btnApagar = New System.Windows.Forms.Button()
        Me.btnAlterar = New System.Windows.Forms.Button()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.txtCBO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvDepartamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mskCodigo
        '
        Me.mskCodigo.BackColor = System.Drawing.SystemColors.Window
        Me.mskCodigo.Enabled = False
        Me.mskCodigo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.mskCodigo.Location = New System.Drawing.Point(79, 6)
        Me.mskCodigo.Mask = "00000"
        Me.mskCodigo.Name = "mskCodigo"
        Me.mskCodigo.Size = New System.Drawing.Size(42, 20)
        Me.mskCodigo.TabIndex = 1
        Me.mskCodigo.ValidatingType = GetType(Integer)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(9, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 156
        Me.Label1.Text = "Codigo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(9, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 155
        Me.Label5.Text = "Cargo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(9, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 154
        Me.Label7.Text = "Centro/Cust"
        '
        'txtCargo
        '
        Me.txtCargo.BackColor = System.Drawing.SystemColors.Window
        Me.txtCargo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCargo.Location = New System.Drawing.Point(79, 58)
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.Size = New System.Drawing.Size(327, 20)
        Me.txtCargo.TabIndex = 3
        '
        'txtDepartamento
        '
        Me.txtDepartamento.BackColor = System.Drawing.SystemColors.Window
        Me.txtDepartamento.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDepartamento.Location = New System.Drawing.Point(79, 32)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Size = New System.Drawing.Size(327, 20)
        Me.txtDepartamento.TabIndex = 2
        '
        'dgvDepartamentos
        '
        Me.dgvDepartamentos.AllowUserToAddRows = False
        Me.dgvDepartamentos.AllowUserToDeleteRows = False
        Me.dgvDepartamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDepartamentos.Location = New System.Drawing.Point(12, 84)
        Me.dgvDepartamentos.Name = "dgvDepartamentos"
        Me.dgvDepartamentos.ReadOnly = True
        Me.dgvDepartamentos.Size = New System.Drawing.Size(394, 155)
        Me.dgvDepartamentos.TabIndex = 153
        '
        'btnApagar
        '
        Me.btnApagar.BackgroundImage = Global.GIPP.My.Resources.Resources.DeleteButtonBlue
        Me.btnApagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnApagar.Location = New System.Drawing.Point(212, 245)
        Me.btnApagar.Name = "btnApagar"
        Me.btnApagar.Size = New System.Drawing.Size(94, 48)
        Me.btnApagar.TabIndex = 157
        Me.btnApagar.UseVisualStyleBackColor = True
        '
        'btnAlterar
        '
        Me.btnAlterar.BackgroundImage = Global.GIPP.My.Resources.Resources.UpdateButtonBlue
        Me.btnAlterar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAlterar.Location = New System.Drawing.Point(112, 245)
        Me.btnAlterar.Name = "btnAlterar"
        Me.btnAlterar.Size = New System.Drawing.Size(94, 48)
        Me.btnAlterar.TabIndex = 151
        Me.btnAlterar.UseVisualStyleBackColor = True
        '
        'btnLimpar
        '
        Me.btnLimpar.BackgroundImage = Global.GIPP.My.Resources.Resources.ClearButtonBlue
        Me.btnLimpar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpar.Location = New System.Drawing.Point(312, 245)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(94, 48)
        Me.btnLimpar.TabIndex = 152
        Me.btnLimpar.UseVisualStyleBackColor = True
        '
        'btnGravar
        '
        Me.btnGravar.BackgroundImage = Global.GIPP.My.Resources.Resources.SaveButtonBlue
        Me.btnGravar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGravar.Location = New System.Drawing.Point(12, 245)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(94, 48)
        Me.btnGravar.TabIndex = 150
        Me.btnGravar.UseVisualStyleBackColor = True
        '
        'txtCBO
        '
        Me.txtCBO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCBO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCBO.Location = New System.Drawing.Point(294, 6)
        Me.txtCBO.Name = "txtCBO"
        Me.txtCBO.Size = New System.Drawing.Size(112, 20)
        Me.txtCBO.TabIndex = 158
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(259, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "CBO"
        '
        'frmDepartamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(418, 301)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCBO)
        Me.Controls.Add(Me.btnApagar)
        Me.Controls.Add(Me.btnAlterar)
        Me.Controls.Add(Me.btnLimpar)
        Me.Controls.Add(Me.btnGravar)
        Me.Controls.Add(Me.mskCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCargo)
        Me.Controls.Add(Me.txtDepartamento)
        Me.Controls.Add(Me.dgvDepartamentos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmDepartamentos"
        Me.Text = "Departamento"
        CType(Me.dgvDepartamentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAlterar As System.Windows.Forms.Button
    Friend WithEvents btnLimpar As System.Windows.Forms.Button
    Friend WithEvents btnGravar As System.Windows.Forms.Button
    Friend WithEvents mskCodigo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCargo As System.Windows.Forms.TextBox
    Friend WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents dgvDepartamentos As System.Windows.Forms.DataGridView
    Friend WithEvents btnApagar As System.Windows.Forms.Button
    Friend WithEvents txtCBO As TextBox
    Friend WithEvents Label2 As Label
End Class
