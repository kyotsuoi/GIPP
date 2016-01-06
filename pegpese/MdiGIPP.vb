Imports System.IO
Imports System.Threading

Public Class MdiGIPP

    Public path As String
    Dim vPopUpCont(2), vPUAGrid As Integer
    Public vClosingPath, vAdminRH, vAlterarRH, vRelatorios As Boolean
    Dim printer As New Printer
    Dim PopUpFerias As New PopUpFerias
    Dim connection As New Connection
    Public Thread As New Thread(AddressOf PopUp_Thread)
    Delegate Sub DelegateCallBack()

    Dim administrador, admin_rh, alterar_rh As Boolean

    Private Sub mdiPeg_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        IsMdiContainer = True
        CadastrosToolStripMenuItem.Enabled = False
        RelatoriosToolStripMenuItem.Enabled = False
        RecibosToolStripMenuItem.Enabled = False
        UsuariosToolStripMenuItem.Enabled = False

        Timer.Start()
        Timer.Interval = 1000

        clock_align()
        lblClock_MouseLeave(sender, e)

        pPopUp.Visible = False
        pPopUp.Location = New Drawing.Point(12, Me.Height - 165)

        Try
            Do While vClosingPath = False
                Path_ConfigTest()
            Loop
        Catch ex As Exception
            MessageBox.Show("Caminho de rede não encontrado! " + ex.Message)
            Me.Close()
        End Try

    End Sub

    Private Sub mdiGIPP_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Deseja realmentente desativar o sistema?", vbYesNo, "Confirmação") = vbNo Then e.Cancel = True
    End Sub

    Private Sub Path_ConfigTest()
        If File.Exists(connection.PathString) Then
            path = My.Computer.FileSystem.ReadAllText(connection.PathString)
        Else
            MessageBox.Show("Caminho de rede não encontrado! Por favor insira o caminho de rede a seguir...")
            Path_Config()
        End If

        If File.Exists(path + "\Fotos\back.jpg") Then
            Me.BackgroundImage = Image.FromFile(path + "\Fotos\back.jpg")
            Me.BackgroundImageLayout = ImageLayout.Stretch
            Connect_Forms()
            vClosingPath = True
        Else
            MessageBox.Show("O caminho de rede para todos os recursos esta desconectado! Provavelmente existe algum erro no caminho de rede do arquivo Path.")
            vClosingPath = False
            Path_Config()
        End If
    End Sub

    Public Sub Path_Config()
        frmPath.ShowDialog()

        Dim SW As New StreamWriter(connection.PathString)
        SW.Write(path)
        SW.Close()
        SW.Dispose()
        path = My.Computer.FileSystem.ReadAllText(connection.PathString)
    End Sub

    Private Sub Connect_Forms()
        PopUpFerias.connect_base()
        printer.connect_base()
        frmLogin.MdiParent = Me
        frmLogin.Show()
        frmLogin.Focus()
    End Sub

    Private Sub mdiPeg_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        Try
            Thread.Abort()
        Catch
            Thread.Resume()
            Thread.Abort()
        End Try
    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click
        If LoginToolStripMenuItem.Text = "Logout" Then
            If MsgBox("Deseja realmentente fazer logout?", vbYesNo, "Confirmação") = vbYes Then
                Me.Text = "GIPP"
                Login_Logout()
                Thread.Suspend()
                pPopUp.Visible = False
            End If
        Else
            Login_Logout()
        End If
    End Sub

    Private Sub Login_Logout()
        frmLogin.Close()
        frmLogin.MdiParent = Me
        frmLogin.Show()
        frmLogin.Focus()
        CadastrosToolStripMenuItem.Enabled = False
        RelatoriosToolStripMenuItem.Enabled = False
        RecibosToolStripMenuItem.Enabled = False
        UsuariosToolStripMenuItem.Enabled = False
        CloseAll()

        If LoginToolStripMenuItem.Enabled = True Then
            LoginToolStripMenuItem.Enabled = False
        Else
            LoginToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub CloseAll()
        frmFuncionarios.Close()
        FrmUsuarios.Close()
        frmArmarios.Close()
        frmDepartamentos.Close()
        frmPrinter.Close()
        frmReciboDomingo.Close()
        frmEmpresas.Close()
        frmAniver.Close()
        frmExp.Close()
    End Sub

    Private Sub FuncionariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FuncionariosToolStripMenuItem.Click
        frmFuncionarios.MdiParent = Me
        frmFuncionarios.Show()
        frmFuncionarios.Focus()
        permissions()
    End Sub

    Private Sub UsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuariosToolStripMenuItem.Click
        FrmUsuarios.MdiParent = Me
        FrmUsuarios.Show()
        FrmUsuarios.Focus()
    End Sub

    Private Sub ArmariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArmariosToolStripMenuItem.Click
        frmArmarios.MdiParent = Me
        frmArmarios.Show()
        frmArmarios.Focus()
        permissions()
    End Sub

    Private Sub DepartamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepartamentosToolStripMenuItem.Click
        frmDepartamentos.MdiParent = Me
        frmDepartamentos.Show()
        frmDepartamentos.Focus()
        permissions()
    End Sub

    Private Sub EmpresaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpresaToolStripMenuItem.Click
        frmEmpresas.MdiParent = Me
        frmEmpresas.Show()
        frmEmpresas.Focus()
        permissions()
    End Sub

    Private Sub permissions()

    End Sub

    Private Sub NotasDeBugsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotasDeAtualiToolStripMenuItem.Click
        MessageBox.Show("Form Funcionarios - Atualizar Combo de empresas ao modificar a tabela de empresas - Concluido " &
                        vbLf & "Busca de funcionario com erro - Concluido" &
                        vbLf & "Form Funcionarios - perguntar antes de alterar, excluir e limpar funcionario - Concluido" &
                        vbLf & "Form Funcionarios - Codigo do relatorio capivara sumiu? - Concluido" &
                        vbLf & "Form Funcionarios - Botao para busca de departamento - Concluido" &
                        vbLf & "Form Funcionarios - Disponibilidade para o admin alterar codigo de usuario - Concluido" &
                        vbLf & "Form Funcionarios - Cancelar fechamento do form quando 'vbQuestion' for 'NO' - Concluido" &
                        vbLf & "Form Funcionarios - Erro na alteracao da foto - Concluido" &
                        vbLf & "Form Funcionarios - Uniformes - Nao busca valor do uniforme na grade - Concluido" &
                        vbLf & "Form Armarios - Mostrar o departamento do funcionario - Concluido" &
                        vbLf & "Form Funcionarios - Relatorio de avaliacao de experiencias para vencer - Em andamento", "Notas de Atualização")
    End Sub

    Private Sub FuncRelatoriosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FuncRelatoriosToolStripMenuItem.Click
        frmPrinter.lblPrinter.Text = "Funcionario"
        frmPrinter.Show()
        printer.CarregaFuncionario()
        frmPrinter.Focus()
    End Sub

    Private Sub VencimentoDeFeriasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VencimentoDeExpToolStripMenuItem.Click
        frmExp.Show()
        frmExp.MdiParent = Me
    End Sub

    Private Sub AniversariantesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AniversariantesToolStripMenuItem.Click
        frmAniver.Show()
        frmAniver.MdiParent = Me
    End Sub

    Private Sub ReciboDeDomingoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReciboDeDomingoToolStripMenuItem.Click
        frmReciboDomingo.MdiParent = Me
        frmReciboDomingo.Show()
        frmReciboDomingo.Focus()
    End Sub




    '>>>>>>>>>>CLOCK<<<<<<<<<<

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        lblClock.Text = Now.ToShortTimeString
        If NotasDeAtualiToolStripMenuItem.Visible = False Then
            NotasDeAtualiToolStripMenuItem.Visible = True
        Else
            NotasDeAtualiToolStripMenuItem.Visible = False
        End If
        clock_align()
    End Sub

    Private Sub lblClock_MouseHover(sender As Object, e As EventArgs) Handles lblClock.MouseHover
        lblClock.Font = New Font(lblClock.Font.FontFamily, 48)

        Dim x As Integer
        x = (Me.Width / 2) - (lblClock.Width / 2)
        lblClock.Location = New System.Drawing.Point(x - 5, 0)
    End Sub

    Private Sub lblClock_MouseLeave(sender As Object, e As EventArgs) Handles lblClock.MouseLeave
        Dim Thread As New Thread(AddressOf Clock_Thread)
        Thread.Start()
    End Sub

    Public Sub Clock_Thread()
        Thread.Sleep(5000)
        clock_minimizer()
    End Sub

    Private Sub clock_minimizer()
        If Me.InvokeRequired Then
            Me.Invoke(New DelegateCallBack(AddressOf clock_minimizer))
        Else
            lblClock.Font = New Font(lblClock.Font.FontFamily, 10)
            clock_align()
        End If
    End Sub

    Private Sub clock_align()
        Dim x As Integer
        x = (Me.Width / 2) - (lblClock.Width / 2)
        lblClock.Location = New System.Drawing.Point(x - 7, 0)
    End Sub




    '>>>>>>>>>>POPUP<<<<<<<<<<

    Public Sub PopUp_Thread()
        While True
            Thread.Sleep(1000)
            If Me.InvokeRequired Then
                Me.Invoke(New DelegateCallBack(AddressOf Open_PopUp))
            Else
                Open_PopUp()
            End If

            Thread.Sleep(2000)
            If Me.InvokeRequired Then
                Me.Invoke(New DelegateCallBack(AddressOf pPopUp_Wide))
            Else
                pPopUp_Wide()
            End If

            Thread.Sleep(5000)
            If Me.InvokeRequired Then
                Me.Invoke(New DelegateCallBack(AddressOf pPopUp_Compress))
            Else
                pPopUp_Compress()
            End If

            Thread.Sleep(2000)
            If Me.InvokeRequired Then
                Me.Invoke(New DelegateCallBack(AddressOf pPopUp_Compress))
            Else
                pPopUp_Compress()
            End If
        End While
    End Sub

    Public Sub pPopUp_Compress()
        If pPopUp.Width > 90 Then
            pPopUp.Width = 90
        Else
            pPopUp.Visible = False
        End If
    End Sub

    Private Sub pPopUp_Wide()
        While pPopUp.Width < 350
            Thread.Sleep(0.5)
            pPopUp.Width += 1
        End While
    End Sub

    Private Sub Open_PopUp()
        Try
            PopUpFerias.CarregarFerias1()
            PopUpFerias.CarregarFerias2()

            If vPUAGrid = 0 Then
                If dgvFerias1.Item(0, vPopUpCont(vPUAGrid)).Value = Nothing Then
                    vPopUpCont(vPUAGrid) = 0
                    vPUAGrid = 1
                    Return
                End If
            Else
                If dgvFerias2.Item(0, vPopUpCont(vPUAGrid)).Value = Nothing Then
                    vPopUpCont(vPUAGrid) = 0
                    vPUAGrid = 0
                    Return
                End If
            End If
            pPopUp.Visible = True

            Dim path As String
            If File.Exists(connection.PathString) Then
                path = My.Computer.FileSystem.ReadAllText(connection.PathString)

                Dim vString As String
                Dim vDate As Date

                If vPUAGrid = 1 Then
                    vString = dgvFerias2.Item(0, vPopUpCont(vPUAGrid)).Value
                    lblNome.Text = PopUpFerias.BuscarNome(vString)
                    vDate = dgvFerias2.Item(1, vPopUpCont(vPUAGrid)).Value
                    lblVenc.Text = vDate.AddYears(1)
                Else
                    vString = dgvFerias1.Item(0, vPopUpCont(vPUAGrid)).Value
                    lblNome.Text = PopUpFerias.BuscarNome(vString)
                    vDate = dgvFerias1.Item(1, vPopUpCont(vPUAGrid)).Value
                    lblVenc.Text = vDate.AddYears(1)
                End If

                Dim vFoto As String = path + "\Fotos\" + vString + ".png"
                If vFoto <> "" Then
                    If File.Exists(vFoto) Then
                        pbPopUp.Image = Image.FromFile(vFoto)
                    Else
                        pbPopUp.Image = Nothing
                    End If
                End If
            Else
                MessageBox.Show("Caminho da rede não encontrado!")
            End If
            vPopUpCont(vPUAGrid) += 1
            If (vPUAGrid) = 0 Then
                vPUAGrid = 1
            Else
                vPUAGrid = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Algo foi alterado nas tabelas de ferias!" + ex.Message)
            vPopUpCont(0) = 0
            vPopUpCont(1) = 0
        End Try

    End Sub

End Class
