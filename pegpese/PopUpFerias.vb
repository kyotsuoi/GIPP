Imports MySql.Data.MySqlClient

Public Class PopUpFerias
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Sub CarregarFerias1()
        Dim mes, ano, vString As String
        Dim vDate As Date = Now
        Dim i As Integer = -1

        vDate = vDate.AddYears(-2)
        mes = vDate.Month.ToString
        ano = vDate.Year.ToString
        If mes.Length = 1 Then
            mes = "0" + mes
        End If
        vString = "SELECT codigo, data_admissao FROM dados WHERE (data_admissao LIKE '___" + mes + "/" + ano
        While i < 12
            vDate = vDate.AddMonths(1)
            mes = vDate.Month.ToString
            ano = vDate.Year.ToString
            If mes.Length = 1 Then
                mes = "0" + mes
            End If
            vString = vString + "%' OR data_admissao LIKE '___" + mes + "/" + ano
            i += 1
        End While
        vString = vString + "%') AND `check` = 0"

        Using da As New MySqlDataAdapter(vString, Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                MdiGIPP.dgvFerias1.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Sub CarregarFerias2()
        Dim mes, ano, vString As String
        Dim vDate As Date = Now
        Dim i As Integer = -1

        vDate = vDate.AddYears(-2)
        mes = vDate.Month.ToString
        ano = vDate.Year.ToString
        If mes.Length = 1 Then
            mes = "0" + mes
        End If
        vString = "SELECT dados_codigo, data_final, `check` FROM ferias WHERE (data_final LIKE '___" + mes + "/" + ano
        While i < 12
            vDate = vDate.AddMonths(1)
            mes = vDate.Month.ToString
            ano = vDate.Year.ToString
            If mes.Length = 1 Then
                mes = "0" + mes
            End If
            vString = vString + "%' OR data_final LIKE '___" + mes + "/" + ano
            i += 1
        End While
        vString = vString + "%') AND `check` = 0"

        Using da As New MySqlDataAdapter(vString, Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                MdiGIPP.dgvFerias2.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Function BuscarNome(codigo As Integer) As String
        Connection.Query = "Select nome FROM dados Where codigo='" + codigo.ToString + "'"
                Connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()
        Connection.Connect.Close()
        Return Scalar
    End Function

End Class
