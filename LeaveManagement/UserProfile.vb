Public Class UserProfile
    Private originalControls As New List(Of Control)

    Private Sub UserProfile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button3.Hide()
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

    Sub switchPanel(ByVal panel As Form)

        ' Store references to the original controls
        For Each ctrl As Control In Panel1.Controls
            originalControls.Add(ctrl)
        Next

        Panel1.Controls.Clear()
        panel.TopLevel = False
        panel.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Panel1.Controls.Add(panel)
        panel.Show()

        ' Add the original button to the panel
        Panel1.Controls.Add(Button3)
        Button3.Visible = True
        ' Bring the original button to the front
        Button3.BringToFront()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        switchPanel(ChangePassword)
        'Dim changePassword As New ChangePassword()
        'changePassword.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        ' Clear the panel's controls
        Panel1.Controls.Clear()
        Button3.Hide()
        ' Show original controls
        For Each ctrl As Control In originalControls
            Panel1.Controls.Add(ctrl)
        Next

        ' Clear the list of original controls
        originalControls.Clear()

        ' Close the new form gracefully
        'DirectCast(Panel1.Controls(0), Form).Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub
End Class