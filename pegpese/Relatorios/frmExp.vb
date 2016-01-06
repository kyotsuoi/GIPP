Public Class frmExp
    Dim contratos As New Contratos
    Private Sub frmExp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        contratos.connect_base()
        contratos.avisoExp1()
        contratos.avisoExp2()
    End Sub
End Class