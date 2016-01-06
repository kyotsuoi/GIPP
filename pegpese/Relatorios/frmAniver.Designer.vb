<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAniver
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
        Me.btnFiltrarAniver = New System.Windows.Forms.Button()
        Me.dtpAniver = New System.Windows.Forms.DateTimePicker()
        Me.dgvAniver = New System.Windows.Forms.DataGridView()
        CType(Me.dgvAniver, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnFiltrarAniver
        '
        Me.btnFiltrarAniver.BackgroundImage = Global.GIPP.My.Resources.Resources.MagnifierBlue
        Me.btnFiltrarAniver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFiltrarAniver.Location = New System.Drawing.Point(99, 2)
        Me.btnFiltrarAniver.Name = "btnFiltrarAniver"
        Me.btnFiltrarAniver.Size = New System.Drawing.Size(30, 28)
        Me.btnFiltrarAniver.TabIndex = 43
        Me.btnFiltrarAniver.UseVisualStyleBackColor = True
        '
        'dtpAniver
        '
        Me.dtpAniver.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAniver.Location = New System.Drawing.Point(12, 7)
        Me.dtpAniver.Name = "dtpAniver"
        Me.dtpAniver.Size = New System.Drawing.Size(81, 20)
        Me.dtpAniver.TabIndex = 42
        Me.dtpAniver.Value = New Date(2015, 8, 14, 0, 0, 0, 0)
        '
        'dgvAniver
        '
        Me.dgvAniver.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAniver.Location = New System.Drawing.Point(12, 45)
        Me.dgvAniver.Name = "dgvAniver"
        Me.dgvAniver.Size = New System.Drawing.Size(240, 285)
        Me.dgvAniver.TabIndex = 41
        '
        'frmAniver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(263, 339)
        Me.Controls.Add(Me.btnFiltrarAniver)
        Me.Controls.Add(Me.dtpAniver)
        Me.Controls.Add(Me.dgvAniver)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmAniver"
        Me.Text = "Aniversariantes"
        CType(Me.dgvAniver, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnFiltrarAniver As Button
    Friend WithEvents dtpAniver As DateTimePicker
    Friend WithEvents dgvAniver As DataGridView
End Class
