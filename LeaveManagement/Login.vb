Public Class Login
    Private originalControls As New List(Of Control)

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Button3.Hide()
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
                    Dim query2 As String = "SELECT role FROM authentication " &
                    "WHERE email = @email AND passwd = SHA2(CONCAT(@email, @password), 256)"

                    Dim command2 As New MySqlCommand(query2, connection)
                    command2.Parameters.AddWithValue("@email", TextBox1.Text)
                    command2.Parameters.AddWithValue("@password", TextBox2.Text)

                    Dim role As String = Convert.ToString(command2.ExecuteScalar())
                    Console.WriteLine(role)
                    Dim approver As String = ""

                    If role = "B.Tech" Then
                        If approver = "" Then
                            command.CommandText = "select email from dupc " &
                            "where department = (select department from students where students.email = @email) and " &
                            "(select on_leave from faculty where faculty.email = dupc.faculty_email) = 0"
                            approver = Convert.ToString(command.ExecuteScalar())
                        End If

                        If approver = "" Then
                            command.CommandText = "select email from hod " &
                            "where department = (select department from students where students.email = @email) and " &
                            "(select on_leave from faculty where faculty.email = hod.faculty_email) = 0"
                            approver = Convert.ToString(command.ExecuteScalar())
                        End If

                        If approver = "" Then
                            command.CommandText = "select email from dean " &
                            "where role = 'dosa' and " &
                            "(select on_leave from faculty where faculty.email = dean.faculty_email) = 0"
                            approver = Convert.ToString(command.ExecuteScalar())
                        End If

                        If approver = "" Then
                            command.CommandText = "select email from director " &
                            "where on_leave = 0"
                            approver = Convert.ToString(command.ExecuteScalar())
                        End If

                        If approver = "" Then
                            approver = "admin@iitg.ac.in"
                        End If

                        Console.WriteLine(approver)
                        Environment.SetEnvironmentVariable("approverEmail", approver)
                    End If

                    If role = "M.Tech" Or role = "Ph.D" Then
                        If approver = "" Then
                            command.CommandText = "select faculty_email from supervisors " &
                            "where student_email = @email and " &
                            "(select on_leave from faculty where faculty.email = supervisors.faculty_email) = 0"
                            approver = Convert.ToString(command.ExecuteScalar())
                        End If

                        If approver = "" Then
                            command.CommandText = "select email from dppc " &
                            "where department = (select department from students where students.email = @email) and " &
                            "(select on_leave from faculty where faculty.email = dppc.faculty_email) = 0"
                            approver = Convert.ToString(command.ExecuteScalar())
                        End If

                        If approver = "" Then
                            command.CommandText = "select email from hod " &
                            "where department = (select department from students where students.email = @email) and " &
                            "(select on_leave from faculty where faculty.email = hod.faculty_email) = 0"
                            approver = Convert.ToString(command.ExecuteScalar())
                        End If

                        If approver = "" Then
                            command.CommandText = "select email from dean " &
                            "where role = 'dosa' and " &
                            "(select on_leave from faculty where faculty.email = dean.faculty_email) = 0"
                            approver = Convert.ToString(command.ExecuteScalar())
                        End If

                        If approver = "" Then
                            command.CommandText = "select email from director " &
                            "where on_leave = 0"
                            approver = Convert.ToString(command.ExecuteScalar())
                        End If

                        If approver = "" Then
                            approver = "admin@iitg.ac.in"
                        End If

                        Console.WriteLine(approver)
                        Environment.SetEnvironmentVariable("approverEmail", approver)
                    End If

                    If role = "Faculty" Then

                        If approver = "" Then
                            command.CommandText = "select email from hod " &
                            "where department = (select department from faculty where faculty.email = @email) and " &
                            "faculty_email <> @email and " &
                            "(select count(*) from dean where dean.faculty_email = @email) = 0 and " &
                            "(select on_leave from faculty where faculty.email = hod.faculty_email) = 0"
                            approver = Convert.ToString(command.ExecuteScalar())
                        End If

                        If approver = "" Then
                            command.CommandText = "select email from dean " &
                            "where role = 'dofa' and " &
                            "faculty_email <> @email and " &
                            "(select count(*) from dean where dean.faculty_email = @email) = 0 and " &
                            "(select on_leave from faculty where faculty.email = dean.faculty_email) = 0"
                            approver = Convert.ToString(command.ExecuteScalar())
                        End If

                        If approver = "" Then
                            command.CommandText = "select email from director " &
                            "where on_leave = 0"
                            approver = Convert.ToString(command.ExecuteScalar())
                        End If

                        If approver = "" Then
                            approver = "admin@iitg.ac.in"
                        End If

                        Console.WriteLine(approver)
                        Environment.SetEnvironmentVariable("approverEmail", approver)
                    End If

                    If role = "Staff" Then
                        If approver = "" Then
                            command.CommandText = "select email from hod " &
                            "where department = (select department from staff where staff.email = @email) and " &
                            "(select on_leave from faculty where faculty.email = hod.faculty_email) = 0"
                            approver = Convert.ToString(command.ExecuteScalar())
                        End If

                        If approver = "" Then
                            command.CommandText = "select email from dean " &
                            "where role = 'dofa' and " &
                            "(select on_leave from faculty where faculty.email = hod.faculty_email) = 0"
                            approver = Convert.ToString(command.ExecuteScalar())
                        End If

                        If approver = "" Then
                            command.CommandText = "select email from director " &
                            "where on_leave = 0"
                            approver = Convert.ToString(command.ExecuteScalar())
                        End If

                        If approver = "" Then
                            approver = "admin@iitg.ac.in"
                        End If

                        Console.WriteLine(approver)
                        Environment.SetEnvironmentVariable("approverEmail", approver)
                    End If

                    Environment.SetEnvironmentVariable("userEmail", userEmail)
                    Environment.SetEnvironmentVariable("role", role)

                    If role = "DUPC" Or role = "DPPC" Or role = "DOSA" Or role = "DOFA" Or role = "HOD" Then
                        Dim authority As authority = New authority()
                        authority.Show()
                    ElseIf role = "Director" Then
                        Dim director As Director = New Director()
                        Director.Show()
                    ElseIf role = "Faculty" Then
                        Dim faculty As faculty = New faculty()
                        faculty.Show()
                    ElseIf role = "Admin" Then
                        Dim Adminpage As AdminPage = New AdminPage()
                        AdminPage.Show()
                    ElseIf role = "Hostel" Then
                        Dim Hostelpage As HostelPage = New HostelPage()
                        HostelPage.Show()
                    Else
                        Dim student As student = New student()
                        student.Show()
                    End If
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
        Dim ForgotPassword As ForgotPassword = New ForgotPassword()
        switchPanel(ForgotPassword)
        'Dim forgotpassword As ForgotPassword = New ForgotPassword()
        'forgotpassword.Show()
    End Sub

    Private Sub MyLeaves_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Sub switchPanel(ByVal panel As Form)
        ' Store references to the original controls
        For Each ctrl As Control In Panel1.Controls
            originalControls.Add(ctrl)
        Next

        Panel1.Controls.Clear()
        panel.TopLevel = False
        panel.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Panel1.Controls.Add(panel)
        panel.Show()

        ' Add the original button to the panel
        Panel1.Controls.Add(Button3)
        Button3.Visible = True
        ' Bring the original button to the front
        Button3.BringToFront()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ' Ask for confirmation before logging out
        Dim result As DialogResult = MessageBox.Show("Do you sure want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Check if the user confirmed the logout
        If result = DialogResult.Yes Then
            ' Clear the panel's controls
            Panel1.Controls.Clear()
            Button3.Hide()
            ' Show original controls
            For Each ctrl As Control In originalControls
                Panel1.Controls.Add(ctrl)
            Next

            ' Clear the list of original controls
            originalControls.Clear()
        End If
    End Sub
End Class