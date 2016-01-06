Imports System.IO
Imports System.Data

Public Class Arquivos

    Dim connection As New Connection

    Public Sub saveArq(nomeDoc As String, codigo As String, data As String, local As String)
        Dim path As String
        File.Exists(Connection.PathString)
        path = My.Computer.FileSystem.ReadAllText(Connection.PathString)
        path = path + "\Arquivos\" + local + "\" + codigo + "-" + data + ".pdf"
        Try
            My.Computer.FileSystem.CopyFile(nomeDoc, path)
            MessageBox.Show("Arquivo anexado")
        Catch ex As Exception
            My.Computer.FileSystem.DeleteFile(path)
            My.Computer.FileSystem.CopyFile(nomeDoc, path)
        End Try
    End Sub

    Public Sub deleteArq(local As String, nomeArq As String)
        Dim path As String
        File.Exists(Connection.PathString)
        path = My.Computer.FileSystem.ReadAllText(Connection.PathString)
        path = path + "\Arquivos\" + local + "\" + nomeArq + ".pdf"
        Try
            My.Computer.FileSystem.DeleteFile(path)
            MessageBox.Show("Arquivo deletado")
        Catch ex As Exception
            MessageBox.Show("Arquivo não existe")
        End Try
    End Sub

    Public Sub openArq(codigo As String, data As String, local As String)
        Dim path As String
        File.Exists(Connection.PathString)
        path = My.Computer.FileSystem.ReadAllText(Connection.PathString)
        path = path + "\Arquivos\" + local + "\" + codigo + "-" + data + ".pdf"
        Try
            System.Diagnostics.Process.Start(path)
        Catch ex As Exception
            MessageBox.Show("Erro ao abrir arquivo codigo ou data do arquivo não existe")
        End Try
    End Sub
    Public Sub Explorer(local As String)
        Try
            System.Diagnostics.Process.Start(local)
        Catch ex As Exception
            MessageBox.Show("Erro ao abrir arquivo codigo ou data do arquivo não existe")
        End Try
    End Sub


    '>>>>>>>>>>RECIBO DE DOMINGO<<<<<<<<<<
    Public Sub saveRecDomingo(nomeDoc As String, data As String, local As String)
        Dim path As String
        File.Exists(Connection.PathString)
        path = My.Computer.FileSystem.ReadAllText(Connection.PathString)
        path = path + "\Arquivos\" + local + "\" + data + ".pdf"
        Try
            My.Computer.FileSystem.CopyFile(nomeDoc, path)
            MessageBox.Show("Arquivo anexado")
        Catch ex As Exception
            My.Computer.FileSystem.DeleteFile(path)
            My.Computer.FileSystem.CopyFile(nomeDoc, path)
        End Try
    End Sub

    Public Sub openRecDomingo(data As String, local As String)
        Dim path As String
        File.Exists(Connection.PathString)
        path = My.Computer.FileSystem.ReadAllText(Connection.PathString)
        path = path + "\Arquivos\" + local + "\" + data + ".pdf"
        Try
            System.Diagnostics.Process.Start(path)
        Catch ex As Exception
            MessageBox.Show("Erro ao abrir arquivo codigo ou data do arquivo não existe")
        End Try
    End Sub

End Class
