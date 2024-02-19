Public Class ChangePassword

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim userEmail = Environment.GetEnvironmentVariable("userEmail")

        If TextBox1.Text <> TextBox2.Text Then
            MessageBox.Show("Passwords do no match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                connection.Open()

                Dim query As String = "UPDATE authentication SET passwd = @password WHERE email = @email"

                Dim password As String = TextBox1.Text

                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@email", userEmail)
                command.Parameters.AddWithValue("@password", password)

                command.ExecuteNonQuery()

            Catch ex As MySqlException
                connection.Close()
                MessageBox.Show("Error: " & ex.Message)
            Finally
                Me.Close()
            End Try
        End Using
    End Sub
End Class