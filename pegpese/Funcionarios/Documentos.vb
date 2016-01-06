Imports System.Globalization
Imports MySql.Data.MySqlClient
Public Class Documentos
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Function Gravar(codigo As Integer, rg As String, data_emissao As String, orgao_emissor As String, pai As String, mae As String,
                           cpf As String, local_nascimento As String, naturalidade As String, cor_raca As String, nacionalidade As String, grau_instrucao As String, data_nascimento As String, estado_civil As String, sexo As String, cheg_brasil As String, status_inst As String,
                           registro As String, habilitacao1 As String, categoria As String, validade As String,
                           endereco As String, numero As Integer, complemento As String, bairro As String, cidade As String, fixo As String, cep As String, uf As String, celular As String, email As String, outros As String,
                           n_reservista As String, ra_reservista As String, serie_reservista As String, dispensado As String,
                           ctps As String, serie_carteira As String, pis As String, data_emissao_carteira As String, uf_carteira As String,
                           insc_titulo As String, zona_titulo As String, secao_titulo As String, municipio_titulo As String, emissao_titulo As String,
                           banco As String, agencia As String, conta As String, dados_codigo As Integer) As Boolean

        Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture("eu-ES")

        Try
            Connection.Query = "INSERT INTO documentos (codigo, rg, data_emissao, orgao_emissor, pai, mae," +
            "cpf, local_nascimento, naturalidade, cor_raca, nacionalidade, grau_instrucao, data_nascimento, estado_civil, sexo, cheg_brasil, status_inst," +
            "endereco, numero, complemento, bairro, cidade, fixo, cep, uf, celular, email, outros," +
            "n_reservista, ra_reservista, serie_reservista, dispensado," +
            "ctps, serie_carteira, pis, data_emissao_carteira, uf_carteira," +
            "insc_titulo, zona_titulo, secao_titulo, municipio_titulo, emissao_titulo," +
            "banco, agencia, conta, dados_codigo) VALUES ('" + codigo.ToString + "', '" + rg + "', '" + data_emissao + "', '" + orgao_emissor + "', '" + pai + "', '" + mae + "'," +
            "'" + cpf + "', '" + local_nascimento + "', '" + naturalidade + "', '" + cor_raca + "', '" + nacionalidade + "', '" + grau_instrucao + "', '" + data_nascimento + "', '" + estado_civil + "', '" + sexo + "', '" + cheg_brasil + "', '" + status_inst + "'," +
            "'" + endereco + "', '" + numero.ToString + "', '" + complemento + "', '" + bairro + "', '" + cidade + "', '" + fixo + "', '" + cep + "', '" + uf + "', '" + celular + "', '" + email + "', '" + outros + "'," +
            "'" + n_reservista + "', '" + ra_reservista + "', '" + serie_reservista + "', '" + dispensado + "'," +
            "'" + ctps + "', '" + serie_carteira + "', '" + pis + "', '" + data_emissao_carteira + "', '" + uf_carteira + "'," +
            "'" + insc_titulo + "', '" + zona_titulo + "', '" + secao_titulo + "', '" + municipio_titulo + "', '" + emissao_titulo + "'," +
            "'" + banco + "', '" + agencia + "', '" + conta + "', '" + dados_codigo.ToString + "')"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            Return True
        Catch ex As Exception
            Connection.Connect.Close()
            MessageBox.Show("Houve um erro ao gravar na classe Documentos " + ex.Message)
            Return False
        End Try
    End Function
End Class
