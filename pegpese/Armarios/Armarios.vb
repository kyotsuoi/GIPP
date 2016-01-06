Imports MySql.Data.MySqlClient

Public Class Armarios
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Sub CarregarGradeF()
        Using da As New MySqlDataAdapter("SELECT codigo, nome " +
                "FROM dados", Connection.Connect)
            Using ds As New DataSet
                da.Fill(ds)
                frmArmarios.dgvFuncionarios.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub
    Public Sub CarregaGrade()
        Using da As New MySqlDataAdapter("SELECT dados_codigo,nome, obs, n_armario " +
                "FROM armarios ", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmArmarios.dgvArmarios.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Sub Gravar(nome As String, obs As String, n_armario As Integer, dados_codigo As Integer)
        Try
            Connection.Query = "INSERT INTO armarios (nome, obs, n_armario, dados_codigo) VALUES ('" + nome + "', '" + obs + "', '" + n_armario.ToString + "', '" + dados_codigo.ToString + "')"
            Connection.Connect.Open()

            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            MsgBox("Dados gravados com sucesso!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao gravar na classe Armarios " + ex.Message)
        End Try
        Connection.Connect.Dispose()
        Connection.Connect.Close()
    End Sub
    Public Sub Alterar(nome As String, obs As String, n_armario As Integer, dados_codigo As Integer)
        Try
            Connection.Query = "UPDATE armarios Set nome='" + nome + "', obs='" + obs + "', n_armario='" + n_armario.ToString + "' where dados_codigo='" + dados_codigo.ToString + "' "
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            MsgBox("Dados alterados com sucesso!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe Armarios " + ex.Message)
        End Try
        Connection.Connect.Dispose()
        Connection.Connect.Close()
    End Sub

    Public Function BuscarArmario(codFunc As Integer, numero As Integer) As String
        Connection.Query = "Select dados_codigo, n_armario FROM armarios " +
                            "Where dados_codigo='" + codFunc.ToString + "' or n_armario='" + numero.ToString + "'"
        Connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()
        Connection.Connect.Close()
        Return Scalar
    End Function

    Public Function BuscarArmarioAlterar(numero As Integer) As String
        Connection.Query = "Select n_armario FROM armarios " +
                            "Where n_armario='" + numero.ToString + "'"
        Connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()
        Connection.Connect.Close()
        Return Scalar
    End Function

    Public Function BuscarDepart(codFunc As Integer) As String
        Connection.Query = "SELECT departamentos_codigo FROM dados " +
                            "WHERE codigo='" + codFunc.ToString + "'"
        Connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()

        Connection.Query = "SELECT centro_custo FROM departamentos " +
                            "WHERE codigo='" + Scalar + "'"
        cmd = New MySqlCommand(Connection.Query, Connection.Connect)
        Scalar = cmd.ExecuteScalar()

        Connection.Connect.Close()
        Return Scalar
    End Function

End Class