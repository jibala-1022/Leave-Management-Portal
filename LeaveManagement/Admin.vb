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

                For Each ctrl As Control In groupDean.Controls
                    If TypeOf ctrl Is TextBox Then
                        Dim textBox As TextBox = DirectCast(ctrl, TextBox)
                        Dim role As String = Convert.ToString(textBox.Tag)
                        command.CommandText = "SELECT faculty_email FROM dean WHERE role = @role"
                        command.Parameters.Clear()
                        command.Parameters.AddWithValue("@role", role)
                        textBox.Text = Convert.ToString(command.ExecuteScalar())
                    End If
                Next

                For Each ctrlGrp As Control In groupDept.Controls
                    If TypeOf ctrlGrp Is GroupBox Then
                        Dim grpBox As GroupBox = DirectCast(ctrlGrp, GroupBox)
                        Dim table As String = Convert.ToString(grpBox.Tag)
                        For Each ctrl As Control In grpBox.Controls
                            If TypeOf ctrl Is TextBox Then
                                Dim textBox As TextBox = DirectCast(ctrl, TextBox)
                                Dim dept As String = Convert.ToString(textBox.Tag)
                                command.CommandText = "SELECT faculty_email FROM " & table & " WHERE department = @dept"
                                command.Parameters.Clear()
                                command.Parameters.AddWithValue("@dept", dept)
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
                        Dim role As String = Convert.ToString(textBox.Tag)
                        command.Parameters.Clear()
                        command.Parameters.AddWithValue("@faculty_email", textBox.Text)
                        command.Parameters.AddWithValue("@role", role)
                        command.CommandText = "SELECT COUNT(*) FROM faculty WHERE email = @faculty_email"
                        If Convert.ToInt32(command.ExecuteScalar()) = 0 Then
                            Throw New Exception("Email " & textBox.Text & " does not exists")
                        End If
                        command.CommandText = "UPDATE dean SET faculty_email = @faculty_email WHERE role = @role"
                        command.ExecuteNonQuery()
                    End If
                Next

                For Each ctrlGrp As Control In groupDept.Controls
                    If TypeOf ctrlGrp Is GroupBox Then
                        Dim grpBox As GroupBox = DirectCast(ctrlGrp, GroupBox)
                        Dim table As String = Convert.ToString(grpBox.Tag)
                        For Each ctrl As Control In grpBox.Controls
                            If TypeOf ctrl Is TextBox Then
                                Dim textBox As TextBox = DirectCast(ctrl, TextBox)
                                Dim dept As String = Convert.ToString(textBox.Tag)
                                command.Parameters.Clear()
                                command.Parameters.AddWithValue("@faculty_email", textBox.Text)
                                command.Parameters.AddWithValue("@dept", dept)
                                command.CommandText = "SELECT COUNT(*) FROM faculty WHERE email = @faculty_email"
                                If Convert.ToInt32(command.ExecuteScalar()) = 0 Then
                                    Throw New Exception("Email " & textBox.Text & " does not exists")
                                End If
                                command.CommandText = "UPDATE " & table & " SET faculty_email = @faculty_email WHERE department = @dept"
                                command.ExecuteNonQuery()
                            End If
                        Next
                    End If
                Next

            Catch ex As MySqlException
                connection.Close()
                MessageBox.Show("Error: " & ex.Message)
            Catch ex As Exception
                connection.Close()
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub


End Class