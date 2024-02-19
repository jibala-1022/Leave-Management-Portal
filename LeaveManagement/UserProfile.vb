Public Class UserProfile

    Private Sub UserProfile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim userEmail = Environment.GetEnvironmentVariable("userEmail")

        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                connection.Open()

                Dim query As String = "SELECT * FROM students WHERE email = @email"

                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@email", userEmail)

                Dim reader As MySqlDataReader = command.ExecuteReader()
                If reader.Read() Then
                    TextBox1.Text = reader.GetString("name")
                    TextBox2.Text = reader.GetUInt32("roll_number")
                    TextBox3.Text = reader.GetString("email")
                    TextBox4.Text = reader.GetString("course")
                    TextBox5.Text = reader.GetString("department")
                    TextBox6.Text = reader.GetString("phone_number")
                End If
                reader.Close()


            Catch ex As MySqlException
                connection.Close()
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim changePassword As New ChangePassword()
        changePassword.Show()
    End Sub
End Class