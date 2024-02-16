Imports MySql.Data.MySqlClient

Public Class Form1
    Dim connectionString As String = "server=172.16.114.244;user id=admin;Password=nimda;database=leave_management;sslmode=none"

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Define your SQL query to create the table
        Dim createTableQuery As String = "CREATE TABLE IF NOT EXISTS hey(ID INT PRIMARY KEY AUTO_INCREMENT, Name VARCHAR(255), Age INT)"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            Try
                ' Open the database connection
                connection.Open()

                ' Create a MySqlCommand object with the SQL query and connection
                Using command As New MySqlCommand(createTableQuery, connection)
                    ' Execute the SQL command to create the table
                    command.ExecuteNonQuery()
                    MessageBox.Show("Table created successfully")
                End Using
            Catch ex As Exception
                MessageBox.Show("Error creating table: " & ex.Message)
            End Try
        End Using
    End Sub

End Class