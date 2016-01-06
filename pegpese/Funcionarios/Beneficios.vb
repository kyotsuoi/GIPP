Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class Beneficios
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Function Gravar(vale_trasporte As Integer, bilhete1 As String, vt1 As Double, bilhete2 As String, vt2 As Double, bilhete3 As String, vt3 As Double, aux_combustivel As Integer, valor As Double, valor_vr As Double, valor_va As Double, dados_codigo As Integer) As Boolean

        Dim vVT1 As String = Replace(vt1, ",", ".")
        Dim vVT2 As String = Replace(vt2, ",", ".")
        Dim vVT3 As String = Replace(vt3, ",", ".")
        Dim Combustivel As String = Replace(valor, ",", ".")
        Dim vVR As String = Replace(valor_vr, ",", ".")
        Dim vVA As String = Replace(valor_va, ",", ".")

        Try
            Connection.Query = "INSERT INTO beneficios (vale_transporte, bilhete1, vt1, bilhete2, vt2, bilhete3, vt3, aux_combustivel, valor, valor_vr, valor_va, dados_codigo) VALUES ('" + vale_trasporte.ToString + "', '" + bilhete1 + "', '" + vVT1 + "', '" + bilhete2 + "', '" + vVT2 + "', '" + bilhete3 + "', '" + vVT3 + "', '" + aux_combustivel.ToString + "', '" + Combustivel + "', '" + vVR + "', '" + vVA + "', '" + dados_codigo.ToString + "')"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            Connection.Connect.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao gravar na classe Beneficios " + ex.Message)
            Connection.Connect.Close()
            Return False
        End Try
    End Function

End Class
