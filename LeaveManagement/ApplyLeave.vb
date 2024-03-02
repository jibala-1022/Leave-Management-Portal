Public Class ApplyLeave

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

    Private Function HasOverlappingRequests(ByVal fromDate As Date, ByVal toDate As Date) As Boolean
        ' Query to check for overlapping requests
        Dim query As String = "SELECT COUNT(*) FROM requests WHERE status = 'pending' AND " &
                              "((from_date <= @to_date AND to_date >= @from_date) OR " &
                              "(from_date >= @from_date AND to_date <= @to_date))"

        Using connection As New MySqlConnection(My.Settings.connectionString)
            Using cmd As New MySqlCommand(query, connection)
                ' Add parameters to the query
                cmd.Parameters.AddWithValue("@from_date", fromDate)
                cmd.Parameters.AddWithValue("@to_date", toDate)

                connection.Open()

                ' Execute the query
                Dim overlappingRequestsCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                ' Return true if there are overlapping requests, false otherwise
                Return overlappingRequestsCount > 0
            End Using
        End Using
    End Function

    Public Function LeavesLeft() As Integer

        Dim applicant_email As String = Environment.GetEnvironmentVariable("userEmail")

        ' Query to check for overlapping requests
        Dim query As String = "SELECT COUNT(*) FROM students WHERE email = @applicant_email"

        Using connection As New MySqlConnection(My.Settings.connectionString)
            Using cmd As New MySqlCommand(query, connection)
                ' Add parameters to the query
                cmd.Parameters.AddWithValue("@applicant_email", applicant_email)
                connection.Open()

                ' Execute the query
                Dim Leaves_left As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                ' Return number of leaves left
                Return Leaves_left
            End Using
        End Using
    End Function

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim type As String = TextBox1.Text
        Dim reason As String = TextBox4.Text
        Dim from_date As Date = DateTimePicker1.Value
        Dim to_date As Date = DateTimePicker2.Value
        Dim numberOfLeaves As Integer = CountWeekdays(from_date, to_date)
        Dim leaves_left As Integer = LeavesLeft()

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

        If numberOfLeaves > LeavesLeft() Then
            MessageBox.Show("Insufficient number of leaves!" & Environment.NewLine & "Leaves left : " & leaves_left)
        ElseIf leaves_left <= 10 Then
            MessageBox.Show("Warning: Only " & LeavesLeft() & " leaves are left!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Dim Conn As New MySqlConnection(My.Settings.connectionString)
        Dim cmd As New MySqlCommand()
        Try
            Conn.Open()
            cmd.Connection = Conn
            cmd.CommandText = "INSERT INTO requests(applicant_email, approver_email, type, from_date, to_date, reason) " &
                "VALUES (@applicant_email, @approver_email, @type, @from_date, @to_date, @reason)"
            Dim applicant_email As String = Environment.GetEnvironmentVariable("userEmail")
            Dim approver_email As String = "dupccse@iitg.ac.in"

            cmd.Parameters.AddWithValue("@applicant_email", applicant_email)
            cmd.Parameters.AddWithValue("@approver_email", approver_email)
            cmd.Parameters.AddWithValue("@type", type)
            cmd.Parameters.AddWithValue("@from_date", from_date)
            cmd.Parameters.AddWithValue("@to_date", to_date)
            cmd.Parameters.AddWithValue("@reason", reason)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Leave Applied Succesfully")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ApplyLeave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


End Class