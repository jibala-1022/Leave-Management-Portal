Public Class ApproveLeave
    Dim email As String = Environment.GetEnvironmentVariable("userEmail")


    Private Sub ApplyLeavePanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT application_id as ID, applicant_email as Applicant, type as Nature, from_date as 'From Date', to_date as 'To Date'  FROM requests " _
                      & "WHERE approver_email = @email AND status = 'pending' " _
                      & "ORDER BY applied_date DESC"

        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                connection.Open()

                Dim SDA As New MySqlDataAdapter
                Dim dbDataset As New DataTable

                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@email", email)

                SDA.SelectCommand = command
                SDA.Fill(dbDataset)
                DataGridView2.DataSource = dbDataset

                If dbDataset.Rows.Count = 0 Then
                    DataGridView2.Visible = False
                    Label1.Visible = True
                Else
                    Label1.Visible = False
                    ' Display the fetched data in the GroupBox
                    DataGridView2.DataSource = dbDataset
                    'DisplayRequestsInGroupBox(dataTable)
                    DataGridView2.AllowUserToAddRows = False
                    DataGridView2.RowHeadersVisible = False
                    DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                    DataGridView2.ScrollBars = ScrollBars.Vertical
                    Dim newColumn As New DataGridViewButtonColumn()
                    newColumn.Name = ""
                    newColumn.UseColumnTextForButtonValue = True
                    newColumn.Text = "Details"
                    newColumn.DefaultCellStyle.BackColor = Color.CadetBlue
                    newColumn.DefaultCellStyle.SelectionBackColor = Color.CadetBlue
                    newColumn.FlatStyle = FlatStyle.Flat
                    DataGridView2.Columns.Add(newColumn)
                End If

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If e.RowIndex < 0 Then
            Return
        End If

        Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
        RequestDetails.application_id = CInt(row.Cells("ID").Value.ToString())
        RequestDetails.Button1.Visible = True
        RequestDetails.Button2.Visible = True
        Dim role As String = Environment.GetEnvironmentVariable("role")
        If role = "Faculty" Then
            RequestDetails.Show()
        Else
            RequestDetails.Show()
        End If

    End Sub

End Class