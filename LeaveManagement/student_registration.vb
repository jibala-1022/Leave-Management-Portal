Public Class student_registration
    Private Function AreFieldsEmpty() As Boolean
        ' Array to hold all six textboxes
        Dim textBoxes() As TextBox = {TextBox1, TextBox6, TextBox3, TextBox4, TextBox2, TextBox5}

        ' Array to hold all three comboboxes
        Dim comboBoxes() As ComboBox = {ComboBox1, ComboBox2, ComboBox3}

        ' Loop through each textbox to check if it's empty
        For Each textbox As TextBox In textBoxes
            If String.IsNullOrWhiteSpace(textbox.Text) Then
                MessageBox.Show("Please fill all fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return True ' If any textbox is empty, return true
            End If
        Next

        ' Loop through each combobox to check if it's empty
        For Each comboBox As ComboBox In comboBoxes
            If comboBox.SelectedItem Is Nothing Then
                MessageBox.Show("Please fill all fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return True ' If any combobox is empty, return true
            End If
        Next

        Return False ' Return false if all textboxes and comboboxes are filled
    End Function


    Private Sub ValidateInputs()

        ' Validate Roll Number
        If TextBox6.Text.Length <> 9 Then
            MessageBox.Show("Please enter a valid 9-digit roll number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Validate Email
        Dim emailPattern As String = "^[a-zA-Z0-9._%+-]+@iitg\.ac\.in$"
        If Not System.Text.RegularExpressions.Regex.IsMatch(TextBox5.Text, emailPattern) Then
            MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not IsNumeric(TextBox3.Text) Then
            MessageBox.Show("Joining year must be a numeric value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If CInt(TextBox3.Text) >= DateTime.Now.Year Then
            MessageBox.Show("Joining year must be less than or equalto current year.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Validate Phone Number
        If TextBox4.Text.Length <> 10 Then
            MessageBox.Show("Please enter a valid 10-digit phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' If all validations pass, you can proceed with other operations
        ' For example, saving the data to a database, processing, etc.
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If AreFieldsEmpty() Then
            Return
        End If

        ValidateInputs()

        Dim Conn As New MySqlConnection(My.Settings.connectionString)
        Dim cmd As New MySqlCommand()

        Try
            Conn.Open()
            cmd.Connection = Conn

            cmd.CommandText = "INSERT INTO students(email, roll_number, name, department, course, year, joining_year, phone_number, hostel, room) " &
                "VALUES (@email, @roll_number, @name, @department, @course, @year, @joining_year, @phone_number, @hostel, @room)"

            ' Add parameters to the query to filter by user email
            cmd.Parameters.AddWithValue("@email", TextBox5.Text)
            cmd.Parameters.AddWithValue("@roll_number", TextBox6.Text)
            cmd.Parameters.AddWithValue("@name", TextBox1.Text)
            cmd.Parameters.AddWithValue("@department", ComboBox3.Text)
            cmd.Parameters.AddWithValue("@course", ComboBox2.Text)
            cmd.Parameters.AddWithValue("@year", DateTime.Now.Year - CInt(TextBox3.Text))
            cmd.Parameters.AddWithValue("@joining_year", TextBox3.Text)
            cmd.Parameters.AddWithValue("@phone_number", TextBox4.Text)
            cmd.Parameters.AddWithValue("@hostel", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@room", TextBox2.Text)

            cmd.ExecuteNonQuery()


            MessageBox.Show("Applied Succesfully")

        Catch ex As Exception

        End Try
    End Sub
End Class