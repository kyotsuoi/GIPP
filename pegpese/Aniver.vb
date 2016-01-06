Imports MySql.Data.MySqlClient
Public Class Aniver
    Dim Connection As New Connection
    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Sub BuscaAniver(data As Date)
        Dim mes As String
        mes = data.Month.ToString
        Using da As New MySqlDataAdapter("select nome,nascimento from pegpese.dados where nascimento like '__%_" + mes + "%_____'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmAniver.dgvAniver.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub
End Class
