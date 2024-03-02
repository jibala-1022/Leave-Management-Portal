Public Class MainApplication

    Private Sub Dashboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Iterate through each control in the panel
        For Each ctrl As Control In Panel2.Controls
            ' Set the Anchor property to None
            ctrl.Anchor = AnchorStyles.None
        Next

        Dim userEmail As String = Environment.GetEnvironmentVariable("userEmail")

        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                connection.Open()

                Dim query As String = "SELECT * FROM students WHERE email=@email"

                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@email", userEmail)

                Dim name As String = "Error:"
                Dim leaves_left As Integer = 0

                Dim reader As MySqlDataReader = command.ExecuteReader()
                If reader.Read() Then
                    name = reader.GetString("name")
                    leaves_left = reader.GetInt32("leaves_left")
                End If
                reader.Close()

                user_profile.Text = name
                TextBox1.Text = leaves_left.ToString

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using

        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                connection.Open()

                Dim query As String = "SELECT * FROM requests WHERE applicant_email = @email AND status = 'pending'"

                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@email", userEmail)

                Dim dataAdapter As New MySqlDataAdapter(command)

                Dim dataTable As New DataTable
                dataAdapter.Fill(dataTable)
                data_active_requests.DataSource = dataTable

            Catch ex As MySqlException
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Sub switchPanel(ByVal panel As Form)
        Panel1.Controls.Clear()
        panel.TopLevel = False
        panel.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Panel1.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Button3.BackColor = Color.SteelBlue
        Button6.BackColor = Color.DodgerBlue
        Button2.BackColor = Color.SteelBlue
        Button4.BackColor = Color.SteelBlue
        switchPanel(MyLeaves)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Button3.BackColor = Color.SteelBlue
        Button6.BackColor = Color.SteelBlue
        Button2.BackColor = Color.DodgerBlue
        Button4.BackColor = Color.SteelBlue
        switchPanel(ApproveLeave)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button3.BackColor = Color.SteelBlue
        Button6.BackColor = Color.SteelBlue
        Button2.BackColor = Color.SteelBlue
        Button4.BackColor = Color.DodgerBlue
        switchPanel(ApplyLeave)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button3.BackColor = Color.DodgerBlue
        Button6.BackColor = Color.SteelBlue
        Button2.BackColor = Color.SteelBlue
        Button4.BackColor = Color.SteelBlue
        switchPanel(Dashboard)
    End Sub

    Private Sub user_profile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles user_profile.Click
        Button3.BackColor = Color.SteelBlue
        Button6.BackColor = Color.SteelBlue
        Button2.BackColor = Color.SteelBlue
        Button4.BackColor = Color.SteelBlue
        'Dim userProfile As New UserProfile()
        'userProfile.Show()
        switchPanel(userProfile)
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
        ' Calculate the new location of the panel when the form is resized
        Panel2.Location = New Point((Me.ClientSize.Width - Panel2.Width) \ 2, (Me.ClientSize.Height - Panel2.Height) \ 2)
    End Sub

    Private Sub Dashboard_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Ask for confirmation before logging out
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Check if the user confirmed the logout
        If result = DialogResult.Yes Then
            ' Close the main application form
            Me.Hide()

            ' Open the login form
            Dim loginForm As New Login()
            loginForm.Show()
        End If
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class