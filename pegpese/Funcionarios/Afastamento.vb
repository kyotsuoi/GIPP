Imports MySql.Data.MySqlClient

Public Class Afastamento
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Function Gravar(motivo As String, data_inicial As Date, data_final As Date, data_retorno As Date, obs As String, data As Date, dados_codigo As Integer) As Boolean
        Try

            Connection.Query = "INSERT INTO afastamentos (motivo, data_inicial, data_final,data_retorno, obs, data, dados_codigo) VALUES ('" + motivo + "','" + data_inicial.ToShortDateString + "','" + data_final.ToShortDateString + "','" + data_retorno.ToShortDateString + "','" + obs + "','" + data.ToShortDateString + "','" + dados_codigo.ToString + "')"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MessageBox.Show("Afastamento salvo")
            Connection.Connect.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao gravar na classe Afastamento " + ex.Message)
            Connection.Connect.Close()
            Return False
        End Try
    End Function

    Public Sub Alterar(motivo As String, data_inicial As Date, data_final As Date, data_retorno As Date, obs As String, data As Date, codigo As Integer)

        Try

            Connection.Query = "UPDATE afastamentos SET motivo='" + motivo + "', data_inicial='" + data_inicial.ToShortDateString + "', data_final='" + data_final.ToShortDateString + "',data_retorno='" + data_retorno.ToShortDateString + "', obs='" + obs + "', data='" + data + "' where codigo='" + codigo.ToString + "'"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MessageBox.Show("Afastamento alterado")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe Afastamento! " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub AlterarContrato(compo As String, valor As String, dados_codigo As Integer)

        Try

            Connection.Query = "UPDATE contratos SET " + compo + "='" + valor + "' WHERE dados_codigo='" + dados_codigo.ToString + "'"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe Afastamento! " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Function dataAfastamento() As String
        Try
            Connection.Query = "SELECT data_final FROM afastamentos  ORDER BY codigo DESC LIMIT 1"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            Dim Scalar As String = cmd.ExecuteScalar()
            Connection.Connect.Close()
            Return Scalar
        Catch ex As Exception
            Connection.Connect.Close()
            Return MessageBox.Show("Houve um erro na classe ferias! " + ex.Message)
        End Try
    End Function

    Public Sub CarregarGrade(codigo As Integer)
        Using da As New MySqlDataAdapter("SELECT codigo, motivo, data_inicial, data_final,data_retorno, obs, data " +
                "FROM afastamentos where dados_codigo='" + codigo.ToString + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvAfastamento.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

End Class

