
Imports MySql.Data.MySqlClient
Imports GuidReorder.MysqlFunctions

Public Class Form1




    Private Sub bCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancel.Click
        Application.Exit()
    End Sub

    Private Sub bLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLogin.Click
        Me.Hide()

        conn = New MySqlConnection()
        MysqlParams = "server=" & txtHost.Text & ";" & "user id=" & txtUsername.Text & ";" & "password=" & txtPassword.Text & ";" & "database=" & txtDb.Text
        conn.ConnectionString = MysqlParams

        Try
            conn.Open()
            conn.Close()
        Catch myerror As MySqlException
            MessageBox.Show("Error Connecting to Database: " & myerror.Message)
            Me.Show()
        Finally
            conn.Dispose()
        End Try

        Main.Show()


    End Sub
End Class
