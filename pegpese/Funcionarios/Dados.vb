Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class Dados
    Dim Connection As New Connection
    Dim delete As New Delete
    Public departamentos_codigo As Integer

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Function Gravar(codigo As Integer, mat As Integer, nome As String, data_admissao As String, tipo As String, departamentos_codigo As Integer, empresas_codigo As Integer) As Boolean
        Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture("eu-ES")

        Try
            Connection.Query = "INSERT INTO dados (codigo, matricula, nome, data_admissao, `check`,tipo, departamentos_codigo, empresas_codigo) VALUES ('" +
                codigo.ToString + "', '" + mat.ToString + "', '" + nome + "', '" + data_admissao + "', '0', '" + tipo + "', '" +
                departamentos_codigo.ToString + "', '" + empresas_codigo.ToString + "')"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            Connection.Connect.Close()
            Return True
        Catch ex As Exception
            Connection.Connect.Close()
            MessageBox.Show("Houve um erro ao gravar na classe dados " + ex.Message)
            Return False
        End Try

    End Function

    Public Sub Alterar(mat As Integer, nome As String, data_admissao As String, tipo As String, departamentos_codigo As String, empresas_codigo As String,
                       rg As String, data_emissao As String, orgao_emissor As String, pai As String, mae As String, cpf As String, local_nascimento As String, naturalidade As String, cor_raca As String, nacionalidade As String, grau_instrucao As String, data_nascimento As String, estado_civil As String, sexo As String, cheg_brasil As String, status_inst As String, endereco As String, numero As String, complemento As String, bairro As String, cidade As String, fixo As String, cep As String, uf As String, celular As String, email As String, outros As String, n_reservista As String, ra_reservista As String, serie_reservista As String, dispensado As String, ctps As String, serie_carteira As String, pis As String, data_emissao_carteira As String, uf_carteira As String, insc_titulo As String, zona_titulo As String, secao_titulo As String, municipio_titulo As String, emissao_titulo As String, banco As String, agencia As String, conta As String,
                       salario As String, dias_exp1 As String, exp1 As String, dias_exp2 As String, exp2 As String, status As String, demitido As String, insalubridade As String, horario_trabalho As String, data_contrato As String,
                      vale_transporte As String, bilhete1 As String, vt1 As String, bilhete2 As String, vt2 As String, bilhete3 As String, vt3 As String, aux_combustivel As String, valor As String, valor_vr As String, valor_va As String, codigo As String)

        Try

            Connection.Query = "update dados inner join documentos on documentos.dados_codigo = dados.codigo INNER JOIN contratos on contratos.dados_codigo = dados.codigo INNER JOIN beneficios on beneficios.dados_codigo = dados.codigo SET " +
                            "dados.matricula = '" + mat.ToString + "',dados.nome = '" + nome + "',dados.data_admissao = '" + data_admissao + "',dados.tipo = '" + tipo + "',dados.departamentos_codigo = '" + departamentos_codigo + "',empresas_codigo = '" + empresas_codigo + "'" +
                            ",documentos.rg = '" + rg + "', documentos.data_emissao = '" + data_emissao + "', documentos.orgao_emissor = '" + orgao_emissor + "', documentos.pai = '" + pai + "', documentos.mae = '" + mae + "', documentos.cpf = '" + cpf + "', documentos.local_nascimento = '" + local_nascimento + "', documentos.naturalidade = '" + naturalidade + "', documentos.cor_raca = '" + cor_raca + "', documentos.nacionalidade = '" + nacionalidade + "', documentos.grau_instrucao = '" + grau_instrucao + "', documentos.data_nascimento = '" + data_nascimento + "', documentos.estado_civil = '" + estado_civil + "', documentos.sexo = '" + sexo + "', documentos.cheg_brasil = '" + cheg_brasil + "', documentos.status_inst = '" + status_inst + "', documentos.endereco = '" + endereco + "', documentos.numero = '" + numero + "', documentos.complemento = '" + complemento + "', documentos.bairro = '" + bairro + "', documentos.cidade = '" + cidade + "',documentos.fixo = '" + fixo + "', documentos.cep = '" + cep + "', documentos.uf = '" + uf + "', documentos.celular = '" + celular + "', documentos.email = '" + email + "', documentos.outros = '" + outros + "', documentos.n_reservista = '" + n_reservista + "', documentos.ra_reservista = '" + ra_reservista + "', documentos.serie_reservista = '" + serie_reservista + "', documentos.dispensado = '" + dispensado + "', documentos.ctps = '" + ctps + "', documentos.serie_carteira = '" + serie_carteira + "', documentos.pis = '" + pis + "', documentos.data_emissao_carteira = '" + data_emissao_carteira + "', documentos.uf_carteira = '" + uf_carteira + "', documentos.insc_titulo = '" + insc_titulo + "', documentos.zona_titulo = '" + zona_titulo + "', documentos.secao_titulo = '" + secao_titulo + "', documentos.municipio_titulo ='" + municipio_titulo + "', documentos.emissao_titulo = '" + emissao_titulo + "', documentos.banco = '" + banco + "', documentos.agencia = '" + agencia + "', documentos.conta = '" + conta + "'," +
                            "contratos.salario = '" + salario + "', contratos.dias_exp1 = '" + dias_exp1 + "', contratos.exp1 = '" + exp1 + "', contratos.dias_exp2 = '" + dias_exp2 + "', contratos.exp2 = '" + exp2 + "', contratos.status = '" + status + "', contratos.demitido = '" + demitido + "', contratos.insalubridade = '" + insalubridade + "', contratos.horario_trabalho = '" + horario_trabalho + "', contratos.data_contrato = '" + data_contrato + "'," +
                            "vale_transporte='" + vale_transporte + "', bilhete1='" + bilhete1 + "', vt1='" + vt1 + "', bilhete2='" + bilhete2 + "', vt2='" + vt2 + "', bilhete3='" + bilhete3 + "', vt3='" + vt3 + "', valor='" + valor + "', valor_vr='" + valor_vr + "', valor_va='" + valor_va + "' where dados.codigo = '" + codigo + "'"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe dados! " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub CarregarGrade()
        Using da As New MySqlDataAdapter("SELECT codigo, matricula, nome, data_admissao, tipo, departamentos_codigo, empresas_codigo " +
                "FROM dados", Connection.Connect)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvFuncionarios.DataSource = ds.Tables(0)
            End Using
        End Using

    End Sub

    Public Function BuscarNomeByCodigo(codigo As Integer) As String
        Connection.Query = "Select nome FROM dados Where codigo='" + codigo.ToString + "'"
        Connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()
        Connection.Connect.Close()
        Return Scalar
    End Function

    Public Sub BuscarNome(nome As String)
        Using da As New MySqlDataAdapter("SELECT * " +
                "FROM dados where nome like'" + nome + "%'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvFuncionarios.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Function BuscarCampo(codigo As String, campo As String, tabela As String) As String
        Connection.Query = "Select " + campo + " FROM " + tabela + " where codigo='" + codigo + "'"
        Connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()
        Connection.Connect.Close()
        Return Scalar
    End Function

    Public Function BuscarOutros(codigo As String, campo As String, tabela As String) As String
        Connection.Query = "Select " + campo + " FROM " + tabela + " where dados_codigo='" + codigo + "'"
        Connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()
        Connection.Connect.Close()
        Return Scalar
    End Function

    Public Sub CarregarEmpresa(CodEmpresa As Integer)
        Using da As New MySqlDataAdapter("select * from dados where empresas_codigo = '" + CodEmpresa.ToString + "'", Connection.Connect)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvFuncionarios.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Sub CarregarNascimento(nascimento As String)
        Using da As New MySqlDataAdapter("SELECT * " +
                "FROM documentos where data_nascimento='" + nascimento + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvFuncionarios.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Sub CarregarAdmitido(admitido As String)
        Using da As New MySqlDataAdapter("SELECT * " +
                "FROM dados where admitido='" + admitido + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvFuncionarios.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Sub CarregarStatus(status As String)
        Using da As New MySqlDataAdapter("SELECT * " +
                "FROM contratos where status='" + status + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvFuncionarios.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Function BuscarByDepartamento(depart As String) As Integer
        Connection.Query = "SELECT * FROM departamentos WHERE centro_custo='" + depart + "'"
        Connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()
        Connection.Connect.Close()
        Return Scalar
    End Function

    Public Sub CarregarByDepart(codigo As String)
        Using da As New MySqlDataAdapter("SELECT * " +
                "FROM dados where departamentos_codigo='" + codigo + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvFuncionarios.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Function LastCod() As String
        Try
            Connection.Query = "SELECT codigo FROM dados ORDER BY codigo DESC LIMIT 1"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            Dim Scalar As String = cmd.ExecuteScalar()
            Connection.Connect.Close()
            Return Scalar
        Catch ex As Exception
            Connection.Connect.Close()
            Return MessageBox.Show(ex.Message)
        End Try
    End Function
End Class
