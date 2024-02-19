Public Class ApplyLeave

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        Dim Conn As New MySqlConnection(My.Settings.connectionString)
        Dim cmd As New MySqlCommand()

        Try
            Conn.Open()
            cmd.Connection = Conn

            cmd.CommandText = "INSERT INTO requests(applicant_email, approver_email, type, from_date, to_date, reason) " &
                "VALUES (@applicant_email, @approver_email, @type, @from_date, @to_date, @reason)"
            Dim applicant_email As String = Environment.GetEnvironmentVariable("userEmail")
            Dim approver_email As String = "dupccse@iitg.ac.in"
            Dim type As String = TextBox1.Text
            Dim from_date As Date = DateTimePicker1.Value
            Dim to_date As Date = DateTimePicker2.Value
            Dim reason As String = TextBox4.Text

            cmd.Parameters.AddWithValue("@applicant_email", applicant_email)
            cmd.Parameters.AddWithValue("@approver_email", approver_email)
            cmd.Parameters.AddWithValue("@type", type)
            cmd.Parameters.AddWithValue("@from_date", from_date)
            cmd.Parameters.AddWithValue("@to_date", to_date)
            cmd.Parameters.AddWithValue("@reason", reason)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Applied Succesfully")

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