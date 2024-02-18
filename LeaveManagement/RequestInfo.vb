Imports MySql.Data.MySqlClient

Public Class RequestInfo
    Public application_id As Integer
    Dim applicant_email As String

    Dim connectionString As String = "server=172.16.114.244;userid=admin;Password=nimda;database=leave_management;sslmode=none"

    Private Sub RequestInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Dim connection As New MySqlConnection(connectionString)
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


    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click
        Dim button As Button = sender
        Dim Status As String = button.Tag

        Dim connection As New MySqlConnection(connectionString)
        Dim command As New MySqlCommand()

        Try
            connection.Open()

            command.Connection = connection

            Dim query As String = "UPDATE requests SET status = @status, reply_date = CURRENT_TIMESTAMP WHERE application_id = @applicationId"
            command.CommandText = query
            command.Parameters.AddWithValue("@status", Status)
            command.Parameters.AddWithValue("@applicationId", application_id)

            command.ExecuteNonQuery()

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

End Class