Imports MySql.Data.MySqlClient

Public Class UserLoginFile

    Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=test")

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub UserLoginFile_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CheckBoxPass_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxPass.CheckedChanged

        ' show password
        If pass.UseSystemPasswordChar = True Then
            pass.UseSystemPasswordChar = False

            ' hide password
        Else
            pass.UseSystemPasswordChar = True

        End If
    End Sub

    Private Sub ButtonExit_Click(sender As Object, e As EventArgs) Handles ButtonExit.Click

        Me.Close()

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click

        Dim command As New MySqlCommand("SELECT `name`,`pass` FROM `admin` WHERE `name`=@uname AND `pass`=@pass", connection)

        command.Parameters.Add("@uname", MySqlDbType.VarChar).Value = uname.Text
        command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass.Text

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count = 0 Then

            MessageBox.Show("Invalid Username or Password")
        Else
            MessageBox.Show("Logged In")
        End If

        'Next Page
        Dim newFrom As New profile_from()
        newFrom.Show()
        Me.Hide()
    End Sub

    Private Sub ButtonLogin_Enter(sender As Object, e As EventArgs) Handles ButtonLogin.Enter

    End Sub

    Private Sub ButtonLogin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ButtonLogin.KeyPress

    End Sub
End Class
