Public Class Login

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Panel1.BackColor = Color.FromArgb(255, 255, 255, 255)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim userEmail As String = TextBox1.Text

        If String.IsNullOrEmpty(TextBox1.Text) Or String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show("Please enter email and password to login")
            Return
        End If

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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        TextBox2.UseSystemPasswordChar = CheckBox1.Checked
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim userEmail As String = TextBox1.Text
        Environment.SetEnvironmentVariable("userEmail", userEmail)
        Dim forgotpassword As ForgotPassword = New ForgotPassword()
        forgotpassword.Show()
    End Sub

    Private Sub MyLeaves_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class