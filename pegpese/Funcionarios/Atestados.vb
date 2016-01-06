Imports MySql.Data.MySqlClient
Public Class Atestados
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Function Gravar(data As Date, dias As Integer, horas As String, injust As Integer, just As Integer, declaracao As Integer, atestado As Integer, sim As Integer, nao As Integer, motivo As String, obs As String, unidade As String, intSim As Integer, intNao As Integer, hora_atendimento As String, afastSim As Integer, afastNao As Integer, natLesao As String, cid As String, crm As String, dados_codigo As Integer) As Boolean
        Try

            Connection.Query = "INSERT INTO atestados (data, dias,horas, injust, just, declaracao, atestado, sim, nao, motivo, obs,unidade,int_sim,int_nao,hora_atendimento,afast_sim,afast_nao,nat_lesao,cid,crm, dados_codigo) VALUES ('" + data.ToShortDateString + "', '" + dias.ToString + "','" + horas + "', '" + injust.ToString + "', '" + just.ToString + "', '" + declaracao.ToString + "', '" + atestado.ToString + "', '" + sim.ToString + "', '" + nao.ToString + "', '" + motivo + "', '" + obs + "','" + unidade + "','" + intSim.ToString + "','" + intNao.ToString + "','" + hora_atendimento + "','" + afastSim.ToString + "','" + afastNao.ToString + "','" + natLesao + "','" + cid + "','" + crm + "', '" + dados_codigo.ToString + "')"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MessageBox.Show("Atestado salvo")
            Connection.Connect.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao gravar na classe Atestados " + ex.Message)
            Connection.Connect.Close()
            Return False
        End Try
    End Function

    Public Sub Alterar(data As String, dias As Integer, horas As String, injust As Integer, just As Integer, declaracao As Integer, atestado As Integer, sim As Integer, nao As Integer, motivo As String, obs As String, unidade As String, intSim As Integer, intNao As Integer, hora_atendimento As String, afastSim As Integer, afastNao As Integer, natLesao As String, cid As String, crm As String, codigo As Integer)
        Try
            Connection.Query = "UPDATE atestados SET data='" + data + "', dias='" + dias.ToString + "', horas='" + horas + "', injust='" + injust.ToString + "', just='" + just.ToString + "', declaracao='" + declaracao.ToString + "', atestado='" + atestado.ToString + "', sim='" + sim.ToString + "', nao='" + nao.ToString + "', motivo='" + motivo + "', obs='" + obs + "', unidade='" + unidade + "', int_sim='" + intSim.ToString + "', int_nao='" + intNao.ToString + "',hora_atendimento='" + hora_atendimento + "',afast_sim='" + afastSim.ToString + "',afast_nao='" + afastNao.ToString + "',nat_lesao='" + natLesao + "',cid='" + cid + "',crm='" + crm + "' WHERE codigo='" + codigo.ToString + "'"

            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            MessageBox.Show("Atestado alterado")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe Atestado! " + ex.Message)
        End Try
        Connection.Connect.Close()
    End Sub

    Public Sub CarregarGrade(codigo As Integer)
        Using da As New MySqlDataAdapter("SELECT codigo,data, dias,horas, injust, just, declaracao, atestado, sim, nao, motivo, obs,unidade,int_sim,int_nao,hora_atendimento,afast_sim,afast_nao,nat_lesao,cid,crm " +
                "FROM atestados where dados_codigo='" + codigo.ToString + "'", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvAtestados.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub
End Class
