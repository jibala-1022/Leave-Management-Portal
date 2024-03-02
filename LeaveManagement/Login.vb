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
                            "(select on_leave from faculty where faculty.email = hod.faculty_email) = 0"
                            approver = Convert.ToString(command.ExecuteScalar())
                        End If

                        If approver = "" Then
                            command.CommandText = "select email from dean " &
                            "where role = 'dofa' and " &
                            "faculty_email <> @email and " &
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
                    Environment.SetEnvironmentVariable("userEmail", userEmail)
                    Environment.SetEnvironmentVariable("role", role)

                    If role = "DUPC" Or role = "DPPC" Or role = "DOSA" Or role = "DOFA" Or role = "HOD" Then
                        switchPanel(authority)
                    ElseIf role = "Director" Then
                        switchPanel(Director)
                    ElseIf role = "Faculty" Then
                        switchPanel(faculty)
                    Else
                        switchPanel(student)
                    End If
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

    Sub switchPanel(ByVal mainApp As Form)
        mainApp.Show()
        Me.Hide()
    End Sub

End Class