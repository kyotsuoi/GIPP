Imports MySql.Data.MySqlClient

Public Class Faltas
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Function Gravar(data As Date, dias_horas As String, motivo As String, dados_codigo As Integer) As Boolean
        Try

            Connection.Query = "INSERT INTO faltas (data, dias_horas, motivo, dados_codigo) VALUES ('" + data.ToShortDateString + "', '" + dias_horas.ToString + "', '" + motivo + "', '" + dados_codigo.ToString + "')"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MessageBox.Show("Falta salva")
            Return True
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao gravar na classe Faltas " + ex.Message)
            Return False
        End Try
        Connection.Connect.Close()
    End Function

    Public Sub Alterar(data As Date, dias_horas As String, motivo As String, codigo As Integer)

        Try

            Connection.Query = "UPDATE faltas SET data='" + data.ToShortDateString + "', dias_horas='" + dias_horas.ToString + "', motivo='" + motivo + "' WHERE codigo='" + codigo.ToString + "'"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MessageBox.Show("Faltas alterado")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe Faltas! " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub CarregarGrade(codigo As Integer)
        Using da As New MySqlDataAdapter("SELECT codigo, data, dias_horas, motivo " +
                "FROM faltas where dados_codigo='" + codigo.ToString + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvFaltas.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

End Class
