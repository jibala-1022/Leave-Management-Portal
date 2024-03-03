Imports System.Net
Imports System.Net.Mail

Public Class faculty_registration

    Dim randomCode As String
    Dim elapsedTime As Integer = 0 ' Track elapsed time in seconds
    Dim WithEvents timer As New Timer()

    Private Function AreFieldsEmpty() As Boolean
        ' Array to hold all six textboxes
        Dim textBoxes() As TextBox = {TextBox1, TextBox3, TextBox2}

        ' Array to hold all  comboboxes
        Dim comboBoxes() As ComboBox = {ComboBox1}

        ' Loop through each textbox to check if it's empty
        For Each textbox As TextBox In textBoxes
            If String.IsNullOrWhiteSpace(textbox.Text) Then
                MessageBox.Show("Please fill all fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return True ' If any textbox is empty, return true
            End If
        Next

        ' Loop through each combobox to check if it's empty
        For Each comboBox As ComboBox In comboBoxes
            If comboBox.SelectedItem Is Nothing Then
                MessageBox.Show("Please fill all fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return True ' If any combobox is empty, return true
            End If
        Next

        Return False ' Return false if all textboxes and comboboxes are filled
    End Function

    Private Sub ValidateInputs()
        ' Validate Email
        Dim emailPattern As String = "^[a-zA-Z0-9._%+-]+@iitg\.ac\.in$"
        If Not System.Text.RegularExpressions.Regex.IsMatch(TextBox2.Text, emailPattern) Then
            MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Validate Phone Number
        If TextBox3.Text.Length <> 10 Then
            MessageBox.Show("Please enter a valid 10-digit phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If


    End Sub

    Private Function checkExistence() As Boolean
        Dim userEmail As String = TextBox2.Text

        Dim Conn As New MySqlConnection(My.Settings.connectionString)
        Dim cmd As New MySqlCommand()

        Dim bool As Boolean = False

        Try
            Conn.Open()
            cmd.Connection = Conn

            cmd.CommandText = "SELECT * FROM faculty where email=@email "

            ' Add parameters to the query to filter by user email
            cmd.Parameters.AddWithValue("@email", TextBox2.Text)

            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            If count > 0 Then
                bool = True
            Else
                bool = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return bool
    End Function

    Private Sub register()
        Dim Conn As New MySqlConnection(My.Settings.connectionString)
        Dim cmd As New MySqlCommand()

        Try
            Conn.Open()
            cmd.Connection = Conn

            cmd.CommandText = "INSERT INTO faculty(email, name, department, phone_number) " &
                "VALUES (@email, @name, @department, @phone_number)"

            cmd.Parameters.AddWithValue("@email", TextBox2.Text)
            cmd.Parameters.AddWithValue("@name", TextBox1.Text)
            cmd.Parameters.AddWithValue("@department", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@phone_number", TextBox3.Text)

            MessageBox.Show("Registered Succesfully!" & Environment.NewLine & "Please create a password to proceed")
            Environment.SetEnvironmentVariable("UserEmail", TextBox2.Text)
            Environment.SetEnvironmentVariable("role", "Faculty")
            switchPanel(addPassword)

            MessageBox.Show("Applied Succesfully")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
        If AreFieldsEmpty() Then
            Return
        End If

        ValidateInputs()

        If checkExistence() Then
            MessageBox.Show("You have already registered with that Email ID!")
            Return
        End If

        Button1.Hide()
        Button2.Hide()
        Label1.Hide()
        Label11.Visible = True
        Panel2.Hide()
        Panel3.Visible = True
    End Sub

    Sub switchPanel(ByVal panel As Form)
        Panel1.Controls.Clear()
        panel.TopLevel = False
        panel.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Panel1.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub faculty_registration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel3.Hide()
        Label11.Hide()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Label12.Visible = True
        Label12.Text = "Sending code....."
        Label12.ForeColor = Color.YellowGreen

        Dim userEmail As String = TextBox2.Text
        Dim rand As New Random()
        randomCode = (rand.Next(999999)).ToString()
        elapsedTime = 0 ' Reset elapsed time
        timer.Interval = 1000 ' Set interval to 1 second
        Try
            Dim mail As New MailMessage()
            Dim SmtpServer As New SmtpClient("smtp.gmail.com")

            mail.From = New MailAddress("LeaveManagementPortalIITG@gmail.com")
            mail.To.Add(userEmail)
            mail.Subject = "VERIFICATION CODE - REGISTRATION"
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
                Label12.Text = "Unexpected Error occured!! Please click on send code again!"
                Label12.ForeColor = Color.Red
                MessageBox.Show("Error occured sending code :", ex.Message)
            End Try

            'Label2.Visible = True
            Label12.Text = "Code sent!" & Environment.NewLine & "Please check your Email for the code!"
            Label12.ForeColor = Color.Green

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If String.IsNullOrEmpty(TextBox8.Text) Then
            MessageBox.Show("Please enter the code to proceed!")
            Return
        End If

        If elapsedTime < 60 Then ' Check if the elapsed time is less than 60 seconds
            If TextBox8.Text.Equals(randomCode) Then
                timer.Stop()
                register()
            ElseIf elapsedTime = 0 Then
                MessageBox.Show("Please click on send code to get a code")
                Return
            Else
                Label12.Text = "Incorrect code."
                Label12.ForeColor = Color.Red
                MessageBox.Show("Incorrect code.")
            End If
        Else
            Label12.Text = "Verification code has expired. Please request a new one."
            Label12.ForeColor = Color.Red
            MessageBox.Show("Verification code has expired. Please request a new one.")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim result As DialogResult = MessageBox.Show("Do you sure want to cancel registration?", "Registration", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Me.Close()
        Else
            Return
        End If
    End Sub

End Class