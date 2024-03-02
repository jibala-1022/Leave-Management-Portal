Public Class Admin

    Private Sub Admin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Details()
    End Sub

    Private Sub Load_Details()
        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                connection.Open()
                Dim command As New MySqlCommand()
                command.Connection = connection

                command.CommandText = "SELECT faculty_email FROM dean " &
                    "WHERE role = 'dosa'"
                txtDosa.Text = Convert.ToString(command.ExecuteScalar())

                command.CommandText = "SELECT faculty_email FROM dean " &
                    "WHERE role = 'dofa'"
                txtDofa.Text = Convert.ToString(command.ExecuteScalar())

                command.CommandText = "SELECT faculty_email FROM hod " &
                    "WHERE department = 'CSE'"
                txtHodCse.Text = Convert.ToString(command.ExecuteScalar())

                command.CommandText = "SELECT faculty_email FROM dupc " &
                    "WHERE department = 'CSE'"
                txtDupcCse.Text = Convert.ToString(command.ExecuteScalar())

                command.CommandText = "SELECT faculty_email FROM dppc " &
                    "WHERE department = 'CSE'"
                txtDppcCse.Text = Convert.ToString(command.ExecuteScalar())

            Catch ex As MySqlException
                connection.Close()
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Update.Click
        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                connection.Open()
                Dim command As New MySqlCommand()
                command.Connection = connection

                command.CommandText =
                    "UPDATE dean " &
                    "SET faculty_email = @dosa " &
                    "WHERE role = 'dosa';" &
                    "UPDATE dean " &
                    "SET faculty_email = @dofa " &
                    "WHERE role = 'dofa';" &
                    "UPDATE hod " &
                    "SET faculty_email = @hodcse " &
                    "WHERE department = 'CSE';" &
                    "UPDATE dupc " &
                    "SET faculty_email = @dupccse " &
                    "WHERE department = 'CSE';" &
                    "UPDATE dppc " &
                    "SET faculty_email = @dppccse " &
                    "WHERE department = 'CSE';"
                command.Parameters.AddWithValue("@dosa", txtDosa.Text)
                command.Parameters.AddWithValue("@dofa", txtDofa.Text)
                command.Parameters.AddWithValue("@hodcse", txtHodCse.Text)
                command.Parameters.AddWithValue("@dupccse", txtDupcCse.Text)
                command.Parameters.AddWithValue("@dppccse", txtDppcCse.Text)

                command.ExecuteNonQuery()

            Catch ex As MySqlException
                connection.Close()
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub
End Class