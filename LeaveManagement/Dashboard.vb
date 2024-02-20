Public Class Dashboard

    Private Sub Dashboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim UserEmail As String = Environment.GetEnvironmentVariable("userEmail")

        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                connection.Open()

                Dim query As String = "SELECT * FROM students WHERE email = @email"

                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@email", UserEmail)

                Dim name As String
                Dim leaves_left As Integer

                Dim reader As MySqlDataReader = command.ExecuteReader()
                If reader.Read() Then
                    name = reader.GetString("name")
                    leaves_left = reader.GetUInt32("leaves_left")
                End If
                reader.Close()

                TextBox1.Text = leaves_left.ToString

            Catch ex As MySqlException
                connection.Close()
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using

        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try

                Dim query As String = "SELECT * FROM requests WHERE applicant_email = @email AND status = 'pending'"

                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@email", UserEmail)

                Dim dataAdapter As New MySqlDataAdapter(command)

                Dim dataTable As New DataTable
                dataAdapter.Fill(dataTable)

                data_active_requests.DataSource = dataTable

            Catch ex As MySqlException
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using

    End Sub


    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class