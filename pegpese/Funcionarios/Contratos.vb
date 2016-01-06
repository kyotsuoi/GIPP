Imports MySql.Data.MySqlClient

Public Class Contratos
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Function Gravar(codigo As Integer, salario As Double, dias_exp1 As Integer, exp1 As String, dias_exp2 As Integer, exp2 As String, status As String,
                           demitido As String, insalubridade As String, horario_trabalho As String, data_contrato As String, dados_codigo As Integer) As Boolean
        Dim vBase As String = Replace(salario, ",", ".")
        Try
            Connection.Query = "INSERT INTO contratos (codigo, salario, dias_exp1, exp1, dias_exp2, exp2, status, demitido, insalubridade, horario_trabalho, data_contrato, dados_codigo) VALUES ('" +
                codigo.ToString + "', '" + vBase + "', '" + dias_exp1.ToString + "', '" + exp1 + "', '" + dias_exp2.ToString + "', '" + exp2 + "', '" + status + "', '" + demitido + "', '" + insalubridade + "', '" + horario_trabalho + "', '" + data_contrato + "', '" + dados_codigo.ToString + "')"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            Connection.Connect.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao gravar na classe Contratos " + ex.Message)
            Connection.Connect.Close()
            Return False
        End Try
    End Function


    Public Sub avisoExp1()
        Dim Data As Date = Now.AddDays(5)
        Dim vMonth As String = Data.Month.ToString
        If vMonth.Length < 2 Then
            vMonth = "0" & vMonth
        End If

        If vMonth = Now.Month.ToString Then Return
        Dim vData As String = vMonth & "/" & Data.Year.ToString
        Using da As New MySqlDataAdapter("SELECT nome,exp1 FROM pegpese.dados INNER JOIN pegpese.contratos ON contratos.dados_codigo = dados.codigo WHERE exp1 LIKE '___" + vData + "%'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmExp.dgvAvisoExp1.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Sub avisoExp2()
        Dim Data As Date = Now.AddDays(5)
        Dim vMonth As String = Data.Month.ToString
        If vMonth.Length < 2 Then
            vMonth = "0" & vMonth
        End If

        If vMonth = Now.Month.ToString Then Return
        Dim vData As String = vMonth & "/" & Data.Year.ToString
        Using da As New MySqlDataAdapter("SELECT nome,exp2 FROM pegpese.dados INNER JOIN pegpese.contratos ON contratos.dados_codigo = dados.codigo WHERE exp2 LIKE '___" + vData + "%'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmExp.dgvAvisoExp2.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

End Class
