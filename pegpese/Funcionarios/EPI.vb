Imports MySql.Data.MySqlClient

Public Class EPI
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Function Gravar(nome As String, n_ca As Integer, qtde As Integer, entrega As Date, cod_fornec As String, obs As String, dados_codigo As Integer) As Boolean
        Try

            Connection.Query = "INSERT INTO epi (nome, n_ca, qtde, entrega, cod_fornec, obs, dados_codigo) VALUES ('" + nome + "', '" + n_ca.ToString + "', '" + qtde.ToString + "', '" + entrega.ToShortDateString + "', '" + cod_fornec + "', '" + obs + "', '" + dados_codigo.ToString + "')"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MessageBox.Show("EPI salvo")
            Connection.Connect.Close()
            Return True
        Catch ex As Exception
            Connection.Connect.Close()
            MessageBox.Show("Houve um erro ao gravar na classe EPI " + ex.Message)
            Return False
        End Try
    End Function

    Public Sub Alterar(nome As String, n_ca As Integer, qtde As Integer, entrega As Date, cod_fornec As String, obs As String, codigo As Integer)

        Try

            Connection.Query = "UPDATE epi SET nome='" + nome + "', n_ca='" + n_ca.ToString + "', qtde='" + qtde.ToString + "', entrega='" + entrega.ToShortDateString + "', cod_fornec='" + cod_fornec + "', obs='" + obs + "' WHERE codigo='" + codigo.ToString + "'"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MessageBox.Show("EPI alterado")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe EPI! " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub CarregarGrade(codigo As Integer)
        Using da As New MySqlDataAdapter("SELECT codigo, nome, n_ca, qtde, entrega, cod_fornec, obs, dados_codigo " +
                "FROM epi where dados_codigo='" + codigo.ToString + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvEPI.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

End Class
