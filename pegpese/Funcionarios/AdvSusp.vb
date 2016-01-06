Imports MySql.Data.MySqlClient

Public Class AdvSusp

    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Function Gravar(data_adv_susp As Date, adv As Integer, susp As Integer, dias As String, dias_ext As String, retorno As Date, motivo As String, dados_codigo As Integer) As Boolean
        Try

            Connection.Query = "INSERT INTO pegpese.adv_susp (data_adv_susp, adv, susp, dias,dias_ext, retorno, motivo, dados_codigo) VALUES ('" + data_adv_susp.ToShortDateString + "','" + adv.ToString + "','" + susp.ToString + "','" + dias.ToString + "','" + dias_ext + "','" + retorno.ToShortDateString + "','" + motivo + "','" + dados_codigo.ToString + "')"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MessageBox.Show("Advertências/Suspenção salvo")
            Connection.Connect.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao gravar na classe AdvSusp " + ex.Message)
            Connection.Connect.Close()
            Return False
        End Try
    End Function

    Public Sub Alterar(codigo As Integer, data_adv_susp As Date, adv As Integer, susp As Integer, dias As String, dias_ext As String, retorno As Date, motivo As String)

        Try

            Connection.Query = "UPDATE adv_susp SET data_adv_susp='" + data_adv_susp.ToShortDateString + "', adv='" + adv.ToString +
                "', susp='" + susp.ToString + "', dias='" + dias.ToString + "',dias_ext='" + dias_ext + "', retorno='" + retorno.ToShortDateString + "', motivo='" + motivo +
                "' WHERE codigo='" + codigo.ToString + "' "

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MessageBox.Show("Advertências/Suspenção alterado")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe AdvSusp! " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub CarregarGrade(codigo As Integer)
        Using da As New MySqlDataAdapter("SELECT codigo,data_adv_susp, adv, susp, dias,dias_ext, retorno, motivo " +
                "FROM adv_susp where dados_codigo='" + codigo.ToString + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvAdvertencia.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

End Class

