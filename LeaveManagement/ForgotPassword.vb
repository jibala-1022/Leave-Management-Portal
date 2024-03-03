Imports System.Net
Imports System.Net.Mail

Public Class ForgotPassword

    'Dim userEmail As String = Environment.GetEnvironmentVariable("userEmail")
    Dim randomCode As String
    Dim elapsedTime As Integer = 0 ' Track elapsed time in seconds
    Dim WithEvents timer As New Timer()

    Private Sub ForgotPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Hide()
    End Sub

    Public Function IsEmailPresent(ByVal email As String) As Boolean
        Dim isPresent As Boolean = False

        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                connection.Open()

                Dim query As String = "SELECT COUNT(*) FROM authentication " &
                    "WHERE email = @email"

                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@email", email)

                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                If count > 0 Then
                    isPresent = True
                    Environment.SetEnvironmentVariable("userEmail", email)
                Else
                    MessageBox.Show("Email you have entered has not been registered!!.", "INVALID EMAIL", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                connection.Close()
            End Try
        End Using

        Return isPresent
    End Function

    Sub switchPanel(ByVal panel As Form)
        Panel1.Controls.Clear()
        panel.TopLevel = False
        panel.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Panel1.Controls.Add(panel)
        panel.Show()
    End Sub

    ' Timer tick event handler to track elapsed time
    Private Sub Timer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer.Tick
        elapsedTime += 1 ' Increment elapsed time by 1 second
        Dim timeLeft As Integer = 60 - elapsedTime
        TimeLeftLabel.Text = "Time Left: " & timeLeft.ToString() & " seconds"
        If elapsedTime >= 60 Then ' Check if 60 seconds have elapsed
            timer.Stop() ' Stop the timer
            MessageBox.Show("Verification code has expired. Please request a new one.")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label2.Visible = True
        Label2.Text = "Sending code....."
        Label2.ForeColor = Color.YellowGreen

        Dim userEmail As String = TextBox2.Text

        If String.IsNullOrEmpty(userEmail) Then
            MessageBox.Show("Please enter your Email to send code")
            Label2.Hide()
            Return
        End If

        If Not IsEmailPresent(userEmail) Then
            Label2.Hide()
            Return
        End If


        Dim rand As New Random()
        randomCode = (rand.Next(999999)).ToString()
        elapsedTime = 0 ' Reset elapsed time
        timer.Interval = 1000 ' Set interval to 1 second
        Try
            Dim mail As New MailMessage()
            Dim SmtpServer As New SmtpClient("smtp.gmail.com")

            mail.From = New MailAddress("LeaveManagementPortalIITG@gmail.com")
            mail.To.Add(userEmail)
            mail.Subject = "VERIFICATION CODE - FORGOT PASSWORD"
            mail.Body = "Verification Code is: " + randomCode

            SmtpServer.Port = 587
            SmtpServer.Credentials = New NetworkCredential("LeaveManagementPortalIITG@gmail.com", "gkltiiturdskigmm")
            SmtpServer.EnableSsl = True

            Try
                SmtpServer.Send(mail)
                MessageBox.Show("Please check your Email for the verification code and enter it below!")
                timer.Start() ' Start the timer
            Catch ex As Exception
                'Label2.Visible = True
                Label2.Text = "Unexpected Error occured!! Please click on send code again!"
                Label2.ForeColor = Color.Red
                MessageBox.Show("Error occured sending code :", ex.Message)
            End Try

            'Label2.Visible = True
            Label2.Text = "Code sent!" & Environment.NewLine & "Please check your Email for the code and enter it below!"
            Label2.ForeColor = Color.Green

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MessageBox.Show("Please enter the code to proceed!")
            Return
        End If

        If elapsedTime < 60 Then ' Check if the elapsed time is less than 60 seconds
            If TextBox1.Text.Equals(randomCode) Then
                timer.Stop()
                switchPanel(ChangePassword)
                'Dim resetPassword As New ChangePassword()
                'resetPassword.Show()
                'Me.Hide()
            ElseIf elapsedTime = 0 Then
                MessageBox.Show("Please click on send code to get a code")
                Return
            Else
                Label2.Text = "Incorrect code."
                Label2.ForeColor = Color.Red
                MessageBox.Show("Incorrect code.")
            End If
        Else
            Label2.Text = "Verification code has expired. Please request a new one."
            Label2.ForeColor = Color.Red
            MessageBox.Show("Verification code has expired. Please request a new one.")
        End If
    End Sub

End Class
