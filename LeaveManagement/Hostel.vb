Public Class Hostel

    Private Sub comboHostels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboHostels.SelectedIndexChanged
        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                Dim command As New MySqlCommand()
                command.Connection = connection

                If comboHostels.Text = "All" Then
                    command.CommandText = "SELECT * FROM requests " &
                    "WHERE"
                End If

                Dim dataAdapter As New MySqlDataAdapter(command)

                Dim dataTable As New DataTable
                dataAdapter.Fill(dataTable)

                DataGridView1.DataSource = dataTable

            Catch ex As MySqlException
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub comboStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboStatus.SelectedIndexChanged

    End Sub
End Class