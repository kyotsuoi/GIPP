Imports MySql.Data.MySqlClient

Public Class Delete
    Dim Connection As New Connection
    Public departamento_codigo As Integer

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Sub Apagar(codigo As Integer, tabela As String)
        Try
            Connection.Query = "DELETE FROM " + tabela + " WHERE codigo='" + codigo.ToString + "'"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            Connection.Connect.Close()
            MessageBox.Show("Registro Deletado")
        Catch ex As Exception
            Connection.Connect.Close()
            MessageBox.Show("Houve um erro ao apagar na classe delete, na tabela" + tabela + "! " + ex.Message)
        End Try
    End Sub
    Public Sub ApagarOutros(codigo As Integer, tabela As String)
        Try
            Connection.Query = "DELETE FROM " + tabela + " WHERE dados_codigo='" + codigo.ToString + "'"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            Connection.Connect.Close()
            MessageBox.Show("Registro Deletado")
        Catch ex As Exception
            Connection.Connect.Close()
            MessageBox.Show("Houve um erro ao apagar na classe delete, na tabela" + tabela + "! " + ex.Message)
        End Try
    End Sub
End Class
