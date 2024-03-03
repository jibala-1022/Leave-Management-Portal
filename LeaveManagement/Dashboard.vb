Public Class Dashboard

    Private Sub Dashboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim UserEmail As String = Environment.GetEnvironmentVariable("userEmail")

        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                connection.Open()

                Dim query As String = ""
                Dim role As String = Environment.GetEnvironmentVariable("role")

                If role = "Faculty" Then
                    query = "SELECT * FROM faculty WHERE email = @email"
                Else
                    query = "SELECT * FROM students WHERE email = @email"
                End If

                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@email", UserEmail)

                Dim casual As Integer
                Dim medical As Integer
                Dim academic As Integer
                Dim on_duty As Integer
                Dim maternal As Integer

                Dim reader As MySqlDataReader = command.ExecuteReader()
                If reader.Read() Then
                    casual = reader.GetUInt32("casual")
                    medical = reader.GetUInt32("medical")
                    academic = reader.GetUInt32("academic")
                    on_duty = reader.GetUInt32("on_duty")
                    maternal = reader.GetUInt32("maternity")
                End If
                reader.Close()
                Label2.Text = casual.ToString
                Label4.Text = academic.ToString
                Label6.Text = medical.ToString
                Label8.Text = on_duty.ToString
                Label9.Text = maternal.ToString

            Catch ex As MySqlException
                connection.Close()
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using

        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try

                Dim query As String = "SELECT application_id, type as Nature, from_date, to_date, reason, status FROM requests WHERE applicant_email = @email AND status = 'pending'"

                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@email", UserEmail)

                Dim dataAdapter As New MySqlDataAdapter(command)

                Dim dataTable As New DataTable
                dataAdapter.Fill(dataTable)
                data_active_requests.DataSource = dataTable
                If dataTable.Rows.Count = 0 Then
                    Dim nodatalabel As New Label()
                    nodatalabel.Text = "No Pending Leaves!!"
                    nodatalabel.AutoSize = True
                    nodatalabel.ForeColor = Color.Green
                    nodatalabel.Font = New Font(nodatalabel.Font.FontFamily, 10)
                    nodatalabel.Padding = New Padding(5)
                    nodatalabel.TextAlign = ContentAlignment.MiddleCenter
                    data_active_requests.Visible = True
                    Me.Controls.Add(nodatalabel)
                    nodatalabel.Top = Panel1.Top + 30
                    nodatalabel.Left = data_active_requests.Left
                Else
                    ' Display the fetched data in the GroupBox
                    data_active_requests.DataSource = dataTable
                    'DisplayRequestsInGroupBox(dataTable)
                    data_active_requests.AllowUserToAddRows = False
                    data_active_requests.RowHeadersVisible = False
                    data_active_requests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    data_active_requests.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                    data_active_requests.ScrollBars = ScrollBars.Vertical
                    Dim newColumn As New DataGridViewButtonColumn()
                    newColumn.Name = "Cancel Leave"
                    newColumn.UseColumnTextForButtonValue = True
                    newColumn.Text = "Cancel"
                    newColumn.DefaultCellStyle.BackColor = Color.Crimson
                    newColumn.DefaultCellStyle.SelectionBackColor = Color.Crimson
                    newColumn.FlatStyle = FlatStyle.Flat
                    data_active_requests.Columns.Add(newColumn)
                End If

            Catch ex As MySqlException
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub data_active_request_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles data_active_requests.CellContentClick
        If e.RowIndex < 0 Then
            Return
        End If

        Dim row As DataGridViewRow = data_active_requests.Rows(e.RowIndex)
        RequestDetails.application_id = CInt(row.Cells("application_id").Value.ToString())
        RequestDetails.Button3.Visible = True
        Dim role As String = Environment.GetEnvironmentVariable("role")
        If role = "Faculty" Then
            faculty.switchPanel(RequestDetails)
        Else
            student.switchPanel(RequestDetails)
        End If
    End Sub


End Class