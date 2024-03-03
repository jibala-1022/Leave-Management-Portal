<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDosa = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDofa = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHodCse = New System.Windows.Forms.TextBox()
        Me.Change = New System.Windows.Forms.Button()
        Me.groupHOD = New System.Windows.Forms.GroupBox()
        Me.groupDean = New System.Windows.Forms.GroupBox()
        Me.groupDUPC = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.groupDPPC = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.groupDept = New System.Windows.Forms.GroupBox()
        Me.groupHOD.SuspendLayout()
        Me.groupDean.SuspendLayout()
        Me.groupDUPC.SuspendLayout()
        Me.groupDPPC.SuspendLayout()
        Me.groupDept.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "DOSA"
        '
        'txtDosa
        '
        Me.txtDosa.Location = New System.Drawing.Point(102, 18)
        Me.txtDosa.Name = "txtDosa"
        Me.txtDosa.Size = New System.Drawing.Size(184, 22)
        Me.txtDosa.TabIndex = 1
        Me.txtDosa.Tag = "DOSA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "DOFA"
        '
        'txtDofa
        '
        Me.txtDofa.Location = New System.Drawing.Point(102, 55)
        Me.txtDofa.Name = "txtDofa"
        Me.txtDofa.Size = New System.Drawing.Size(184, 22)
        Me.txtDofa.TabIndex = 1
        Me.txtDofa.Tag = "DOFA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "HOD"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(30, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "CSE"
        '
        'txtHodCse
        '
        Me.txtHodCse.Location = New System.Drawing.Point(118, 46)
        Me.txtHodCse.Name = "txtHodCse"
        Me.txtHodCse.Size = New System.Drawing.Size(184, 22)
        Me.txtHodCse.TabIndex = 1
        Me.txtHodCse.Tag = "CSE"
        '
        'Change
        '
        Me.Change.BackColor = System.Drawing.Color.LimeGreen
        Me.Change.FlatAppearance.BorderSize = 0
        Me.Change.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Change.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Change.ForeColor = System.Drawing.Color.White
        Me.Change.Location = New System.Drawing.Point(277, 476)
        Me.Change.Name = "Change"
        Me.Change.Size = New System.Drawing.Size(153, 37)
        Me.Change.TabIndex = 2
        Me.Change.Text = "UPDATE"
        Me.Change.UseVisualStyleBackColor = False
        '
        'groupHOD
        '
        Me.groupHOD.Controls.Add(Me.txtHodCse)
        Me.groupHOD.Controls.Add(Me.Label4)
        Me.groupHOD.Controls.Add(Me.Label3)
        Me.groupHOD.Location = New System.Drawing.Point(13, 8)
        Me.groupHOD.Name = "groupHOD"
        Me.groupHOD.Size = New System.Drawing.Size(520, 81)
        Me.groupHOD.TabIndex = 3
        Me.groupHOD.TabStop = False
        Me.groupHOD.Tag = "hod"
        '
        'groupDean
        '
        Me.groupDean.Controls.Add(Me.txtDofa)
        Me.groupDean.Controls.Add(Me.Label2)
        Me.groupDean.Controls.Add(Me.txtDosa)
        Me.groupDean.Controls.Add(Me.Label1)
        Me.groupDean.Location = New System.Drawing.Point(38, 12)
        Me.groupDean.Name = "groupDean"
        Me.groupDean.Size = New System.Drawing.Size(331, 94)
        Me.groupDean.TabIndex = 4
        Me.groupDean.TabStop = False
        '
        'groupDUPC
        '
        Me.groupDUPC.Controls.Add(Me.TextBox1)
        Me.groupDUPC.Controls.Add(Me.Label5)
        Me.groupDUPC.Controls.Add(Me.Label6)
        Me.groupDUPC.Location = New System.Drawing.Point(13, 109)
        Me.groupDUPC.Name = "groupDUPC"
        Me.groupDUPC.Size = New System.Drawing.Size(520, 81)
        Me.groupDUPC.TabIndex = 5
        Me.groupDUPC.TabStop = False
        Me.groupDUPC.Tag = "dupc"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(118, 46)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(184, 22)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Tag = "CSE"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(30, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "CSE"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "DUPC"
        '
        'groupDPPC
        '
        Me.groupDPPC.Controls.Add(Me.TextBox2)
        Me.groupDPPC.Controls.Add(Me.Label7)
        Me.groupDPPC.Controls.Add(Me.Label8)
        Me.groupDPPC.Location = New System.Drawing.Point(13, 218)
        Me.groupDPPC.Name = "groupDPPC"
        Me.groupDPPC.Size = New System.Drawing.Size(520, 81)
        Me.groupDPPC.TabIndex = 6
        Me.groupDPPC.TabStop = False
        Me.groupDPPC.Tag = "dppc"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(118, 46)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(184, 22)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Tag = "CSE"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(30, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "CSE"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 20)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "DPPC"
        '
        'groupDept
        '
        Me.groupDept.Controls.Add(Me.groupDPPC)
        Me.groupDept.Controls.Add(Me.groupDUPC)
        Me.groupDept.Controls.Add(Me.groupHOD)
        Me.groupDept.Location = New System.Drawing.Point(27, 122)
        Me.groupDept.Name = "groupDept"
        Me.groupDept.Size = New System.Drawing.Size(636, 320)
        Me.groupDept.TabIndex = 7
        Me.groupDept.TabStop = False
        '
        'Admin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 557)
        Me.Controls.Add(Me.groupDept)
        Me.Controls.Add(Me.groupDean)
        Me.Controls.Add(Me.Change)
        Me.Name = "Admin"
        Me.Text = "Admin"
        Me.groupHOD.ResumeLayout(False)
        Me.groupHOD.PerformLayout()
        Me.groupDean.ResumeLayout(False)
        Me.groupDean.PerformLayout()
        Me.groupDUPC.ResumeLayout(False)
        Me.groupDUPC.PerformLayout()
        Me.groupDPPC.ResumeLayout(False)
        Me.groupDPPC.PerformLayout()
        Me.groupDept.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDosa As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDofa As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHodCse As System.Windows.Forms.TextBox
    Friend WithEvents Change As System.Windows.Forms.Button
    Friend WithEvents groupHOD As System.Windows.Forms.GroupBox
    Friend WithEvents groupDean As System.Windows.Forms.GroupBox
    Friend WithEvents groupDUPC As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents groupDPPC As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents groupDept As System.Windows.Forms.GroupBox
End Class
