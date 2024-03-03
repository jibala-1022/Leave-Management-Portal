Public Class Director

    Private Sub Dashboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel2.Location = New Point((Me.ClientSize.Width - Panel2.Width) \ 2, (Me.ClientSize.Height - Panel2.Height) \ 2)
        switchPanel(Dashboard_authority)
    End Sub

    Sub switchPanel(ByVal panel As Form)
        Panel1.Controls.Clear()
        panel.TopLevel = False
        panel.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Panel1.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles my_leaves.Click
        dashboard_but.BackColor = Color.SteelBlue
        my_leaves.BackColor = Color.DodgerBlue
        approve_leave.BackColor = Color.SteelBlue
        apply_leave.BackColor = Color.SteelBlue
        switchPanel(MyLeaves)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles approve_leave.Click
        dashboard_but.BackColor = Color.SteelBlue
        my_leaves.BackColor = Color.SteelBlue
        approve_leave.BackColor = Color.DodgerBlue
        apply_leave.BackColor = Color.SteelBlue
        switchPanel(ApproveLeave)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles apply_leave.Click
        dashboard_but.BackColor = Color.SteelBlue
        my_leaves.BackColor = Color.SteelBlue
        approve_leave.BackColor = Color.SteelBlue
        apply_leave.BackColor = Color.DodgerBlue
        switchPanel(ApplyLeave)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dashboard_but.Click
        dashboard_but.BackColor = Color.DodgerBlue
        my_leaves.BackColor = Color.SteelBlue
        approve_leave.BackColor = Color.SteelBlue
        apply_leave.BackColor = Color.SteelBlue
        switchPanel(Dashboard_authority)
    End Sub

    Private Sub user_profile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles user_profile.Click
        dashboard_but.BackColor = Color.SteelBlue
        my_leaves.BackColor = Color.SteelBlue
        approve_leave.BackColor = Color.SteelBlue
        apply_leave.BackColor = Color.SteelBlue
        'Dim userProfile As New UserProfile()
        'userProfile.Show()
        switchPanel(UserProfile)
    End Sub

    Private Sub Dashboard_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles logut.Click
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