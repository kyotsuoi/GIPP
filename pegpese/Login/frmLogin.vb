Public Class frmLogin
    Dim usuarios As New usuarios
    Dim login As New Login
    Dim aniver As New Aniver
    Public vCheck As Boolean = False

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear_all()
        login.connect_base()
        aniver.connect_base()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Loged()
    End Sub

    Private Sub Loged()
        If txtLogin.Text = "" Or txtSenha.Text = "" Then
            MessageBox.Show("Preencha os campos login e senha!")
        Else
            Dim log As String = login.BuscarLogin(txtLogin.Text)

            If log <> "" Or log <> Nothing Then
                Dim senha As String = login.BuscarSenha(log)
                Dim vFuncionarios As Boolean = login.BuscarCampo(log, "funcionarios")
                Dim vAdministrador As Boolean = login.BuscarCampo(log, "administrador")
                Dim vArmarios As Boolean = login.BuscarCampo(log, "armarios")
                Dim vDepartamentos As Boolean = login.BuscarCampo(log, "departamentos")
                Dim vRelatorios As Boolean = login.BuscarCampo(log, "relatorios")
                Dim vRecibos As Boolean = login.BuscarCampo(log, "recibos")
                Dim vEmpresas As Boolean = login.BuscarCampo(log, "empresas")
                Dim vAdminRH As Boolean = login.BuscarCampo(log, "admin_rh")
                Dim vAlterarRH As Boolean = login.BuscarCampo(log, "alterar_rh")

                If txtLogin.Text = log And txtSenha.Text = senha Then
                    MessageBox.Show("Entrou como " + log + "!")
                    vCheck = True
                    Login_Test()

                    MdiGIPP.CadastrosToolStripMenuItem.Enabled = True
                    MdiGIPP.UsuariosToolStripMenuItem.Enabled = True

                    MdiGIPP.FuncionariosToolStripMenuItem.Enabled = vFuncionarios
                    MdiGIPP.UsuariosToolStripMenuItem.Enabled = vAdministrador
                    MdiGIPP.ArmariosToolStripMenuItem.Enabled = vArmarios
                    MdiGIPP.DepartamentosToolStripMenuItem.Enabled = vDepartamentos
                    MdiGIPP.RelatoriosToolStripMenuItem.Enabled = vFuncionarios
                    MdiGIPP.RecibosToolStripMenuItem.Enabled = vRecibos
                    MdiGIPP.EmpresaToolStripMenuItem.Enabled = vEmpresas

                    MdiGIPP.vAdminRH = vAdminRH
                    MdiGIPP.vAlterarRH = vAlterarRH
                    MdiGIPP.vRelatorios = vRelatorios

                    Try
                        If vFuncionarios = True Then MdiGIPP.Thread.Start()
                    Catch
                        Try
                            If vFuncionarios = True Then MdiGIPP.Thread.Resume()
                        Catch ex As Exception
                            MessageBox.Show(ex.Message)
                        End Try
                    End Try

                    MdiGIPP.Text = MdiGIPP.Text + " (" + log + ")"
                    Me.Close()

                    frmAniver.Show()
                    frmAniver.MdiParent = MdiGIPP
                    aniver.BuscaAniver(Now)
                    If frmAniver.dgvAniver.RowCount - 1 <= 0 Then
                        frmAniver.Close()
                    End If

                Else
                    Try
                        My.Computer.Audio.Play("C:\Program Files (x86)\GIPP\alarme.wav", AudioPlayMode.Background)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                    MessageBox.Show("Login ou senha não conferem!")
                End If
            Else
                Try
                    My.Computer.Audio.Play("C:\Program Files (x86)\GIPP\alarme.wav", AudioPlayMode.Background)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                MessageBox.Show("Login ou senha não conferem!")
            End If
        End If
    End Sub

    Private Sub Login_Test()
        If vCheck = True Then
            MdiGIPP.LoginToolStripMenuItem.Text = "Logout"
            MdiGIPP.LoginToolStripMenuItem.Enabled = True
        Else
            MdiGIPP.LoginToolStripMenuItem.Text = "Login"
            MdiGIPP.LoginToolStripMenuItem.Enabled = True
            MdiGIPP.UsuariosToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub clear_all()
        txtLogin.Text = ""
        txtSenha.Text = ""
    End Sub

    Private Sub frmLogin_Closing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        If vCheck = False Then
            MessageBox.Show("Fechando sem login... recursos bloqueados...")
            Login_Test()
            MdiGIPP.Text = "GIPP"
        End If
    End Sub

    Private Sub btnAjuda_Click(sender As Object, e As EventArgs) Handles btnAjuda.MouseClick
        If Me.Height = 157 Then
            While Me.Height < 600
                Me.Height = Me.Height + 1
            End While
        Else
            While Me.Height <> 157
                Me.Height = Me.Height - 1
            End While
        End If
    End Sub

    Private Sub txtSenha_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSenha.KeyDown
        If e.KeyCode = Keys.Enter Then
            Loged()
        End If
    End Sub

    Private Sub txtLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLogin.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSenha.Focus()
        End If
    End Sub

End Class