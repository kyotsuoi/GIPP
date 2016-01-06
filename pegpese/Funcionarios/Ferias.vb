
Imports MySql.Data.MySqlClient

Public Class Ferias
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Sub CarregarGrade(dados_codigo As Integer)
        Using da As New MySqlDataAdapter("SELECT codigo, data_inicial, data_final FROM ferias where dados_codigo = '" + dados_codigo.ToString + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvFerias.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Function Ferias(codigo As Integer) As String
        Try
            Connection.Query = "SELECT data_inicial FROM ferias WHERE dados_codigo='" + codigo.ToString + "'ORDER BY codigo DESC LIMIT 1"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            Dim Scalar As String = cmd.ExecuteScalar()
            Connection.Connect.Close()
            Return Scalar
        Catch ex As Exception
            Connection.Connect.Close()
            Return MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Function UltimoCodFerias(dados_codigo As Integer) As String
        Try
            Connection.Query = "SELECT codigo FROM ferias where dados_codigo='" + dados_codigo.ToString + "'  ORDER BY codigo DESC LIMIT 1"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            Dim Scalar As String = cmd.ExecuteScalar()
            Connection.Connect.Close()
            Return Scalar
        Catch ex As Exception
            Connection.Connect.Close()
            Return MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Sub AlterarCheck2(codigo As Integer)
        Try
            Connection.Query = "UPDATE ferias SET `check`='0' WHERE codigo='" + codigo.ToString + "'"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MsgBox("Dados alterados com sucesso!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe Ferias " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub AlterarCheck1(codigo As Integer)
        Try
            Connection.Query = "UPDATE dados SET `check`='1' WHERE codigo='" + codigo.ToString + "'"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe Ferias " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Function Check(dados_codigo As Integer) As String
        Try
            Connection.Query = "SELECT codigo FROM ferias WHERE dados_codigo ='" + dados_codigo.ToString + "' ORDER BY codigo DESC LIMIT 1"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            Dim Scalar As String = cmd.ExecuteScalar()
            Connection.Connect.Close()
            Return Scalar
        Catch ex As Exception
            Connection.Connect.Close()
            Return MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Sub Gravar(data_inicial As String, data_final As String, dados_codigo As Integer, vCheck As Integer)
        Try
            Connection.Query = "INSERT INTO ferias (data_inicial, data_final, `check`, dados_codigo) VALUES ('" +
                data_inicial + "','" + data_final + "','" + vCheck.ToString + "','" + dados_codigo.ToString + "')"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MsgBox("Dados gravados com sucesso!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao gravar na classe Ferias " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub Alterar(data_inicial As String, data_final As String, codigo As Integer)
        Try
            Connection.Query = "UPDATE ferias SET data_inicial='" + data_inicial + "', data_final='" + data_final +
                "' WHERE codigo='" + codigo.ToString + "'"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MsgBox("Dados alterados com sucesso!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe Ferias " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub AlterarCheck(codigo As Integer, vCheck As Integer)
        Try
            Connection.Query = "UPDATE ferias SET `check`='" + vCheck.ToString +
                "' WHERE codigo='" + codigo.ToString + "'"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar 'check' na classe Ferias " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub Apagar(codigo As Integer)
        Try
            Connection.Query = "DELETE FROM ferias WHERE codigo='" + codigo.ToString + "'"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MsgBox("Dados apagados com sucesso!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao apagar na classe Ferias! " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub
End Class
