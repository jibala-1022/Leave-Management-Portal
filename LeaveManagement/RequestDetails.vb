Imports System.Net
Imports System.Net.Mail

Public Class RequestDetails
    Public application_id As Integer
    Dim applicant_email As String
    Dim from_date As Date
    Dim to_date As Date

    Private Sub RequestInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim connection As New MySqlConnection(My.Settings.connectionString)
        Dim command As New MySqlCommand()

        Try
            connection.Open()

            command.Connection = connection

            Dim query As String = "SELECT * FROM requests WHERE application_id = @applicationId"
            command.CommandText = query
            command.Parameters.AddWithValue("@applicationId", application_id)

            Dim reader As MySqlDataReader = command.ExecuteReader()
            If reader.Read() Then
                applicant_email = reader.GetString("applicant_email")

                TextBox6.Text = reader.GetString("type")
                DateTimePicker1.Value = reader.GetDateTime("from_date")
                DateTimePicker2.Value = reader.GetDateTime("to_date")
                DateTimePicker3.Value = reader.GetDateTime("applied_date")
                TextBox9.Text = reader.GetString("reason")
                from_date = DateTimePicker1.Value
                to_date = DateTimePicker2.Value
            End If
            reader.Close()

            query = "SELECT * FROM students WHERE email = @applicant_email"
            command.CommandText = query
            command.Parameters.AddWithValue("@applicant_email", applicant_email)

            reader = command.ExecuteReader()
            If reader.Read() Then
                TextBox1.Text = reader.GetString("name")
                TextBox2.Text = reader.GetString("roll_number")
                TextBox3.Text = reader.GetString("course")
                TextBox4.Text = reader.GetString("department")
                TextBox5.Text = reader.GetString("phone_number")
            End If
            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub


    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click
        Dim button As Button = sender
        Dim Status As String = button.Tag

        Dim connection As New MySqlConnection(My.Settings.connectionString)
        Dim command As New MySqlCommand()

        Try
            connection.Open()

            command.Connection = connection

            Dim query As String = "UPDATE requests SET status = @status, reply_date = CURRENT_TIMESTAMP WHERE application_id = @applicationId"
            command.CommandText = query
            command.Parameters.AddWithValue("@status", Status)
            command.Parameters.AddWithValue("@applicationId", application_id)

            command.ExecuteNonQuery()

            Try
                Dim mail As New MailMessage()
                Dim SmtpServer As New SmtpClient("smtp.gmail.com")

                mail.From = New MailAddress("LeaveManagementPortalIITG@gmail.com")
                mail.To.Add(applicant_email)
                If Status = "approved" Then
                    mail.Subject = "LEAVE APPROVED"
                    mail.Body = "Your leave request from " & from_date.ToString() & " to " & to_date.ToString() & " has been approved."
                Else
                    mail.Subject = "LEAVE REJECTED"
                    mail.Body = "Your leave request from " & from_date.ToString() & " to " & to_date.ToString() & " has been rejected."
                End If

                SmtpServer.Port = 587
                SmtpServer.Credentials = New NetworkCredential("LeaveManagementPortalIITG@gmail.com", "gkltiiturdskigmm")
                SmtpServer.EnableSsl = True

                Try
                    SmtpServer.Send(mail)
                    MessageBox.Show("Mail sent to respective student")
                Catch ex As Exception
                    MessageBox.Show("Error occured sending code :", ex.Message)
                End Try
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
End Class