Public Class ApplyLeave

    Public applicant_email As String = Environment.GetEnvironmentVariable("userEmail")
    Public approver_email As String = Environment.GetEnvironmentVariable("approverEmail")
    Public role As String = Environment.GetEnvironmentVariable("role")

    ' Function to check if a date is not in the past
    Private Function IsDateValid(ByVal dateToCheck As DateTime) As Boolean
        Return dateToCheck >= DateTime.Today
    End Function

    ' Function to count the number of weekdays between two dates
    Private Function CountWeekdays(ByVal startDate As DateTime, ByVal endDate As DateTime) As Integer
        Dim count As Integer = 0
        Dim currentDate As DateTime = startDate

        While currentDate <= endDate
            If currentDate.DayOfWeek <> DayOfWeek.Saturday AndAlso currentDate.DayOfWeek <> DayOfWeek.Sunday Then
                count += 1
            End If
            currentDate = currentDate.AddDays(1)
        End While

        Return count
    End Function

    'Function to check if applicant has any overlapping requests
    Private Function HasOverlappingRequests(ByVal fromDate As Date, ByVal toDate As Date) As Boolean

        ' Query to check for overlapping requests
        Dim query As String = "SELECT COUNT(*) FROM requests WHERE status = 'pending' AND applicant_email = @applicant_email " &
                              "AND ((from_date <= @to_date AND to_date >= @from_date) OR " &
                              "(from_date >= @from_date AND to_date <= @to_date))"

        Try
            Using connection As New MySqlConnection(My.Settings.connectionString)
                connection.Open()
                Using cmd As New MySqlCommand(query, connection)
                    ' Add parameters to the query
                    cmd.Parameters.AddWithValue("@from_date", fromDate)
                    cmd.Parameters.AddWithValue("@to_date", toDate)
                    cmd.Parameters.AddWithValue("@applicant_email", applicant_email)

                    ' Execute the query
                    Dim overlappingRequestsCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    ' Return true if there are overlapping requests, false otherwise
                    Return overlappingRequestsCount > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Function LeavesLeft(ByVal leaveType As String) As Integer
        Dim leaveColumn As String = ""
        Dim table As String = ""

        'set the appropiate credential tables based on role
        Select Case role
            Case "Director"
                table = "director"
            Case "Staff"
                table = "staff"
            Case "Faculty"
                table = "faculty"
            Case Else
                table = "students"
                ' Handle other cases if necessary
        End Select

        ' Set the appropriate column based on the leave type
        Select Case leaveType
            Case "Medical"
                leaveColumn = "medical"
            Case "Casual"
                leaveColumn = "casual"
            Case "Academic"
                leaveColumn = "academic"
            Case "On Duty"
                leaveColumn = "on_duty"
            Case "Maternity"
                leaveColumn = "maternity"
            Case Else
                ' Handle other cases if necessary
        End Select

        ' Query to check for the number of leaves left
        Dim query As String = "SELECT " & leaveColumn & " FROM " & table & " WHERE email = @applicant_email "

        Try
            Using connection As New MySqlConnection(My.Settings.connectionString)
                connection.Open()
                Using cmd As New MySqlCommand(query, connection)
                    ' Add parameters to the query
                    ' cmd.Parameters.AddWithValue("@leavetype", leaveColumn)
                    cmd.Parameters.AddWithValue("@applicant_email", applicant_email)
                    Console.WriteLine(leaveColumn)
                    Console.WriteLine(applicant_email)
                    Console.WriteLine(leaveType)
                    ' Execute the query
                    Dim leaves_Left As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    ' Return the number of leaves left
                    Return leaves_Left
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function


    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim type As String = ComboBox1.Text
        Dim reason As String = TextBox4.Text
        Dim from_date As Date = DateTimePicker1.Value
        Dim to_date As Date = DateTimePicker2.Value
        Dim numberOfLeaves As Integer = CountWeekdays(from_date, to_date)
        Dim leaves_left As Integer = LeavesLeft(type)

        ' check if any fields are empty
        If String.IsNullOrEmpty(type) Or String.IsNullOrEmpty(reason) Then
            MessageBox.Show("Please enter the details to proceed!")
            Return
        End If

        ' Check if both dates are valid
        If Not (to_date >= from_date AndAlso from_date >= DateTime.Today AndAlso to_date >= DateTime.Today) Then
            MessageBox.Show("Please select valid dates. 'To date' should be after 'from date' and both dates should not be in the past.")
            Return
        End If

        If numberOfLeaves < 1 Then
            MessageBox.Show("The dates you are applying your leave for are holidays!!")
            Return
        End If

        If HasOverlappingRequests(from_date, to_date) Then
            MessageBox.Show("The selected leave dates overlap with existing pending requests. Please adjust your leave dates.")
            Return
        End If

        If numberOfLeaves > leaves_left Then
            MessageBox.Show("WARNING : Insufficient number of leaves!" & Environment.NewLine & type & " Leaves left : " & leaves_left, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Using Conn As New MySqlConnection(My.Settings.connectionString)
            Dim cmd As New MySqlCommand()
            Try
                Conn.Open()
                cmd.Connection = Conn
                Dim hostel As String = ""

                If role = "B.Tech" Or role = "M.Tech" Or role = "Ph.D" Then
                    cmd.CommandText = "SELECT hostel FROM students WHERE email = @applicant_email"
                    cmd.Parameters.AddWithValue("@applicant_email", applicant_email)
                    hostel = Convert.ToString(cmd.ExecuteScalar())
                End If

                cmd.CommandText = "INSERT INTO requests(applicant_email, approver_email, type, from_date, to_date, reason, hostel) " &
                    "VALUES (@applicant_email, @approver_email, @type, @from_date, @to_date, @reason, @hostel)"

                cmd.Parameters.AddWithValue("@approver_email", approver_email)
                cmd.Parameters.AddWithValue("@type", type)
                cmd.Parameters.AddWithValue("@from_date", from_date)
                cmd.Parameters.AddWithValue("@to_date", to_date)
                cmd.Parameters.AddWithValue("@reason", reason)
                cmd.Parameters.AddWithValue("@hostel", hostel)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Leave Applied Succesfully")

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Using
    End Sub

    Private Sub ApplyLeave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class