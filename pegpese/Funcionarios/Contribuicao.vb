Imports MySql.Data.MySqlClient

Public Class Contribuicao
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Function Gravar(data As Date, tipo As String, sindicato As String, valor As Double, dados_codigo As Integer) As Boolean

        Dim vValor As String = Replace(valor, ",", ".")

        Try
            Connection.Query = "INSERT INTO contribuicoes (data, tipo, sindicato, valor, dados_codigo) VALUES ('" + data.ToShortDateString + "', '" + tipo + "', '" + sindicato + "', '" + vValor + "', '" + dados_codigo.ToString + "')"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MessageBox.Show("Contribuições salvo")
            Connection.Connect.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao gravar na classe Contribuições " + ex.Message)
            Connection.Connect.Close()
            Return False
        End Try
    End Function

    Public Sub Alterar(data As Date, tipo As String, sindicato As String, valor As Double, codigo As Integer)

        Dim vValor As String = Replace(valor, ",", ".")

        Try
            Connection.Query = "UPDATE contribuicoes SET data='" + data + "', tipo='" + tipo + "', sindicato='" + sindicato + "', valor='" + vValor + "' where codigo='" + codigo.ToString + "' "

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            Connection.Connect.Close()
            MessageBox.Show("Contribuições alterado")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe Contribuições! " + ex.Message)
            Connection.Connect.Close()
        End Try
    End Sub

    Public Sub CarregarGrade(codigo As Integer)
        Using da As New MySqlDataAdapter("SELECT codigo,data, tipo, sindicato, valor " +
                "FROM contribuicoes where dados_codigo='" + codigo.ToString + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvCont.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

End Class
