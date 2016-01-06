<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReciboDomingo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReciboDomingo))
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.btnProcRecDom = New System.Windows.Forms.Button()
        Me.btnRecDomingo = New System.Windows.Forms.Button()
        Me.btnAbrirRecDom = New System.Windows.Forms.Button()
        Me.dtpRecibo_Domingo = New System.Windows.Forms.DateTimePicker()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox17.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox17
        '
        Me.GroupBox17.Controls.Add(Me.btnProcRecDom)
        Me.GroupBox17.Controls.Add(Me.btnRecDomingo)
        Me.GroupBox17.Controls.Add(Me.btnAbrirRecDom)
        Me.GroupBox17.Controls.Add(Me.dtpRecibo_Domingo)
        Me.GroupBox17.Controls.Add(Me.Label58)
        Me.GroupBox17.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(263, 82)
        Me.GroupBox17.TabIndex = 172
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "Recibo de domingo"
        '
        'btnProcRecDom
        '
        Me.btnProcRecDom.BackgroundImage = CType(resources.GetObject("btnProcRecDom.BackgroundImage"), System.Drawing.Image)
        Me.btnProcRecDom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnProcRecDom.Location = New System.Drawing.Point(217, 36)
        Me.btnProcRecDom.Name = "btnProcRecDom"
        Me.btnProcRecDom.Size = New System.Drawing.Size(40, 40)
        Me.btnProcRecDom.TabIndex = 190
        Me.btnProcRecDom.UseVisualStyleBackColor = True
        '
        'btnRecDomingo
        '
        Me.btnRecDomingo.BackgroundImage = CType(resources.GetObject("btnRecDomingo.BackgroundImage"), System.Drawing.Image)
        Me.btnRecDomingo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRecDomingo.Location = New System.Drawing.Point(125, 36)
        Me.btnRecDomingo.Name = "btnRecDomingo"
        Me.btnRecDomingo.Size = New System.Drawing.Size(40, 40)
        Me.btnRecDomingo.TabIndex = 188
        Me.btnRecDomingo.UseVisualStyleBackColor = True
        '
        'btnAbrirRecDom
        '
        Me.btnAbrirRecDom.BackgroundImage = CType(resources.GetObject("btnAbrirRecDom.BackgroundImage"), System.Drawing.Image)
        Me.btnAbrirRecDom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAbrirRecDom.Location = New System.Drawing.Point(171, 36)
        Me.btnAbrirRecDom.Name = "btnAbrirRecDom"
        Me.btnAbrirRecDom.Size = New System.Drawing.Size(40, 40)
        Me.btnAbrirRecDom.TabIndex = 189
        Me.btnAbrirRecDom.UseVisualStyleBackColor = True
        '
        'dtpRecibo_Domingo
        '
        Me.dtpRecibo_Domingo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRecibo_Domingo.Location = New System.Drawing.Point(16, 35)
        Me.dtpRecibo_Domingo.Name = "dtpRecibo_Domingo"
        Me.dtpRecibo_Domingo.Size = New System.Drawing.Size(81, 20)
        Me.dtpRecibo_Domingo.TabIndex = 154
        Me.dtpRecibo_Domingo.Value = New Date(2015, 8, 14, 0, 0, 0, 0)
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(18, 19)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(30, 13)
        Me.Label58.TabIndex = 155
        Me.Label58.Text = "Data"
        '
        'btnNovo
        '
        Me.btnNovo.Location = New System.Drawing.Point(12, 100)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(263, 23)
        Me.btnNovo.TabIndex = 191
        Me.btnNovo.Text = "Abrir e selecionar funcionarios do novo recibo"
        Me.btnNovo.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        '
        'frmReciboDomingo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(288, 130)
        Me.Controls.Add(Me.btnNovo)
        Me.Controls.Add(Me.GroupBox17)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmReciboDomingo"
        Me.Text = "Recibo de Domingo"
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox17 As GroupBox
    Friend WithEvents btnProcRecDom As Button
    Friend WithEvents btnRecDomingo As Button
    Friend WithEvents btnAbrirRecDom As Button
    Friend WithEvents dtpRecibo_Domingo As DateTimePicker
    Friend WithEvents Label58 As Label
    Friend WithEvents btnNovo As Button
    Friend WithEvents OpenFileDialog As OpenFileDialog
End Class
