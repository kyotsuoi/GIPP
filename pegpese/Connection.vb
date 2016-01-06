Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Connection '
    Dim autentication As String
    Public ConnectionAutentication As String
    Public Query As String
    Public Connect As MySqlConnection
    Public PathString As String = "C:\Program Files (x86)\GIPP\path"
    Public PathModels As String = "C:\Program Files (x86)\GIPP\models"

    Public Sub Connection()
        If File.Exists(MdiGIPP.path + "\arquivos\autentication") Then
            autentication = My.Computer.FileSystem.ReadAllText(MdiGIPP.path + "\arquivos\autentication")
            ConnectionAutentication = autentication
            Connect = New MySqlConnection(ConnectionAutentication)
        Else
            MessageBox.Show("Caminho do banco não encontrado!")
        End If
    End Sub
End Class
