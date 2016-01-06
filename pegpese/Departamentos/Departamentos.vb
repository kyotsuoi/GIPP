Imports MySql.Data.MySqlClient

Public Class Departamentos
    Dim Connection As New Connection

    Public Sub connect_base()
        Connection.Connection()
    End Sub

    Public Sub CarregarGradeF()
        Connection.Connection()
        Using da As New MySqlDataAdapter("SELECT * FROM departamentos", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmFuncionarios.dgvDepartamentos.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Sub CarregarGrade()
        Using da As New MySqlDataAdapter("SELECT codigo,centro_custo,cargo,cbo FROM departamentos", Connection.ConnectionAutentication)
            Using ds As New DataSet
                da.Fill(ds)
                frmDepartamentos.dgvDepartamentos.DataSource = ds.Tables(0)
            End Using
        End Using
    End Sub

    Public Sub Gravar(centro_custo As String, cargo As String, cbo As String)

        Try
            Connection.Query = "Insert into departamentos (centro_custo, cargo,cbo) values ('" + centro_custo + "','" + cargo + "','" + cbo + "')"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            MsgBox("Dados gravados com sucesso!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao gravar na classe Departamento " + ex.Message)
        End Try
        Connection.Connect.Dispose()
        Connection.Connect.Close()
    End Sub

    Public Sub Alterar(codigo As Integer, centro_custo As String, cargo As String, cbo As String)
        Try
            Connection.Query = "UPDATE departamentos Set centro_custo='" + centro_custo + "', cargo='" + cargo + "',cbo='" + cbo + "' WHERE codigo='" + codigo.ToString + "'"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            Connection.Connect.Dispose()
            Connection.Connect.Close()
            MsgBox("Dados alterados com sucesso!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao alterar na classe Funcionarios " + ex.Message)
        End Try
        Connection.Connect.Dispose()
        Connection.Connect.Close()
    End Sub

    Public Sub Apagar(codigo As Integer)
        Try
            Connection.Query = "DELETE FROM departamentos WHERE codigo='" + codigo.ToString + "'"
            Connection.Connect.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
            cmd.ExecuteNonQuery()
            MsgBox("Dados apagados com sucesso!")
        Catch ex As Exception
            MessageBox.Show("Houve um erro ao apagar na classe Funcionarios " + ex.Message)
        End Try
        CarregarGrade()
        Connection.Connect.Dispose()
        Connection.Connect.Close()
    End Sub

    Public Function BuscarDepartamento(centro_custo As String, cargo As String) As String
        Connection.Query = "Select centro_custo, cargo FROM departamentos " +
                            "Where centro_custo='" + centro_custo.ToString + "' and cargo='" + cargo.ToString + "'"
        Connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()
        Connection.Connect.Close()
        Return Scalar
    End Function

    Public Function Buscar(nome As String, campo As String, tabela As String) As String
        Connection.Query = "Select " + campo + " FROM " + tabela + " where centro_custo='" + nome + "'"
        Connection.Connect.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(Connection.Query, Connection.Connect)
        Dim Scalar As String = cmd.ExecuteScalar()
        Connection.Connect.Close()
        Return Scalar
    End Function
End Class
