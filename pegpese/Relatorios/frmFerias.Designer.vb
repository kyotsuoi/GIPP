<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFerias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFerias))
        Me.dtpFerias = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvAvisoFerias2 = New System.Windows.Forms.DataGridView()
        Me.dgvAvisoFerias = New System.Windows.Forms.DataGridView()
        Me.btnFiltrarFerias = New System.Windows.Forms.Button()
        CType(Me.dgvAvisoFerias2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAvisoFerias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpFerias
        '
        Me.dtpFerias.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFerias.Location = New System.Drawing.Point(380, 10)
        Me.dtpFerias.Name = "dtpFerias"
        Me.dtpFerias.Size = New System.Drawing.Size(81, 20)
        Me.dtpFerias.TabIndex = 43
        Me.dtpFerias.Value = New Date(2015, 8, 14, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(325, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Vencimento de ferias"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(66, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "1° Vencimento de ferias"
        '
        'dgvAvisoFerias2
        '
        Me.dgvAvisoFerias2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAvisoFerias2.Location = New System.Drawing.Point(258, 63)
        Me.dgvAvisoFerias2.Name = "dgvAvisoFerias2"
        Me.dgvAvisoFerias2.Size = New System.Drawing.Size(240, 285)
        Me.dgvAvisoFerias2.TabIndex = 40
        '
        'dgvAvisoFerias
        '
        Me.dgvAvisoFerias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAvisoFerias.Location = New System.Drawing.Point(12, 63)
        Me.dgvAvisoFerias.Name = "dgvAvisoFerias"
        Me.dgvAvisoFerias.Size = New System.Drawing.Size(240, 285)
        Me.dgvAvisoFerias.TabIndex = 39
        '
        'btnFiltrarFerias
        '
        Me.btnFiltrarFerias.BackgroundImage = CType(resources.GetObject("btnFiltrarFerias.BackgroundImage"), System.Drawing.Image)
        Me.btnFiltrarFerias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFiltrarFerias.Location = New System.Drawing.Point(467, 5)
        Me.btnFiltrarFerias.Name = "btnFiltrarFerias"
        Me.btnFiltrarFerias.Size = New System.Drawing.Size(30, 28)
        Me.btnFiltrarFerias.TabIndex = 44
        Me.btnFiltrarFerias.UseVisualStyleBackColor = True
        '
        'frmFerias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 356)
        Me.Controls.Add(Me.btnFiltrarFerias)
        Me.Controls.Add(Me.dtpFerias)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvAvisoFerias2)
        Me.Controls.Add(Me.dgvAvisoFerias)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmFerias"
        Me.Text = "frmFerias"
        CType(Me.dgvAvisoFerias2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAvisoFerias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnFiltrarFerias As Button
    Friend WithEvents dtpFerias As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvAvisoFerias2 As DataGridView
    Friend WithEvents dgvAvisoFerias As DataGridView
End Class
