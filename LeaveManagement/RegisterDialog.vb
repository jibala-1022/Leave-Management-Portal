Imports System.Windows.Forms

Public Class RegisterDialog
    Public user_role As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        ' Check if exactly one radio button is checked
        If Not (RadioButton1.Checked Xor RadioButton2.Checked Xor RadioButton3.Checked) Then
            MessageBox.Show("Please choose one role to proceed!")
            Return
        End If

        ' Determine which radio button is checked and set the result accordingly
        If RadioButton1.Checked Then
            user_role = "Student"
            Me.DialogResult = DialogResult.OK
        ElseIf RadioButton2.Checked Then
            user_role = "Faculty"
            Me.DialogResult = DialogResult.OK
        ElseIf RadioButton3.Checked Then
            user_role = "Staff"
            Me.DialogResult = DialogResult.OK
        End If

        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub RegisterDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
