Imports MySql.Data.MySqlClient

Public Class TD
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Function Gravar(treinamento As String, data As Date, carg_horaria As String, n_registro As String, ministrado_por As String, dados_codigo As Integer) As Boolean
        Try

            Connection.Query = "INSERT INTO td (treinamento, data, carg_horaria, n_registro, ministrado_por, dados_codigo) VALUES ('" + treinamento + "', '" + data.ToShortDateString + "', '" + carg_horaria + "', '" + n_registro + "', '" + ministrado_por + "', '" + dados_codigo.ToString + "')"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            Connection.Connect.Close()
            MessageBox.Show("T&D salvo")
            Return True
        Catch ex As Exception
            Connection.Connect.Close()
            MessageBox.Show("Houve um erro ao gravar na classe T&D " + ex.Message)
            Return False
        End Try
    End Function

    Public Sub Alterar(treinamento As String, data As Date, carg_horaria As String, n_registro As String, ministrado_por As String, codigo As Integer)

        Try

            Connection.Query = "UPDATE td SET treinamento='" + treinamento + "',data='" + data.ToShortDateString + "', carg_horaria='" + carg_horaria + "', n_registro='" + n_registro + "',ministrado_por='" + ministrado_por + "' where codigo='" + codigo.ToString + "' "

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MessageBox.Show("T&D  alterado")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe T&D ! " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub CarregarGrade(codigo As Integer)
        Using da As New MySqlDataAdapter("SELECT codigo,treinamento, data, carg_horaria, n_registro, ministrado_por " +
                "FROM td where dados_codigo='" + codigo.ToString + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvTD.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

End Class
