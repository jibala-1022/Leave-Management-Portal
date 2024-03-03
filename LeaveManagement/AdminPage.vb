Public Class AdminPage

    Private Sub AdminPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        switchPanel(Hostel)
    End Sub

    Sub switchPanel(ByVal panel As Form)
        Panel1.Controls.Clear()
        panel.TopLevel = False
        panel.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Panel1.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button3.BackColor = Color.DodgerBlue
        Button2.BackColor = Color.SteelBlue

        switchPanel(Hostel)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button2.BackColor = Color.DodgerBlue
        Button3.BackColor = Color.SteelBlue
        Dim admin As Admin = New Admin()
        switchPanel(admin)
    End Sub

    Private Sub Admin_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Ask for confirmation before logging out
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Check if the user confirmed the logout
        If result = DialogResult.Yes Then
            ' Close the main application form
            Me.Hide()

            ' Open the login form
            Dim loginForm As New Login()
            loginForm.Show()
        End If
    End Sub

    Private Sub AdminPage_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
        ' Calculate the new location of the panel when the form is resized
        Panel2.Location = New Point((Me.ClientSize.Width - Panel2.Width) \ 2, (Me.ClientSize.Height - Panel2.Height) \ 2)
    End Sub
End Class