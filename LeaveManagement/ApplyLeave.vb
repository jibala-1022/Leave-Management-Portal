Imports MySql.Data.MySqlClient

Public Class ApplyLeave

    Dim email As String = "dupccse@iitg.ac.in"

    Private Sub ApplyLeave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim query As String = "select * from requests where approver_email = @email and status = 'pending'"

        Dim connectionString As String = "server=172.16.114.244;userid=admin;Password=nimda;database=leave_management;sslmode=none"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                Dim SDA As New MySqlDataAdapter
                Dim dbDataset As New DataTable

                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@email", email)

                SDA.SelectCommand = command
                SDA.Fill(dbDataset)
                DataGridView1.DataSource = dbDataset

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex < 0 Then
            Return
        End If

        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        RequestInfo.application_id = CInt(row.Cells("application_id").Value.ToString())
        RequestInfo.Show()

    End Sub
End Class