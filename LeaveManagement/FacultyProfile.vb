Imports System.Data.SqlClient

Public Class FacultyProfile
    Private Sub FacultyProfile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim FacultyEmail = Environment.GetEnvironmentVariable("FacultyEmail")

        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                connection.Open()

                Dim query As String = "SELECT * FROM faculty WHERE email = @email"

                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@email", FacultyEmail)

                Dim reader As MySqlDataReader = command.ExecuteReader()
                If reader.Read() Then
                    TextBox1.Text = reader.GetString("name")
                    TextBox2.Text = reader.GetString("email")
                    TextBox3.Text = reader.GetString("department")
                    TextBox4.Text = reader.GetString("phone_number")
                    TextBox5.Text = reader.GetString("on_leave")
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