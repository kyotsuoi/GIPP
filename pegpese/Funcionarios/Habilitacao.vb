Imports MySql.Data.MySqlClient

Public Class Habilitacao
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Function Gravar(registro As String, habilitacao1 As Date, categoria As String, validade As Date, codigo As Integer) As Boolean

        Try
            Connection.Query = "INSERT INTO habilitacao (registro, habilitacao1, categoria, validade, dados_codigo) VALUES ('" +
                registro + "', '" + habilitacao1.ToShortDateString + "', '" + categoria + "', '" + validade.ToShortDateString + "','" + codigo.ToString + "')"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            Connection.Connect.Close()
            MessageBox.Show("Habilitação salva")
            Return True
        Catch ex As Exception
            Connection.Connect.Close()
            MessageBox.Show("Houve um erro ao gravar na classe Habilitação " + ex.Message)
            Return False
        End Try
    End Function
    Public Sub Alterar(registro As String, habilitacao1 As String, categoria As String, validade As String, codigo As Integer)
        Try
            Connection.Query = "UPDATE habilitacao SET registro='" + registro + "', habilitacao1='" + habilitacao1 + "', categoria='" + categoria + "', validade='" + validade + "' WHERE codigo='" + codigo.ToString + "'"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MsgBox("Registro alterado!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe Habilitacao " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub CarregarGrade(codigo As Integer)
        Using da As New MySqlDataAdapter("SELECT codigo,registro,habilitacao1,categoria,validade " +
                "FROM habilitacao where dados_codigo=" + codigo.ToString, Connection.Connect)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvHabilit.DataSource = ds.Tables(0)
            End Using
        End Using

    End Sub
End Class
