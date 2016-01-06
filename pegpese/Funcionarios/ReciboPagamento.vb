Imports MySql.Data.MySqlClient

Public Class ReciboPagamento
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub
    Public Sub Gravar(data As Date, descricao As String, menssagens As String, referencia As String, provento As Double, desconto As Double, total As Double, dados_codigo As Integer)

        Dim vProvento As String = Replace(provento, ",", ".")
        Dim vTotal As String = Replace(total, ",", ".")

        Try
            Connection.Query = "INSERT INTO recibo_pagamentos (data, descricao, menssagens, referencia, provento, desconto, total, dados_codigo) VALUES ('" + data.ToShortDateString + "', '" + descricao + "', '" + menssagens + "', '" + referencia + "', '" + vProvento + "', '" + desconto.ToString + "', '" + vTotal + "', '" + dados_codigo.ToString + "')"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MsgBox("Recibo de pagamento salvo!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao gravar na classe Recibo de Pagamento " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub Alterar(data As Date, descricao As String, menssagens As String, referencia As String, provento As Double, desconto As Double, total As Double, codigo As Integer)

        Dim vProvento As String = Replace(provento, ",", ".")
        Dim vTotal As String = Replace(total, ",", ".")

        Try
            Connection.Query = "UPDATE recibo_pagamentos SET data='" + data + "', descricao='" + descricao + "', menssagens='" + menssagens + "', referencia='" + referencia + "', provento='" + vProvento + "', desconto='" + desconto.ToString + "',total='" + vTotal + "' where codigo='" + codigo.ToString + "' "
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MsgBox("Recibo de Pagamento alterado!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe Recibo de Pagamento " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub CarregarGrade(dados_codigo As Integer)
        Using da As New MySqlDataAdapter("Select codigo,data, descricao, menssagens, referencia, provento, desconto, total FROM recibo_pagamentos where dados_codigo = '" + dados_codigo.ToString + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvReciboPagamento.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

End Class
