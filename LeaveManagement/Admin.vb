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

                Dim role As String = ""
                Dim table As String = ""
                Dim dept As String = ""
                'command.Parameters.AddWithValue("@role", role)
                'command.Parameters.AddWithValue("@table", table)
                'command.Parameters.AddWithValue("@dept", dept)

                For Each ctrl As Control In groupDean.Controls
                    If TypeOf ctrl Is TextBox Then
                        Dim textBox As TextBox = DirectCast(ctrl, TextBox)
                        role = Convert.ToString(textBox.Tag)
                        command.CommandText = "SELECT faculty_email FROM dean WHERE role = @role"
                        command.Parameters.AddWithValue("@role", role)
                        textBox.Text = Convert.ToString(command.ExecuteScalar())
                    End If
                Next

                For Each ctrlGrp As Control In groupDept.Controls
                    If TypeOf ctrlGrp Is GroupBox Then
                        Dim grpBox As GroupBox = DirectCast(ctrlGrp, GroupBox)
                        table = Convert.ToString(grpBox.Tag)
                        For Each ctrl As Control In grpBox.Controls
                            If TypeOf ctrl Is TextBox Then
                                Dim textBox As TextBox = DirectCast(ctrl, TextBox)
                                dept = Convert.ToString(textBox.Tag)
                                command.CommandText = "SELECT faculty_email FROM @table WHERE department = @dept"
                                command.Parameters.AddWithValue("@table", table)
                                command.Parameters.AddWithValue("@department", dept)
                                textBox.Text = Convert.ToString(command.ExecuteScalar())
                            End If
                        Next
                    End If
                Next

            Catch ex As MySqlException
                connection.Close()
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Change_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Change.Click
        Using connection As New MySqlConnection(My.Settings.connectionString)
            Try
                connection.Open()
                Dim command As New MySqlCommand()
                command.Connection = connection

                For Each ctrl As Control In groupDean.Controls
                    If TypeOf ctrl Is TextBox Then
                        Dim textBox As TextBox = DirectCast(ctrl, TextBox)
                        Dim role = Convert.ToString(textBox.Tag)
                        command.CommandText = "UPDATE dean SET faculty_email FROM dean WHERE role = @role"
                        command.Parameters.AddWithValue("@role", role)
                        textBox.Text = Convert.ToString(command.ExecuteScalar())
                    End If
                Next

                For Each ctrl As Control In groupHOD.Controls
                    If TypeOf ctrl Is TextBox Then
                        Dim textBox As TextBox = DirectCast(ctrl, TextBox)
                        Dim department = Convert.ToString(textBox.Tag)
                        command.CommandText = "SELECT faculty_email FROM hod WHERE department = @department"
                        command.Parameters.AddWithValue("@department", department)
                        textBox.Text = Convert.ToString(command.ExecuteScalar())
                    End If
                Next

                For Each ctrl As Control In groupDUPC.Controls
                    If TypeOf ctrl Is TextBox Then
                        Dim textBox As TextBox = DirectCast(ctrl, TextBox)
                        Dim department = Convert.ToString(textBox.Tag)
                        command.CommandText = "SELECT faculty_email FROM dupc WHERE department = @department"
                        command.Parameters.AddWithValue("@department", department)
                        textBox.Text = Convert.ToString(command.ExecuteScalar())
                    End If
                Next

                For Each ctrl As Control In groupDPPC.Controls
                    If TypeOf ctrl Is TextBox Then
                        Dim textBox As TextBox = DirectCast(ctrl, TextBox)
                        Dim department = Convert.ToString(textBox.Tag)
                        command.CommandText = "SELECT faculty_email FROM dppc WHERE department = @department"
                        command.Parameters.AddWithValue("@department", department)
                        textBox.Text = Convert.ToString(command.ExecuteScalar())
                    End If
                Next

                command.ExecuteNonQuery()

            Catch ex As MySqlException
                connection.Close()
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub


End Class