<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Director
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Director))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.my_leaves = New System.Windows.Forms.Button()
        Me.dashboard_but = New System.Windows.Forms.Button()
        Me.logut = New System.Windows.Forms.Button()
        Me.apply_leave = New System.Windows.Forms.Button()
        Me.approve_leave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.user_profile = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Location = New System.Drawing.Point(31, 15)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1056, 529)
        Me.Panel2.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(267, 92)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(767, 414)
        Me.Panel1.TabIndex = 32
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.my_leaves)
        Me.GroupBox2.Controls.Add(Me.dashboard_but)
        Me.GroupBox2.Controls.Add(Me.logut)
        Me.GroupBox2.Controls.Add(Me.apply_leave)
        Me.GroupBox2.Controls.Add(Me.approve_leave)
        Me.GroupBox2.Location = New System.Drawing.Point(25, 90)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(229, 416)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        '
        'my_leaves
        '
        Me.my_leaves.BackColor = System.Drawing.Color.SteelBlue
        Me.my_leaves.Cursor = System.Windows.Forms.Cursors.Hand
        Me.my_leaves.FlatAppearance.BorderSize = 0
        Me.my_leaves.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.my_leaves.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.my_leaves.ForeColor = System.Drawing.Color.White
        Me.my_leaves.Location = New System.Drawing.Point(5, 190)
        Me.my_leaves.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.my_leaves.Name = "my_leaves"
        Me.my_leaves.Size = New System.Drawing.Size(215, 36)
        Me.my_leaves.TabIndex = 15
        Me.my_leaves.Text = "My Leaves"
        Me.my_leaves.UseVisualStyleBackColor = False
        '
        'dashboard_but
        '
        Me.dashboard_but.BackColor = System.Drawing.Color.DodgerBlue
        Me.dashboard_but.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dashboard_but.FlatAppearance.BorderSize = 0
        Me.dashboard_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.dashboard_but.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dashboard_but.ForeColor = System.Drawing.Color.White
        Me.dashboard_but.Location = New System.Drawing.Point(5, 22)
        Me.dashboard_but.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dashboard_but.Name = "dashboard_but"
        Me.dashboard_but.Size = New System.Drawing.Size(215, 36)
        Me.dashboard_but.TabIndex = 14
        Me.dashboard_but.Text = "Dashboard"
        Me.dashboard_but.UseVisualStyleBackColor = False
        '
        'logut
        '
        Me.logut.BackColor = System.Drawing.Color.Crimson
        Me.logut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.logut.FlatAppearance.BorderSize = 0
        Me.logut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.logut.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logut.ForeColor = System.Drawing.Color.White
        Me.logut.Location = New System.Drawing.Point(5, 247)
        Me.logut.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.logut.Name = "logut"
        Me.logut.Size = New System.Drawing.Size(215, 36)
        Me.logut.TabIndex = 13
        Me.logut.Text = "Logout"
        Me.logut.UseVisualStyleBackColor = False
        '
        'apply_leave
        '
        Me.apply_leave.BackColor = System.Drawing.Color.SteelBlue
        Me.apply_leave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.apply_leave.FlatAppearance.BorderSize = 0
        Me.apply_leave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.apply_leave.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.apply_leave.ForeColor = System.Drawing.Color.White
        Me.apply_leave.Location = New System.Drawing.Point(5, 129)
        Me.apply_leave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.apply_leave.Name = "apply_leave"
        Me.apply_leave.Size = New System.Drawing.Size(215, 36)
        Me.apply_leave.TabIndex = 11
        Me.apply_leave.Text = "Apply Leave"
        Me.apply_leave.UseVisualStyleBackColor = False
        '
        'approve_leave
        '
        Me.approve_leave.BackColor = System.Drawing.Color.SteelBlue
        Me.approve_leave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.approve_leave.FlatAppearance.BorderSize = 0
        Me.approve_leave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.approve_leave.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.approve_leave.ForeColor = System.Drawing.Color.White
        Me.approve_leave.Location = New System.Drawing.Point(5, 73)
        Me.approve_leave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.approve_leave.Name = "approve_leave"
        Me.approve_leave.Size = New System.Drawing.Size(215, 36)
        Me.approve_leave.TabIndex = 12
        Me.approve_leave.Text = "Approve Leave"
        Me.approve_leave.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.user_profile)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 9)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1009, 75)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        '
        'user_profile
        '
        Me.user_profile.BackColor = System.Drawing.Color.Navy
        Me.user_profile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.user_profile.FlatAppearance.BorderSize = 0
        Me.user_profile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.user_profile.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.user_profile.ForeColor = System.Drawing.Color.White
        Me.user_profile.Location = New System.Drawing.Point(835, 17)
        Me.user_profile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.user_profile.Name = "user_profile"
        Me.user_profile.Size = New System.Drawing.Size(153, 36)
        Me.user_profile.TabIndex = 9
        Me.user_profile.Text = "Director"
        Me.user_profile.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label2.Location = New System.Drawing.Point(260, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(485, 40)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "LEAVE MANAGEMENT SYSTEM"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(5, 6)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(69, 64)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Director
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.LeaveManagement.My.Resources.Resources.iitg_jpeg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1144, 614)
        Me.Controls.Add(Me.Panel2)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Director"
        Me.Text = "Director"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents user_profile As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents my_leaves As System.Windows.Forms.Button
    Friend WithEvents dashboard_but As System.Windows.Forms.Button
    Friend WithEvents logut As System.Windows.Forms.Button
    Friend WithEvents apply_leave As System.Windows.Forms.Button
    Friend WithEvents approve_leave As System.Windows.Forms.Button
End Class
