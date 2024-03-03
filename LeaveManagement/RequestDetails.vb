Imports System.Net
Imports System.Net.Mail

Public Class RequestDetails
    Public application_id As Integer
    Dim applicant_email As String
    Dim from_date As Date
    Dim to_date As Date
    Dim leave_type As String

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
                leave_type = TextBox6.Text
                from_date = DateTimePicker1.Value
                to_date = DateTimePicker2.Value
            End If
            reader.Close()
            Dim role As String = Environment.GetEnvironmentVariable("role")
            If role = "Faculty" Then
                query = "SELECT * FROM faculty WHERE email = @applicant_email"
            Else

                query = "SELECT * FROM students WHERE email = @applicant_email"
            End If

            command.CommandText = query
            command.Parameters.AddWithValue("@applicant_email", applicant_email)

            reader = command.ExecuteReader()
            If reader.Read() Then
                TextBox1.Text = reader.GetString("name")
                If role = "Faculty" Then
                    Label2.Visible = False
                    Label3.Visible = False
                    TextBox2.Visible = False
                    TextBox3.Visible = False
                Else
                    TextBox2.Text = reader.GetString("roll_number")
                    TextBox3.Text = reader.GetString("course")
                End If
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

        Dim rejection_remarks As String = ""

        If Status = "rejected" Then
            Dim popupForm As New Remarks()
            Dim result As DialogResult = popupForm.ShowDialog()

            If result = DialogResult.OK Then
                rejection_remarks = popupForm.remarks
            End If
        End If

        Dim connection As New MySqlConnection(My.Settings.connectionString)
        Dim command As New MySqlCommand()

        Try
            connection.Open()

            command.Connection = connection

            Dim query As String = "UPDATE requests SET status = @status, remarks = @remarks, reply_date = CURRENT_TIMESTAMP WHERE application_id = @applicationId"
            command.CommandText = query
            command.Parameters.AddWithValue("@status", Status)
            command.Parameters.AddWithValue("@remarks", rejection_remarks)
            command.Parameters.AddWithValue("@applicationId", application_id)

            command.ExecuteNonQuery()

            If Status = "approved" Then
                command.CommandText = "UPDATE students " &
                    "SET " & leave_type & " = (" & leave_type & " - DATEDIFF(@to_date, @from_date) + 1) " &
                    "WHERE email = @applicant_email"
                command.Parameters.AddWithValue("@from_date", from_date)
                command.Parameters.AddWithValue("@to_date", to_date)
                command.Parameters.AddWithValue("@applicant_email", applicant_email)
            End If

            command.ExecuteNonQuery()

            Try
                Dim mail As New MailMessage()
                Dim SmtpServer As New SmtpClient("smtp.gmail.com")

                mail.From = New MailAddress("LeaveManagementPortalIITG@gmail.com")
                mail.To.Add(applicant_email)

                If Status = "approved" Then
                    command.CommandText = "SELECT * FROM students where email = @applicant_email"
                    Dim casual As Integer = 0
                    Dim medical As Integer = 0
                    Dim academic As Integer = 0
                    Dim on_duty As Integer = 0
                    Dim maternity As Integer = 0
                    Dim reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        casual = reader.GetInt32("casual")
                        medical = reader.GetInt32("medical")
                        academic = reader.GetInt32("academic")
                        on_duty = reader.GetInt32("on_duty")
                        maternity = reader.GetInt32("maternity")
                    End If
                    reader.Close()

                    mail.Subject = "LEAVE APPROVED"
                    mail.Body = "Your leave request from " & from_date.ToString() & " to " & to_date.ToString() & " has been approved." & vbCrLf &
                        "Leaves left: " & vbCrLf &
                        "Casual : " & casual & vbCrLf &
                        "Medical : " & medical & vbCrLf &
                        "Academic : " & academic & vbCrLf &
                        "On Duty : " & on_duty & vbCrLf &
                        "Maternity : " & maternity & vbCrLf
                    Me.Hide()
                    MessageBox.Show("Leave Approved")
                ElseIf Status = "cancelled" Then
                    mail.Subject = "LEAVE CANCELLED"
                    mail.Body = "You have cancelled your leave request from " & from_date.ToString() & " to " & to_date.ToString() & " successfully."
                    Me.Hide()
                    MessageBox.Show("Leave Cancelled")
                Else
                    mail.Subject = "LEAVE REJECTED"
                    mail.Body = "Your leave request from " & from_date.ToString() & " to " & to_date.ToString() & " has been rejected." & vbCrLf &
                        "Remarks : " & vbCrLf & rejection_remarks
                    Me.Hide()
                    MessageBox.Show("Leave Rejected")
                End If

                SmtpServer.Port = 587
                SmtpServer.Credentials = New NetworkCredential("LeaveManagementPortalIITG@gmail.com", "gkltiiturdskigmm")
                SmtpServer.EnableSsl = True

                Try
                    SmtpServer.Send(mail)
                    MessageBox.Show("Mail sent")
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