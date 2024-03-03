Public Class HostelPage

    Private formLoaded As Boolean = False

    Private Function getHostelName() As String
        Dim hostelEmail As String = Environment.GetEnvironmentVariable("userEmail")
        Dim hostel As String = ""
        'set the appropiate credential tables based on role
        Select Case hostelEmail
            Case "lohit_off@iitg.ac.in"
                hostel = "Lohit"
            Case "brahmaputra_off@iitg.ac.in"
                hostel = "Brahmaputra"
            Case "dihing_off@iitg.ac.in"
                hostel = "Dihing"
            Case "disang_off@iitg.ac.in"
                hostel = "Disang"
            Case "kameng_off@iitg.ac.in"
                hostel = "Brahmaputra"
            Case "kapili_off@iitg.ac.in"
                hostel = "Dihing"
            Case "manas_off@iitg.ac.in"
                hostel = "Manas"
            Case "married_scholars_off@iitg.ac.in"
                hostel = "Married Scholars"
            Case "siang_off@iitg.ac.in"
                hostel = "Siang"
            Case Else
                hostel = "Umiam"
                ' Handle other cases if necessary
        End Select

        Return hostel
    End Function

    Private Sub comboFilters_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If formLoaded Then
            Load_Details()
        End If
    End Sub

    Private Sub HostelPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Details()
        formLoaded = True

    End Sub

    Private Sub HostelPage_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
        ' Calculate the new location of the panel when the form is resized
        Panel2.Location = New Point((Me.ClientSize.Width - Panel2.Width) \ 2, (Me.ClientSize.Height - Panel2.Height) \ 2)
    End Sub

     Private Sub Load_Details()
        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                Dim command As New MySqlCommand()
                command.Connection = connection

                Dim hostel As String = getHostelName()
                user_profile.Text = hostel

                command.CommandText = "SELECT * FROM requests "

                Dim status = comboStatus.Text
                Dim type = comboType.Text

                Dim dateRange = comboDateRange.Text
                Dim conditionList As New List(Of String)

                If hostel <> "" And hostel <> "All" Then
                    conditionList.Add("( (SELECT hostel FROM students WHERE students.email = requests.applicant_email) = @hostel )")
                End If

                If status <> "" And status <> "All" Then
                    If status = "Pending" Then
                        status = "pending"
                    ElseIf status = "Approved" Then
                        status = "approved"
                    ElseIf status = "Rejected" Then
                        status = "rejected"
                    End If

                    conditionList.Add("( status = @status )")
                End If

                If type <> "" And type <> "All" Then
                    If type = "Casual Leave" Then
                        type = "casual"
                    ElseIf type = "Medical Leave" Then
                        type = "medical"
                    ElseIf type = "Academic Leave" Then
                        type = "academic"
                    ElseIf type = "On Duty Leave" Then
                        type = "on_duty"
                    ElseIf type = "Maternity Leave" Then
                        type = "maternity"
                    End If

                    conditionList.Add("( type = @type )")
                End If

                If dateRange <> "" And dateRange <> "All" Then
                    Dim condition As String = ""
                    If dateRange = "This Year" Then
                        condition = "( YEAR(CURDATE()) BETWEEN YEAR(from_date) AND YEAR(to_date) )"
                    ElseIf dateRange = "This Month" Then
                        condition = "( MONTH(CURDATE()) BETWEEN MONTH(from_date) AND MONTH(to_date) ) AND " &
                            "( YEAR(CURDATE()) BETWEEN YEAR(from_date) AND YEAR(to_date) )"
                    ElseIf dateRange = "This Week" Then
                        condition = "( WEEK(CURDATE()) BETWEEN WEEK(from_date) AND WEEK(to_date) ) AND " &
                            "( MONTH(CURDATE()) BETWEEN MONTH(from_date) AND MONTH(to_date) ) AND " &
                            "( YEAR(CURDATE()) BETWEEN YEAR(from_date) AND YEAR(to_date) )"
                    ElseIf dateRange = "Today" Then
                        condition = "( CURDATE() BETWEEN from_date AND to_date )"
                    End If

                    conditionList.Add(condition)
                End If

                If conditionList.Count <> 0 Then
                    command.CommandText &= "WHERE " & conditionList(0) & " "
                    For index As Integer = 1 To conditionList.Count - 1
                        command.CommandText &= "AND " & conditionList(index) & " "
                    Next
                End If


                command.CommandText &= "ORDER BY from_date DESC, to_date DESC "

                command.Parameters.AddWithValue("@hostel", hostel)
                command.Parameters.AddWithValue("@status", comboStatus.Text)
                command.Parameters.AddWithValue("@type", type)

                Dim dataAdapter As New MySqlDataAdapter(command)

                Dim dataTable As New DataTable
                dataAdapter.Fill(dataTable)

                DataGridView1.DataSource = dataTable
                DataGridView1.AllowUserToAddRows = False
                DataGridView1.RowHeadersVisible = False
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView1.ScrollBars = ScrollBars.Vertical

            Catch ex As MySqlException
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.ShowDialog()

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim imagebmp As New Bitmap(DataGridView1.Width, DataGridView1.Height)
        DataGridView1.DrawToBitmap(imagebmp, New Rectangle(0, 0, DataGridView1.Width, DataGridView1.Height))
        e.Graphics.DrawImage(imagebmp, 0, 0)
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Dashboard_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' Ask for confirmation before logging out
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Check if the user confirmed the logout
        If result = DialogResult.Yes Then
            ' Close the main application form
            Me.Hide()

            ' Open the login form
            Dim loginForm As New Login()
            loginForm.Show()
        End If
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class