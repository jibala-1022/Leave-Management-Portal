Public Class UserProfile
    Private originalControls As New List(Of Control)
    Public phonenumber As String = ""

    Private Sub UserProfile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button3.Hide()
        Button4.Hide()
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
                    TextBox7.Text = reader.GetString("hostel")
                    phonenumber = TextBox6.Text
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

    Private Function ValidatePhoneNumber(ByVal newPhoneNumber As String) As Boolean
        ' Check if the new phone number is not the same as the old one
        If newPhoneNumber = phonenumber Then
            MessageBox.Show("New phone number cannot be the same as the old one.")
            Return False
        End If

        ' Check if the new phone number has exactly 10 digits
        If newPhoneNumber.Length <> 10 OrElse Not IsNumeric(newPhoneNumber) Then
            MessageBox.Show("Phone number should have exactly 10 digits.")
            Return False
        End If

        ' If all checks pass, return true indicating valid phone number
        Return True
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox6.ReadOnly = True Then
            Button4.Visible = True
            Button1.Text = "Discard"
            TextBox6.ReadOnly = False
            TextBox6.BorderStyle = BorderStyle.Fixed3D
            TextBox6.Top = TextBox6.Location.Y - 5
        Else
            Button4.Hide()
            Button1.Text = "Change"
            TextBox6.ReadOnly = True
            TextBox6.BorderStyle = BorderStyle.None
            TextBox6.Top = TextBox6.Location.Y + 5
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim newPhoneNumber As String = TextBox6.Text
        Dim userEmail = Environment.GetEnvironmentVariable("userEmail")

        ' Validate the new phone number
        If Not ValidatePhoneNumber(newPhoneNumber) Then
            Return
        End If

        ' Update the phone number in the database
        Dim query As String = "UPDATE students SET phone_number = @newPhoneNumber WHERE email = @userEmail"

        Try
            Using connection As New MySqlConnection(My.Settings.connectionString)
                Using cmd As New MySqlCommand(query, connection)
                    ' Add parameters to the query
                    cmd.Parameters.AddWithValue("@newPhoneNumber", newPhoneNumber)
                    cmd.Parameters.AddWithValue("@userEmail", userEmail) ' Assuming you have defined applicant_email somewhere

                    connection.Open()

                    ' Execute the query
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    ' Check if the update was successful
                    If rowsAffected > 0 Then
                        MessageBox.Show("Phone number updated successfully.")
                    Else
                        MessageBox.Show("Failed to update phone number.")
                        Return
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating phone number: " & ex.Message)
        End Try
        Button4.Hide()
        Button1.Text = "Change"
        TextBox6.ReadOnly = True
        TextBox6.BorderStyle = BorderStyle.None
        TextBox6.Top = TextBox6.Location.Y + 5
        phonenumber = newPhoneNumber
    End Sub
End Class