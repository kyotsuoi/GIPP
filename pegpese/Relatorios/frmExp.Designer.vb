<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExp
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvAvisoExp2 = New System.Windows.Forms.DataGridView()
        Me.dgvAvisoExp1 = New System.Windows.Forms.DataGridView()
        CType(Me.dgvAvisoExp2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAvisoExp1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(325, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "2° Periodo de Experiencia"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(66, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "1° Periodo de Experiencia"
        '
        'dgvAvisoExp2
        '
        Me.dgvAvisoExp2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAvisoExp2.Location = New System.Drawing.Point(258, 25)
        Me.dgvAvisoExp2.Name = "dgvAvisoExp2"
        Me.dgvAvisoExp2.Size = New System.Drawing.Size(240, 285)
        Me.dgvAvisoExp2.TabIndex = 40
        '
        'dgvAvisoExp1
        '
        Me.dgvAvisoExp1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAvisoExp1.Location = New System.Drawing.Point(12, 25)
        Me.dgvAvisoExp1.Name = "dgvAvisoExp1"
        Me.dgvAvisoExp1.Size = New System.Drawing.Size(240, 285)
        Me.dgvAvisoExp1.TabIndex = 39
        '
        'frmExp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 319)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvAvisoExp2)
        Me.Controls.Add(Me.dgvAvisoExp1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmExp"
        Me.Text = "Experiencias para vencer"
        CType(Me.dgvAvisoExp2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAvisoExp1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvAvisoExp2 As DataGridView
    Friend WithEvents dgvAvisoExp1 As DataGridView
End Class
