<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MdiGIPP
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MdiGIPP))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.RHToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArmariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DepartamentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmpresaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FuncionariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecibosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReciboDeDomingoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FeriadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AvulsoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RelatoriosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FuncRelatoriosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VencimentoDeExpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AniversariantesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotasDeAtualiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.lblClock = New System.Windows.Forms.Label()
        Me.pbPopUp = New System.Windows.Forms.PictureBox()
        Me.pPopUp = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblVenc = New System.Windows.Forms.Label()
        Me.lblNome = New System.Windows.Forms.Label()
        Me.dgvFerias1 = New System.Windows.Forms.DataGridView()
        Me.dgvFerias2 = New System.Windows.Forms.DataGridView()
        Me.MenuStrip.SuspendLayout()
        CType(Me.pbPopUp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pPopUp.SuspendLayout()
        CType(Me.dgvFerias1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFerias2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RHToolStripMenuItem, Me.UsuariosToolStripMenuItem, Me.LoginToolStripMenuItem, Me.NotasDeAtualiToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1131, 24)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'RHToolStripMenuItem
        '
        Me.RHToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastrosToolStripMenuItem, Me.RecibosToolStripMenuItem, Me.RelatoriosToolStripMenuItem})
        Me.RHToolStripMenuItem.Name = "RHToolStripMenuItem"
        Me.RHToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.RHToolStripMenuItem.Text = "&RH"
        '
        'CadastrosToolStripMenuItem
        '
        Me.CadastrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArmariosToolStripMenuItem, Me.DepartamentosToolStripMenuItem, Me.EmpresaToolStripMenuItem, Me.FuncionariosToolStripMenuItem})
        Me.CadastrosToolStripMenuItem.Name = "CadastrosToolStripMenuItem"
        Me.CadastrosToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.CadastrosToolStripMenuItem.Text = "&Cadastros"
        '
        'ArmariosToolStripMenuItem
        '
        Me.ArmariosToolStripMenuItem.Name = "ArmariosToolStripMenuItem"
        Me.ArmariosToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ArmariosToolStripMenuItem.Text = "&Armarios"
        '
        'DepartamentosToolStripMenuItem
        '
        Me.DepartamentosToolStripMenuItem.Name = "DepartamentosToolStripMenuItem"
        Me.DepartamentosToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.DepartamentosToolStripMenuItem.Text = "&Departamentos"
        '
        'EmpresaToolStripMenuItem
        '
        Me.EmpresaToolStripMenuItem.Name = "EmpresaToolStripMenuItem"
        Me.EmpresaToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.EmpresaToolStripMenuItem.Text = "&Empresa"
        '
        'FuncionariosToolStripMenuItem
        '
        Me.FuncionariosToolStripMenuItem.Name = "FuncionariosToolStripMenuItem"
        Me.FuncionariosToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.FuncionariosToolStripMenuItem.Text = "&Funcionarios"
        '
        'RecibosToolStripMenuItem
        '
        Me.RecibosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReciboDeDomingoToolStripMenuItem, Me.FeriadoToolStripMenuItem, Me.AvulsoToolStripMenuItem})
        Me.RecibosToolStripMenuItem.Name = "RecibosToolStripMenuItem"
        Me.RecibosToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.RecibosToolStripMenuItem.Text = "Recibos"
        '
        'ReciboDeDomingoToolStripMenuItem
        '
        Me.ReciboDeDomingoToolStripMenuItem.Name = "ReciboDeDomingoToolStripMenuItem"
        Me.ReciboDeDomingoToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ReciboDeDomingoToolStripMenuItem.Text = "Recibo de Domingo"
        '
        'FeriadoToolStripMenuItem
        '
        Me.FeriadoToolStripMenuItem.Name = "FeriadoToolStripMenuItem"
        Me.FeriadoToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.FeriadoToolStripMenuItem.Text = "Feriado"
        '
        'AvulsoToolStripMenuItem
        '
        Me.AvulsoToolStripMenuItem.Name = "AvulsoToolStripMenuItem"
        Me.AvulsoToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.AvulsoToolStripMenuItem.Text = "Avulso"
        '
        'RelatoriosToolStripMenuItem
        '
        Me.RelatoriosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FuncRelatoriosToolStripMenuItem, Me.VencimentoDeExpToolStripMenuItem, Me.AniversariantesToolStripMenuItem})
        Me.RelatoriosToolStripMenuItem.Name = "RelatoriosToolStripMenuItem"
        Me.RelatoriosToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.RelatoriosToolStripMenuItem.Text = "Relatorios"
        '
        'FuncRelatoriosToolStripMenuItem
        '
        Me.FuncRelatoriosToolStripMenuItem.Name = "FuncRelatoriosToolStripMenuItem"
        Me.FuncRelatoriosToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.FuncRelatoriosToolStripMenuItem.Text = "Funcionarios"
        '
        'VencimentoDeExpToolStripMenuItem
        '
        Me.VencimentoDeExpToolStripMenuItem.Name = "VencimentoDeExpToolStripMenuItem"
        Me.VencimentoDeExpToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.VencimentoDeExpToolStripMenuItem.Text = "Vencimento de Experiencias"
        '
        'AniversariantesToolStripMenuItem
        '
        Me.AniversariantesToolStripMenuItem.Name = "AniversariantesToolStripMenuItem"
        Me.AniversariantesToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.AniversariantesToolStripMenuItem.Text = "Aniversariantes"
        '
        'UsuariosToolStripMenuItem
        '
        Me.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        Me.UsuariosToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.UsuariosToolStripMenuItem.Text = "&Usuarios"
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.LoginToolStripMenuItem.Text = "Login"
        '
        'NotasDeAtualiToolStripMenuItem
        '
        Me.NotasDeAtualiToolStripMenuItem.Name = "NotasDeAtualiToolStripMenuItem"
        Me.NotasDeAtualiToolStripMenuItem.Size = New System.Drawing.Size(130, 20)
        Me.NotasDeAtualiToolStripMenuItem.Text = "Notas de Atualização"
        '
        'Timer
        '
        '
        'lblClock
        '
        Me.lblClock.AutoSize = True
        Me.lblClock.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblClock.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClock.ForeColor = System.Drawing.Color.Blue
        Me.lblClock.Location = New System.Drawing.Point(479, 0)
        Me.lblClock.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblClock.Name = "lblClock"
        Me.lblClock.Size = New System.Drawing.Size(194, 73)
        Me.lblClock.TabIndex = 1
        Me.lblClock.Text = "00:00"
        '
        'pbPopUp
        '
        Me.pbPopUp.InitialImage = Nothing
        Me.pbPopUp.Location = New System.Drawing.Point(3, 3)
        Me.pbPopUp.Name = "pbPopUp"
        Me.pbPopUp.Size = New System.Drawing.Size(84, 106)
        Me.pbPopUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbPopUp.TabIndex = 4
        Me.pbPopUp.TabStop = False
        '
        'pPopUp
        '
        Me.pPopUp.Controls.Add(Me.Label2)
        Me.pPopUp.Controls.Add(Me.Label1)
        Me.pPopUp.Controls.Add(Me.lblVenc)
        Me.pPopUp.Controls.Add(Me.lblNome)
        Me.pPopUp.Controls.Add(Me.pbPopUp)
        Me.pPopUp.Location = New System.Drawing.Point(12, 375)
        Me.pPopUp.Name = "pPopUp"
        Me.pPopUp.Size = New System.Drawing.Size(90, 112)
        Me.pPopUp.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(106, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Vencimento..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(106, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Periodo de ferias ainda pendente"
        '
        'lblVenc
        '
        Me.lblVenc.AutoSize = True
        Me.lblVenc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVenc.Location = New System.Drawing.Point(199, 68)
        Me.lblVenc.Name = "lblVenc"
        Me.lblVenc.Size = New System.Drawing.Size(89, 20)
        Me.lblVenc.TabIndex = 8
        Me.lblVenc.Text = "26/09/2015"
        '
        'lblNome
        '
        Me.lblNome.AutoSize = True
        Me.lblNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNome.Location = New System.Drawing.Point(105, 12)
        Me.lblNome.Name = "lblNome"
        Me.lblNome.Size = New System.Drawing.Size(75, 20)
        Me.lblNome.TabIndex = 7
        Me.lblNome.Text = "Marianna"
        '
        'dgvFerias1
        '
        Me.dgvFerias1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFerias1.Location = New System.Drawing.Point(975, 203)
        Me.dgvFerias1.Name = "dgvFerias1"
        Me.dgvFerias1.Size = New System.Drawing.Size(321, 150)
        Me.dgvFerias1.TabIndex = 7
        Me.dgvFerias1.Visible = False
        '
        'dgvFerias2
        '
        Me.dgvFerias2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFerias2.Location = New System.Drawing.Point(975, 359)
        Me.dgvFerias2.Name = "dgvFerias2"
        Me.dgvFerias2.Size = New System.Drawing.Size(321, 150)
        Me.dgvFerias2.TabIndex = 8
        Me.dgvFerias2.Visible = False
        '
        'MdiGIPP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1131, 569)
        Me.Controls.Add(Me.dgvFerias2)
        Me.Controls.Add(Me.dgvFerias1)
        Me.Controls.Add(Me.pPopUp)
        Me.Controls.Add(Me.lblClock)
        Me.Controls.Add(Me.MenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip
        Me.MaximizeBox = False
        Me.Name = "MdiGIPP"
        Me.Text = "GIPP"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.pbPopUp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pPopUp.ResumeLayout(False)
        Me.pPopUp.PerformLayout()
        CType(Me.dgvFerias1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFerias2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents LoginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotasDeAtualiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer As Timer
    Friend WithEvents lblClock As Label
    Friend WithEvents pbPopUp As PictureBox
    Friend WithEvents pPopUp As Panel
    Friend WithEvents lblNome As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblVenc As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvFerias1 As DataGridView
    Friend WithEvents dgvFerias2 As DataGridView
    Friend WithEvents RHToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CadastrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ArmariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DepartamentosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmpresaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FuncionariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RecibosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReciboDeDomingoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FeriadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AvulsoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RelatoriosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FuncRelatoriosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VencimentoDeExpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AniversariantesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As ToolStripMenuItem
End Class
