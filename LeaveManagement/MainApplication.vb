Public Class MainApplication

    Private Sub MainApplication_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim userEmail As String = Environment.GetEnvironmentVariable("userEmail")
        Dim role As String = Environment.GetEnvironmentVariable("role")

        Dim approves As String = ""
        Dim course As String = ""
        Dim department As String = ""

        If role = "student" Then
            Button2.Visible = False

            approves = "student"

            Dim year As Integer = 0

            Using connection As New MySqlConnection(My.Settings.connectionString)
                Try
                    connection.Open()

                    Dim query As String = "SELECT * FROM students WHERE email = @email"

                    Dim command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@email", userEmail)

                    Dim reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        user_profile.Text = reader.GetString("name")
                        course = reader.GetString("course")
                        department = reader.GetString("department")
                        year = reader.GetUInt32("year")
                    End If
                    reader.Close()

                Catch ex As MySqlException
                    connection.Close()
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using

        ElseIf role = "staff" Then

        ElseIf role = "faculty" Then
            approves = "faculty"
        End If

        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                connection.Open()

                Dim query As String = "SELECT email FROM positions " &
                    "WHERE approves = @approves AND course = @course AND department = @department AND on_leave = 0 " &
                    "ORDER BY rank DESC " &
                    "LIMIT 1 "

                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@approves", approves)
                command.Parameters.AddWithValue("@course", course)
                command.Parameters.AddWithValue("@department", department)

                role = Convert.ToString(command.ExecuteScalar())

            Catch ex As MySqlException
                connection.Close()
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using



        Button3.BackColor = Color.DodgerBlue
        Button6.BackColor = Color.SteelBlue
        Button2.BackColor = Color.SteelBlue
        Button4.BackColor = Color.SteelBlue
        switchPanel(Dashboard)

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

    Private Sub Dashboard_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub


    Private Sub user_profile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles user_profile.Click
        Dim userProfile As New UserProfile()
        userProfile.Show()

    End Sub

End Class