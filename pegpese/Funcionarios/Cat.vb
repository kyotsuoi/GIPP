Imports MySql.Data.MySqlClient

Public Class Cat

    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Function Gravar(numCAT As String, emitente As String, email As String, tipo_cat As String, filiacao As String, data_emissao As Date, comunicado_obito As String, data As Date, hora_acidente As String, hora_trabalho As String, tipo As String, afastamento As String, reg_policial As String, local As String, exp_local As String, cgc As String, uf_acidente As String, municipio As String, ultimo_dia As String, parte_corpo As String, agente_causador As String, sit_gerador As String, morte As String, data_obito As String, dados_codigo As Integer, atestados_codigo As Integer) As Boolean
        Try

            Connection.Query = "INSERT INTO cat (numCAT,emitente, email, tipo_cat, filiacao, data_emissao, comunicado_obito, data, hora_acidente, hora_trabalho, tipo, afastamento, reg_policial, local, exp_local, cgc, uf_acidente, municipio, ultimo_dia, parte_corpo, agente_causador, sit_gerador, morte, data_obito, dados_codigo, atestados_codigo) VALUES ('" + numCAT + "','" + emitente + "', '" + email + "', '" + tipo_cat + "', '" + filiacao + "', '" + data_emissao.ToShortDateString + "', '" + comunicado_obito + "', '" + data.ToShortDateString + "', '" + hora_acidente + "', '" + hora_trabalho + "', '" + tipo + "', '" + afastamento + "', '" + reg_policial + "', '" + local + "', '" + exp_local + "', '" + cgc + "', '" + uf_acidente + "', '" + municipio + "', '" + ultimo_dia + "', '" + parte_corpo + "', '" + agente_causador + "', '" + sit_gerador + "', '" + morte + "', '" + data_obito + "', '" + dados_codigo.ToString + "', '" + atestados_codigo.ToString + "')"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MessageBox.Show("CAT salvo")
            Connection.Connect.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao gravar na classe CAT " + ex.Message)
            Connection.Connect.Close()
            Return False
        End Try
    End Function
    Public Sub AltContrato(status As String, dados_codigo As Integer)
        Try
            Connection.Query = "UPDATE contratos SET status='" + status + "' WHERE dados_codigo='" + dados_codigo.ToString + "'"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe CAT! " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub Alterar(numCAT As String, emitente As String, email As String, tipo_cat As String, filiacao As String, data_emissao As Date, comunicado_obito As String, data As Date, hora_acidente As String, hora_trabalho As String, tipo As String, afastamento As String, reg_policial As String, local As String, exp_local As String, cgc As String, uf_acidente As String, municipio As String, ultimo_dia As String, parte_corpo As String, agente_causador As String, sit_gerador As String, morte As String, data_obito As String, codigo As Integer)
        Try

            Connection.Query = "UPDATE cat SET numCAT='" + numCAT + "', emitente='" + emitente + "', email='" + email + "', tipo_cat='" + tipo_cat + "', filiacao='" + filiacao + "', data_emissao='" + data_emissao.ToShortDateString + "', comunicado_obito='" + comunicado_obito + "', data='" + data.ToShortDateString + "', hora_acidente='" + hora_acidente + "', hora_trabalho='" + hora_trabalho + "', tipo='" + tipo + "', afastamento='" + afastamento + "', reg_policial='" + reg_policial + "', local='" + local + "', exp_local='" + exp_local + "', cgc='" + cgc + "', uf_acidente='" + uf_acidente + "', municipio='" + municipio + "', ultimo_dia='" + ultimo_dia + "', parte_corpo='" + parte_corpo + "', agente_causador='" + agente_causador + "', sit_gerador='" + sit_gerador + "', morte='" + morte + "', data_obito='" + data_obito + "' WHERE codigo='" + codigo.ToString + "'"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MessageBox.Show("Atestado alterado")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe CAT! " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub CarregarGrade(codigo As Integer)
        Using da As New MySqlDataAdapter("SELECT * " +
                "FROM cat where dados_codigo='" + codigo.ToString + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvCAT.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Function BuscarAtestado(codigo As String, campo As String, tabela As String) As String
        Connection.Query = "Select " + campo + " FROM " + tabela + " where codigo='" + codigo + "'"
        Connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()
        Connection.Connect.Close()
        Return Scalar
    End Function
End Class
