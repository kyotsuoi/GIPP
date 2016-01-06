Imports MySql.Data.MySqlClient

Public Class Dependentes
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Function Gravar(nome As String, pensao_aliment As Double, nascimento As Date, parentesco As String, obs As String, data_dependente As Date, dados_codigo As Integer) As Boolean
        Try
            Connection.Query = "INSERT INTO dependentes (nome, pensao_aliment, nascimento, parentesco, obs, data_dependente, dados_codigo) VALUES ('" + nome + "', '" + pensao_aliment.ToString + "','" + nascimento.ToShortDateString + "', '" + parentesco + "', '" + obs + "', '" + data_dependente.ToShortDateString + "', '" + dados_codigo.ToString + "')"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            Connection.Connect.Close()
            Return True
        Catch ex As Exception
            Connection.Connect.Close()
            MessageBox.Show("Houve um erro ao gravar na classe Dependentes " + ex.Message)
            Return False
        End Try
    End Function

    Public Sub Alterar(nome As String, pensao_aliment As Double, nascimento As Date, parentesco As String, obs As String, data_dependente As Date, dados_codigo As Integer)

        Try
            Connection.Query = "UPDATE dependentes SET nome='" + nome + "', pensao_aliment='" + pensao_aliment.ToString + "', nascimento='" + nascimento.ToShortDateString + "', parentesco='" + parentesco + "', obs='" + obs + "', data_dependente='" + data_dependente.ToShortDateString + "'  WHERE  dados_codigo='" + dados_codigo.ToString + "'"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MessageBox.Show("Dependete alterado")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe Dependentes! " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub CarregarGrade(codigo As Integer)
        Using da As New MySqlDataAdapter("SELECT codigo, nome, pensao_aliment, nascimento, parentesco, obs, data_dependente " +
                "FROM dependentes where dados_codigo='" + codigo.ToString + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvDependentes.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub
End Class
