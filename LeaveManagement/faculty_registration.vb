Public Class faculty_registration
    Private Function AreFieldsEmpty() As Boolean
        ' Array to hold all six textboxes
        Dim textBoxes() As TextBox = {TextBox1, TextBox3, TextBox2}

        ' Array to hold all  comboboxes
        Dim comboBoxes() As ComboBox = {ComboBox1}

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
        ' Validate Email
        Dim emailPattern As String = "^[a-zA-Z0-9._%+-]+@iitg\.ac\.in$"
        If Not System.Text.RegularExpressions.Regex.IsMatch(TextBox2.Text, emailPattern) Then
            MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Validate Phone Number
        If TextBox3.Text.Length <> 10 Then
            MessageBox.Show("Please enter a valid 10-digit phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If


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

            cmd.CommandText = "INSERT INTO faculty(email, name, department, phone_number) " &
                "VALUES (@email, @name, @department, @phone_number)"

            cmd.Parameters.AddWithValue("@email", TextBox2.Text)
            cmd.Parameters.AddWithValue("@name", TextBox1.Text)
            cmd.Parameters.AddWithValue("@department", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@phone_number", TextBox3.Text)

            cmd.ExecuteNonQuery()

            MessageBox.Show("Applied Succesfully")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

End Class