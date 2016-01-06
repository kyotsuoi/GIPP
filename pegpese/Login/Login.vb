Imports MySql.Data.MySqlClient

Public Class Login
    Dim connection As New Connection
    Dim usuarios As New usuarios

    Public Sub connect_base()
        connection.Connection()
    End Sub

    Public Function BuscarSenha(login As String) As String
        connection.Query = "Select senha FROM usuarios where login='" + login + "'"
        connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(connection.Query, connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()
        connection.Connect.Close()
        Return Scalar
    End Function

    Public Function BuscarLogin(login As String) As String
        Try
            connection.Query = "Select login FROM usuarios where login='" + login + "'"
            connect_base()
            connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(connection.Query, connection.Connect)
            Dim Scalar As String = cmd.ExecuteScalar()
            connection.Connect.Close()
            Return Scalar
        Catch ex As Exception
            MessageBox.Show("Houve um erro! Provavelmente por não estar conectado ao banco de dados! " + ex.Message)
            Return ""
        End Try
    End Function

    Public Function BuscarCampo(login As String, campo As String) As Boolean
        connection.Query = "Select " + campo + " FROM usuarios where login='" + login + "'"
        connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(connection.Query, connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()
        connection.Connect.Close()
        Return Scalar
    End Function

End Class
