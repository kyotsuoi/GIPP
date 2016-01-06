
Imports MySql.Data.MySqlClient

Public Class Empresas
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Sub Gravar(nome As String, razao_social As String, endereco As String, numero As Integer, bairro As String, municipio As String, cnpj As String, cep As String, Insc_Estadual As String, estado As String, telefone As String)
        Try

            Connection.Query = "INSERT INTO empresas (nome, razao_social, endereco, numero, bairro, municipio, cnpj, cep, Insc_Estadual, estado, telefone) VALUES ('" + nome + "', '" + razao_social + "', '" + endereco + "', '" + numero.ToString + "', '" + bairro + "', '" + municipio + "', '" + cnpj + "', '" + cep + "', '" + Insc_Estadual + "', '" + estado + "', '" + telefone + "')"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            MsgBox("Registro Salvo!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao gravar na classe empresas " + ex.Message)
        End Try
        Connection.Connect.Dispose()
        Connection.Connect.Close()
    End Sub

    Public Sub Alterar(nome As String, razao_social As String, endereco As String, numero As Integer, bairro As String, municipio As String, cnpj As String, cep As String, Insc_Estadual As String, estado As String, telefone As String, codigo As Integer)
        Try

            Connection.Query = "UPDATE empresas SET nome='" + nome + "', razao_social='" + razao_social + "', endereco='" + endereco + "', numero='" + numero.ToString + "', bairro='" + bairro + "', municipio='" + municipio + "', cnpj='" + cnpj + "', cep='" + cep + "', Insc_Estadual='" + Insc_Estadual + "', estado='" + estado + "', telefone='" + telefone + "' WHERE codigo='" + codigo.ToString + "'"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            MsgBox("Registro Alterado!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe empresas " + ex.Message)
        End Try
        Connection.Connect.Dispose()
        Connection.Connect.Close()
    End Sub

    Public Sub CarregarGrade()
        Using da As New MySqlDataAdapter("SELECT * FROM empresas", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmEmpresas.dgvEmpresa.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Sub CarregaCombo()
        Try
            Connection.Connect.Open()
            Dim reader As MySqlDataReader
            Dim cmd As MySqlCommand
            cmd = New MySqlCommand("select nome from empresas", Connection.Connect)
            reader = cmd.ExecuteReader

            While reader.Read
                frmFuncionarios.cmbEmpresa.Items.Add(reader.Item("nome"))
            End While
        Catch ex As Exception
            MessageBox.Show("Não conectado ao banco de dados!")
        End Try
        Connection.Connect.Close()
    End Sub

    Public Function BuscarEmpresa(nome As String, campo As String, tabela As String) As String
        Connection.Query = "Select " + campo + " FROM " + tabela + " where nome='" + nome + "'"
        Connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()
        Connection.Connect.Close()
        Return Scalar
    End Function
End Class
