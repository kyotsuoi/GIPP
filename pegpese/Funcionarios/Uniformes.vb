Imports MySql.Data.MySqlClient

Public Class Uniformes
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Function Gravar(desc_uniforme As String, entrega As Date, qtde As Integer, tm As String, obs As String, valor As String, dados_codigo As Integer) As Boolean
        Dim vValor As String = Replace(valor, ",", ".")
        Try

            Connection.Query = "INSERT INTO uniformes (desc_uniforme, entrega, qtde, tm, obs,valor, dados_codigo) VALUES ('" + desc_uniforme + "', '" + entrega.ToShortDateString + "', '" + qtde.ToString + "', '" + tm + "', '" + obs + "','" + vValor + "', '" + dados_codigo.ToString + "')"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            Connection.Connect.Close()
            MessageBox.Show("Uniforme salvo")
            Return True
        Catch ex As Exception
            Connection.Connect.Close()
            MessageBox.Show("Houve um erro ao gravar na classe Uniforme " + ex.Message)
            Return False
        End Try
    End Function

    Public Sub Alterar(desc_uniforme As String, entrega As Date, qtde As Integer, tm As String, obs As String, valor As String, codigo As Integer)
        Dim vValor As String = Replace(valor, ",", ".")
        Try

            Connection.Query = "UPDATE uniformes SET desc_uniforme='" + desc_uniforme + "', entrega='" + entrega.ToShortDateString + "', qtde='" + qtde.ToString + "', tm='" + tm + "', obs='" + obs + "',valor='" + vValor + "' WHERE codigo='" + codigo.ToString + "'"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MessageBox.Show("Uniformes alterado")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe Uniformes! " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub CarregarGrade(codigo As Integer)
        Using da As New MySqlDataAdapter("SELECT codigo, desc_uniforme, entrega, qtde, tm, obs, valor " +
                "FROM uniformes where dados_codigo='" + codigo.ToString + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvUniformes.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

End Class
