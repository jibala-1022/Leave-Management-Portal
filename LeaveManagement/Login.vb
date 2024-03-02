Public Class Login

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim userEmail As String = TextBox1.Text

        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                connection.Open()

                Dim query As String = "SELECT role FROM authentication " &
                    "WHERE email = @email AND passwd = SHA2(CONCAT(@email, @password), 256)"

                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@email", TextBox1.Text)
                command.Parameters.AddWithValue("@password", TextBox2.Text)

                Dim role As String = Convert.ToString(command.ExecuteScalar())
                Console.WriteLine(role)

                If role = "" Then
                    MessageBox.Show("Invalid email or password. Please try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                Dim approver As String

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
                        "(select on_leave from faculty where faculty.email = hod.faculty_email) = 0"
                        approver = Convert.ToString(command.ExecuteScalar())
                    End If

                    If approver = "" Then
                        command.CommandText = "select email from dean " &
                        "where role = 'dofa' and " &
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


                Dim mainApp As New MainApplication()
                Environment.SetEnvironmentVariable("userEmail", userEmail)
                Environment.SetEnvironmentVariable("role", role)
                mainApp.Show()
                Me.Hide()

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub MyLeaves_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class