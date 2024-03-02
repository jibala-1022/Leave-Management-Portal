Public Class ApproveLeave
    Dim email As String = Environment.GetEnvironmentVariable("userEmail")


    Private Sub ApplyLeavePanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM requests " _
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

        RequestDetails.application_id = CInt(row.Cells("application_id").Value.ToString())
        RequestDetails.Show()
    End Sub


End Class