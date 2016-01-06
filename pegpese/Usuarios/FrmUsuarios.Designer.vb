<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUsuarios
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
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.txtSenha2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.txtCodFunc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAlterar = New System.Windows.Forms.Button()
        Me.txtSenha1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.dgvUsuarios = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFiltrarNome = New System.Windows.Forms.Button()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvFuncionarios = New System.Windows.Forms.DataGridView()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbEmpresas = New System.Windows.Forms.CheckBox()
        Me.cbArmarios = New System.Windows.Forms.CheckBox()
        Me.cbDepartamentos = New System.Windows.Forms.CheckBox()
        Me.cbFuncionarios = New System.Windows.Forms.CheckBox()
        Me.cbAdminRH = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbRecibos = New System.Windows.Forms.CheckBox()
        Me.cbRelatorios = New System.Windows.Forms.CheckBox()
        Me.ttUsuarios = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbAlterarRH = New System.Windows.Forms.CheckBox()
        Me.cbAdministrador = New System.Windows.Forms.CheckBox()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvFuncionarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(54, 71)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(174, 20)
        Me.txtLogin.TabIndex = 124
        '
        'txtSenha2
        '
        Me.txtSenha2.Location = New System.Drawing.Point(54, 123)
        Me.txtSenha2.Name = "txtSenha2"
        Me.txtSenha2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenha2.Size = New System.Drawing.Size(174, 20)
        Me.txtSenha2.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(8, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 121
        Me.Label4.Text = "Senha"
        '
        'btnLimpar
        '
        Me.btnLimpar.BackgroundImage = Global.GIPP.My.Resources.Resources.ClearButtonBlue
        Me.btnLimpar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpar.Location = New System.Drawing.Point(593, 154)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(92, 47)
        Me.btnLimpar.TabIndex = 7
        Me.ttUsuarios.SetToolTip(Me.btnLimpar, "Limpar todos os campos.")
        Me.btnLimpar.UseVisualStyleBackColor = True
        '
        'txtCodFunc
        '
        Me.txtCodFunc.Enabled = False
        Me.txtCodFunc.Location = New System.Drawing.Point(223, 19)
        Me.txtCodFunc.Name = "txtCodFunc"
        Me.txtCodFunc.Size = New System.Drawing.Size(43, 20)
        Me.txtCodFunc.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Código"
        '
        'btnAlterar
        '
        Me.btnAlterar.BackgroundImage = Global.GIPP.My.Resources.Resources.UpdateButtonBlue
        Me.btnAlterar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAlterar.Location = New System.Drawing.Point(395, 154)
        Me.btnAlterar.Name = "btnAlterar"
        Me.btnAlterar.Size = New System.Drawing.Size(92, 48)
        Me.btnAlterar.TabIndex = 6
        Me.ttUsuarios.SetToolTip(Me.btnAlterar, "Alterar cadastro atual.")
        Me.btnAlterar.UseVisualStyleBackColor = True
        '
        'txtSenha1
        '
        Me.txtSenha1.Location = New System.Drawing.Point(54, 97)
        Me.txtSenha1.Name = "txtSenha1"
        Me.txtSenha1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenha1.Size = New System.Drawing.Size(173, 20)
        Me.txtSenha1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(8, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "Senha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(8, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Login"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(53, 45)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(213, 20)
        Me.txtNome.TabIndex = 124
        '
        'dgvUsuarios
        '
        Me.dgvUsuarios.AllowUserToAddRows = False
        Me.dgvUsuarios.AllowUserToDeleteRows = False
        Me.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsuarios.Location = New System.Drawing.Point(12, 208)
        Me.dgvUsuarios.Name = "dgvUsuarios"
        Me.dgvUsuarios.ReadOnly = True
        Me.dgvUsuarios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgvUsuarios.Size = New System.Drawing.Size(671, 167)
        Me.dgvUsuarios.TabIndex = 123
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnFiltrarNome)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtLogin)
        Me.GroupBox1.Controls.Add(Me.txtNome)
        Me.GroupBox1.Controls.Add(Me.txtSenha2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCodFunc)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtSenha1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(278, 190)
        Me.GroupBox1.TabIndex = 131
        Me.GroupBox1.TabStop = False
        '
        'btnFiltrarNome
        '
        Me.btnFiltrarNome.BackgroundImage = Global.GIPP.My.Resources.Resources.GridBlue
        Me.btnFiltrarNome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnFiltrarNome.Location = New System.Drawing.Point(232, 142)
        Me.btnFiltrarNome.Name = "btnFiltrarNome"
        Me.btnFiltrarNome.Size = New System.Drawing.Size(40, 40)
        Me.btnFiltrarNome.TabIndex = 129
        Me.ttUsuarios.SetToolTip(Me.btnFiltrarNome, "Abrir grade de funcionários.")
        Me.btnFiltrarNome.UseVisualStyleBackColor = True
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(53, 19)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(43, 20)
        Me.txtCodigo.TabIndex = 127
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(107, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 126
        Me.Label6.Text = "Código do funcionário"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(8, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "Nome"
        '
        'dgvFuncionarios
        '
        Me.dgvFuncionarios.AllowUserToAddRows = False
        Me.dgvFuncionarios.AllowUserToDeleteRows = False
        Me.dgvFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFuncionarios.Location = New System.Drawing.Point(12, 208)
        Me.dgvFuncionarios.Name = "dgvFuncionarios"
        Me.dgvFuncionarios.ReadOnly = True
        Me.dgvFuncionarios.Size = New System.Drawing.Size(671, 167)
        Me.dgvFuncionarios.TabIndex = 142
        '
        'btnExcluir
        '
        Me.btnExcluir.BackgroundImage = Global.GIPP.My.Resources.Resources.DeleteButtonBlue
        Me.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnExcluir.Location = New System.Drawing.Point(493, 154)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(92, 47)
        Me.btnExcluir.TabIndex = 128
        Me.ttUsuarios.SetToolTip(Me.btnExcluir, "Excluir cadastro atual.")
        Me.btnExcluir.UseVisualStyleBackColor = True
        '
        'btnGravar
        '
        Me.btnGravar.BackgroundImage = Global.GIPP.My.Resources.Resources.SaveButtonBlue
        Me.btnGravar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGravar.Location = New System.Drawing.Point(295, 154)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(94, 48)
        Me.btnGravar.TabIndex = 5
        Me.ttUsuarios.SetToolTip(Me.btnGravar, "Gravar cadastro atual.")
        Me.btnGravar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbEmpresas)
        Me.GroupBox2.Controls.Add(Me.cbArmarios)
        Me.GroupBox2.Controls.Add(Me.cbDepartamentos)
        Me.GroupBox2.Controls.Add(Me.cbFuncionarios)
        Me.GroupBox2.Location = New System.Drawing.Point(296, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(121, 139)
        Me.GroupBox2.TabIndex = 132
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cadastros RH"
        Me.ttUsuarios.SetToolTip(Me.GroupBox2, "Marcar formulários que serão disponiveis para este usuários.")
        '
        'cbEmpresas
        '
        Me.cbEmpresas.AutoSize = True
        Me.cbEmpresas.Location = New System.Drawing.Point(7, 88)
        Me.cbEmpresas.Name = "cbEmpresas"
        Me.cbEmpresas.Size = New System.Drawing.Size(72, 17)
        Me.cbEmpresas.TabIndex = 4
        Me.cbEmpresas.Text = "Empresas"
        Me.cbEmpresas.UseVisualStyleBackColor = True
        '
        'cbArmarios
        '
        Me.cbArmarios.AutoSize = True
        Me.cbArmarios.Location = New System.Drawing.Point(7, 65)
        Me.cbArmarios.Name = "cbArmarios"
        Me.cbArmarios.Size = New System.Drawing.Size(66, 17)
        Me.cbArmarios.TabIndex = 3
        Me.cbArmarios.Text = "Armários"
        Me.cbArmarios.UseVisualStyleBackColor = True
        '
        'cbDepartamentos
        '
        Me.cbDepartamentos.AutoSize = True
        Me.cbDepartamentos.Location = New System.Drawing.Point(7, 43)
        Me.cbDepartamentos.Name = "cbDepartamentos"
        Me.cbDepartamentos.Size = New System.Drawing.Size(98, 17)
        Me.cbDepartamentos.TabIndex = 1
        Me.cbDepartamentos.Text = "Departamentos"
        Me.cbDepartamentos.UseVisualStyleBackColor = True
        '
        'cbFuncionarios
        '
        Me.cbFuncionarios.AutoSize = True
        Me.cbFuncionarios.Location = New System.Drawing.Point(7, 20)
        Me.cbFuncionarios.Name = "cbFuncionarios"
        Me.cbFuncionarios.Size = New System.Drawing.Size(86, 17)
        Me.cbFuncionarios.TabIndex = 0
        Me.cbFuncionarios.Text = "Funcionários"
        Me.cbFuncionarios.UseVisualStyleBackColor = True
        '
        'cbAdminRH
        '
        Me.cbAdminRH.AutoSize = True
        Me.cbAdminRH.Location = New System.Drawing.Point(6, 19)
        Me.cbAdminRH.Name = "cbAdminRH"
        Me.cbAdminRH.Size = New System.Drawing.Size(89, 17)
        Me.cbAdminRH.TabIndex = 2
        Me.cbAdminRH.Text = "Administrador"
        Me.cbAdminRH.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbAlterarRH)
        Me.GroupBox3.Controls.Add(Me.cbAdminRH)
        Me.GroupBox3.Controls.Add(Me.cbRecibos)
        Me.GroupBox3.Controls.Add(Me.cbRelatorios)
        Me.GroupBox3.Location = New System.Drawing.Point(423, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(121, 139)
        Me.GroupBox3.TabIndex = 133
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Permissões RH"
        '
        'cbRecibos
        '
        Me.cbRecibos.AutoSize = True
        Me.cbRecibos.Location = New System.Drawing.Point(6, 65)
        Me.cbRecibos.Name = "cbRecibos"
        Me.cbRecibos.Size = New System.Drawing.Size(65, 17)
        Me.cbRecibos.TabIndex = 7
        Me.cbRecibos.Text = "Recibos"
        Me.cbRecibos.UseVisualStyleBackColor = True
        '
        'cbRelatorios
        '
        Me.cbRelatorios.AutoSize = True
        Me.cbRelatorios.Location = New System.Drawing.Point(6, 42)
        Me.cbRelatorios.Name = "cbRelatorios"
        Me.cbRelatorios.Size = New System.Drawing.Size(73, 17)
        Me.cbRelatorios.TabIndex = 6
        Me.cbRelatorios.Text = "Relatórios"
        Me.cbRelatorios.UseVisualStyleBackColor = True
        '
        'cbAlterarRH
        '
        Me.cbAlterarRH.AutoSize = True
        Me.cbAlterarRH.Location = New System.Drawing.Point(6, 88)
        Me.cbAlterarRH.Name = "cbAlterarRH"
        Me.cbAlterarRH.Size = New System.Drawing.Size(56, 17)
        Me.cbAlterarRH.TabIndex = 8
        Me.cbAlterarRH.Text = "Alterar"
        Me.cbAlterarRH.UseVisualStyleBackColor = True
        '
        'cbAdministrador
        '
        Me.cbAdministrador.AutoSize = True
        Me.cbAdministrador.Location = New System.Drawing.Point(550, 31)
        Me.cbAdministrador.Name = "cbAdministrador"
        Me.cbAdministrador.Size = New System.Drawing.Size(117, 17)
        Me.cbAdministrador.TabIndex = 10
        Me.cbAdministrador.Text = "Administrador Geral"
        Me.cbAdministrador.UseVisualStyleBackColor = True
        '
        'FrmUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 380)
        Me.Controls.Add(Me.cbAdministrador)
        Me.Controls.Add(Me.dgvFuncionarios)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnGravar)
        Me.Controls.Add(Me.dgvUsuarios)
        Me.Controls.Add(Me.btnAlterar)
        Me.Controls.Add(Me.btnLimpar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrmUsuarios"
        Me.Text = "Usuarios"
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvFuncionarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtLogin As TextBox
    Friend WithEvents txtSenha2 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnLimpar As Button
    Friend WithEvents txtCodFunc As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnAlterar As Button
    Friend WithEvents txtSenha1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNome As TextBox
    Friend WithEvents dgvUsuarios As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnGravar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cbArmarios As System.Windows.Forms.CheckBox
    Friend WithEvents cbAdminRH As System.Windows.Forms.CheckBox
    Friend WithEvents cbDepartamentos As System.Windows.Forms.CheckBox
    Friend WithEvents cbFuncionarios As System.Windows.Forms.CheckBox
    Friend WithEvents cbRecibos As System.Windows.Forms.CheckBox
    Friend WithEvents cbRelatorios As System.Windows.Forms.CheckBox
    Friend WithEvents btnExcluir As System.Windows.Forms.Button
    Friend WithEvents btnFiltrarNome As System.Windows.Forms.Button
    Friend WithEvents dgvFuncionarios As DataGridView
    Friend WithEvents ttUsuarios As ToolTip
    Friend WithEvents cbEmpresas As CheckBox
    Friend WithEvents cbAlterarRH As CheckBox
    Friend WithEvents cbAdministrador As CheckBox
End Class
