Public Class Hostel

    Private Sub comboHostel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboHostel.SelectedIndexChanged
        Load_Details()
    End Sub

    Private Sub comboStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboStatus.SelectedIndexChanged
        Load_Details()
    End Sub

    Private Sub Hostel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Details()
    End Sub

    Private Sub Load_Details()
        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                Dim command As New MySqlCommand()
                command.Connection = connection

                command.CommandText = "SELECT * FROM requests "

                If comboHostel.Text = "All" Then
                    If comboStatus.Text = "All" Then
                        command.CommandText &= ""
                    Else
                        command.CommandText &= "WHERE status = @status "
                    End If
                Else
                    If comboStatus.Text = "All" Then
                        command.CommandText &= "WHERE hostel = @hostel "
                    Else
                        command.CommandText &= "WHERE hostel = @hostel AND status = @status "
                    End If
                End If

                command.CommandText &= "ORDER BY from_date DESC, to_date DESC "

                command.Parameters.AddWithValue("@hostel", comboHostel.Text)
                command.Parameters.AddWithValue("@status", comboStatus.Text)

                Dim dataAdapter As New MySqlDataAdapter(command)

                Dim dataTable As New DataTable
                dataAdapter.Fill(dataTable)

                DataGridView1.DataSource = dataTable

            Catch ex As MySqlException
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.ShowDialog()

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim imagebmp As New Bitmap(DataGridView1.Width, DataGridView1.Height)
        DataGridView1.DrawToBitmap(imagebmp, New Rectangle(0, 0, DataGridView1.Width, DataGridView1.Height))
        e.Graphics.DrawImage(imagebmp, 0, 0)
    End Sub
End Class