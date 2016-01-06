Imports MySql.Data.MySqlClient

Public Class HistoricoEPI

    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Sub Gravar(data As String, descricao As String, dados_codigo As Integer)
        Try
            Connection.Query = "Insert into historico_epi (data,descricao,dados_codigo) values ('" + data + "','" + descricao + "','" + dados_codigo.ToString + "')"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MsgBox("Dados gravados com sucesso!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao gravar na classe historico_epi " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub Alterar(data As String, descricao As String, dados_codigo As Integer)
        Try
            Connection.Query = "UPDATE historico_epi SET data='" + data + "', descricao='" + descricao +
                "' WHERE codigo='" + dados_codigo.ToString + "'"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MsgBox("Dados alterados com sucesso!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe historico_epi " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub CarregarGrade(dados_codigo As Integer)
        Using da As New MySqlDataAdapter("Select codigo,data,descricao from historico_epi where dados_codigo = '" +
                                         dados_codigo.ToString + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvEPI.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub
End Class
