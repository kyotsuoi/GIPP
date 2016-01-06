
Imports MySql.Data.MySqlClient

Public Class Empresa
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub
    Public Sub Gravar(nome As String, endereco As String, numero As Integer, cnpj As String)
        Try
            Connection.Query = "INSERT INTO empresa (nome, endereco, numero, cnpj) VALUES ('" + nome + "', '" + endereco + "', '" + numero.ToString + "', '" + cnpj + "')"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            Connection.Connect.Close()
            MsgBox("Registro Salvo!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao gravar na classe Empresa " + ex.Message)
        End Try
    End Sub

    Public Sub Alterar(nome As String, endereco As String, numero As Integer, cnpj As String, codigo As Integer)
        Try
            Connection.Query = "UPDATE empresa SET nome='" + nome + "', endereco='" + endereco + "', numero='" + numero.ToString + "',cnpj='" + cnpj + "'" +
                "  WHERE codigo='" + codigo.ToString + "'"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            Connection.Connect.Close()
            MsgBox("Registro Alterado!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe Empresa " + ex.Message)
        End Try
    End Sub

    Public Sub CarregarGrade()
        Using da As New MySqlDataAdapter("SELECT codigo, nome, endereco, numero, cnpj FROM empresa", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmEmpresa.dgvEmpresa.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Sub CarregaCombo()
        Connection.Connect.Open()
        Dim reader As MySqlDataReader
        Dim cmd As MySqlCommand
        cmd = New MySqlCommand("select nome from empresa", Connection.Connect)
        reader = cmd.ExecuteReader

        While reader.Read
            frmFuncionarios.cmbEmpresa.Items.Add(reader.Item("nome"))
        End While
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
