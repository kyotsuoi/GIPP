Imports MySql.Data.MySqlClient

Public Class usuarios
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Sub Gravar(codFunc As Integer, login As String, senha As String, vAdministrador As Integer, vFuncionarios As Integer, vDepartamentos As Integer,
                      vArmarios As Integer, vRelatorios As Integer, vrecibos As Integer, vempresas As Integer, vAdminRH As Integer, vAlterarRH As Integer)
        Try
            Connection.Query = "Insert into usuarios (dados_codigo, login, senha, administrador, funcionarios, departamentos, armarios, relatorios, recibos" +
                ", empresas, admin_rh, alterar_rh)" +
                "values ('" + codFunc.ToString + "','" + login + "','" + senha + "','" + vAdministrador.ToString + "','" + vFuncionarios.ToString + "','" +
                vDepartamentos.ToString + "','" + vArmarios.ToString + "','" + vRelatorios.ToString + "','" + vrecibos.ToString + "','" + vempresas.ToString +
                "','" + vAdminRH.ToString + "','" + vAlterarRH.ToString + "')"
            Connection.Connect.Close()
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MsgBox("Dados gravados com sucesso!")
        Catch ex As Exception
            Connection.Connect.Close()
            MessageBox.Show("Houve um erro ao gravar na classe usuarios! " + ex.Message)
        End Try
    End Sub

    Public Sub Alterar(login As String, senha As String, vAdministrador As Integer, vFuncionarios As Integer, vDepartamentos As Integer, vArmarios As Integer,
                       vRelatorios As Integer, vRecibos As Integer, vEmpresas As Integer, vAdminRH As Integer, vAlterarRH As Integer, codigo As Integer)
        Try
            Connection.Query = "UPDATE usuarios Set login='" + login + "', senha='" + senha +
                                "', administrador='" + vAdministrador.ToString + "', funcionarios='" + vFuncionarios.ToString + "', departamentos='" +
                                vDepartamentos.ToString + "', armarios='" + vArmarios.ToString + "', relatorios='" + vRelatorios.ToString + "', recibos='" +
                                vRecibos.ToString + "', empresas='" + vEmpresas.ToString + "', admin_rh='" + vAdminRH.ToString + "', alterar_rh='" +
                                vAlterarRH.ToString + "'" +
                                " WHERE codigo='" + codigo.ToString + "'"
            Connection.Connect.Close()
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MsgBox("Dados alterados com sucesso!")
        Catch ex As Exception
            Connection.Connect.Close()
            MessageBox.Show("Houve um erro ao alterar na classe usuarios! " + ex.Message)
        End Try
    End Sub

    Public Sub Apagar(codigo As Integer)
        Try
            Connection.Query = "DELETE FROM usuarios WHERE codigo='" + codigo.ToString + "'"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            Connection.Connect.Close()
            MsgBox("Dados apagados com sucesso!")
        Catch ex As Exception
            Connection.Connect.Close()
            MessageBox.Show("Houve um erro ao apagar na classe Usuarios! " + ex.Message)
        End Try
        CarregarGrade()
    End Sub

    Public Sub CarregarGrade()
        Using da As New MySqlDataAdapter("SELECT *" +
                                         "FROM usuarios", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                FrmUsuarios.dgvUsuarios.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Function BuscarNome(codigo As Integer) As String
        connection.Query = "Select nome FROM dados where codigo='" + codigo.ToString + "'"
        connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(connection.Query, connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()
        connection.Connect.Close()
        Return Scalar
    End Function

    Public Sub CarregarGradeF()
        Using da As New MySqlDataAdapter("SELECT codigo, nome " +
                "FROM dados", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                FrmUsuarios.dgvFuncionarios.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Function Exixtente(codigo As Integer) As String
        Connection.Query = "Select dados_codigo FROM usuarios Where dados_codigo ='" + codigo.ToString + "'"
        Connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()
        Connection.Connect.Close()
        Return Scalar
    End Function
    Public Function BuscaSenha(codigo As Integer) As String
        Connection.Query = "Select senha FROM usuarios Where dados_codigo ='" + codigo.ToString + "'"
        Connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()
        Connection.Connect.Close()
        Return Scalar
    End Function
End Class


