Imports MySql.Data.MySqlClient

Public Class Beneficiarios
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Sub CarregarGrade(dados_codigo As Integer)
        Using da As New MySqlDataAdapter("SELECT codigo, nome, parentesco, nascimento, pensao FROM beneficiarios where dados_codigo = '" + dados_codigo.ToString + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvDependentes.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Sub Gravar(nome As String, parentesco As String, nascimento As String, pensao As Double, dados_codigo As Integer)

        Try
            Connection.Query = "Insert into beneficiarios (nome, parentesco, nascimento, pensao, dados_codigo) values ('" + nome + "','" + parentesco + "','" + nascimento + "','" + pensao.ToString + "','" + dados_codigo.ToString + "')"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MsgBox("Dados gravados com sucesso!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao gravar na classe Beneficiarios " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub Alterar(nome As String, parentesco As String, nascimento As String, pensao As Double, codigo As Integer)
        Try
            Connection.Query = "UPDATE beneficiarios SET nome='" + nome + "', parentesco='" + parentesco + "', nascimento='" + nascimento + "', pensao='" + pensao.ToString +
                "' WHERE codigo='" + codigo.ToString + "'"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MsgBox("Dados alterados com sucesso!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe Beneficiarios " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub
End Class
