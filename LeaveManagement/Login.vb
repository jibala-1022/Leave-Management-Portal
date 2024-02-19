﻿Public Class Login

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim userEmail As String = TextBox1.Text

        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                connection.Open()

                Dim query As String = "SELECT COUNT(*) FROM authentication " &
                    "WHERE email = @email AND passwd = SHA2(CONCAT(@email, @password), 256)"

                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@email", TextBox1.Text)
                command.Parameters.AddWithValue("@password", TextBox2.Text)

                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                If count > 0 Then
                    Dim mainApp As New MainApplication()
                    Environment.SetEnvironmentVariable("userEmail", userEmail)
                    mainApp.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Invalid email or password. Please try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Private Sub MyLeaves_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

End Class