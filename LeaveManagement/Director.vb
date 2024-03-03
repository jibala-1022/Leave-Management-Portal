Public Class Director

    Private Sub Dashboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel2.Location = New Point((Me.ClientSize.Width - Panel2.Width) \ 2, (Me.ClientSize.Height - Panel2.Height) \ 2)
    End Sub

    Sub switchPanel(ByVal panel As Form)
        Panel1.Controls.Clear()
        panel.TopLevel = False
        panel.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Panel1.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Button3.BackColor = Color.SteelBlue
        Button6.BackColor = Color.DodgerBlue
        Button2.BackColor = Color.SteelBlue
        Button4.BackColor = Color.SteelBlue
        switchPanel(MyLeaves)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Button3.BackColor = Color.SteelBlue
        Button6.BackColor = Color.SteelBlue
        Button2.BackColor = Color.DodgerBlue
        Button4.BackColor = Color.SteelBlue
        switchPanel(ApproveLeave)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button3.BackColor = Color.SteelBlue
        Button6.BackColor = Color.SteelBlue
        Button2.BackColor = Color.SteelBlue
        Button4.BackColor = Color.DodgerBlue
        switchPanel(ApplyLeave)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button3.BackColor = Color.DodgerBlue
        Button6.BackColor = Color.SteelBlue
        Button2.BackColor = Color.SteelBlue
        Button4.BackColor = Color.SteelBlue
        switchPanel(Dashboard)
    End Sub

    Private Sub user_profile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles user_profile.Click
        Button3.BackColor = Color.SteelBlue
        Button6.BackColor = Color.SteelBlue
        Button2.BackColor = Color.SteelBlue
        Button4.BackColor = Color.SteelBlue
        'Dim userProfile As New UserProfile()
        'userProfile.Show()
        switchPanel(UserProfile)
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
        ' Calculate the new location of the panel when the form is resized
        Panel1.Location = New Point((Me.ClientSize.Width - Panel1.Width) \ 2, (Me.ClientSize.Height - Panel1.Height) \ 2)
    End Sub

    Private Sub Dashboard_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
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
End Class